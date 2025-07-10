namespace CinemaProject
{
    partial class ActorList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActorList));
            this.AcListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.aSearch = new DevExpress.XtraEditors.TextEdit();
            this.focus2 = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focus2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // AcListPanel
            // 
            this.AcListPanel.AutoScroll = true;
            this.AcListPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AcListPanel.Location = new System.Drawing.Point(0, 80);
            this.AcListPanel.Name = "AcListPanel";
            this.AcListPanel.Padding = new System.Windows.Forms.Padding(10);
            this.AcListPanel.Size = new System.Drawing.Size(1924, 668);
            this.AcListPanel.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CinemaProject.Properties.Resources.zoomer2;
            this.pictureBox1.Location = new System.Drawing.Point(1355, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // aSearch
            // 
            this.aSearch.Location = new System.Drawing.Point(558, 18);
            this.aSearch.Name = "aSearch";
            this.aSearch.Properties.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aSearch.Properties.Appearance.Options.UseFont = true;
            this.aSearch.Size = new System.Drawing.Size(791, 56);
            this.aSearch.TabIndex = 4;
            this.aSearch.TextChanged += new System.EventHandler(this.dSearch_TextChanged);
            // 
            // focus2
            // 
            this.focus2.Location = new System.Drawing.Point(54, 14);
            this.focus2.Name = "focus2";
            this.focus2.Size = new System.Drawing.Size(125, 34);
            this.focus2.TabIndex = 7;
            this.focus2.Visible = false;
            // 
            // ActorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 748);
            this.Controls.Add(this.focus2);
            this.Controls.Add(this.AcListPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.aSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActorList";
            this.ShowIcon = false;
            this.Text = "🎭 Actor/Actress List";
            this.Load += new System.EventHandler(this.ActorList_Load);
            this.Shown += new System.EventHandler(this.ActorList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focus2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.FlowLayoutPanel AcListPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.TextEdit aSearch;
        private DevExpress.XtraEditors.TextEdit focus2;
    }
}