using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace CinemaProject
{
    public partial class userListControl: UserControl
    {
        public userListControl()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=CinemaProject;Integrated Security=True");

        private int _id;
        private string _name;
        private string _surname;
        private int _age;
        private int _salary;
        private string _imagePath;
        private void userListControl_Load(object sender, EventArgs e)
        {
          
        }
        public void SetUser(int id, string name, string surname, int age, int salary, string imagePath)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _age = age;
            _salary = salary;
            _imagePath = imagePath;

            nameAdmin.Text = $"{name} {surname}";
            ageAdmin.Text = $"Age: {age}";
            salaryAdmin.Text = $"Salary: {salary} $";

            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                pictureAdmin.Image = Image.FromFile(imagePath);
            }
            else
            {
                pictureAdmin.Image = Properties.Resources.No_image; // Eğer yoksa bir varsayılan resim ekle
            }
        }

        private void fireBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to fire this admin?", "Confirm Firing", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", _id);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    // Kartı ekrandan sil
                    this.Parent.Controls.Remove(this);

                    MessageBox.Show("The admin has been successfully fired.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show("An error occurred while firing the admin: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
