using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraCharts.Native;
using System.Data.SqlClient;

namespace CinemaProject
{
    public partial class FastAccess: Form
    {
        public FastAccess()
        {
            InitializeComponent();
        }
        //we need an connection string to find the way of DB
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = CinemaProject; Integrated Security = True;");
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadTodaySessions();
            userName.Text = "Welcome "+LogIn.fullName+"!";
            UpdateStats();


            SetRoundedRegion(panelDirector, 15);
            SetRoundedRegion(panelActor, 15);
            SetRoundedRegion(panelMovies, 15);
            SetRoundedRegion(panelTicket, 15);
            SetRoundedRegion(panelMoney, 15);


            //date
            CultureInfo enUS = new CultureInfo("en-US");
            DashboardDate.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy", enUS);
            DashboardDate.ForeColor = ColorTranslator.FromHtml("#7F8C8D");



           

        }
        public void LoadTodaySessions()
        {
            flowLayoutPanelTodaySessions.Controls.Clear();

            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=CinemaProject; Integrated Security=True;"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
            SELECT s.ID, s.MovieName, s.HallName, s.SessionDate, s.SessionTime, m.PosterPath 
            FROM Sessions s
            JOIN Movies m ON s.MovieName = m.Name
            WHERE CAST(s.SessionDate AS DATE) = CAST(GETDATE() AS DATE)
            ORDER BY s.SessionTime", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.HasRows)
                {
                    Label emptyLabel = new Label();
                    emptyLabel.Text = "No sessions today.";
                    emptyLabel.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                    emptyLabel.ForeColor = Color.Gray;
                    emptyLabel.AutoSize = true;
                    flowLayoutPanelTodaySessions.Controls.Add(emptyLabel);
                    reader.Close();
                    return;
                }

                while (reader.Read())
                {
                    TimeSpan sessionTime = (TimeSpan)reader["SessionTime"];
                    DateTime sessionDate = Convert.ToDateTime(reader["SessionDate"]);
                    DateTime fullDateTime = sessionDate + sessionTime;

                    string posterPath = reader["PosterPath"]?.ToString();

                    // Her seans için yeni bir UserControl oluştur
                    SessionListUserControl session = new SessionListUserControl();
                    session.IsCompactView = true; // 👈 Küçük görünüm modu
                    session.SetSession(
                        Convert.ToInt32(reader["ID"]),
                        reader["MovieName"].ToString(),
                        reader["HallName"].ToString(),
                        sessionDate,
                        fullDateTime,
                        posterPath
                    );

                    flowLayoutPanelTodaySessions.Controls.Add(session);
                }

                reader.Close();
            }
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
        public void UpdateStats()
        {
            conn.Open();

            // Total Directors
            SqlCommand cmd1 = new SqlCommand("SELECT COUNT(*) FROM Directors", conn);
            int totalDirectors = (int)cmd1.ExecuteScalar();
            TotalDirector.Text = totalDirectors.ToString();

            // Total Actors
            SqlCommand cmd2 = new SqlCommand("SELECT COUNT(*) FROM Casts", conn);
            int totalActors = (int)cmd2.ExecuteScalar();
            TotalActor.Text = totalActors.ToString();

            // Total Movies
            SqlCommand cmd3 = new SqlCommand("SELECT COUNT(*) FROM Movies", conn);
            int totalMovies = (int)cmd3.ExecuteScalar();
            TotalMovie.Text = totalMovies.ToString();

            // Tickets sold today
            SqlCommand cmd4 = new SqlCommand(@"SELECT COUNT(*) FROM Ticket 
                                       WHERE CAST(ProcessTime AS DATE) = CAST(GETDATE() AS DATE)", conn);
            int ticketsToday = (int)cmd4.ExecuteScalar();
            todayTicket.Text = ticketsToday.ToString();

            // Today's revenue
            SqlCommand cmd5 = new SqlCommand(@"SELECT ISNULL(SUM(Price), 0) FROM Ticket 
                                       WHERE CAST(ProcessTime AS DATE) = CAST(GETDATE() AS DATE)", conn);
            decimal revenueToday = Convert.ToDecimal(cmd5.ExecuteScalar());
            todayIncome.Text = $"{revenueToday.ToString("C", CultureInfo.GetCultureInfo("en-US"))}";

            conn.Close();
        }

    }
}
