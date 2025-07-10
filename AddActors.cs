using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils.DirectXPaint;
using static DevExpress.Skins.SolidColorHelper;

namespace CinemaProject
{
    public partial class AddActors: Form
    {
        public AddActors()
        {
            InitializeComponent();
        }

        //we need an connection string to find the way of DB
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = CinemaProject; Integrated Security = True;");

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
           
        }

        private void DeleteBtn_Click_1(object sender, EventArgs e)
        {
            ActorImage.Image = Properties.Resources.No_image;
            imagePath = "";
            ActorUploadBtn.Text = "Upload";
        }


        // Upload A Cast İmage!!
        public string imagePath = "";
        private void ActorUploadBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose an image";
            openFileDialog.Filter = "PNG | *.png | JPG | *.jpg | JPEG | *.jpeg | All Files | *.*";
            openFileDialog.FilterIndex = 4;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                ActorImage.Image = new Bitmap(openFileDialog.FileName);
                imagePath = openFileDialog.FileName.ToString();
                ActorUploadBtn.Text = "Change";

            }
        }

        //ShowAlert
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
        private void AddActors_Load(object sender, EventArgs e)
        {
            //Round Alert
            SetRoundedRegion(sidePanel, 10);
            SetRoundedRegion(PanelAlert, 25);
            // DirectorName
            ActorName.Properties.NullValuePrompt = "e.g. John";
            ActorName.Properties.NullValuePromptShowForEmptyValue = true;
            ActorName.Properties.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Italic);


            // DirectorSurname
            ActorSurname.Properties.NullValuePrompt = "e.g. Doyle";
            ActorSurname.Properties.NullValuePromptShowForEmptyValue = true;
            ActorSurname.Properties.Appearance.Font = new Font("Segoe UI", 14F);



            ActorBiography.Properties.NullValuePrompt = "Write a short biography...";
            ActorBiography.Properties.NullValuePromptShowForEmptyValue = true;
            ActorBiography.Properties.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            ActorBiography.Properties.Appearance.ForeColor = Color.Gray;




            //nationality
            ActorNationality.Properties.DropDownRows = 10;
            ActorNationality.Properties.PopupFormWidth = 200;
            ActorNationality.Properties.Appearance.Font = new Font("Segoe UI", 10F);
            ActorNationality.SelectedItem = "Turkey";

            ActorNationality.Properties.Appearance.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            ActorNationality.Properties.AppearanceDropDown.Font = new Font("Segoe UI", 10F);






            //ToolTip
            toolTip1.InitialDelay = 500;        // tooltip will open immidiately
            toolTip1.AutoPopDelay = 3000;      // 10 second stay open
            toolTip1.ReshowDelay = 100;
            toolTip1.ShowAlways = true;


            toolTip1.SetToolTip(ActorName, "Enter the director's first name");
            toolTip1.SetToolTip(ActorSurname, "Enter the director's last name");
            toolTip1.SetToolTip(ActorImage, "Upload a clear portrait photo");
            toolTip1.SetToolTip(ActorSaveBtn, "Click to save the director's information");
            toolTip1.SetToolTip(ActorBiography, "Write a short biography (max 300 characters)");
            toolTip1.SetToolTip(ActorNationality, "Select the director's nationality");
            toolTip1.SetToolTip(ActorMale, "Select if the director is male");
            toolTip1.SetToolTip(ActorFemale, "Select if the director is female");

            //ToolTip efect
            toolTip1.BackColor = Color.LightYellow;
            toolTip1.ForeColor = Color.DarkBlue;
            toolTip1.IsBalloon = true;  // Baloncuk şeklinde görünüm
            toolTip1.ToolTipTitle = "Hint";
            toolTip1.ToolTipIcon = ToolTipIcon.Info;

        }

        private void ActorSaveBtn_Click(object sender, EventArgs e)
        {

            //Date correction for february
            if (ActorMonth.Value == 2 && ActorDay.Value > 29)
            {

                ShowAlert("Invalid date for February!", Color.FromArgb(192, 192, 0));
            }
            else
            {

                if (ActorName.Text != "" && ActorSurname.Text != "" && ActorBiography.Text != "" && imagePath != "")
                {



                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Casts (AcName, AcSurname, AcGender, AcNationality, AcBiography, AcImage,AcDay,AcMonth,AcYear) VALUES (@name, @surname, @gender,@nationality, @bio, @image,@day,@month,@year)", conn);
                    cmd.Parameters.AddWithValue("@name", ActorName.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@surname", ActorSurname.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@nationality", ActorNationality.Text);
                    cmd.Parameters.AddWithValue("@bio", ActorBiography.Text);
                    cmd.Parameters.AddWithValue("@image", imagePath);
                    cmd.Parameters.AddWithValue("@day", ActorDay.Value);
                    cmd.Parameters.AddWithValue("@month", ActorMonth.Value);
                    cmd.Parameters.AddWithValue("@year", ActorYear.Value);
                    cmd.ExecuteNonQuery();

                    if (Application.OpenForms["FastAccess"] is FastAccess fastAccessForm)
                    {
                        fastAccessForm.UpdateStats();
                    }

                    conn.Close();
                    ShowAlert("✓ Actor/Actress saved successfully!", Color.FromArgb(46, 204, 113));

                    if (Application.OpenForms["ActorList"] is ActorList actorForm)
                    {
                        actorForm.RefreshActorList();
                    }
                    if (Application.OpenForms["AddMovies"] is AddMovies addMoviesForm)
                    {
                        addMoviesForm.RefreshActorList();
                    }
                    if (Application.OpenForms["Report"] is DailyReport reportForm)
                    {
                        reportForm.LoadSummaryChart();
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
        private void ActorMale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "M";
        }

        private void ActorFemale_CheckedChanged(object sender, EventArgs e)
        {
            gender = "F";
        }


        //refresh registration page
        void refresh()
        {
            ActorName.Text = "";
            ActorSurname.Text = "";
            ActorDay.Value = 1;
            ActorYear.Value = 2025;
            ActorMonth.Value = 1;
            ActorImage.Image = Properties.Resources.No_image;
            ActorBiography.Text = "";
            ActorName.Focus();


        }

        private void ActorName_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ActorName.Text))
            {
                // Placeholder görünümüne dön
                ActorName.Properties.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
                ActorName.Properties.Appearance.ForeColor = Color.Gray;
            }
            else
            {
                // Kullanıcı yazı yazıyor
                ActorName.Properties.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                ActorName.Properties.Appearance.ForeColor = Color.Black;
            }
        }

        private void ActorSurname_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ActorSurname.Text))
            {
                // Placeholder görünümüne dön
                ActorSurname.Properties.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Italic);
                ActorSurname.Properties.Appearance.ForeColor = Color.Gray;
            }
            else
            {
                // Kullanıcı yazı yazıyor
                ActorSurname.Properties.Appearance.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
                ActorSurname.Properties.Appearance.ForeColor = Color.Black;
            }
        }

        private void ActorBiography_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ActorBiography.Text))
            {
                ActorBiography.Properties.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
                ActorBiography.Properties.Appearance.ForeColor = Color.Gray;
            }
            else
            {
                ActorBiography.Properties.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                ActorBiography.Properties.Appearance.ForeColor = Color.Black;
            }


            int count = ActorBiography.Text.Length;
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
    }
}
