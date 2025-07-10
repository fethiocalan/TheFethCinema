using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaProject
{
    public partial class CreateTicket: Form
    {
        public CreateTicket()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=CinemaProject; Integrated Security=True;");
        private void CreateTicket_Load(object sender, EventArgs e)
        {
            TicketMovie.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            TicketDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            TicketTime.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            TicketHall.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            ticketNo();
            bringMoviName();
        }

        void bringMoviName() {
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT DISTINCT MovieName, SessionDate, SessionTime FROM Sessions ORDER BY MovieName ASC", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                DateTime sessionDate = Convert.ToDateTime(reader["SessionDate"]);
                TimeSpan sessionTime = (TimeSpan)reader["SessionTime"];
                DateTime fullSessionTime = sessionDate + sessionTime;

                if (fullSessionTime > DateTime.Now)
                {
                    string movieName = reader["MovieName"].ToString();
                    if (!TicketMovie.Properties.Items.Contains(movieName)) // aynı film eklenmesin
                    {
                        TicketMovie.Properties.Items.Add(movieName);
                    }
                }
            }
            conn.Close(); // EKLENDİ
        }

        void ticketNo() { 
            Random rnd = new Random();
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghıjklmnoprqtuwxyz";
            string code = "";
            for (int i = 1; i <= 10; i++) { 
            
            code += characters[rnd.Next(characters.Length)];
            }
            TicketNumber.Text = code.ToString();

        }

        

        private void TicketMovie_SelectedIndexChanged(object sender, EventArgs e)
        {

            // SEÇİMLERİ TEMİZLE
            selectedSeats.Clear();
            TicketSeat.Text = "";
            ticketSeatPanel.Controls.Clear();

            TicketDate.Properties.Items.Clear();
            TicketDate.Text = "";
            TicketTime.Properties.Items.Clear();
            TicketTime.Text = "";
            TicketHall.Properties.Items.Clear();
            TicketHall.Text = "";

            if (string.IsNullOrWhiteSpace(TicketMovie.Text))
                return;

            using (SqlCommand cmd = new SqlCommand("SELECT SessionDate, SessionTime FROM Sessions WHERE MovieName = @movieName", conn))
            {
                cmd.Parameters.AddWithValue("@movieName", TicketMovie.Text);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DateTime sessionDate = Convert.ToDateTime(reader["SessionDate"]);
                    TimeSpan sessionTime = (TimeSpan)reader["SessionTime"];
                    DateTime fullSession = sessionDate + sessionTime;

                    if (fullSession > DateTime.Now)
                    {
                        string dateText = sessionDate.ToShortDateString();
                        if (!TicketDate.Properties.Items.Contains(dateText))
                            TicketDate.Properties.Items.Add(dateText);
                    }
                }
                conn.Close();
            }
        }

        private void TicketTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSeats.Clear();
            TicketSeat.Text = "";
            ticketSeatPanel.Controls.Clear();

            TicketHall.Properties.Items.Clear();
            TicketHall.Text = "";

            string selectedMovie = TicketMovie.Text;
            DateTime selectedDate;
            TimeSpan selectedTime;

            if (!DateTime.TryParse(TicketDate.Text, out selectedDate)) return;
            if (!TimeSpan.TryParse(TicketTime.Text, out selectedTime)) return;

            using (SqlCommand cmd = new SqlCommand(@"SELECT HallName 
                                              FROM Sessions 
                                              WHERE MovieName = @movie 
                                              AND CAST(SessionDate AS DATE) = @date 
                                              AND SessionTime = @time", conn))
            {
                cmd.Parameters.AddWithValue("@movie", selectedMovie);
                cmd.Parameters.AddWithValue("@date", selectedDate.Date);
                cmd.Parameters.AddWithValue("@time", selectedTime);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string hall = reader["HallName"].ToString();
                    if (!TicketHall.Properties.Items.Contains(hall))
                        TicketHall.Properties.Items.Add(hall);
                }
                conn.Close();
            }
        }

        private void TicketDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSeats.Clear();
            TicketSeat.Text = "";
            ticketSeatPanel.Controls.Clear();

            TicketTime.Properties.Items.Clear();
            TicketTime.Text = "";
            TicketHall.Properties.Items.Clear();
            TicketHall.Text = "";

            // Seçilen film ve tarih alınır
            string selectedMovie = TicketMovie.Text;
            if (string.IsNullOrWhiteSpace(selectedMovie)) return;

            DateTime selectedDate;
            if (!DateTime.TryParse(TicketDate.Text, out selectedDate)) return;

            using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT SessionTime FROM Sessions WHERE MovieName = @movieName AND SessionDate = @sessionDate", conn))
            {
                cmd.Parameters.AddWithValue("@movieName", selectedMovie);
                cmd.Parameters.AddWithValue("@sessionDate", selectedDate.Date);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TimeSpan sessionTime = (TimeSpan)reader["SessionTime"];
                    DateTime fullTime = selectedDate.Date + sessionTime;

                    if (fullTime > DateTime.Now) // Gelecekteyse sadece göster
                    {
                        string formattedTime = sessionTime.ToString(@"hh\:mm");
                        if (!TicketTime.Properties.Items.Contains(formattedTime))
                            TicketTime.Properties.Items.Add(formattedTime);
                    }
                }
                conn.Close();
            }
        }

        string HallCapacity = "";
        private void TicketHall_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Halls Where HallName = @hallName",conn);
            cmd.Parameters.AddWithValue("@hallName", TicketHall.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                HallCapacity = reader["Capacity"].ToString();
            }

            conn.Close();
        }
        string lastMovie = "", lastDate = "", lastTime = "", lastHall = "";
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string currentMovie = TicketMovie.Text;
            string currentDate = TicketDate.Text;
            string currentTime = TicketTime.Text;
            string currentHall = TicketHall.Text;

            // Eğer öncekiyle aynı seçim yapıldıysa yeniden çizme
            if (currentMovie == lastMovie &&
                currentDate == lastDate &&
                currentTime == lastTime &&
                currentHall == lastHall &&
                ticketSeatPanel.Controls.Count > 0)
            {
                return; // Hiçbir şey yapmadan çık
            }

            // 1) Formda seans bilgileri seçildi mi?
            if (string.IsNullOrWhiteSpace(currentMovie) ||
                string.IsNullOrWhiteSpace(currentDate) ||
                string.IsNullOrWhiteSpace(currentTime) ||
                string.IsNullOrWhiteSpace(currentHall))
            {
                MessageBox.Show("Please first select Movie, Date, Time and Hall!");
                return;
            }

            // 2) Paneli temizle
            ticketSeatPanel.Controls.Clear();

            // 3) Kapasiteye göre koltuk oluştur
            if (!int.TryParse(HallCapacity, out var cap) || cap == 0)
            {
                MessageBox.Show("Hall capacity hasn't been found!");
                return;
            }

            for (int i = 1; i <= cap; i++)
            {
                var seatCode = $"{RowLetter(i)}{ColumnNumber(i)}";

                // Varsayılan değerler: boş koltuk
                Image chairImage = Properties.Resources.cinema_chair_blue;
                Color foreColor = Color.LightGray;
                bool enabled = true;

                // Koltuk dolu mu kontrol et
                using (SqlCommand cmd = new SqlCommand(@"SELECT COUNT(*) FROM Ticket 
                   WHERE SeatNo = @seat 
                   AND Movie = @m 
                   AND [Date] = @d 
                   AND [Time] = @t 
                   AND Hall = @h", conn))
                {
                    cmd.Parameters.AddWithValue("@seat", seatCode);
                    cmd.Parameters.AddWithValue("@m", TicketMovie.Text.Trim());
                    cmd.Parameters.AddWithValue("@d", DateTime.Parse(TicketDate.Text).Date);
                    cmd.Parameters.AddWithValue("@t", DateTime.Parse(TicketTime.Text).TimeOfDay);
                    cmd.Parameters.AddWithValue("@h", TicketHall.Text.Trim());

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();

                    if (count > 0)
                    {
                        // if the seat is full
                        chairImage = (System.Drawing.Image)(Properties.Resources.cinema_chair_red);
                        foreColor = Color.White;
                        enabled = true;
                    }
                }

                var btn = new Button
                {
                    Name = $"seat{i}",
                    Text = seatCode,
                    Size = new Size(64, 64),
                    Font = new Font("Trebuchet MS", 12),
                    Image = chairImage,
                    Tag = seatCode,
                    ImageAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent,
                    ForeColor = foreColor,
                    Cursor = Cursors.Hand,
                    Enabled = enabled,
                    UseVisualStyleBackColor = false, // BUNU EKLE
                    FlatStyle = FlatStyle.Flat
                };

                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                btn.FlatAppearance.MouseDownBackColor = Color.Transparent;

                if (enabled)
                    btn.Click += Btn_Click;

                ticketSeatPanel.Controls.Add(btn);
            }

            // 4) Daha önce satılmış koltukları kırmızıya boya
            BringOccupiedSeats();

            // 5) Şu anki seçimleri kayıt et
            lastMovie = currentMovie;
            lastDate = currentDate;
            lastTime = currentTime;
            lastHall = currentHall;
        }
        /* Row ve Kolon hesaplaması (A1, A2, … G12) */
        private static string RowLetter(int i) => ((char)('A' + (i - 1) / 10)).ToString();
        private static int ColumnNumber(int i) => ((i - 1) % 10) + 1;
        List<string> selectedSeats = new List<string>();

        int TicketPrice = 0;
        private void Btn_Click(object sender, EventArgs e) {

            var btn = (Button)sender;
            if (btn.Tag == null) return;

            string seat = btn.Tag.ToString();

            if (btn.ForeColor == Color.White) // Zaten satılmış
            {
                MessageBox.Show("This seat has already been occupied!.");
            }
            else if (btn.ForeColor == Color.LightGray) // Boş → Seçiliyor
            {
                
                if (selectedSeats.Count >= 5)
                {
                    MessageBox.Show("at most you can choose 5 seats!.");
                    return;
                }

                btn.Image = Properties.Resources.cinema_chair_yellow;
                btn.ForeColor = Color.Red;
                selectedSeats.Add(seat);
            }
            else if (btn.ForeColor == Color.Red) // Seçilmiş → Geri bırakılıyor
            {
                btn.Image = Properties.Resources.cinema_chair_blue;
                btn.ForeColor = Color.LightGray;
                selectedSeats.Remove(seat);
            }

            TicketSeat.Text = string.Join(", ", selectedSeats);
        }

        void BringOccupiedSeats()
        {
            if (string.IsNullOrWhiteSpace(TicketMovie.Text) ||
                string.IsNullOrWhiteSpace(TicketDate.Text) ||
                string.IsNullOrWhiteSpace(TicketTime.Text) ||
                string.IsNullOrWhiteSpace(TicketHall.Text))
                return;

            List<string> occupied = new List<string>();
            using (SqlCommand cmd = new SqlCommand(
                @"SELECT SeatNo FROM Ticket
          WHERE Movie = @m AND CONVERT(date, [Date]) = @d AND [Time] = @t AND Hall = @h", conn))
            {
                cmd.Parameters.AddWithValue("@m", TicketMovie.Text.Trim());
                cmd.Parameters.AddWithValue("@d", DateTime.Parse(TicketDate.Text).Date);
                cmd.Parameters.AddWithValue("@t", TimeSpan.Parse(TicketTime.Text));
                cmd.Parameters.AddWithValue("@h", TicketHall.Text.Trim());

                conn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                    while (rd.Read())
                        occupied.Add(rd["SeatNo"].ToString());
                conn.Close();
            }

            foreach (Button btn in ticketSeatPanel.Controls.OfType<Button>())
            {
                string seatCode = btn.Tag?.ToString();
                if (seatCode != null && occupied.Contains(seatCode))
                {
                    btn.Image = Properties.Resources.cinema_chair_red_icon;
                    btn.ForeColor = Color.White;
                    btn.Enabled = false;
                }
            }
        }

        



        int GetTicketPrice(string ticketType)
        {
            switch (ticketType)
            {
                case "Adult (+35)":
                    return 50;
                case "Student (14 - 35)":
                    return 35;
                case "Child (7 - 13)":
                    return 20;
                case "Disabled":
                    return 15;
                default:
                    return 0; // Geçersizse
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            // 1) Zorunlu alanlar kontrolü
            if (string.IsNullOrWhiteSpace(TicketName.Text) ||
                string.IsNullOrWhiteSpace(TicketPhone.Text) ||
                string.IsNullOrWhiteSpace(TicketType.Text))
            {
                MessageBox.Show("Please enter Name-surname, Phone and Ticket type!.");
                return;
            }

            // 2) Seçili koltuk kontrolü
            if (ticketSeatPanel.Controls.OfType<Button>().All(b => b.ForeColor != Color.Red))
            {
                MessageBox.Show("Please at least choose one seat!");
                return;
            }

            // 3) DB'ye kaydet
            conn.Open();
            foreach (var btn in ticketSeatPanel.Controls.OfType<Button>()
                                .Where(b => b.ForeColor == Color.Red))
            {
                int price = GetTicketPrice(TicketType.Text); // Fiyatı al

                var cmd = new SqlCommand(
                    "INSERT INTO Ticket (BKod, NameSurname, Phone, SeatNo, Movie, Date, Time, Hall, Type, ProcessTime, Price) " +
                    "VALUES (@bk, @ns, @ph, @seat, @mv, @dt, @tm, @hl, @tp, @pt, @pr)", conn);

                cmd.Parameters.AddWithValue("@bk", TicketNumber.Text);
                cmd.Parameters.AddWithValue("@ns", TicketName.Text);
                cmd.Parameters.AddWithValue("@ph", TicketPhone.Text);
                cmd.Parameters.AddWithValue("@seat", btn.Tag.ToString());
                cmd.Parameters.AddWithValue("@mv", TicketMovie.Text);
                cmd.Parameters.AddWithValue("@dt", DateTime.Parse(TicketDate.Text));
                cmd.Parameters.AddWithValue("@tm", TimeSpan.Parse(TicketTime.Text));
                cmd.Parameters.AddWithValue("@hl", TicketHall.Text);
                cmd.Parameters.AddWithValue("@tp", TicketType.Text);
                cmd.Parameters.AddWithValue("@pt", DateTime.Now);
                cmd.Parameters.AddWithValue("@pr", price); // Fiyatı ekle

                cmd.ExecuteNonQuery();

                // UI'de koltuğu kırmızıya boya ve pasifleştir
                btn.Image = Properties.Resources.cinema_chair_red;
                btn.ForeColor = Color.White;
                btn.Enabled = false;
            }
            conn.Close();
            if (Application.OpenForms["FastAccess"] is FastAccess fastAccessForm)
            {
                fastAccessForm.UpdateStats();
            }
            if (Application.OpenForms["ProfitLoss"] is ProfitLoss profitLossForm)
            {
                profitLossForm.LoadMonths();
            }

            MessageBox.Show("Ticket(s) has been sold successfully!");

            // Yeni bilet numarası üret
            ResetForm();
        }

        private void ResetForm()
        {
            TicketName.Text = "";
            TicketPhone.Text = "";
            TicketType.Text = "";
            TicketMovie.Text = "";
            TicketDate.Text = "";
            TicketTime.Text = "";
            TicketHall.Text = "";
            TicketSeat.Text = "";

            TicketDate.Properties.Items.Clear();
            TicketTime.Properties.Items.Clear();
            TicketHall.Properties.Items.Clear();

            ticketSeatPanel.Controls.Clear();
            selectedSeats.Clear();

            ticketNo(); // Yeni bilet no üret
        }
    }
    }

