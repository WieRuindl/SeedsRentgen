namespace SeedsRentgen
{
    partial class FMainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_whiteTreshold = new System.Windows.Forms.Label();
            this.button_CutImage = new System.Windows.Forms.Button();
            this.label_blackTreshold = new System.Windows.Forms.Label();
            this.hScrollBar_WhiteTreshold = new System.Windows.Forms.HScrollBar();
            this.textBox_BlackTreshold = new System.Windows.Forms.TextBox();
            this.hScrollBar_BlackTreshold = new System.Windows.Forms.HScrollBar();
            this.textBox_WhiteTreshold = new System.Windows.Forms.TextBox();
            this.button_OpenImage = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox_Brightness = new System.Windows.Forms.TextBox();
            this.label_brightness = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_ClearAll = new System.Windows.Forms.Button();
            this.button_Undo = new System.Windows.Forms.Button();
            this.hScrollBar_Brightness = new System.Windows.Forms.HScrollBar();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.связьСАвторомToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.button_OpenImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 72);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label_whiteTreshold);
            this.panel3.Controls.Add(this.button_CutImage);
            this.panel3.Controls.Add(this.label_blackTreshold);
            this.panel3.Controls.Add(this.hScrollBar_WhiteTreshold);
            this.panel3.Controls.Add(this.textBox_BlackTreshold);
            this.panel3.Controls.Add(this.hScrollBar_BlackTreshold);
            this.panel3.Controls.Add(this.textBox_WhiteTreshold);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(68, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(320, 72);
            this.panel3.TabIndex = 3;
            // 
            // label_whiteTreshold
            // 
            this.label_whiteTreshold.AutoSize = true;
            this.label_whiteTreshold.Location = new System.Drawing.Point(76, 43);
            this.label_whiteTreshold.Name = "label_whiteTreshold";
            this.label_whiteTreshold.Size = new System.Drawing.Size(72, 13);
            this.label_whiteTreshold.TabIndex = 11;
            this.label_whiteTreshold.Text = "Серый порог";
            // 
            // button_CutImage
            // 
            this.button_CutImage.Enabled = false;
            this.button_CutImage.Image = global::SeedsRentgen.Properties.Resources.icon_cut_scissors;
            this.button_CutImage.Location = new System.Drawing.Point(18, 12);
            this.button_CutImage.Name = "button_CutImage";
            this.button_CutImage.Size = new System.Drawing.Size(48, 48);
            this.button_CutImage.TabIndex = 2;
            this.button_CutImage.UseVisualStyleBackColor = true;
            this.button_CutImage.Click += new System.EventHandler(this.button_CutImage_Click);
            // 
            // label_blackTreshold
            // 
            this.label_blackTreshold.AutoSize = true;
            this.label_blackTreshold.Location = new System.Drawing.Point(76, 15);
            this.label_blackTreshold.Name = "label_blackTreshold";
            this.label_blackTreshold.Size = new System.Drawing.Size(72, 13);
            this.label_blackTreshold.TabIndex = 10;
            this.label_blackTreshold.Text = "Белый порог";
            // 
            // hScrollBar_WhiteTreshold
            // 
            this.hScrollBar_WhiteTreshold.LargeChange = 1;
            this.hScrollBar_WhiteTreshold.Location = new System.Drawing.Point(149, 12);
            this.hScrollBar_WhiteTreshold.Maximum = 256;
            this.hScrollBar_WhiteTreshold.Minimum = -1;
            this.hScrollBar_WhiteTreshold.Name = "hScrollBar_WhiteTreshold";
            this.hScrollBar_WhiteTreshold.Size = new System.Drawing.Size(120, 20);
            this.hScrollBar_WhiteTreshold.TabIndex = 3;
            this.hScrollBar_WhiteTreshold.Value = -1;
            this.hScrollBar_WhiteTreshold.ValueChanged += new System.EventHandler(this.hScrollBar_Tresholds_ValueChanged);
            // 
            // textBox_BlackTreshold
            // 
            this.textBox_BlackTreshold.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_BlackTreshold.Location = new System.Drawing.Point(280, 40);
            this.textBox_BlackTreshold.Name = "textBox_BlackTreshold";
            this.textBox_BlackTreshold.ReadOnly = true;
            this.textBox_BlackTreshold.Size = new System.Drawing.Size(30, 20);
            this.textBox_BlackTreshold.TabIndex = 6;
            this.textBox_BlackTreshold.Text = "-1";
            // 
            // hScrollBar_BlackTreshold
            // 
            this.hScrollBar_BlackTreshold.LargeChange = 1;
            this.hScrollBar_BlackTreshold.Location = new System.Drawing.Point(149, 40);
            this.hScrollBar_BlackTreshold.Maximum = 256;
            this.hScrollBar_BlackTreshold.Minimum = -1;
            this.hScrollBar_BlackTreshold.Name = "hScrollBar_BlackTreshold";
            this.hScrollBar_BlackTreshold.Size = new System.Drawing.Size(120, 20);
            this.hScrollBar_BlackTreshold.TabIndex = 4;
            this.hScrollBar_BlackTreshold.Value = -1;
            this.hScrollBar_BlackTreshold.ValueChanged += new System.EventHandler(this.hScrollBar_Tresholds_ValueChanged);
            // 
            // textBox_WhiteTreshold
            // 
            this.textBox_WhiteTreshold.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_WhiteTreshold.Location = new System.Drawing.Point(280, 12);
            this.textBox_WhiteTreshold.Name = "textBox_WhiteTreshold";
            this.textBox_WhiteTreshold.ReadOnly = true;
            this.textBox_WhiteTreshold.Size = new System.Drawing.Size(30, 20);
            this.textBox_WhiteTreshold.TabIndex = 5;
            this.textBox_WhiteTreshold.Text = "-1";
            // 
            // button_OpenImage
            // 
            this.button_OpenImage.Image = global::SeedsRentgen.Properties.Resources.icon_exportfile;
            this.button_OpenImage.Location = new System.Drawing.Point(12, 12);
            this.button_OpenImage.Name = "button_OpenImage";
            this.button_OpenImage.Size = new System.Drawing.Size(48, 48);
            this.button_OpenImage.TabIndex = 1;
            this.button_OpenImage.UseVisualStyleBackColor = true;
            this.button_OpenImage.Click += new System.EventHandler(this.button_OpenImage_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.textBox_Brightness);
            this.panel2.Controls.Add(this.label_brightness);
            this.panel2.Controls.Add(this.button_Save);
            this.panel2.Controls.Add(this.button_ClearAll);
            this.panel2.Controls.Add(this.button_Undo);
            this.panel2.Controls.Add(this.hScrollBar_Brightness);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Enabled = false;
            this.panel2.Location = new System.Drawing.Point(0, 553);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(388, 72);
            this.panel2.TabIndex = 1;
            // 
            // textBox_Brightness
            // 
            this.textBox_Brightness.BackColor = System.Drawing.SystemColors.Info;
            this.textBox_Brightness.Location = new System.Drawing.Point(187, 12);
            this.textBox_Brightness.Name = "textBox_Brightness";
            this.textBox_Brightness.ReadOnly = true;
            this.textBox_Brightness.Size = new System.Drawing.Size(30, 20);
            this.textBox_Brightness.TabIndex = 12;
            this.textBox_Brightness.Text = "0,40";
            // 
            // label_brightness
            // 
            this.label_brightness.AutoSize = true;
            this.label_brightness.Location = new System.Drawing.Point(133, 15);
            this.label_brightness.Name = "label_brightness";
            this.label_brightness.Size = new System.Drawing.Size(50, 13);
            this.label_brightness.TabIndex = 9;
            this.label_brightness.Text = "Яркость";
            // 
            // button_Save
            // 
            this.button_Save.Image = global::SeedsRentgen.Properties.Resources.icon_save_floppy;
            this.button_Save.Location = new System.Drawing.Point(330, 12);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(48, 48);
            this.button_Save.TabIndex = 8;
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_ClearAll
            // 
            this.button_ClearAll.Image = global::SeedsRentgen.Properties.Resources.icon_fastleft;
            this.button_ClearAll.Location = new System.Drawing.Point(68, 12);
            this.button_ClearAll.Name = "button_ClearAll";
            this.button_ClearAll.Size = new System.Drawing.Size(48, 48);
            this.button_ClearAll.TabIndex = 7;
            this.button_ClearAll.UseVisualStyleBackColor = true;
            this.button_ClearAll.Click += new System.EventHandler(this.button_ClearAll_Click);
            // 
            // button_Undo
            // 
            this.button_Undo.Image = global::SeedsRentgen.Properties.Resources.icon_chevron_left;
            this.button_Undo.Location = new System.Drawing.Point(12, 12);
            this.button_Undo.Name = "button_Undo";
            this.button_Undo.Size = new System.Drawing.Size(48, 48);
            this.button_Undo.TabIndex = 6;
            this.button_Undo.UseVisualStyleBackColor = true;
            this.button_Undo.Click += new System.EventHandler(this.button_Undo_Click);
            // 
            // hScrollBar_Brightness
            // 
            this.hScrollBar_Brightness.LargeChange = 1;
            this.hScrollBar_Brightness.Location = new System.Drawing.Point(136, 38);
            this.hScrollBar_Brightness.Maximum = 0;
            this.hScrollBar_Brightness.Minimum = -99;
            this.hScrollBar_Brightness.Name = "hScrollBar_Brightness";
            this.hScrollBar_Brightness.Size = new System.Drawing.Size(176, 20);
            this.hScrollBar_Brightness.TabIndex = 5;
            this.hScrollBar_Brightness.Value = -60;
            this.hScrollBar_Brightness.ValueChanged += new System.EventHandler(this.hScrollBar_Brightness_ValueChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Enabled = false;
            this.pictureBox.Location = new System.Drawing.Point(0, 96);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(388, 457);
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.связьСАвторомToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(388, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.файлToolStripMenuItem.Text = "Справка";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // связьСАвторомToolStripMenuItem
            // 
            this.связьСАвторомToolStripMenuItem.Name = "связьСАвторомToolStripMenuItem";
            this.связьСАвторомToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.связьСАвторомToolStripMenuItem.Text = "Связь с автором";
            this.связьСАвторомToolStripMenuItem.Click += new System.EventHandler(this.связьСАвторомToolStripMenuItem_Click);
            // 
            // FMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(388, 625);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(431, 664);
            this.MinimizeBox = false;
            this.Name = "FMainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.HScrollBar hScrollBar_BlackTreshold;
        private System.Windows.Forms.HScrollBar hScrollBar_WhiteTreshold;
        private System.Windows.Forms.Button button_CutImage;
        private System.Windows.Forms.Button button_OpenImage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_ClearAll;
        private System.Windows.Forms.Button button_Undo;
        private System.Windows.Forms.HScrollBar hScrollBar_Brightness;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label_whiteTreshold;
        private System.Windows.Forms.Label label_blackTreshold;
        private System.Windows.Forms.TextBox textBox_BlackTreshold;
        private System.Windows.Forms.TextBox textBox_WhiteTreshold;
        private System.Windows.Forms.TextBox textBox_Brightness;
        private System.Windows.Forms.Label label_brightness;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem связьСАвторомToolStripMenuItem;
    }
}

