namespace CinemaProject
{
    partial class SessionList
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
            this.sessionFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // sessionFlowPanel
            // 
            this.sessionFlowPanel.AutoScroll = true;
            this.sessionFlowPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.sessionFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sessionFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.sessionFlowPanel.Name = "sessionFlowPanel";
            this.sessionFlowPanel.Size = new System.Drawing.Size(1069, 727);
            this.sessionFlowPanel.TabIndex = 0;
            // 
            // SessionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 727);
            this.Controls.Add(this.sessionFlowPanel);
            this.Name = "SessionList";
            this.Text = "📋 Session List";
            this.Load += new System.EventHandler(this.SessionList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel sessionFlowPanel;
    }
}