using System;
using System.Windows.Forms;

namespace SeedsRentgen
{
    partial class FMainForm : Form
    {
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
    }
}
