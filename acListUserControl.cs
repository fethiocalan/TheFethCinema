using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts.Native;
using System.Data.SqlClient;
using System.Reflection.Emit;

namespace CinemaProject
{
    public partial class acListUserControl: UserControl
    {
        public acListUserControl()
        {
            InitializeComponent();
        }
        //we need an connection string to find the way of DB
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = CinemaProject; Integrated Security = True;");
       
        private void actorPanel_MouseClick(object sender, MouseEventArgs e)
        {




            string name = labelAc.Text.Trim() + " " + labelAc_.Text.Trim();
            if (actorPanel.BackColor == Color.Gray)
            {
                actorPanel.BackColor = Color.IndianRed;

                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Choosen (Name, Type) values (@person, @type) ", conn);
                cmd.Parameters.AddWithValue("@person", name);
                cmd.Parameters.AddWithValue("@type", "Actor");
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            else
            {
                actorPanel.BackColor = Color.Gray;
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from Choosen where Name = @person AND Type = @type", conn);
                cmd.Parameters.AddWithValue("@person", name);
                cmd.Parameters.AddWithValue("@type", "Actor");
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        private void actorPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void acListUserControl_Load(object sender, EventArgs e)
        {
            string name = labelAc.Text.Trim() + " " + labelAc_.Text.Trim();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Choosen where Name= @person AND Type = @type", conn);
            cmd.Parameters.AddWithValue("@person", name);
            cmd.Parameters.AddWithValue("@type", "Actor");
            SqlDataReader read = cmd.ExecuteReader();

            if (read.Read())
            {
                actorPanel.BackColor = Color.IndianRed;

            }
            else
            {

                actorPanel.BackColor = Color.Gray;
            }
            conn.Close();
        }
    }
}
