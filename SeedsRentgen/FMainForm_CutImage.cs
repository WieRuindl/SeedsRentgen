using System;
using System.Drawing;
using System.Windows.Forms;

namespace SeedsRentgen
{
    partial class FMainForm : Form
    {
        Point _startPoint;
        Rectangle _areaToCut;

        private void StartCut(MouseEventArgs e)
        {
            if (e.X <= pictureBox.Image.Width && e.Y <= pictureBox.Image.Height)
            {
                _startPoint = new Point(e.X, e.Y);

                CreateRectangleAndUpdateMainForm(0, 0, 0, 0);
            }
        }

        private void CreateRectangleAndUpdateMainForm(int x, int y, int width, int height)
        {
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

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                int x = Math.Max(Math.Min(_startPoint.X, e.X), 0);
                int y = Math.Max(Math.Min(_startPoint.Y, e.Y), 0);
                int width = Math.Min(Math.Max(_startPoint.X, e.X), pictureBox.Image.Width - 1) - x;
                int height = Math.Min(Math.Max(_startPoint.Y, e.Y), pictureBox.Image.Height - 1) - y;

                CreateRectangleAndUpdateMainForm(x, y, width, height);
            }
        }

        private void button_CutImage_Click(object sender, EventArgs e)
        {
            //обрезание изображения
            _rentgenPhoto.CutImage(_areaToCut);

            _startPoint = new Point();
            _areaToCut = new Rectangle();
            button_CutImage.Enabled = false;
            hScrollBar_Brightness.Enabled = false;

            _areasStorage = new CAreasStorage();
            _areaFinder = new CAreaFinder(pictureBox.Image.Size);

            UpdateMainFormImage();
            UpdateHelpFormImage();
        }
    }
}
