namespace CinemaProject
{
    partial class HallList
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
            this.hallFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // hallFlowPanel
            // 
            this.hallFlowPanel.AutoScroll = true;
            this.hallFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hallFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.hallFlowPanel.Name = "hallFlowPanel";
            this.hallFlowPanel.Size = new System.Drawing.Size(1171, 744);
            this.hallFlowPanel.TabIndex = 0;
            // 
            // HallList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1171, 744);
            this.Controls.Add(this.hallFlowPanel);
            this.Name = "HallList";
            this.Text = "HallList";
            this.Load += new System.EventHandler(this.HallList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel hallFlowPanel;
    }
}