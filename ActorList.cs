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
    public partial class ActorList: Form
    {
        public ActorList()
        {
            InitializeComponent();
            this.Shown += ActorList_Shown;
        }
        //we need an connection string to find the way of DB
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = CinemaProject; Integrated Security = True;");
        private void ActorList_Load(object sender, EventArgs e)
        {
            RefreshActorList();
            aSearch.Properties.NullText = "🔍 Search Actor/Actress name...";
          
        }
        public void RefreshActorList()
        {
            string sorgu = "select * from Casts ORDER BY AcName,AcSurname ASC";
            AcListPanel.Controls.Clear();
            conn.Open();

            SqlCommand komut = new SqlCommand(sorgu, conn);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ActorListUserControl acTool = new ActorListUserControl();
                acTool.SetActor(
                    Convert.ToInt32(oku["ID"]),
                    oku["AcName"].ToString(),
                    oku["AcSurname"].ToString(),
                    oku["AcImage"].ToString(),
                    oku["AcGender"].ToString(),
                    oku["AcNationality"].ToString(),
                    oku["AcBiography"].ToString(),
                    Convert.ToInt32(oku["AcDay"]),
                    Convert.ToInt32(oku["AcMonth"]),
                    Convert.ToInt32(oku["AcYear"])
                );
                AcListPanel.Controls.Add(acTool);
            }

            conn.Close();
        }

        private void dSearch_TextChanged(object sender, EventArgs e)
        {
            AcListPanel.Controls.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Casts WHERE AcName LIKE @search OR AcSurname LIKE @search ORDER BY AcName ASC", conn);
            cmd.Parameters.AddWithValue("@search", "%" + aSearch.Text.ToUpper() + "%");
            SqlDataReader oku = cmd.ExecuteReader();

            while (oku.Read())
            {
                ActorListUserControl acTool = new ActorListUserControl();
                acTool.SetActor(
                     Convert.ToInt32(oku["ID"]),
                     oku["AcName"].ToString(),
                    oku["AcSurname"].ToString(),
                    oku["AcImage"].ToString(),
                    oku["AcGender"].ToString(),
                    oku["AcNationality"].ToString(),
                    oku["AcBiography"].ToString(),
                    Convert.ToInt32(oku["AcDay"]),
                    Convert.ToInt32(oku["AcMonth"]),
                    Convert.ToInt32(oku["AcYear"])
                );
                AcListPanel.Controls.Add(acTool);
            }

            conn.Close();
        }

        private void ActorList_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = focus2;
        }
    }
}
