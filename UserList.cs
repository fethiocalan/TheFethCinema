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
    public partial class UserList: Form
    {
        public UserList()
        {
            InitializeComponent();
        }

        private void UserList_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=CinemaProject;Integrated Security=True");
        public  void LoadUsers()
        {
            userListPanel.Controls.Clear();

            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT id, name, surname, Age, salary, image FROM Users WHERE Type <> 'S'", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["id"]);
                string name = reader["name"].ToString();
                string surname = reader["surname"].ToString();
                int age = Convert.ToInt32(reader["Age"]);
                int salary = Convert.ToInt32(reader["salary"]);
                string imagePath = reader["image"].ToString();

                userListControl userControl = new userListControl();
                userControl.SetUser(id, name, surname, age, salary, imagePath);

                userListPanel.Controls.Add(userControl);
            }

            conn.Close();
        }

        private void userListPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
