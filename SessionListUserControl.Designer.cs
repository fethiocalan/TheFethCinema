namespace CinemaProject
{
    partial class SessionListUserControl
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
            this.sessionMovieName = new DevExpress.XtraEditors.LabelControl();
            this.sessionPic = new System.Windows.Forms.PictureBox();
            this.sessionHallName = new DevExpress.XtraEditors.LabelControl();
            this.sessionDate = new DevExpress.XtraEditors.LabelControl();
            this.sessionTime = new DevExpress.XtraEditors.LabelControl();
            this.deleteBtn = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.sessionPic)).BeginInit();
            this.SuspendLayout();
            // 
            // sessionMovieName
            // 
            this.sessionMovieName.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sessionMovieName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.sessionMovieName.Appearance.Options.UseFont = true;
            this.sessionMovieName.Appearance.Options.UseForeColor = true;
            this.sessionMovieName.Location = new System.Drawing.Point(340, 20);
            this.sessionMovieName.Name = "sessionMovieName";
            this.sessionMovieName.Size = new System.Drawing.Size(187, 42);
            this.sessionMovieName.TabIndex = 1;
            this.sessionMovieName.Text = "Movie Name";
            // 
            // sessionPic
            // 
            this.sessionPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.sessionPic.Dock = System.Windows.Forms.DockStyle.Left;
            this.sessionPic.Location = new System.Drawing.Point(0, 0);
            this.sessionPic.Name = "sessionPic";
            this.sessionPic.Size = new System.Drawing.Size(325, 314);
            this.sessionPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sessionPic.TabIndex = 0;
            this.sessionPic.TabStop = false;
            // 
            // sessionHallName
            // 
            this.sessionHallName.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sessionHallName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.sessionHallName.Appearance.Options.UseFont = true;
            this.sessionHallName.Appearance.Options.UseForeColor = true;
            this.sessionHallName.Location = new System.Drawing.Point(340, 89);
            this.sessionHallName.Name = "sessionHallName";
            this.sessionHallName.Size = new System.Drawing.Size(102, 42);
            this.sessionHallName.TabIndex = 2;
            this.sessionHallName.Text = "Saloon";
            // 
            // sessionDate
            // 
            this.sessionDate.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sessionDate.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.sessionDate.Appearance.Options.UseFont = true;
            this.sessionDate.Appearance.Options.UseForeColor = true;
            this.sessionDate.Location = new System.Drawing.Point(340, 158);
            this.sessionDate.Name = "sessionDate";
            this.sessionDate.Size = new System.Drawing.Size(71, 42);
            this.sessionDate.TabIndex = 3;
            this.sessionDate.Text = "Date";
            // 
            // sessionTime
            // 
            this.sessionTime.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sessionTime.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.sessionTime.Appearance.Options.UseFont = true;
            this.sessionTime.Appearance.Options.UseForeColor = true;
            this.sessionTime.Location = new System.Drawing.Point(340, 230);
            this.sessionTime.Name = "sessionTime";
            this.sessionTime.Size = new System.Drawing.Size(77, 42);
            this.sessionTime.TabIndex = 4;
            this.sessionTime.Text = "Time";
            // 
            // deleteBtn
            // 
            this.deleteBtn.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.deleteBtn.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.Appearance.Options.UseBackColor = true;
            this.deleteBtn.Appearance.Options.UseFont = true;
            this.deleteBtn.Location = new System.Drawing.Point(905, 282);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(94, 29);
            this.deleteBtn.TabIndex = 7;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // SessionListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.sessionTime);
            this.Controls.Add(this.sessionDate);
            this.Controls.Add(this.sessionHallName);
            this.Controls.Add(this.sessionMovieName);
            this.Controls.Add(this.sessionPic);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Name = "SessionListUserControl";
            this.Size = new System.Drawing.Size(1002, 314);
            this.Load += new System.EventHandler(this.SessionListUserControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sessionPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sessionPic;
        private DevExpress.XtraEditors.LabelControl sessionMovieName;
        private DevExpress.XtraEditors.LabelControl sessionHallName;
        private DevExpress.XtraEditors.LabelControl sessionDate;
        private DevExpress.XtraEditors.LabelControl sessionTime;
        private DevExpress.XtraEditors.SimpleButton deleteBtn;
    }
}
