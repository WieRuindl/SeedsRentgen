using SeedsRentgen.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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

            this.label_blackTreshold.Text = SeedsRentgen.Properties.Resources.labelBlackTreshold;
            this.label_whiteTreshold.Text = SeedsRentgen.Properties.Resources.labelWhiteTreshold;
            this.label_brightness.Text = SeedsRentgen.Properties.Resources.labelBrightness;
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

                if (null != _helpForm) _helpForm.Dispose();
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
            _rentgenPhoto.Refresh();
            _areaFinder = new CAreaFinder(pictureBox.Image.Size);
            if (!hScrollBar_Brightness.Enabled) hScrollBar_Brightness.Enabled = true;
            SetHScrollBarsInStartPosition();

            UpdateMainFormImage();
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
                   
                    if (Directory.Exists(directoryPath))
                    {
                        if (MessageBox.Show(SeedsRentgen.Properties.Resources.messageSaveWarningBody, 
                            SeedsRentgen.Properties.Resources.messageSaveWarningHeader, 
                            MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                            return;
                    }

                    Directory.CreateDirectory(directoryPath);

                    List<CSeed> seeds = SCSeedsLinker.GetSeeds(_areasStorage.GetAllAreas());

                    (new CSaverTxt(directoryPath, this.Text)).Save(seeds);
                    (new CSaverBmp(directoryPath, this.Text)).Save(SCImageProcessing.NumberizePhoto(_rentgenPhoto.PhotoBrightness, seeds));

                    MessageBox.Show(SeedsRentgen.Properties.Resources.messageSaveSuccess);

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
                        MessageBox.Show(Resources.messageClickError);
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
            _helpForm.Image = SCImageProcessing.ColorizePhoto(_rentgenPhoto.PhotoBrightness, _areasStorage.GetAllAreas());
        }

        private void CnagneEnable(bool state)
        {
            panel_Up.Enabled = state;
            panel_Down.Enabled = state;      
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

        private void MenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "helpfile.chm");
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new FProperties()).ShowDialog();
            if (pictureBox.Image != null) UpdateHelpFormImage();
        }
    }
}