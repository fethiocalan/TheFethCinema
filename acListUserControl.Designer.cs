namespace CinemaProject
{
    partial class acListUserControl
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
            this.actorPanel = new System.Windows.Forms.Panel();
            this.labelAc_ = new DevExpress.XtraEditors.LabelControl();
            this.labelAc = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.actorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // actorPanel
            // 
            this.actorPanel.BackColor = System.Drawing.Color.Gray;
            this.actorPanel.Controls.Add(this.labelAc_);
            this.actorPanel.Controls.Add(this.labelAc);
            this.actorPanel.Controls.Add(this.pictureBox1);
            this.actorPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.actorPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.actorPanel.Location = new System.Drawing.Point(0, 0);
            this.actorPanel.Margin = new System.Windows.Forms.Padding(2);
            this.actorPanel.Name = "actorPanel";
            this.actorPanel.Size = new System.Drawing.Size(205, 51);
            this.actorPanel.TabIndex = 0;
            this.actorPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.actorPanel_Paint);
            this.actorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.actorPanel_MouseClick);
            // 
            // labelAc_
            // 
            this.labelAc_.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAc_.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelAc_.Appearance.Options.UseFont = true;
            this.labelAc_.Appearance.Options.UseForeColor = true;
            this.labelAc_.Location = new System.Drawing.Point(43, 20);
            this.labelAc_.Margin = new System.Windows.Forms.Padding(1);
            this.labelAc_.Name = "labelAc_";
            this.labelAc_.Size = new System.Drawing.Size(45, 23);
            this.labelAc_.TabIndex = 10;
            this.labelAc_.Text = "Label";
            this.labelAc_.MouseClick += new System.Windows.Forms.MouseEventHandler(this.actorPanel_MouseClick);
            // 
            // labelAc
            // 
            this.labelAc.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAc.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelAc.Appearance.Options.UseFont = true;
            this.labelAc.Appearance.Options.UseForeColor = true;
            this.labelAc.Location = new System.Drawing.Point(42, 3);
            this.labelAc.Margin = new System.Windows.Forms.Padding(1);
            this.labelAc.Name = "labelAc";
            this.labelAc.Size = new System.Drawing.Size(45, 23);
            this.labelAc.TabIndex = 9;
            this.labelAc.Text = "Label";
            this.labelAc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.actorPanel_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::CinemaProject.Properties.Resources.add_icon3;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(1, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 34);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.actorPanel_MouseClick);
            // 
            // acListUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(5F, 9F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.actorPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "acListUserControl";
            this.Size = new System.Drawing.Size(205, 51);
            this.Load += new System.EventHandler(this.acListUserControl_Load);
            this.actorPanel.ResumeLayout(false);
            this.actorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        public DevExpress.XtraEditors.LabelControl labelAc_;
        public DevExpress.XtraEditors.LabelControl labelAc;
        public System.Windows.Forms.Panel actorPanel;
    }
}
