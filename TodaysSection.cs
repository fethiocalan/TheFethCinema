using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CinemaProject
{
    public partial class TodaysSection: UserControl
    {
        public TodaysSection()
        {
            InitializeComponent();
        }

       

        private void TodaySectionPanel_MouseLeave(object sender, EventArgs e)
        {
            TodaySectionPanel.BackColor = Color.LightGray;
        }

        private void TodaySectionPanel_MouseMove(object sender, MouseEventArgs e)
        {
            TodaySectionPanel.BackColor = Color.DarkGray;
        }


       
    }
}
