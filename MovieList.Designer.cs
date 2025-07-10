namespace CinemaProject
{
    partial class MovieList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.MovieListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.mSearch = new DevExpress.XtraEditors.TextEdit();
            this.focus2 = new DevExpress.XtraEditors.TextEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.focus2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.MovieListPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1924, 748);
            this.panel1.TabIndex = 9;
            // 
            // MovieListPanel
            // 
            this.MovieListPanel.AutoScroll = true;
            this.MovieListPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MovieListPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MovieListPanel.Location = new System.Drawing.Point(0, 80);
            this.MovieListPanel.Name = "MovieListPanel";
            this.MovieListPanel.Size = new System.Drawing.Size(1924, 668);
            this.MovieListPanel.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CinemaProject.Properties.Resources.zoomer2;
            this.pictureBox1.Location = new System.Drawing.Point(1356, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // mSearch
            // 
            this.mSearch.Location = new System.Drawing.Point(559, 18);
            this.mSearch.Name = "mSearch";
            this.mSearch.Properties.Appearance.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mSearch.Properties.Appearance.Options.UseFont = true;
            this.mSearch.Size = new System.Drawing.Size(791, 56);
            this.mSearch.TabIndex = 8;
            this.mSearch.EditValueChanged += new System.EventHandler(this.mSearch_EditValueChanged);
            // 
            // focus2
            // 
            this.focus2.Location = new System.Drawing.Point(83, 21);
            this.focus2.Name = "focus2";
            this.focus2.Size = new System.Drawing.Size(125, 34);
            this.focus2.TabIndex = 8;
            this.focus2.Visible = false;
            // 
            // MovieList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 748);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mSearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.focus2);
            this.Name = "MovieList";
            this.Text = "📽️ Movie List";
            this.Load += new System.EventHandler(this.MovieList_Load);
            this.Shown += new System.EventHandler(this.MovieList_Shown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.focus2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.TextEdit focus2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel MovieListPanel;
        private DevExpress.XtraEditors.TextEdit mSearch;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}