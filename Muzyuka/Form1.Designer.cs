namespace Muzyuka
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.trackBarVolume = new System.Windows.Forms.TrackBar();
            this.labelVolume = new System.Windows.Forms.Label();
            this.timerRender = new System.Windows.Forms.Timer(this.components);
            this.visual = new System.Windows.Forms.PictureBox();
            this.trackBarRefreshRate = new System.Windows.Forms.TrackBar();
            this.labelRefreshRate = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.visual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRefreshRate)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Font = new System.Drawing.Font("Arial Black", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(376, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "Загрузить музяку";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Title = "Выберите басс";
            // 
            // trackBarVolume
            // 
            this.trackBarVolume.AutoSize = false;
            this.trackBarVolume.Location = new System.Drawing.Point(394, 31);
            this.trackBarVolume.Maximum = 100;
            this.trackBarVolume.Name = "trackBarVolume";
            this.trackBarVolume.Size = new System.Drawing.Size(154, 27);
            this.trackBarVolume.TabIndex = 2;
            this.trackBarVolume.Value = 50;
            this.trackBarVolume.Scroll += new System.EventHandler(this.trackBarVolume_Scroll);
            // 
            // labelVolume
            // 
            this.labelVolume.Location = new System.Drawing.Point(393, 12);
            this.labelVolume.Name = "labelVolume";
            this.labelVolume.Size = new System.Drawing.Size(155, 23);
            this.labelVolume.TabIndex = 3;
            this.labelVolume.Text = "Громкость";
            this.labelVolume.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerRender
            // 
            this.timerRender.Enabled = true;
            this.timerRender.Interval = 20;
            this.timerRender.Tick += new System.EventHandler(this.timerRender_Tick);
            // 
            // visual
            // 
            this.visual.BackColor = System.Drawing.Color.Black;
            this.visual.Location = new System.Drawing.Point(12, 64);
            this.visual.Name = "visual";
            this.visual.Size = new System.Drawing.Size(701, 347);
            this.visual.TabIndex = 4;
            this.visual.TabStop = false;
            this.visual.Paint += new System.Windows.Forms.PaintEventHandler(this.visual_Paint);
            // 
            // trackBarRefreshRate
            // 
            this.trackBarRefreshRate.AutoSize = false;
            this.trackBarRefreshRate.Location = new System.Drawing.Point(555, 31);
            this.trackBarRefreshRate.Maximum = 100;
            this.trackBarRefreshRate.Minimum = 1;
            this.trackBarRefreshRate.Name = "trackBarRefreshRate";
            this.trackBarRefreshRate.Size = new System.Drawing.Size(154, 27);
            this.trackBarRefreshRate.TabIndex = 2;
            this.trackBarRefreshRate.Value = 20;
            this.trackBarRefreshRate.Scroll += new System.EventHandler(this.trackBarRefreshRate_Scroll);
            // 
            // labelRefreshRate
            // 
            this.labelRefreshRate.Location = new System.Drawing.Point(554, 12);
            this.labelRefreshRate.Name = "labelRefreshRate";
            this.labelRefreshRate.Size = new System.Drawing.Size(155, 23);
            this.labelRefreshRate.TabIndex = 3;
            this.labelRefreshRate.Text = "Скорость";
            this.labelRefreshRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 423);
            this.Controls.Add(this.visual);
            this.Controls.Add(this.labelRefreshRate);
            this.Controls.Add(this.trackBarRefreshRate);
            this.Controls.Add(this.labelVolume);
            this.Controls.Add(this.trackBarVolume);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "MUZYAKA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.visual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRefreshRate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TrackBar trackBarVolume;
        private System.Windows.Forms.Label labelVolume;
        private System.Windows.Forms.Timer timerRender;
        private System.Windows.Forms.PictureBox visual;
        private System.Windows.Forms.TrackBar trackBarRefreshRate;
        private System.Windows.Forms.Label labelRefreshRate;
    }
}

