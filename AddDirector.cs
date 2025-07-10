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
using static DevExpress.Skins.SolidColorHelper;
using System.Drawing.Drawing2D;

namespace CinemaProject
{
    public partial class AddDirector: Form
    {
        public AddDirector()
        {
            InitializeComponent();
        }

        //we need an connection string to find the way of DB
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = CinemaProject; Integrated Security = True;");





        // Upload A Director İmage!!
        public string imagePath = "";
        private void DirectorUploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose an image";
            openFileDialog.Filter = "PNG | *.png | JPG | *.jpg | JPEG | *.jpeg | All Files | *.*";
            openFileDialog.FilterIndex = 4;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                DirectorImage.Image = new Bitmap(openFileDialog.FileName);
                imagePath = openFileDialog.FileName.ToString();
                DirectorUploadBtn.Text = "Change";

            }
        }

        private void DirectorBiography_TextChanged(object sender, EventArgs e)
        {
            int count = DirectorBiography.Text.Length;
            int countBack = 300 - count;
            charCount.Text = countBack.ToString();


            if (countBack < 200 && countBack >= 100)
            {
                charCount.ForeColor = Color.DarkOrange;
            }
            else if (countBack < 100 && countBack >= 10)
            {
                charCount.ForeColor = Color.Orange;
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

        private void DirectorSaveBtn_Click(object sender, EventArgs e)
        {
           


            //Date correction for february
            if (DirectorMonth.Value == 2 && DirectorDay.Value > 29)
            {
               
                ShowAlert("Invalid date for February!", Color.FromArgb(192, 192, 0));
            }
            else {

                if (DirectorName.Text != "" && DirectorSurname.Text != "" && DirectorBiography.Text != "" && imagePath != "")
                {



                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Directors (drName, drSurname, drGender,drNationality, drBio, drImage,drDay,drMonth,drYear) VALUES (@name, @surname, @gender,@nationality, @bio, @image,@day,@month,@year)", conn);
                    cmd.Parameters.AddWithValue("@name", DirectorName.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@surname", DirectorSurname.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@nationality",DirectorNationality.Text);
                    cmd.Parameters.AddWithValue("@bio", DirectorBiography.Text);
                    cmd.Parameters.AddWithValue("@image", imagePath);
                    cmd.Parameters.AddWithValue("@day", DirectorDay.Value);
                    cmd.Parameters.AddWithValue("@month", DirectorMonth.Value);
                    cmd.Parameters.AddWithValue("@year", DirectorYear.Value);
                    cmd.ExecuteNonQuery();

                    if (Application.OpenForms["FastAccess"] is FastAccess fastAccessForm)
                    {
                        fastAccessForm.UpdateStats();
                    }
                    conn.Close();
                    ShowAlert("✓ Director saved successfully!", Color.FromArgb(46, 204, 113));
                    if (Application.OpenForms["DirectorList"] is DirectorList directorListForm)
                    {
                        directorListForm.RefreshDirectorList();
                    }
                    if (Application.OpenForms["AddMovies"] is AddMovies addMovieForm)
                    {
                        addMovieForm.RefreshDirectorList();
                    }


                    //this method will refresh the Add Director Page and Focus the mouse on the director name
                    refresh();

                }

                else
                {
                    ShowAlert("⚠️ Please fill all fields!", Color.IndianRed);
                }



            }
        }


        public string gender = "M";
        private void DirectorMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "M";
        }

        private void DirectorFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "F";
        }

        //refresh registration page
        void refresh()
        {
            DirectorName.Text = "";
            DirectorSurname.Text = "";
            DirectorDay.Value = 1;
            DirectorYear.Value = 2025;
            DirectorMonth.Value = 1;
            DirectorImage.Image = Properties.Resources.No_image;
            DirectorBiography.Text = "";
            DirectorName.Focus();


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

        //round shape Alert
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

        private void AddDirector_Load(object sender, EventArgs e)
        {
            //Round Alert
            SetRoundedRegion(sidePanel, 10);
            SetRoundedRegion(PanelAlert, 25);
            // DirectorName
            DirectorName.Properties.NullValuePrompt = "e.g. John";
            DirectorName.Properties.NullValuePromptShowForEmptyValue = true;
            DirectorName.Properties.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
           

            // DirectorSurname
            DirectorSurname.Properties.NullValuePrompt = "e.g. Doyle";
            DirectorSurname.Properties.NullValuePromptShowForEmptyValue = true;
            DirectorSurname.Properties.Appearance.Font = new Font("Segoe UI", 14F);



            DirectorBiography.Properties.NullValuePrompt = "Write a short biography...";
            DirectorBiography.Properties.NullValuePromptShowForEmptyValue = true;
            DirectorBiography.Properties.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            DirectorBiography.Properties.Appearance.ForeColor = Color.Gray;




            //nationality
            DirectorNationality.Properties.DropDownRows = 10;
            DirectorNationality.Properties.PopupFormWidth = 200;
            DirectorNationality.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            DirectorNationality.SelectedItem = "Turkey";

            DirectorNationality.Properties.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            DirectorNationality.Properties.AppearanceDropDown.Font = new Font("Segoe UI", 10F);
          





            //ToolTip
            toolTip1.InitialDelay = 500;        // tooltip will open immidiately
            toolTip1.AutoPopDelay = 3000;      // 10 second stay open
            toolTip1.ReshowDelay = 100;
            toolTip1.ShowAlways = true;


            toolTip1.SetToolTip(DirectorName, "Enter the director's first name");
            toolTip1.SetToolTip(DirectorSurname, "Enter the director's last name");
            toolTip1.SetToolTip(DirectorImage, "Upload a clear portrait photo");
            toolTip1.SetToolTip(DirectorSaveBtn, "Click to save the director's information");
            toolTip1.SetToolTip(DirectorBiography, "Write a short biography (max 300 characters)");
            toolTip1.SetToolTip(DirectorNationality, "Select the director's nationality");
            toolTip1.SetToolTip(DirectorMale, "Select if the director is male");
            toolTip1.SetToolTip(DirectorFemale, "Select if the director is female");

            //ToolTip efect
            toolTip1.BackColor = Color.LightYellow;
            toolTip1.ForeColor = Color.DarkBlue;
            toolTip1.IsBalloon = true;  // Baloncuk şeklinde görünüm
            toolTip1.ToolTipTitle = "Hint";
            toolTip1.ToolTipIcon = ToolTipIcon.Info;



        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            
            DirectorImage.Image = Properties.Resources.No_image;
            imagePath = "";
            DirectorUploadBtn.Text = "Upload";

        }

        private void DirectorName_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DirectorName.Text))
            {
                // Placeholder görünümüne dön
                DirectorName.Properties.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
                DirectorName.Properties.Appearance.ForeColor = Color.Gray;
            }
            else
            {
                // Kullanıcı yazı yazıyor
                DirectorName.Properties.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                DirectorName.Properties.Appearance.ForeColor = Color.Black;
            }
        }

        private void DirectorSurname_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DirectorName.Text))
            {
                // Placeholder görünümüne dön
                DirectorSurname.Properties.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
                DirectorSurname.Properties.Appearance.ForeColor = Color.Gray;
            }
            else
            {
                // Kullanıcı yazı yazıyor
                DirectorSurname.Properties.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                DirectorSurname.Properties.Appearance.ForeColor = Color.Black;
            }
        }

        private void DirectorBiography_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DirectorBiography.Text))
            {
                DirectorBiography.Properties.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
                DirectorBiography.Properties.Appearance.ForeColor = Color.Gray;
            }
            else
            {
                DirectorBiography.Properties.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                DirectorBiography.Properties.Appearance.ForeColor = Color.Black;
            }


            int count = DirectorBiography.Text.Length;
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

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void DirectorNationality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
