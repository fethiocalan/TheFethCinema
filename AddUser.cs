using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.Utils.DirectXPaint;
using static DevExpress.Skins.SolidColorHelper;
using System.Drawing.Drawing2D;



namespace CinemaProject
{
    public partial class AddUser: Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            SetRoundedRegion(sidePanel, 10);
            SetRoundedRegion(PanelAlert, 25);
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
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // Verileri Formdan Al  
            string name = txtName.Text.Trim();
            string surname = txtSurname_.Text.Trim();
            string ageText = txtAge_.Text.Trim();
            string gender = txtGender_.Text.Trim();
            string email = txtEmail_.Text.Trim();
            string phone = txtPhone_.Text.Trim();
            string salaryText = txtSalary_.Text.Trim();
            string username = txtUsername_.Text.Trim();
            string password = txtPassword_.Text.Trim();
            string imagePath = imagePath_; // Fotoğraf yolu  

            // Genel Boşluk Kontrolü
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(ageText) ||
                string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phone) ||
                string.IsNullOrEmpty(salaryText) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(imagePath))
            {
                ShowAlert("⚠️ Please fill all fields!", Color.IndianRed);
               
                return;
            }

            // Sayısal değerleri alma  
            int age = Convert.ToInt32(ageText);
            int salary = Convert.ToInt32(salaryText);
            string type = "A"; // Admin tipi  

            // Veritabanı Kaydı  
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=CinemaProject;Integrated Security=True"))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Users (userName, passWord, Type, name, surname, Age, gender, email, phone, salary, image) " +
                                                    "VALUES (@userName, @passWord, @Type, @name, @surname, @Age, @gender, @email, @phone, @salary, @image)", conn);

                    cmd.Parameters.AddWithValue("@userName", username);
                    cmd.Parameters.AddWithValue("@passWord", password); // Hashlemen daha iyi olur  
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@Age", age);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@image", imagePath);

                    cmd.ExecuteNonQuery();
                    foreach (Form form in Application.OpenForms)
                    {
                        if (form is UserList userList)
                        {
                            userList.LoadUsers();
                            break;
                        }
                    }
                    if (Application.OpenForms["ProfitLoss"] is ProfitLoss profitLossForm)
                    {
                        profitLossForm.LoadMonths();
                    }
                    ShowAlert("✓ Admin has been successfully added!", Color.FromArgb(46, 204, 113));
              
                    // Alanları temizle
                    txtName.Text = "";
                    txtSurname_.Text = "";
                    txtAge_.Text = "";
                    txtGender_.Text = "";
                    txtEmail_.Text = "";
                    txtPhone_.Text = "";
                    txtSalary_.Text = "";
                    txtUsername_.Text = "";
                    txtPassword_.Text = "";
                    image.Image = null;
                    imagePath_ = "";
                    uploadBtn.Text = "Upload";

                    // Focus ver
                    txtName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public string imagePath_ = "";
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose an image";
            openFileDialog.Filter = "PNG | *.png | JPG | *.jpg | JPEG | *.jpeg | All Files | *.*";
            openFileDialog.FilterIndex = 4;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                image.Image = new Bitmap(openFileDialog.FileName);
                imagePath_ = openFileDialog.FileName.ToString();
                uploadBtn.Text = "Change";

            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            uploadBtn.Text = "Update";
        }

        private void txtEmail__EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMail_Click(object sender, EventArgs e)
        {

        }
    }
}
