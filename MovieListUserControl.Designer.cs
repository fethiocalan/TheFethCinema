namespace CinemaProject
{
    partial class MovieListUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.DeleteBtn = new DevExpress.XtraEditors.SimpleButton();
            this.UpdateBtn = new DevExpress.XtraEditors.SimpleButton();
            this.DetailsBtn = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.MovieTitle = new DevExpress.XtraEditors.LabelControl();
            this.MovieDuration = new DevExpress.XtraEditors.LabelControl();
            this.MovieRelease = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MovieGenre = new DevExpress.XtraEditors.LabelControl();
            this.MovieImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MovieImage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(48, 304);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(60, 35);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Title";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(43, 380);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(109, 35);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Duration";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(48, 525);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(165, 35);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Release Date";
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.DeleteBtn.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.Appearance.Options.UseBackColor = true;
            this.DeleteBtn.Appearance.Options.UseFont = true;
            this.DeleteBtn.Location = new System.Drawing.Point(417, 605);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(79, 30);
            this.DeleteBtn.TabIndex = 14;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(169)))), ((int)(((byte)(244)))));
            this.UpdateBtn.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateBtn.Appearance.Options.UseBackColor = true;
            this.UpdateBtn.Appearance.Options.UseFont = true;
            this.UpdateBtn.Location = new System.Drawing.Point(331, 605);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(80, 30);
            this.UpdateBtn.TabIndex = 13;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // DetailsBtn
            // 
            this.DetailsBtn.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(195)))), ((int)(((byte)(74)))));
            this.DetailsBtn.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsBtn.Appearance.Options.UseBackColor = true;
            this.DetailsBtn.Appearance.Options.UseFont = true;
            this.DetailsBtn.Location = new System.Drawing.Point(245, 604);
            this.DetailsBtn.Name = "DetailsBtn";
            this.DetailsBtn.Size = new System.Drawing.Size(80, 30);
            this.DetailsBtn.TabIndex = 12;
            this.DetailsBtn.Text = "Details";
            this.DetailsBtn.Click += new System.EventHandler(this.DetailsBtn_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(48, 445);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(78, 35);
            this.labelControl4.TabIndex = 15;
            this.labelControl4.Text = "Genre";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(59, 345);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(6, 20);
            this.labelControl5.TabIndex = 16;
            this.labelControl5.Text = "-";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(54, 421);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(6, 20);
            this.labelControl6.TabIndex = 17;
            this.labelControl6.Text = "-";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl7.Appearance.Options.UseFont = true;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.Location = new System.Drawing.Point(59, 494);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(6, 20);
            this.labelControl7.TabIndex = 18;
            this.labelControl7.Text = "-";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.Location = new System.Drawing.Point(59, 566);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(6, 20);
            this.labelControl8.TabIndex = 19;
            this.labelControl8.Text = "-";
            // 
            // MovieTitle
            // 
            this.MovieTitle.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovieTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.MovieTitle.Appearance.Options.UseFont = true;
            this.MovieTitle.Appearance.Options.UseForeColor = true;
            this.MovieTitle.Location = new System.Drawing.Point(94, 339);
            this.MovieTitle.Name = "MovieTitle";
            this.MovieTitle.Size = new System.Drawing.Size(44, 26);
            this.MovieTitle.TabIndex = 20;
            this.MovieTitle.Text = "Title";
            // 
            // MovieDuration
            // 
            this.MovieDuration.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovieDuration.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.MovieDuration.Appearance.Options.UseFont = true;
            this.MovieDuration.Appearance.Options.UseForeColor = true;
            this.MovieDuration.Location = new System.Drawing.Point(89, 415);
            this.MovieDuration.Name = "MovieDuration";
            this.MovieDuration.Size = new System.Drawing.Size(82, 26);
            this.MovieDuration.TabIndex = 21;
            this.MovieDuration.Text = "Duration";
            // 
            // MovieRelease
            // 
            this.MovieRelease.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovieRelease.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.MovieRelease.Appearance.Options.UseFont = true;
            this.MovieRelease.Appearance.Options.UseForeColor = true;
            this.MovieRelease.Location = new System.Drawing.Point(94, 560);
            this.MovieRelease.Name = "MovieRelease";
            this.MovieRelease.Size = new System.Drawing.Size(123, 26);
            this.MovieRelease.TabIndex = 23;
            this.MovieRelease.Text = "Release date";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.MovieGenre);
            this.panel1.Location = new System.Drawing.Point(71, 483);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 46);
            this.panel1.TabIndex = 24;
            // 
            // MovieGenre
            // 
            this.MovieGenre.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MovieGenre.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(189)))));
            this.MovieGenre.Appearance.Options.UseFont = true;
            this.MovieGenre.Appearance.Options.UseForeColor = true;
            this.MovieGenre.Location = new System.Drawing.Point(3, 3);
            this.MovieGenre.Name = "MovieGenre";
            this.MovieGenre.Size = new System.Drawing.Size(58, 26);
            this.MovieGenre.TabIndex = 23;
            this.MovieGenre.Text = "Genre";
            // 
            // MovieImage
            // 
            this.MovieImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MovieImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.MovieImage.Image = global::CinemaProject.Properties.Resources.GOT;
            this.MovieImage.Location = new System.Drawing.Point(0, 0);
            this.MovieImage.Name = "MovieImage";
            this.MovieImage.Size = new System.Drawing.Size(499, 298);
            this.MovieImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MovieImage.TabIndex = 0;
            this.MovieImage.TabStop = false;
            // 
            // MovieListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MovieRelease);
            this.Controls.Add(this.MovieDuration);
            this.Controls.Add(this.MovieTitle);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.DeleteBtn);
            this.Controls.Add(this.UpdateBtn);
            this.Controls.Add(this.DetailsBtn);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.MovieImage);
            this.Name = "MovieListUserControl";
            this.Size = new System.Drawing.Size(499, 638);
            this.Load += new System.EventHandler(this.MovieListUserControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MovieImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox MovieImage;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton DeleteBtn;
        private DevExpress.XtraEditors.SimpleButton UpdateBtn;
        private DevExpress.XtraEditors.SimpleButton DetailsBtn;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl MovieTitle;
        private DevExpress.XtraEditors.LabelControl MovieDuration;
        private DevExpress.XtraEditors.LabelControl MovieRelease;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl MovieGenre;
    }
}
