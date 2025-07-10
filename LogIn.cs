using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaProject
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        // ESKİ SQL SERVER BAĞLANTISI 👇
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=CinemaProject; Integrated Security=True;");

        public static string userType = "";   // Kullanıcı tipi (S veya A)
        public static string loggedUser = ""; // Giriş yapan kullanıcı adı
        public static string fullName = "";   // Kullanıcı tam adı

        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            checkBox1.Text = checkBox1.Checked ? "Hide Password" : "Show Password";
        }

        private void enter_Click(object sender, EventArgs e)
        {
            string username = UserName.Text.Trim();
            string password = Password.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT Type, name, surname FROM Users WHERE userName = @username AND passWord = @password", conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    userType = reader["Type"].ToString();
                    loggedUser = username;
                    fullName = reader["name"].ToString() + " " + reader["surname"].ToString();

                    this.Hide();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during login: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Password.Properties.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
