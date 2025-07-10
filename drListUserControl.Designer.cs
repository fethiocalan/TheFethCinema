namespace CinemaProject
{
    partial class drListUserControl
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
            this.directorPanel = new System.Windows.Forms.Panel();
            this.labelDr_ = new DevExpress.XtraEditors.LabelControl();
            this.labelDr = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.directorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // directorPanel
            // 
            this.directorPanel.Controls.Add(this.labelDr_);
            this.directorPanel.Controls.Add(this.labelDr);
            this.directorPanel.Controls.Add(this.pictureBox1);
            this.directorPanel.Location = new System.Drawing.Point(0, 0);
            this.directorPanel.Name = "directorPanel";
            this.directorPanel.Size = new System.Drawing.Size(205, 51);
            this.directorPanel.TabIndex = 6;
            this.directorPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.directorPanel_Paint);
            this.directorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.directorPanel_MouseClick);
            // 
            // labelDr_
            // 
            this.labelDr_.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDr_.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelDr_.Appearance.Options.UseFont = true;
            this.labelDr_.Appearance.Options.UseForeColor = true;
            this.labelDr_.Location = new System.Drawing.Point(43, 20);
            this.labelDr_.Margin = new System.Windows.Forms.Padding(1);
            this.labelDr_.Name = "labelDr_";
            this.labelDr_.Size = new System.Drawing.Size(45, 23);
            this.labelDr_.TabIndex = 8;
            this.labelDr_.Text = "Label";
            this.labelDr_.MouseClick += new System.Windows.Forms.MouseEventHandler(this.directorPanel_MouseClick);
            // 
            // labelDr
            // 
            this.labelDr.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDr.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelDr.Appearance.Options.UseFont = true;
            this.labelDr.Appearance.Options.UseForeColor = true;
            this.labelDr.Location = new System.Drawing.Point(42, 3);
            this.labelDr.Margin = new System.Windows.Forms.Padding(1);
            this.labelDr.Name = "labelDr";
            this.labelDr.Size = new System.Drawing.Size(45, 23);
            this.labelDr.TabIndex = 7;
            this.labelDr.Text = "Label";
            this.labelDr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.directorPanel_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CinemaProject.Properties.Resources.add_icon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(1, 7);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 34);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.directorPanel_MouseClick);
            // 
            // drListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 9F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.directorPanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "drListUserControl";
            this.Size = new System.Drawing.Size(205, 51);
            this.Load += new System.EventHandler(this.drListUserControl_Load);
            this.directorPanel.ResumeLayout(false);
            this.directorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public DevExpress.XtraEditors.LabelControl labelDr_;
        public DevExpress.XtraEditors.LabelControl labelDr;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Panel directorPanel;
    }
}
