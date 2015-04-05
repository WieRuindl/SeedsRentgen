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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel_Up = new System.Windows.Forms.Panel();
            this.label_whiteTreshold = new System.Windows.Forms.Label();
            this.button_CutImage = new System.Windows.Forms.Button();
            this.label_blackTreshold = new System.Windows.Forms.Label();
            this.hScrollBar_WhiteTreshold = new System.Windows.Forms.HScrollBar();
            this.textBox_BlackTreshold = new System.Windows.Forms.TextBox();
            this.hScrollBar_BlackTreshold = new System.Windows.Forms.HScrollBar();
            this.textBox_WhiteTreshold = new System.Windows.Forms.TextBox();
            this.button_OpenImage = new System.Windows.Forms.Button();
            this.panel_Down = new System.Windows.Forms.Panel();
            this.textBox_Brightness = new System.Windows.Forms.TextBox();
            this.label_brightness = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_ClearAll = new System.Windows.Forms.Button();
            this.button_Undo = new System.Windows.Forms.Button();
            this.hScrollBar_Brightness = new System.Windows.Forms.HScrollBar();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel_Up.SuspendLayout();
            this.panel_Down.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.panel_Up);
            this.panel1.Controls.Add(this.button_OpenImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 72);
            this.panel1.TabIndex = 0;
            // 
            // panel_Up
            // 
            this.panel_Up.Controls.Add(this.label_whiteTreshold);
            this.panel_Up.Controls.Add(this.button_CutImage);
            this.panel_Up.Controls.Add(this.label_blackTreshold);
            this.panel_Up.Controls.Add(this.hScrollBar_WhiteTreshold);
            this.panel_Up.Controls.Add(this.textBox_BlackTreshold);
            this.panel_Up.Controls.Add(this.hScrollBar_BlackTreshold);
            this.panel_Up.Controls.Add(this.textBox_WhiteTreshold);
            this.panel_Up.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_Up.Enabled = false;
            this.panel_Up.Location = new System.Drawing.Point(68, 0);
            this.panel_Up.Name = "panel_Up";
            this.panel_Up.Size = new System.Drawing.Size(320, 72);
            this.panel_Up.TabIndex = 3;
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
            // panel_Down
            // 
            this.panel_Down.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_Down.Controls.Add(this.textBox_Brightness);
            this.panel_Down.Controls.Add(this.label_brightness);
            this.panel_Down.Controls.Add(this.button_Save);
            this.panel_Down.Controls.Add(this.button_ClearAll);
            this.panel_Down.Controls.Add(this.button_Undo);
            this.panel_Down.Controls.Add(this.hScrollBar_Brightness);
            this.panel_Down.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Down.Enabled = false;
            this.panel_Down.Location = new System.Drawing.Point(0, 553);
            this.panel_Down.Name = "panel_Down";
            this.panel_Down.Size = new System.Drawing.Size(388, 72);
            this.panel_Down.TabIndex = 1;
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
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(388, 24);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "menuStrip";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(148, 20);
            this.файлToolStripMenuItem.Text = "Справка по программе";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.MenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // FMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(388, 625);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panel_Down);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(431, 664);
            this.MinimizeBox = false;
            this.Name = "FMainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel_Up.ResumeLayout(false);
            this.panel_Up.PerformLayout();
            this.panel_Down.ResumeLayout(false);
            this.panel_Down.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.HScrollBar hScrollBar_BlackTreshold;
        private System.Windows.Forms.HScrollBar hScrollBar_WhiteTreshold;
        private System.Windows.Forms.Button button_CutImage;
        private System.Windows.Forms.Button button_OpenImage;
        private System.Windows.Forms.Panel panel_Down;
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
        private System.Windows.Forms.Panel panel_Up;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
    }
}

