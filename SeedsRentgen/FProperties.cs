using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeedsRentgen
{
    public partial class FProperties : Form
    {
        public FProperties()
        {
            InitializeComponent();

            numericUpDown_Scope.Value = SeedsRentgen.Properties.Settings.Default.scopeCoefficient;

            hScrollBar_HuskR.Value = SeedsRentgen.Properties.Settings.Default.colorHusk.R;
            textBox_HuskR.Text = SeedsRentgen.Properties.Settings.Default.colorHusk.R.ToString();
            hScrollBar_HuskG.Value = SeedsRentgen.Properties.Settings.Default.colorHusk.G;
            textBox_HuskG.Text = SeedsRentgen.Properties.Settings.Default.colorHusk.G.ToString();
            hScrollBar_HuskB.Value = SeedsRentgen.Properties.Settings.Default.colorHusk.B;
            textBox_HuskB.Text = SeedsRentgen.Properties.Settings.Default.colorHusk.B.ToString();

            hScrollBar_CoreR.Value = SeedsRentgen.Properties.Settings.Default.colorSeed.R;
            textBox_CoreR.Text = SeedsRentgen.Properties.Settings.Default.colorSeed.R.ToString();
            hScrollBar_CoreG.Value = SeedsRentgen.Properties.Settings.Default.colorSeed.G;
            textBox_CoreG.Text = SeedsRentgen.Properties.Settings.Default.colorSeed.G.ToString();
            hScrollBar_CoreB.Value = SeedsRentgen.Properties.Settings.Default.colorSeed.B;
            textBox_CoreB.Text = SeedsRentgen.Properties.Settings.Default.colorSeed.B.ToString();

            hScrollBar1.Minimum = 1;
            hScrollBar1.Maximum = (int)Math.Pow(255, 3);
            hScrollBar1.Value = 1;

            DrawImage();
        }

        private void SetTexts()
        {
            textBox_HuskR.Text = hScrollBar_HuskR.Value.ToString();
            textBox_HuskG.Text = hScrollBar_HuskG.Value.ToString();
            textBox_HuskB.Text = hScrollBar_HuskB.Value.ToString();
            textBox_CoreR.Text = hScrollBar_CoreR.Value.ToString();
            textBox_CoreG.Text = hScrollBar_CoreG.Value.ToString();
            textBox_CoreB.Text = hScrollBar_CoreB.Value.ToString();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            SeedsRentgen.Properties.Settings.Default.colorHusk = Color.FromArgb(hScrollBar_HuskR.Value, hScrollBar_HuskG.Value, hScrollBar_HuskB.Value);
            SeedsRentgen.Properties.Settings.Default.colorSeed = Color.FromArgb(hScrollBar_CoreR.Value, hScrollBar_CoreG.Value, hScrollBar_CoreB.Value);
            SeedsRentgen.Properties.Settings.Default.scopeCoefficient = (int)numericUpDown_Scope.Value;

            this.Close();
        }

        private void DrawImage()
        {
            Color huskColor = Color.FromArgb(200, hScrollBar_HuskR.Value, hScrollBar_HuskG.Value, hScrollBar_HuskB.Value);
            Color coreColor = Color.FromArgb(200, hScrollBar_CoreR.Value, hScrollBar_CoreG.Value, hScrollBar_CoreB.Value);
            
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics canvas = Graphics.FromImage(bmp);
            SolidBrush huskBrush = new SolidBrush(huskColor);
            SolidBrush coreBrush = new SolidBrush(coreColor);
            
            canvas.Clear(Color.Black);

            canvas.FillEllipse(huskBrush, 4, 4, bmp.Width - 8, bmp.Height - 8);
            canvas.FillEllipse(coreBrush, bmp.Width / 4, bmp.Height / 4, bmp.Width / 2, bmp.Height / 2);

            pictureBox.Image = bmp;
        }

        private void hScrollBars_ValueChanged(object sender, EventArgs e)
        {
            DrawImage();
            SetTexts();
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            Color huskColor = Color.FromArgb(200, hScrollBar_HuskR.Value, hScrollBar_HuskG.Value, hScrollBar_HuskB.Value);
            Color coreColor = Color.FromArgb(200, hScrollBar_CoreR.Value, hScrollBar_CoreG.Value, hScrollBar_CoreB.Value);

            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics canvas = Graphics.FromImage(bmp);
            SolidBrush huskBrush = new SolidBrush(huskColor);
            SolidBrush coreBrush = new SolidBrush(coreColor);

            int R = (int)((double)hScrollBar1.Value / Math.Pow(255,2));
            int G = (int)(((double)hScrollBar1.Value / 255) % 255);
            int B = (int)(((double)hScrollBar1.Value) % 255);
            canvas.Clear(Color.FromArgb(R, G, B));

            canvas.FillEllipse(huskBrush, 4, 4, bmp.Width - 8, bmp.Height - 8);
            canvas.FillEllipse(coreBrush, bmp.Width / 4, bmp.Height / 4, bmp.Width / 2, bmp.Height / 2);

            pictureBox.Image = bmp;
        }
    }
}
