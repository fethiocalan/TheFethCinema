using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaProject
{
    public partial class TicketCheck: Form
    {
        public TicketCheck()
        {
            InitializeComponent();
        }

        private void check_Click(object sender, EventArgs e)
        {

            string ticketCode = ticketNo.Text.Trim();

            if (string.IsNullOrEmpty(ticketCode))
            {
                MessageBox.Show("Please enter a ticket code.");
                return;
            }

            SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = CinemaProject; Integrated Security = True;");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Ticket WHERE BKod = @TicketCode", conn);
            cmd.Parameters.AddWithValue("@TicketCode", ticketCode);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            List<string> seatNumbers = new List<string>();
            string name = "", phone = "", hall = "", ticketType = "", movieName = "";
            DateTime date = DateTime.MinValue;

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    // Sadece ilk kayıttan bilgileri al
                    if (string.IsNullOrEmpty(name))
                    {
                        name = reader["NameSurname"].ToString();
                        phone = reader["Phone"].ToString();

                        DateTime ticketDate = Convert.ToDateTime(reader["Date"]);
                        TimeSpan ticketTime = TimeSpan.Parse(reader["Time"].ToString());
                        date = ticketDate.Add(ticketTime); // Tarih ve saati birleştir

                        hall = reader["Hall"].ToString();
                        ticketType = reader["Type"].ToString();
                        movieName = reader["Movie"].ToString();
                    }

                    // Tüm koltukları listeye ekle
                    seatNumbers.Add(reader["SeatNo"].ToString());
                }

                conn.Close();

                string combinedSeats = string.Join(",", seatNumbers);

                // Paneli temizle
                ticketPanel.Controls.Clear();

                // Bileti oluştur ve panele ekle
                ticketUserControl tcontrol = new ticketUserControl();
                tcontrol.SetTicketData(movieName, ticketCode, name, phone, date, hall, ticketType, combinedSeats);
                ticketPanel.Controls.Add(tcontrol);
            }
            else
            {
                conn.Close();
                MessageBox.Show("Ticket not found.");
            }

        }

        private void TicketCheck_Load(object sender, EventArgs e)
        {

        }
    }
}
