namespace CinemaProject
{
    partial class DirectorListUserControl
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
            this.DrListSurname = new DevExpress.XtraEditors.LabelControl();
            this.DrListName = new DevExpress.XtraEditors.LabelControl();
            this.DrListImage = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrListImage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.DeleteBtn);
            this.panel1.Controls.Add(this.UpdateBtn);
            this.panel1.Controls.Add(this.DetailsBtn);
            this.panel1.Controls.Add(this.DrListSurname);
            this.panel1.Controls.Add(this.DrListName);
            this.panel1.Controls.Add(this.DrListImage);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(495, 178);
            this.panel1.TabIndex = 0;
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
            this.DetailsBtn.Location = new System.Drawing.Point(240, 144);
            this.DetailsBtn.Name = "DetailsBtn";
            this.DetailsBtn.Size = new System.Drawing.Size(80, 30);
            this.DetailsBtn.TabIndex = 9;
            this.DetailsBtn.Text = "Details";
            this.DetailsBtn.Click += new System.EventHandler(this.DetailsBtn_Click);
            // 
            // DrListSurname
            // 
            this.DrListSurname.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrListSurname.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.DrListSurname.Appearance.Options.UseFont = true;
            this.DrListSurname.Appearance.Options.UseForeColor = true;
            this.DrListSurname.Location = new System.Drawing.Point(215, 70);
            this.DrListSurname.Name = "DrListSurname";
            this.DrListSurname.Size = new System.Drawing.Size(121, 35);
            this.DrListSurname.TabIndex = 8;
            this.DrListSurname.Text = "-Surname";
            this.DrListSurname.Click += new System.EventHandler(this.DrListSurname_Click);
            // 
            // DrListName
            // 
            this.DrListName.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DrListName.Appearance.ForeColor = System.Drawing.Color.White;
            this.DrListName.Appearance.Options.UseFont = true;
            this.DrListName.Appearance.Options.UseForeColor = true;
            this.DrListName.Location = new System.Drawing.Point(197, 29);
            this.DrListName.Name = "DrListName";
            this.DrListName.Size = new System.Drawing.Size(81, 35);
            this.DrListName.TabIndex = 7;
            this.DrListName.Text = "-Name";
            this.DrListName.Click += new System.EventHandler(this.DrListName_Click);
            // 
            // DrListImage
            // 
            this.DrListImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DrListImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.DrListImage.Image = global::CinemaProject.Properties.Resources.No_image;
            this.DrListImage.Location = new System.Drawing.Point(0, 0);
            this.DrListImage.Name = "DrListImage";
            this.DrListImage.Size = new System.Drawing.Size(173, 178);
            this.DrListImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.DrListImage.TabIndex = 6;
            this.DrListImage.TabStop = false;
            this.DrListImage.Click += new System.EventHandler(this.DrListImage_Click);
            // 
            // DirectorListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "DirectorListUserControl";
            this.Size = new System.Drawing.Size(494, 178);
            this.Load += new System.EventHandler(this.DirectorListUserControl_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DrListImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton DeleteBtn;
        private DevExpress.XtraEditors.SimpleButton UpdateBtn;
        private DevExpress.XtraEditors.SimpleButton DetailsBtn;
        public DevExpress.XtraEditors.LabelControl DrListSurname;
        public DevExpress.XtraEditors.LabelControl DrListName;
        private System.Windows.Forms.PictureBox DrListImage;
    }
}
