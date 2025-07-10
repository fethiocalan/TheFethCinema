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
    public partial class DirectorList: Form
    {
        public DirectorList()
        {
            InitializeComponent();
            this.Shown += DirectorList_Shown;
        }
        //we need an connection string to find the way of DB
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = CinemaProject; Integrated Security = True;");
        private void DirectorListcs_Load(object sender, EventArgs e)
        {
            RefreshDirectorList();
            mSearch.Properties.NullText = "🔍 Search director name...";

        }

        public void RefreshDirectorList()
        {
            string sorgu = "select * from Directors ORDER BY drName,drSurname ASC";
            MovieListPanel.Controls.Clear();
            conn.Open();

            SqlCommand komut = new SqlCommand(sorgu, conn);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                DirectorListUserControl drTool = new DirectorListUserControl();
                drTool.SetDirector(
                    Convert.ToInt32(oku["ID"]),
                    oku["drName"].ToString(),
                    oku["drSurname"].ToString(),
                    oku["drImage"].ToString(),
                    oku["drGender"].ToString(),
                    oku["drNationality"].ToString(),
                    oku["drBio"].ToString(),
                    Convert.ToInt32(oku["drDay"]),
                    Convert.ToInt32(oku["drMonth"]),
                    Convert.ToInt32(oku["drYear"])
                );
                MovieListPanel.Controls.Add(drTool);
            }

            conn.Close();
        }
        private void textEdit1_TextChanged(object sender, EventArgs e)
        {
            MovieListPanel.Controls.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Directors WHERE drName LIKE @search OR drSurname LIKE @search ORDER BY drName ASC", conn);
            cmd.Parameters.AddWithValue("@search", "%" + mSearch.Text.ToUpper() + "%");
            SqlDataReader oku = cmd.ExecuteReader();

            while (oku.Read())
            {
                DirectorListUserControl drTool = new DirectorListUserControl();
                drTool.SetDirector(
                     Convert.ToInt32(oku["ID"]),
                     oku["drName"].ToString(),
                    oku["drSurname"].ToString(),
                    oku["drImage"].ToString(),
                    oku["drGender"].ToString(),
                    oku["drNationality"].ToString(),
                    oku["drBio"].ToString(),
                    Convert.ToInt32(oku["drDay"]),
                    Convert.ToInt32(oku["drMonth"]),
                    Convert.ToInt32(oku["drYear"])
                );
                MovieListPanel.Controls.Add(drTool);
            }

            conn.Close();
        }

        private void backstageViewControl1_Click(object sender, EventArgs e)
        {

        }

        private void DirectorList_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = focus;
        }
    }
}
