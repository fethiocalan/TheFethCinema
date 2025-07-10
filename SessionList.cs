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
using DevExpress.XtraCharts.Native;

namespace CinemaProject
{
    public partial class SessionList: Form
    {
        public SessionList()
        {
            InitializeComponent();
        }

        private void SessionList_Load(object sender, EventArgs e)
        {
            LoadSessions();
        }
        //we need an connection string to find the way of DB
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = CinemaProject; Integrated Security = True;");
        public void LoadSessions()
        {
            sessionFlowPanel.Controls.Clear();

            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=CinemaProject; Integrated Security=True;"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
            SELECT s.ID, s.MovieName, s.HallName, s.SessionDate, s.SessionTime, m.PosterPath 
            FROM Sessions s
            JOIN Movies m ON s.MovieName = m.Name
            ORDER BY s.MovieName ASC", conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    TimeSpan sessionTime = (TimeSpan)reader["SessionTime"];
                    DateTime sessionDate = Convert.ToDateTime(reader["SessionDate"]);
                    DateTime fullDateTime = sessionDate + sessionTime;
                    string posterPath = reader["PosterPath"]?.ToString();

                    SessionListUserControl session = new SessionListUserControl();
                    session.SetSession(
                        Convert.ToInt32(reader["ID"]),
                        reader["MovieName"].ToString(),
                        reader["HallName"].ToString(),
                        sessionDate,
                        fullDateTime,
                        posterPath // yeni parametre
                    );

                    sessionFlowPanel.Controls.Add(session);
                }
            }
        
    }
    }
}
