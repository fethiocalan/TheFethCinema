namespace CinemaProject
{
    partial class DirectorList
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
            this.MovieListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.focus = new DevExpress.XtraEditors.TextEdit();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mSearch = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.focus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSearch.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // MovieListPanel
            // 
            this.MovieListPanel.AutoScroll = true;
            this.MovieListPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MovieListPanel.Location = new System.Drawing.Point(0, 80);
            this.MovieListPanel.Name = "MovieListPanel";
            this.MovieListPanel.Padding = new System.Windows.Forms.Padding(10);
            this.MovieListPanel.Size = new System.Drawing.Size(1924, 668);
            this.MovieListPanel.TabIndex = 3;
            // 
            // focus
            // 
            this.focus.Location = new System.Drawing.Point(12, 18);
            this.focus.Name = "focus";
            this.focus.Size = new System.Drawing.Size(125, 22);
            this.focus.TabIndex = 4;
            this.focus.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CinemaProject.Properties.Resources.zoomer2;
            this.pictureBox1.Location = new System.Drawing.Point(1355, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // mSearch
            // 
            this.mSearch.Location = new System.Drawing.Point(558, 18);
            this.mSearch.Name = "mSearch";
            this.mSearch.Properties.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mSearch.Properties.Appearance.Options.UseFont = true;
            this.mSearch.Size = new System.Drawing.Size(791, 44);
            this.mSearch.TabIndex = 1;
            this.mSearch.TextChanged += new System.EventHandler(this.textEdit1_TextChanged);
            // 
            // DirectorList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 748);
            this.Controls.Add(this.focus);
            this.Controls.Add(this.MovieListPanel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mSearch);
            this.Name = "DirectorList";
            this.Text = "📋 Director List";
            this.Load += new System.EventHandler(this.DirectorListcs_Load);
            this.Shown += new System.EventHandler(this.DirectorList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.focus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSearch.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit mSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.FlowLayoutPanel MovieListPanel;
        private DevExpress.XtraEditors.TextEdit focus;
    }
}