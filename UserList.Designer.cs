namespace CinemaProject
{
    partial class UserList
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
            this.userListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // userListPanel
            // 
            this.userListPanel.BackColor = System.Drawing.Color.White;
            this.userListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userListPanel.Location = new System.Drawing.Point(0, 0);
            this.userListPanel.Name = "userListPanel";
            this.userListPanel.Size = new System.Drawing.Size(1272, 811);
            this.userListPanel.TabIndex = 0;
            this.userListPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.userListPanel_Paint);
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1272, 811);
            this.Controls.Add(this.userListPanel);
            this.Name = "UserList";
            this.Text = "UserList";
            this.Load += new System.EventHandler(this.UserList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel userListPanel;
    }
}