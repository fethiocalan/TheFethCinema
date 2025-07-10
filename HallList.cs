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
    public partial class HallList: Form
    {
        public HallList()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=CinemaProject; Integrated Security=True;");
        private void HallList_Load(object sender, EventArgs e)
        {
            LoadHalls();

        }
        public void ReloadData()
        {
            // Buraya Hall listesini yeniden dolduran kodu yazacaksın
            LoadHalls(); // örnek
        }
        public void LoadHalls()
        {
            hallFlowPanel.Controls.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Halls ORDER BY HallName ASC", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                HallListUserControl hall = new HallListUserControl();
                hall.SetHall(
                    Convert.ToInt32(reader["ID"]),
                    reader["HallName"].ToString(),
                    Convert.ToInt32(reader["Capacity"]),
                    reader["Status"].ToString(),
                    Convert.ToDateTime(reader["CreatedAt"]),
                    reader["ScreenType"].ToString(),
                    reader["AccessibilityOptions"].ToString(),
                    reader["Location"].ToString()
                );

                hallFlowPanel.Controls.Add(hall); // EKLENMESİ GEREKEN SATIR
            }

            conn.Close();
        }
        }


       
    }

