using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaProject
{
    public partial class UpdateActor: Form
    {

        private int _id;
        private string _imagePath; // Eski resmi saklamak için
        private string newImagePath = ""; // Yeni yüklenen resmi tutmak için

        public UpdateActor(int id, string name, string surname, string gender, string nationality, string bio, string imagePath, int day, int month, int year)
        {
            InitializeComponent();
            _id = id;
            _imagePath = imagePath; // Eski resmi saklıyoruz

            AcUpdateName_.Text = name;
            AcUpdateSurname_.Text = surname;
            AcUpdateGender_.SelectedItem = gender;
            AcUpdateNationality_.Text = nationality;
            AcUpdateBiography_.Text = bio;
            AcUpdateBirthDay.Value = day;
            AcUpdateBirthMonth.Value = month;
            AcUpdateBirthYear.Value = year;

            if (File.Exists(imagePath))
                AcUpdateImage.Image = Image.FromFile(imagePath);
            else
                AcUpdateImage.Image = Properties.Resources.No_image;

        }

        private void UpdateActor_Load(object sender, EventArgs e)
        {
            // Nationality ayarları (sadece tasarım için görsel ayarlar)
            AcUpdateNationality_.Properties.DropDownRows = 10;
            AcUpdateNationality_.Properties.PopupFormWidth = 200;
            AcUpdateNationality_.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            AcUpdateNationality_.Properties.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            AcUpdateNationality_.Properties.AppearanceDropDown.Font = new Font("Segoe UI", 10F);

            // Gender ayarları
            AcUpdateGender_.Properties.DropDownRows = 10;
            AcUpdateGender_.Properties.PopupFormWidth = 200;
            AcUpdateGender_.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            AcUpdateGender_.Properties.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            AcUpdateGender_.Properties.AppearanceDropDown.Font = new Font("Segoe UI", 10F);
        }

        private void AcUpdateBiography__EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AcUpdateBiography_.Text))
            {
                AcUpdateBiography_.Properties.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
                AcUpdateBiography_.Properties.Appearance.ForeColor = Color.Gray;
            }
            else
            {
                AcUpdateBiography_.Properties.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                AcUpdateBiography_.Properties.Appearance.ForeColor = Color.Black;
            }


            int count = AcUpdateBiography_.Text.Length;
            int countBack = 300 - count;
            charCount.Text = countBack.ToString();


            if (countBack < 200 && countBack >= 100)
            {
                charCount.ForeColor = Color.Orange;
            }
            else if (countBack < 100 && countBack >= 10)
            {
                charCount.ForeColor = Color.DarkOrange;
            }
            else if (countBack < 10 && countBack >= 0)
            {
                charCount.ForeColor = Color.DarkRed;
            }
            else
            {
                charCount.ForeColor = Color.MediumBlue;
            }
        }


        public string path = "";
        private void uploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose an image";
            openFileDialog.Filter = "PNG | *.png | JPG | *.jpg | JPEG | *.jpeg | All Files | *.*";
            openFileDialog.FilterIndex = 4;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                AcUpdateImage.Image = new Bitmap(openFileDialog.FileName);
                newImagePath = openFileDialog.FileName;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            uploadBtn.Text = "Upload";
            AcUpdateImage.Image = Properties.Resources.No_image;
            newImagePath = ""; // ✔️ Yeni resim sıfırlanmalı
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            // Zorunlu alanlar boşsa uyarı ver
            if (string.IsNullOrWhiteSpace(AcUpdateName_.Text) ||
                string.IsNullOrWhiteSpace(AcUpdateSurname_.Text) ||
                string.IsNullOrWhiteSpace(AcUpdateNationality_.Text) ||
                string.IsNullOrWhiteSpace(AcUpdateBiography_.Text) ||
                AcUpdateGender_.SelectedItem == null ||
                (string.IsNullOrWhiteSpace(newImagePath) && string.IsNullOrWhiteSpace(_imagePath)))
            {
                MessageBox.Show("⚠️ Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yeni resim yoksa eskisini kullan
            string finalImagePath;

            if (!string.IsNullOrWhiteSpace(newImagePath)) // Kullanıcı yeni bir resim seçtiyse
            {
                finalImagePath = newImagePath;
            }
            else if (AcUpdateImage.Image == Properties.Resources.No_image) // No_image görünüyorsa
            {
                finalImagePath = "No_image";
            }
            else // Hiçbir şey yapılmadıysa eski resmi kullan
            {
                finalImagePath = _imagePath;
            }

            SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=CinemaProject; Integrated Security=True;");
            conn.Open();
            SqlCommand cmd = new SqlCommand(@"
    UPDATE Casts SET
        AcName = @name,
        AcSurname = @surname,
        AcGender = @gender,
        AcNationality = @nationality,
        AcBiography = @bio,
        AcImage = @image,
        AcDay = @day,
        AcMonth = @month,
        AcYear = @year
    WHERE ID = @id", conn);

            cmd.Parameters.AddWithValue("@id", _id);
            cmd.Parameters.AddWithValue("@name", AcUpdateName_.Text.Trim());
            cmd.Parameters.AddWithValue("@surname", AcUpdateSurname_.Text.Trim());
            cmd.Parameters.AddWithValue("@gender", AcUpdateGender_.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@nationality", AcUpdateNationality_.Text.Trim());
            cmd.Parameters.AddWithValue("@bio", AcUpdateBiography_.Text.Trim());
            cmd.Parameters.AddWithValue("@image", finalImagePath);
            cmd.Parameters.AddWithValue("@day", AcUpdateBirthDay.Value);
            cmd.Parameters.AddWithValue("@month", AcUpdateBirthMonth.Value);
            cmd.Parameters.AddWithValue("@year", AcUpdateBirthYear.Value);
          
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("🎉 Actor/Actress updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;

            // Ana formu yenile
            ActorList parentForm = this.Owner as ActorList;
            if (parentForm != null)
            {
                parentForm.RefreshActorList();
            }

            this.Close();
        }
    }
}
