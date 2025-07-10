using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CinemaProject
{
    public partial class ticketUserControl: UserControl
    {
        public ticketUserControl()
        {
            InitializeComponent();
        }

        private void ticketUserControl_Load(object sender, EventArgs e)
        {

        }


        public void SetTicketData(string movieName, string ticketCode, string customerName, string phone, DateTime date, string hall, string ticketType, string seatNumbers)
        {
            movie.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            movie.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            movie.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            movie.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            movie.Text = movieName;
            ticketCode1.Text = ticketCode;
            ticketCode2.Text = ticketCode;
            ticketCode3.Text = ticketCode;
            ticketCode4.Text = ticketCode;
            name.Text = customerName;
            phoneNum.Text = phone;
            dateTime.Text = date.ToString("dd/MM/yyyy HH:mm");
            hallPlace.Text = hall;
            typeTicket.Text = ticketType;

            seatPanel.Controls.Clear();

            string[] seats = seatNumbers.Split(',');

            foreach (var seat in seats)
            {
                var seatButton = new System.Windows.Forms.Button();
                seatButton.Width = 64;
                seatButton.Height = 64;
                seatButton.Margin = new Padding(5);
                seatButton.Text = seat.Trim();
                seatButton.TextAlign = ContentAlignment.MiddleCenter;
                seatButton.Font = new Font("Arial", 12, FontStyle.Bold);
                seatButton.ForeColor = Color.White;
                seatButton.Image = Properties.Resources.cinema_chair_red;
                seatButton.ImageAlign = ContentAlignment.MiddleCenter;
                seatButton.TextImageRelation = TextImageRelation.Overlay;

                // Hover ve Click sırasında arka plan değişmesin
                seatButton.FlatStyle = FlatStyle.Flat;
                seatButton.FlatAppearance.BorderSize = 0;
                seatButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
                seatButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
                seatButton.BackColor = Color.Transparent;

                // Butonu panele ekle
                seatPanel.Controls.Add(seatButton);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
