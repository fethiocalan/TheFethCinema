using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaProject
{
    public partial class AddSession: Form
    {
        public AddSession()
        {
            InitializeComponent();
        }

        public void SetRoundedRegion(Control control, int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, control.Width, control.Height);
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90); // sol üst
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90); // sağ üst
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90); // sağ alt
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90); // sol alt
            path.CloseFigure();
            control.Region = new Region(path);
        }

        void ShowAlert(string message, Color bgColor)
        {
            AlertText.Text = message;
            PanelAlert.BackColor = bgColor;
            PanelAlert.Visible = true;
            PanelAlert.BringToFront();

            // İster zamanlayıcıyla otomatik kapansın:
            Timer timer = new Timer();
            timer.Interval = 3000; // 3 saniye sonra kaybolsun
            timer.Tick += (s, e) =>
            {
                PanelAlert.Visible = false;
                timer.Stop();
            };
            timer.Start();
        }
        private void AddSession_Load(object sender, EventArgs e)
        {
            
            SetRoundedRegion(PanelAlert, 25);
            LoadMovies();
            LoadHalls();

          
            // Start ve End time sınırları
            SessionDate.Properties.MinValue = DateTime.Today;
            SessionTime.Time = DateTime.Now.Date.AddHours(10);


            SessionMovie.Properties.DropDownRows = 10;
            SessionMovie.Properties.PopupFormWidth = 200;
            SessionMovie.Properties.Appearance.Font = new Font("Segoe UI", 22F);
            SessionMovie.Properties.Appearance.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            SessionMovie.Properties.AppearanceDropDown.Font = new Font("Segoe UI", 10F);



            SessionHall.Properties.DropDownRows = 10;
            SessionHall.Properties.PopupFormWidth = 200;
            SessionHall.Properties.Appearance.Font = new Font("Segoe UI", 22F);       
            SessionHall.Properties.Appearance.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            SessionHall.Properties.AppearanceDropDown.Font = new Font("Segoe UI", 10F);
        }

        private void LoadMovies()
        {
            SessionMovie.Properties.Items.Clear();
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=CinemaProject; Integrated Security=True;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Movies", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SessionMovie.Properties.Items.Add(reader["Name"].ToString());
                }
                conn.Close();
            }
        }

        private void LoadHalls()
        {
            SessionHall.Properties.Items.Clear();
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=CinemaProject; Integrated Security=True;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT HallName FROM Halls WHERE Status = 'Active'", conn);  // sadece aktif salonları al
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SessionHall.Properties.Items.Add(reader["HallName"].ToString());
                }
                conn.Close();
            }
        }
        private void ClearFields()
        {
            SessionMovie.SelectedIndex = -1;
            SessionHall.SelectedIndex = -1;
            SessionDate.EditValue = null;
            SessionTime.EditValue = null;
        }
        private void SessionStart_EditValueChanged(object sender, EventArgs e)
        {
          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SaveSession();
        }
        private void SaveSession()
        {

            // Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(SessionMovie.Text) ||
                string.IsNullOrWhiteSpace(SessionHall.Text) ||
                SessionDate.EditValue == null ||
                SessionTime.EditValue == null)
            {
                ShowAlert("⚠️ Please fill all fields!", Color.IndianRed);
                return;
            }

            DateTime selectedDate = SessionDate.DateTime.Date;
            TimeSpan selectedTime = SessionTime.Time.TimeOfDay;
            DateTime fullSessionTime = selectedDate + selectedTime;

            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=CinemaProject; Integrated Security=True;"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
            SELECT SessionDate, SessionTime 
            FROM Sessions 
            WHERE HallName = @hall AND SessionDate = @date", conn);

                cmd.Parameters.AddWithValue("@hall", SessionHall.Text);
                cmd.Parameters.AddWithValue("@date", selectedDate);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DateTime existingDate = Convert.ToDateTime(reader["SessionDate"]);
                    TimeSpan existingTime = (TimeSpan)reader["SessionTime"];
                    DateTime existingFullTime = existingDate + existingTime;

                    TimeSpan difference = fullSessionTime - existingFullTime;

                    if (Math.Abs(difference.TotalHours) < 4)
                    {
                        ShowAlert("⚠️ This hall at this time is not available!", Color.IndianRed);
                        return;
                    }
                }

                reader.Close();

                // Eklemeye uygunsa veritabanına ekle
                SqlCommand insert = new SqlCommand(@"
            INSERT INTO Sessions (MovieName, HallName, SessionDate, SessionTime)
            VALUES (@movie, @hall, @date, @time)", conn);

                insert.Parameters.AddWithValue("@movie", SessionMovie.Text);
                insert.Parameters.AddWithValue("@hall", SessionHall.Text);
                insert.Parameters.AddWithValue("@date", selectedDate);
                insert.Parameters.AddWithValue("@time", selectedTime);

                insert.ExecuteNonQuery();
                ClearFields();
                conn.Close();
                ((FastAccess)Application.OpenForms["FastAccess"]).UpdateStats();
                ShowAlert("✓ Session Added successfully!", Color.FromArgb(46, 204, 113));
                if (Application.OpenForms["SessionList"] is SessionList sessionListForm)
                {
                    sessionListForm.LoadSessions();
                }

            }
        }
    }
}
