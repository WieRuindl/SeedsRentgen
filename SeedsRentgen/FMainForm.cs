using SeedsRentgen.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SeedsRentgen
{
    public partial class FMainForm : Form
    {
        private CRentgenPhoto _rentgenPhoto;
        private CAreasStorage _areasStorage;
        private CAreaFinder _areaFinder;
        private FHelpForm _helpForm;


        public FMainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //16, 39 - границы окна
            int width = 404;// 
            int height = 668;// 

            this.MaximumSize = new Size(width, height);
            this.MinimumSize = new Size(width, height);
            this.Size = new Size(width, height);
        }

        private void button_OpenImage_Click(object sender, EventArgs e)
        {
            //открытие изображения
            using (OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = ".bmp изображения|*.bmp|.jpg изображения|*.jpg",
                Title = "Выберите изображение для обработки"
            })
            {
                if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                using (System.IO.FileStream fileStream = new System.IO.FileStream(dialog.FileName, System.IO.FileMode.Open))
                {
                    this.Text = System.IO.Path.GetFileNameWithoutExtension(dialog.FileName);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(fileStream);

                    _rentgenPhoto = new CRentgenPhoto((Bitmap)image, pictureBox.Size);
                }

                SetHScrollBarsInStartPosition();

                this.pictureBox.Image = _rentgenPhoto.PhotoBW;

                _areasStorage = new CAreasStorage();
                _areaFinder = new CAreaFinder(pictureBox.Image.Size);

                CnagneEnable(true);

                _helpForm = new FHelpForm(_rentgenPhoto.PhotoBrightness);
                _helpForm.Show();
            }
        }

        #region ИЗМЕНЕНИЕ ПОРОГОВ
        /// <summary>
        /// Метод вызывается при изменении значения ползунков-"порогов" и изменяет изображение в главной форме
        /// </summary>
        private void hScrollBar_Tresholds_ValueChanged(object sender, EventArgs e)
        {
            ChangeTresholds(hScrollBar_BlackTreshold.Value, hScrollBar_WhiteTreshold.Value);
            UpdateMainFormImage();
        }
        private void ChangeTresholds(int blackTreshold, int whiteTreshold)
        {
            if (hScrollBar_BlackTreshold.Value.ToString() == textBox_BlackTreshold.Text &&
                hScrollBar_WhiteTreshold.Value <= hScrollBar_BlackTreshold.Value)
            {
                hScrollBar_BlackTreshold.Value = hScrollBar_WhiteTreshold.Value;
            }

            if (hScrollBar_WhiteTreshold.Value.ToString() == textBox_WhiteTreshold.Text &&
                hScrollBar_BlackTreshold.Value >= hScrollBar_WhiteTreshold.Value)
            {
                hScrollBar_WhiteTreshold.Value = hScrollBar_BlackTreshold.Value;
            }

            _rentgenPhoto.ChangeTreshold(hScrollBar_BlackTreshold.Value, hScrollBar_WhiteTreshold.Value);

            textBox_WhiteTreshold.Text = hScrollBar_WhiteTreshold.Value.ToString();
            textBox_BlackTreshold.Text = hScrollBar_BlackTreshold.Value.ToString();
        }

        #endregion

        #region ИЗМЕНЕНИЕ ЯРКОСТИ
        /// <summary>
        /// Метод вызывается при изменении значения ползунка-"яркости" и изменяет изображения в обеих формах
        /// </summary>
        private void hScrollBar_Brightness_ValueChanged(object sender, EventArgs e)
        {
            ChangeBrightness();
            _rentgenPhoto.ChangeTreshold(hScrollBar_BlackTreshold.Value, hScrollBar_WhiteTreshold.Value); 

            UpdateHelpFormImage();
            UpdateMainFormImage();
        }
        private void ChangeBrightness()
        {
            textBox_Brightness.Text = String.Format("{0:0.00}", (1 + (double)hScrollBar_Brightness.Value / 100).ToString()); ;
            _rentgenPhoto.ChangeBrightness(hScrollBar_Brightness.Value);
        }
        #endregion



        private void button_Undo_Click(object sender, EventArgs e)
        {
            //отмена последнего действия
            CArea area = _areasStorage.RemoveLastArea();
            if (area != null) _areaFinder.RestoreControlMatrix(area);

            UpdateHelpFormImage();
        }

        /// <summary>
        /// отменяет все выбранные области
        /// очищается хранилище областей _areasStorage и 
        /// </summary>
        private void button_ClearAll_Click(object sender, EventArgs e)
        {
            _areasStorage = new CAreasStorage();
            _areaFinder = new CAreaFinder(pictureBox.Image.Size);

            UpdateHelpFormImage();
        }


        private void button_Save_Click(object sender, EventArgs e)
        {
            //сохранение в отчет
            if (_areasStorage.IsReadyForSave())
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                        return;

                    String directoryPath = dialog.SelectedPath + "\\" + this.Text;
                    Directory.CreateDirectory(directoryPath);

                    if (Directory.Exists(directoryPath))
                    {
                        if (MessageBox.Show("Подпапка с таким названием уже существует. Продолжать работу?", "", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                            return;
                    }
                    
                    List<CSeed> seeds = CSeedsLinker.GetSeeds(_areasStorage.GetAllAreas());

                    (new CSaverTxt(directoryPath, this.Text)).Save(seeds);
                    (new CSaverBmp(directoryPath, this.Text)).Save(SCImageProcessing.NumberizePhoto(_rentgenPhoto.PhotoBrightness, seeds));

                    MessageBox.Show("Сохранение успешно!");

                    CompleteWork();
                }
            }
            else
            {
                MessageBox.Show(Resources.messageSaveError);
            }
        }



        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (System.Windows.Forms.MouseButtons.Left == e.Button)
            {
                StartFindArea(e);
            }
            if (System.Windows.Forms.MouseButtons.Right == e.Button)
            {
                StartCut(e);
            }
        }

        private void StartFindArea(MouseEventArgs e)
        {
            if (e.X < pictureBox.Image.Width && e.Y < pictureBox.Image.Height)
            {
                using (Bitmap bitmap = new Bitmap(pictureBox.Image))
                {
                    byte color = bitmap.GetPixel(e.X, e.Y).R;

                    if (Color.Black.R != color && Color.Gray.R != color && Color.White.R != color)
                    {
                        //MessageBox.Show(Resources.messageClickError);
                        return;
                    }

                    if (Color.Black.R == color)
                    {
                        return;
                    }

                    CArea area = _areaFinder.GetArea(bitmap, e.X, e.Y);
                    if (null != area) _areasStorage.AddArea(area);

                    UpdateHelpFormImage();
                }
            }
        }

        #region ОБРЕЗАНИЕ ИЗОБРАЖЕНИЯ
        Point _startPoint;
        Rectangle _areaToCut;

        private void StartCut(MouseEventArgs e)
        {
            if (e.X <= pictureBox.Image.Width && e.Y <= pictureBox.Image.Height)
            {
                _startPoint = new Point(e.X, e.Y);
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int x = Math.Max(Math.Min(_startPoint.X, e.X), 0);
                int y = Math.Max(Math.Min(_startPoint.Y, e.Y), 0);
                int width = Math.Min(Math.Max(_startPoint.X, e.X), pictureBox.Image.Width - 1) - x;
                int height = Math.Min(Math.Max(_startPoint.Y, e.Y), pictureBox.Image.Height - 1) - y;
                _areaToCut = new Rectangle(x, y, width, height);

                if (_areaToCut.Width > SeedsRentgen.Properties.Settings.Default.frameSensitivity &&
                    _areaToCut.Height > SeedsRentgen.Properties.Settings.Default.frameSensitivity)
                {
                    button_CutImage.Enabled = true;
                }
                else
                {
                    button_CutImage.Enabled = false;
                }

                UpdateMainFormImage();
            }
        }

        private void button_CutImage_Click(object sender, EventArgs e)
        {
            //обрезание изображения
            _rentgenPhoto.CutImage(_areaToCut);

            _startPoint = new Point();
            _areaToCut = new Rectangle();
            button_CutImage.Enabled = false;

            _areasStorage = new CAreasStorage();
            _areaFinder = new CAreaFinder(pictureBox.Image.Size);

            UpdateMainFormImage();
            UpdateHelpFormImage();
        }
        #endregion

        //выводит в pictureBox _rentgen.PhotoBW и рисует рамку
        private void UpdateMainFormImage()
        {
            if (pictureBox.Image != null) pictureBox.Image.Dispose();
            Bitmap image = new Bitmap(_rentgenPhoto.PhotoBW);

            if (_areaToCut.Width > 0 && _areaToCut.Height > 0)
            {
                Graphics canvas = Graphics.FromImage(image);
                canvas.DrawRectangle(new Pen(Color.Red), _areaToCut);
            }

            pictureBox.Image = image;
        }

        private void UpdateHelpFormImage()
        {
            Bitmap image = SCImageProcessing.ColorizePhoto(_rentgenPhoto.PhotoBrightness, _areasStorage.GetAllAreas());
            _helpForm.Image = image;
        }

        private void CnagneEnable(bool state)
        {
            panel2.Enabled = state;
            panel3.Enabled = state;
            pictureBox.Enabled = state;
        }

        private void CompleteWork()
        {
            CnagneEnable(false);
            SetHScrollBarsInStartPosition();
            _helpForm.Dispose();

            this.pictureBox.Image.Dispose();
            this.pictureBox.Image = new Bitmap(1, 1);
            this.Text = "";
        }

        private void SetHScrollBarsInStartPosition()
        {
            hScrollBar_Brightness.Value = SeedsRentgen.Properties.Settings.Default.brightness;

            hScrollBar_BlackTreshold.Value = SeedsRentgen.Properties.Settings.Default.blackTreshold;
            hScrollBar_WhiteTreshold.Value = SeedsRentgen.Properties.Settings.Default.whiteTreshold;
        }
    }
}
