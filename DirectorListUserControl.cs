using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DevExpress.Skins.SolidColorHelper;
using System.IO;
using System.Data.SqlClient;

namespace CinemaProject
{
    public partial class DirectorListUserControl : UserControl
    {
        public DirectorListUserControl()
        {
            InitializeComponent();
        }

        //we need an connection string to find the way of DB
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = CinemaProject; Integrated Security = True;");
        public void SetDirector(int id, string name, string surname, string imagePath, string gender, string nationality, string biography, int day, int month, int year)
        {

            //Details

             _id = id;
            _name = name;
            _surname = surname;
            _gender = gender;
            _nationality = nationality;
            _biography = biography;
            _imagePath = imagePath;
            _day = day;
            _month = month;
            _year = year;

            DrListName.Text = name;
            DrListSurname.Text = surname;

            DrListName.Text = name;
            DrListSurname.Text = surname;

            // Resim
            if (!string.IsNullOrEmpty(imagePath) && imagePath != "No_image" && File.Exists(imagePath))
            {
                DrListImage.Image = Image.FromFile(imagePath);
            }
            else
            {
                DrListImage.Image = Properties.Resources.No_image;
            }

            // Arka plan ve yazı rengi
            if (gender == "F")
            {
                panel1.BackColor = Color.FromArgb(250, 224, 220); // Toz pembe
                DrListName.ForeColor = Color.FromArgb(255, 71, 87); // Koyu pembe
                DrListSurname.ForeColor = Color.FromArgb(136, 84, 208); // Mor ton
            }
            else
            {
                panel1.BackColor = Color.FromArgb(209, 237, 242); // Pastel mavi
                DrListName.ForeColor = Color.FromArgb(33, 97, 140); // Koyu mavi
                DrListSurname.ForeColor = Color.FromArgb(84, 153, 199); // Açık mavi
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this director?", "Confirm Delete",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {


                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Directors WHERE drName = @name AND drSurname = @surname", conn);
                cmd.Parameters.AddWithValue("@name", DrListName.Text);
                cmd.Parameters.AddWithValue("@surname", DrListSurname.Text);
                cmd.ExecuteNonQuery();

                conn.Close();

                this.Parent.Controls.Remove(this);
                MessageBox.Show("Successfully deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((FastAccess)Application.OpenForms["FastAccess"]).UpdateStats();

                // Ekrandan da sil

            }
        }

        private void DirectorListUserControl_Load(object sender, EventArgs e)
        {

        }


        private string _name;
        private string _surname;
        private string _gender;
        private string _nationality;
        private string _imagePath;
        private string _biography;
        private int _day;
        private int _month;
        private int _year;
        private int _id;
     

        private void DetailsBtn_Click(object sender, EventArgs e)
        {
            string birthDate = $"{_day:D2}.{_month:D2}.{_year}";
            string info = $"👤 Name: {_name} {_surname}\n" +
                          $"🌍 Nationality: {_nationality}\n" +
                          $"🚻 Gender: {_gender}\n" +
                          $"🎂 Birth Date: {birthDate}\n\n" +
                          $"📖 Biography:\n{_biography}";

            MessageBox.Show(info, "Director Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            dr updateForm = new dr(
       _id,
       _name,
       _surname,
       _gender,
       _nationality,
       _biography,
       _imagePath,
       _day,
       _month,
       _year
   );
            updateForm.Owner = this.FindForm();
            updateForm.ShowDialog();
        }

        private void DrListSurname_Click(object sender, EventArgs e)
        {

        }

        private void DrListName_Click(object sender, EventArgs e)
        {

        }

        private void DrListImage_Click(object sender, EventArgs e)
        {

        }
    }
}
