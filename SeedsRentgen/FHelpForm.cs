using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SeedsRentgen.Properties;

namespace SeedsRentgen
{
    public partial class FHelpForm : Form
    {
        public Bitmap Image
        {
            get
            {
                return (Bitmap)pictureBox.Image;
            }
            set
            {
                if (null != pictureBox.Image) pictureBox.Image.Dispose();
                pictureBox.Image = value;
                Text = "Масштаб = " + SeedsRentgen.Properties.Settings.Default.scopeCoefficient.ToString();
            }
        }

        public FHelpForm(Bitmap image)
        {
            InitializeComponent();

            Image = image;
            Text = "Масштаб = " + SeedsRentgen.Properties.Settings.Default.scopeCoefficient.ToString();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            MessageBox.Show(Resources.messageOnClosing);
        }
    }
}
