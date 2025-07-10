namespace CinemaProject
{
    partial class ActorListUserControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.DeleteBtn = new DevExpress.XtraEditors.SimpleButton();
            this.UpdateBtn = new DevExpress.XtraEditors.SimpleButton();
            this.DetailsBtn = new DevExpress.XtraEditors.SimpleButton();
            this.AcListSurname = new DevExpress.XtraEditors.LabelControl();
            this.AcListName = new DevExpress.XtraEditors.LabelControl();
            this.AcListImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AcListImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.DeleteBtn);
            this.panel1.Controls.Add(this.UpdateBtn);
            this.panel1.Controls.Add(this.DetailsBtn);
            this.panel1.Controls.Add(this.AcListSurname);
            this.panel1.Controls.Add(this.AcListName);
            this.panel1.Controls.Add(this.AcListImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 178);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.DeleteBtn.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteBtn.Appearance.Options.UseBackColor = true;
            this.DeleteBtn.Appearance.Options.UseFont = true;
            this.DeleteBtn.Location = new System.Drawing.Point(412, 145);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(79, 30);
            this.DeleteBtn.TabIndex = 11;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // UpdateBtn
            // 
            this.UpdateBtn.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.UpdateBtn.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateBtn.Appearance.Options.UseBackColor = true;
            this.UpdateBtn.Appearance.Options.UseFont = true;
            this.UpdateBtn.Location = new System.Drawing.Point(326, 145);
            this.UpdateBtn.Name = "UpdateBtn";
            this.UpdateBtn.Size = new System.Drawing.Size(80, 30);
            this.UpdateBtn.TabIndex = 10;
            this.UpdateBtn.Text = "Update";
            this.UpdateBtn.Click += new System.EventHandler(this.UpdateBtn_Click);
            // 
            // DetailsBtn
            // 
            this.DetailsBtn.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Success;
            this.DetailsBtn.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DetailsBtn.Appearance.Options.UseBackColor = true;
            this.DetailsBtn.Appearance.Options.UseFont = true;
            this.DetailsBtn.Location = new System.Drawing.Point(240, 145);
            this.DetailsBtn.Name = "DetailsBtn";
            this.DetailsBtn.Size = new System.Drawing.Size(80, 30);
            this.DetailsBtn.TabIndex = 9;
            this.DetailsBtn.Text = "Details";
            this.DetailsBtn.Click += new System.EventHandler(this.DetailsBtn_Click);
            // 
            // AcListSurname
            // 
            this.AcListSurname.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcListSurname.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.AcListSurname.Appearance.Options.UseFont = true;
            this.AcListSurname.Appearance.Options.UseForeColor = true;
            this.AcListSurname.Location = new System.Drawing.Point(215, 70);
            this.AcListSurname.Name = "AcListSurname";
            this.AcListSurname.Size = new System.Drawing.Size(121, 35);
            this.AcListSurname.TabIndex = 8;
            this.AcListSurname.Text = "-Surname";
            // 
            // AcListName
            // 
            this.AcListName.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AcListName.Appearance.ForeColor = System.Drawing.Color.White;
            this.AcListName.Appearance.Options.UseFont = true;
            this.AcListName.Appearance.Options.UseForeColor = true;
            this.AcListName.Location = new System.Drawing.Point(197, 29);
            this.AcListName.Name = "AcListName";
            this.AcListName.Size = new System.Drawing.Size(81, 35);
            this.AcListName.TabIndex = 7;
            this.AcListName.Text = "-Name";
            // 
            // AcListImage
            // 
            this.AcListImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.AcListImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.AcListImage.Image = global::CinemaProject.Properties.Resources.No_image;
            this.AcListImage.Location = new System.Drawing.Point(0, 0);
            this.AcListImage.Name = "AcListImage";
            this.AcListImage.Size = new System.Drawing.Size(173, 178);
            this.AcListImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AcListImage.TabIndex = 6;
            this.AcListImage.TabStop = false;
            // 
            // ActorListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "ActorListUserControl";
            this.Size = new System.Drawing.Size(494, 178);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AcListImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton DeleteBtn;
        private DevExpress.XtraEditors.SimpleButton UpdateBtn;
        private DevExpress.XtraEditors.SimpleButton DetailsBtn;
        public DevExpress.XtraEditors.LabelControl AcListSurname;
        public DevExpress.XtraEditors.LabelControl AcListName;
        private System.Windows.Forms.PictureBox AcListImage;
    }
}
