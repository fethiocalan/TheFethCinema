using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraEditors.Repository;
using static DevExpress.Skins.SolidColorHelper;

namespace CinemaProject
{
    public partial class AddMovies : Form
    {
      
        public AddMovies()
        {
            InitializeComponent();
        

        }
        //we need an connection string to find the way of DB
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = CinemaProject; Integrated Security = True;");

        PictureBox[] stars;
        int currentRating = 0;  // Tıklanan rating (0-5)


        //Uploading a Movie POSTER !!
        public string imagePath = "";
        private void posterUploadBtn_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose an image";
            openFileDialog.Filter = "PNG | *.png | JPG | *.jpg | JPEG | *.jpeg | All Files | *.*";
            openFileDialog.FilterIndex = 4;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                PosterImage.Image = new Bitmap(openFileDialog.FileName);
                imagePath = openFileDialog.FileName.ToString();
                posterUploadBtn.Text = "Change";

            }



          

           
        }


        //bring Director

        void drListBring()
        {
            string sorgu = "select * from Directors ORDER BY drName,drSurname ASC";
            drPanel.Controls.Clear();
            conn.Open();

            SqlCommand komut = new SqlCommand(sorgu, conn);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                drListUserControl drTool = new drListUserControl();
                drTool.labelDr.Text = oku["drName"].ToString();
                drTool.labelDr_.Text = oku["drSurname"].ToString();
                drPanel.Controls.Add(drTool);
            }

            conn.Close();
        }

        public void RefreshDirectorList()
        {
            drPanel.Controls.Clear();

            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=CinemaProject;Integrated Security=True;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Directors ORDER BY drName, drSurname ASC", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    drListUserControl drTool = new drListUserControl();
                    drTool.labelDr.Text = reader["drName"].ToString();
                    drTool.labelDr_.Text = reader["drSurname"].ToString();
                    drPanel.Controls.Add(drTool);
                }

                conn.Close();
            }
        }

        public void RefreshActorList()
        {
            acPanel.Controls.Clear();

            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=CinemaProject;Integrated Security=True;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Casts ORDER BY AcName, AcSurname ASC", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    acListUserControl acTool = new acListUserControl();
                    acTool.labelAc.Text = reader["AcName"].ToString().Trim();
                    acTool.labelAc_.Text = reader["AcSurname"].ToString().Trim();
                    acPanel.Controls.Add(acTool);
                }

                conn.Close();
            }
        }
        private void AddMovies_Load(object sender, EventArgs e)
        {
            drListBring();
            acListBring();

            dateEdit1.Properties.MinValue = DateTime.Today;
            dateEdit1.Properties.CalendarView = CalendarView.Vista;

            
 
            


            //tooltip

            toolTip1.AutoPopDelay = 3000;
            toolTip1.InitialDelay = 200;
            toolTip1.ReshowDelay = 200;
            toolTip1.ShowAlways = true;

            // Movie Features Tooltips (left to right)
            toolTip1.SetToolTip(L1, "Suitable for viewers aged 7+");
            toolTip1.SetToolTip(L2, "Suitable for viewers aged 13+");
            toolTip1.SetToolTip(L3, "Suitable for viewers aged 18+");
            toolTip1.SetToolTip(L4, "Suitable for viewers aged 21+");

            toolTip1.SetToolTip(L5, "Recommended for all family members");
            toolTip1.SetToolTip(L6, "Includes alcohol, drug or smoking scenes");

            toolTip1.SetToolTip(L7, "Includes romantic or sexual content");
            toolTip1.SetToolTip(L8, "Safe for general audience of all ages");

            toolTip1.SetToolTip(L9, "Contains scenes with violence or fighting");
            toolTip1.SetToolTip(L10, "Based on or inspired by true events");

            toolTip1.SetToolTip(L11, "Uses intense or strong language");
            toolTip1.SetToolTip(L12, "Contains sad or tragic elements");

            //General tooltip
            toolTip1.SetToolTip(txtMovieName, "Enter the movie title here.");
            toolTip1.SetToolTip(dateEdit1, "Select the movie's release date.");

            toolTip1.SetToolTip(ImdbRating, "Click a star to rate this movie (1 to 10).");

            
            toolTip1.SetToolTip(lbl11, "Choose if the movie is available in 4K UHD.");
            toolTip1.SetToolTip(lbl12, "Select 1080p format availability.");
            toolTip1.SetToolTip(lbl13, "Mark if the movie supports IMAX.");
            toolTip1.SetToolTip(lbl14, "Check if English closed captions are available.");
            toolTip1.SetToolTip(lbl15, "Check if Arabic closed captions are available.");
            toolTip1.SetToolTip(lbl16, "Check if Turkish closed captions are available.");
            toolTip1.SetToolTip(lbl17, "Check if Kurdish closed captions are available.");
            toolTip1.SetToolTip(lbl18, "Check MP4 format support.");
            toolTip1.SetToolTip(lbl19, "Check MKV format support.");
            toolTip1.SetToolTip(lbl20, "Check AVI format support.");
            toolTip1.SetToolTip(lbl21, "Select if Turkish dubbing is available.");
            toolTip1.SetToolTip(lbl22, "Select if original audio is available.");

            toolTip1.SetToolTip(detail, "Write a short summary or description (Max 300 characters).");
            toolTip1.SetToolTip(simpleButton2, "Delete the poster");
            toolTip1.SetToolTip(posterUploadBtn, "Click to upload a movie poster.");
            toolTip1.SetToolTip(saveBtn, "Click to save the movie to the database.");

            //Genre Tooltip
            toolTip1.SetToolTip(lbl1, "Light and humorous content to make you laugh.");
            toolTip1.SetToolTip(lbl2, "Mysterious stories with twists and secrets.");
            toolTip1.SetToolTip(lbl3, "High energy scenes with action and excitement.");
            toolTip1.SetToolTip(lbl4, "Emotional and romantic relationships are in focus.");
            toolTip1.SetToolTip(lbl5, "Magical, mythical, or otherworldly adventures.");
            toolTip1.SetToolTip(lbl6, "Intense suspense and psychological tension.");
            toolTip1.SetToolTip(lbl7, "Scary themes involving ghosts or monsters.");
            toolTip1.SetToolTip(lbl8, "Animated characters and creative visuals.");
            toolTip1.SetToolTip(lbl9, "Science-based futuristic settings or technology.");
            toolTip1.SetToolTip(lbl10, "Old-time cowboy and frontier-themed stories.");

            //Rating
            stars = new PictureBox[] { rate1, rate2, rate3, rate4, rate6,rate7,rate8,rate9,rate10,rate11 };

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].Tag = i + 1; // 1'den 5'e kadar index veriyoruz
                stars[i].MouseMove += Star_MouseMove;
                stars[i].MouseLeave += Star_MouseLeave;
                stars[i].Click += Star_Click;
            }
        }

        //Rating
        private void Star_MouseMove(object sender, MouseEventArgs e)
        {
            int hoverIndex = (int)((PictureBox)sender).Tag;

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].Image = (i < hoverIndex)
                    ? Properties.Resources.Star_filled
                    : Properties.Resources.Star_empty;
            }

            label1.Text = $"IMDB = {hoverIndex}";
        }

        private void Star_MouseLeave(object sender, EventArgs e)
        {
            // Fare çıkınca sabit değere dön
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].Image = (i < currentRating)
                    ? Properties.Resources.Star_filled
                    : Properties.Resources.Star_empty;
            }

            label1.Text = $"IMDB = {currentRating}";
        }

        private void Star_Click(object sender, EventArgs e)
        {
            currentRating = (int)((PictureBox)sender).Tag;
        }

        private void dSearch_TextChanged(object sender, EventArgs e)
        {
            drPanel.Controls.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Directors WHERE drName LIKE @search OR drSurname LIKE @search ORDER BY drName ASC", conn);
            cmd.Parameters.AddWithValue("@search", "%" + dSearch.Text.ToUpper() + "%");
            SqlDataReader oku = cmd.ExecuteReader();

            while (oku.Read())
            {
                drListUserControl drTool = new drListUserControl();
                drTool.labelDr.Text = oku["drName"].ToString();
                drTool.labelDr_.Text = oku["drSurname"].ToString();
                drPanel.Controls.Add(drTool);
            }

            conn.Close();
        }

        private void aSearch_TextChanged(object sender, EventArgs e)
        {
            acPanel.Controls.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Casts WHERE AcName LIKE @search OR AcSurname LIKE @search ORDER BY AcName ASC", conn);
            cmd.Parameters.AddWithValue("@search", "%" + aSearch.Text.ToUpper() + "%");
            SqlDataReader oku = cmd.ExecuteReader();

            while (oku.Read())
            {
                acListUserControl acTool = new acListUserControl();
                acTool.labelAc.Text = oku["AcName"].ToString();
                acTool.labelAc_.Text = oku["AcSurname"].ToString();
                acPanel.Controls.Add(acTool);
            }

            conn.Close();
        }

        void acListBring()
        {
            string sorgu = "select * from Casts ORDER BY AcName,AcSurname ASC";
            acPanel.Controls.Clear();
            conn.Open();

            SqlCommand komut = new SqlCommand(sorgu, conn);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                acListUserControl acTool = new acListUserControl();
                acTool.labelAc.Text = oku["AcName"].ToString();
                acTool.labelAc_.Text = oku["AcSurname"].ToString();
                acPanel.Controls.Add(acTool);
            }

            conn.Close();
        }




        //Genre
        bool isRed1 = false;
        bool isRed2 = false;
        bool isRed3 = false;
        bool isRed4 = false;
        bool isRed5 = false;
        bool isRed6 = false;
        bool isRed7 = false;
        bool isRed8 = false;
        bool isRed9 = false;
        bool isRed10 = false;
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed1)
            {
                panel1.BackColor = Color.LightGray; // Orijinal renk (gri)
                picture1.BackColor = Color.LightGray;
                isRed1 = false;
            }
            else
            {
                panel1.BackColor = Color.IndianRed;
                picture1.BackColor = Color.IndianRed;
                isRed1 = true;
            }
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed2)
            {
                panel2.BackColor = Color.LightGray; // Orijinal renk (gri)
                picture2.BackColor = Color.LightGray;
                isRed2 = false;
            }
            else
            {
                panel2.BackColor = Color.IndianRed;
                picture2.BackColor = Color.IndianRed;
                isRed2 = true;
            }
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed3)
            {
                panel3.BackColor = Color.LightGray; // Orijinal renk (gri)
                picture3.BackColor = Color.LightGray;
                isRed3 = false;
            }
            else
            {
                panel3.BackColor = Color.IndianRed;
                picture3.BackColor = Color.IndianRed;
                isRed3 = true;
            }
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed4)
            {
                panel4.BackColor = Color.LightGray; // Orijinal renk (gri)
                picture4.BackColor = Color.LightGray;
                isRed4 = false;
            }
            else
            {
                panel4.BackColor = Color.IndianRed;
                picture4.BackColor = Color.IndianRed;
                isRed4 = true;
            }
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed5)
            {
                panel5.BackColor = Color.LightGray; // Orijinal renk (gri)
                picture5.BackColor = Color.LightGray;
                isRed5 = false;
            }
            else
            {
                panel5.BackColor = Color.IndianRed;
                picture5.BackColor = Color.IndianRed;
                isRed5 = true;
            }
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed6)
            {
                panel6.BackColor = Color.LightGray; // Orijinal renk (gri)
                picture6.BackColor = Color.LightGray;
                isRed6 = false;
            }
            else
            {
                panel6.BackColor = Color.IndianRed;
                picture6.BackColor = Color.IndianRed;
                isRed6 = true;
            }
        }

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed7)
            {
                panel7.BackColor = Color.LightGray; // Orijinal renk (gri)
                picture7.BackColor = Color.LightGray;
                isRed7 = false;
            }
            else
            {
                panel7.BackColor = Color.IndianRed;
                picture7.BackColor = Color.IndianRed;
                isRed7 = true;
            }
        }

        private void panel8_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed8)
            {
                panel8.BackColor = Color.LightGray; // Orijinal renk (gri)
                picture8.BackColor = Color.LightGray;
                isRed8 = false;
            }
            else
            {
                panel8.BackColor = Color.IndianRed;
                picture8.BackColor = Color.IndianRed;
                isRed8 = true;
            }
        }

        private void panel9_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed9)
            {
                panel9.BackColor = Color.LightGray; // Orijinal renk (gri)
                picture9.BackColor = Color.LightGray;
                isRed9 = false;
            }
            else
            {
                panel9.BackColor = Color.IndianRed;
                picture9.BackColor = Color.IndianRed;
                isRed9 = true;
            }
        }

        private void panel10_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed10)
            {
                panel10.BackColor = Color.LightGray; // Orijinal renk (gri)
                picture10.BackColor = Color.LightGray;
                isRed10 = false;
            }
            else
            {
                panel10.BackColor = Color.IndianRed;
                picture10.BackColor = Color.IndianRed;
                isRed10 = true;
            }
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {

        }



        //Format
        bool isRed11 = false;
        bool isRed12 = false;
        bool isRed13 = false;
        bool isRed14 = false;
        bool isRed15 = false;
        bool isRed16 = false;
        bool isRed17 = false;
        bool isRed18 = false;
        bool isRed19 = false;
        bool isRed20 = false;
        bool isRed21 = false;
        bool isRed22 = false;

       
        private void panel11_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed11)
            {
                panel11.BackColor = Color.LightGray; // Orijinal renk (gri)
                picture10.BackColor = Color.LightGray;
                isRed11 = false;
            }
            else
            {
                panel11.BackColor = Color.IndianRed;
                picture11.BackColor = Color.IndianRed;
                isRed11 = true;
            }
        }

        private void panel12_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed12)
            {
                panel12.BackColor = Color.LightGray;
                picture12.BackColor = Color.LightGray;
                isRed12 = false;
            }
            else
            {
                panel12.BackColor = Color.IndianRed;
                picture12.BackColor = Color.IndianRed;
                isRed12 = true;
            }
        }

        private void panel13_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed13)
            {
                panel13.BackColor = Color.LightGray;
                picture13.BackColor = Color.LightGray;
                isRed13 = false;
            }
            else
            {
                panel13.BackColor = Color.IndianRed;
                picture13.BackColor = Color.IndianRed;
                isRed13 = true;
            }
        }

        private void panel14_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed14)
            {
                panel14.BackColor = Color.LightGray;
                picture14.BackColor = Color.LightGray;
                isRed14 = false;
            }
            else
            {
                panel14.BackColor = Color.IndianRed;
                picture14.BackColor = Color.IndianRed;
                isRed14 = true;
            }
        }

        private void panel15_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed15)
            {
                panel15.BackColor = Color.LightGray;
                picture15.BackColor = Color.LightGray;
                isRed15 = false;
            }
            else
            {
                panel15.BackColor = Color.IndianRed;
                picture15.BackColor = Color.IndianRed;
                isRed15 = true;
            }
        }

        private void panel16_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed16)
            {
                panel16.BackColor = Color.LightGray;
                picture16.BackColor = Color.LightGray;
                isRed16 = false;
            }
            else
            {
                panel16.BackColor = Color.IndianRed;
                picture16.BackColor = Color.IndianRed;
                isRed16 = true;
            }
        }

        private void panel17_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed17)
            {
                panel17.BackColor = Color.LightGray;
                picture17.BackColor = Color.LightGray;
                isRed17 = false;
            }
            else
            {
                panel17.BackColor = Color.IndianRed;
                picture17.BackColor = Color.IndianRed;
                isRed17 = true;
            }
        }

        private void panel18_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed18)
            {
                panel18.BackColor = Color.LightGray;
                picture18.BackColor = Color.LightGray;
                isRed18 = false;
            }
            else
            {
                panel18.BackColor = Color.IndianRed;
                picture18.BackColor = Color.IndianRed;
                isRed18 = true;
            }
        }

        private void panel19_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed19)
            {
                panel19.BackColor = Color.LightGray;
                picture19.BackColor = Color.LightGray;
                isRed19 = false;
            }
            else
            {
                panel19.BackColor = Color.IndianRed;
                picture19.BackColor = Color.IndianRed;
                isRed19 = true;
            }
        }

        private void panel20_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed20)
            {
                panel20.BackColor = Color.LightGray;
                picture20.BackColor = Color.LightGray;
                isRed20 = false;
            }
            else
            {
                panel20.BackColor = Color.IndianRed;
                picture20.BackColor = Color.IndianRed;
                isRed20 = true;
            }
        }

        private void panel21_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed21)
            {
                panel21.BackColor = Color.LightGray;
                picture21.BackColor = Color.LightGray;
                isRed21 = false;
            }
            else
            {
                panel21.BackColor = Color.IndianRed;
                picture21.BackColor = Color.IndianRed;
                isRed21 = true;
            }
        }

        private void panel22_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed22)
            {
                panel22.BackColor = Color.LightGray;
                picture22.BackColor = Color.LightGray;
                isRed22 = false;
            }
            else
            {
                panel22.BackColor = Color.IndianRed;
                picture22.BackColor = Color.IndianRed;
                isRed22 = true;
            }
        }




        //Movie Feature
        bool isRed23 = false;
        bool isRed24 = false;
        bool isRed25 = false;
        bool isRed26 = false;
        bool isRed27 = false;
        bool isRed28 = false;
        bool isRed29 = false;
        bool isRed30 = false;
        bool isRed31 = false;
        bool isRed32 = false;
        bool isRed33 = false;
        bool isRed34 = false;
        private void panel23_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed23)
            {
                panel23.BackColor = Color.LightGray;
                picture23.BackColor = Color.LightGray;
                isRed23 = false;
            }
            else
            {
                panel23.BackColor = Color.IndianRed;
                picture23.BackColor = Color.IndianRed;
                isRed23 = true;
            }
        }

        private void panel24_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed24)
            {
                panel24.BackColor = Color.LightGray;
                picture24.BackColor = Color.LightGray;
                isRed24 = false;
            }
            else
            {
                panel24.BackColor = Color.IndianRed;
                picture24.BackColor = Color.IndianRed;
                isRed24 = true;
            }
        }

        private void panel25_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed25)
            {
                panel25.BackColor = Color.LightGray;
                picture25.BackColor = Color.LightGray;
                isRed25 = false;
            }
            else
            {
                panel25.BackColor = Color.IndianRed;
                picture25.BackColor = Color.IndianRed;
                isRed25 = true;
            }
        }

        private void panel26_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed26)
            {
                panel26.BackColor = Color.LightGray;
                picture26.BackColor = Color.LightGray;
                isRed26 = false;
            }
            else
            {
                panel26.BackColor = Color.IndianRed;
                picture26.BackColor = Color.IndianRed;
                isRed26 = true;
            }
        }

        private void panel27_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed27)
            {
                panel27.BackColor = Color.LightGray;
                picture27.BackColor = Color.LightGray;
                isRed27 = false;
            }
            else
            {
                panel27.BackColor = Color.IndianRed;
                picture27.BackColor = Color.IndianRed;
                isRed27 = true;
            }
        }

        private void panel28_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed28)
            {
                panel28.BackColor = Color.LightGray;
                picture28.BackColor = Color.LightGray;
                isRed28 = false;
            }
            else
            {
                panel28.BackColor = Color.IndianRed;
                picture28.BackColor = Color.IndianRed;
                isRed28 = true;
            }
        }

        private void panel29_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed29)
            {
                panel29.BackColor = Color.LightGray;
                picture29.BackColor = Color.LightGray;
                isRed29 = false;
            }
            else
            {
                panel29.BackColor = Color.IndianRed;
                picture29.BackColor = Color.IndianRed;
                isRed29 = true;
            }
        }

        private void panel30_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed30)
            {
                panel30.BackColor = Color.LightGray;
                picture30.BackColor = Color.LightGray;
                isRed30 = false;
            }
            else
            {
                panel30.BackColor = Color.IndianRed;
                picture30.BackColor = Color.IndianRed;
                isRed30 = true;
            }
        }

        private void panel31_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed31)
            {
                panel31.BackColor = Color.LightGray;
                picture31.BackColor = Color.LightGray;
                isRed31 = false;
            }
            else
            {
                panel31.BackColor = Color.IndianRed;
                picture31.BackColor = Color.IndianRed;
                isRed31 = true;
            }
        }

        private void panel32_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed32)
            {
                panel32.BackColor = Color.LightGray;
                picture32.BackColor = Color.LightGray;
                isRed32 = false;
            }
            else
            {
                panel32.BackColor = Color.IndianRed;
                picture32.BackColor = Color.IndianRed;
                isRed32 = true;
            }
        }

        private void panel33_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed33)
            {
                panel33.BackColor = Color.LightGray;
                picture33.BackColor = Color.LightGray;
                isRed33 = false;
            }
            else
            {
                panel33.BackColor = Color.IndianRed;
                picture33.BackColor = Color.IndianRed;
                isRed33 = true;
            }
        }

        private void panel34_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed34)
            {
                panel34.BackColor = Color.LightGray;
                picture34.BackColor = Color.LightGray;
                isRed34 = false;
            }
            else
            {
                panel34.BackColor = Color.IndianRed;
                picture34.BackColor = Color.IndianRed;
                isRed34 = true;
            }
        }


    //Show alert
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
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            
            string name = txtMovieName.Text.Trim();
            DateTime releaseDate = dateEdit1.DateTime;
            int imdbRating = currentRating;
            string selectedDirectors = string.Join(", ", drPanel.Controls
    .OfType<drListUserControl>()
    .Where(x => x.directorPanel.BackColor == Color.IndianRed)
    .Select(x => x.labelDr.Text.Trim() + " " + x.labelDr_.Text.Trim()));

            string selectedActors = string.Join(", ", acPanel.Controls
    .OfType<acListUserControl>()
    .Where(x => x.actorPanel.BackColor == Color.IndianRed)
    .Select(x => x.labelAc.Text.Trim() + " " + x.labelAc_.Text.Trim()));


            //genre
            string selectedGenres = "";
            if (isRed1) selectedGenres += "Comedy, ";
            if (isRed2) selectedGenres += "Action, ";
            if (isRed3) selectedGenres += "Fantasy, ";
            if (isRed4) selectedGenres += "Horror, ";
            if (isRed5) selectedGenres += "Sci-Fi, ";
            if (isRed6) selectedGenres += "Mystery, ";
            if (isRed7) selectedGenres += "Romance, ";
            if (isRed8) selectedGenres += "Thriller, ";
            if (isRed9) selectedGenres += "Animation, ";
            if (isRed10) selectedGenres += "Western, ";
            selectedGenres = selectedGenres.TrimEnd(',', ' ');

            //format
            string selectedFormats = "";
            if (isRed11) selectedFormats += "4K UHD, ";
            if (isRed12) selectedFormats += "1080p, ";
            if (isRed13) selectedFormats += "IMAX, ";
            if (isRed14) selectedFormats += "English CC, ";
            if (isRed15) selectedFormats += "Arabic CC, ";
            if (isRed16) selectedFormats += "Turkish CC, ";
            if (isRed17) selectedFormats += "Kurdish CC, ";
            if (isRed18) selectedFormats += "MP4, ";
            if (isRed19) selectedFormats += "MKV, ";
            if (isRed20) selectedFormats += "AVI, ";
            if (isRed21) selectedFormats += "Turkish Sound, ";
            if (isRed22) selectedFormats += "Original Audio, ";
            selectedFormats = selectedFormats.TrimEnd(',', ' ');

            //feature
            string selectedFeatures = "";
            if (isRed23) selectedFeatures += "+7, ";
            if (isRed24) selectedFeatures += "+13, ";
            if (isRed25) selectedFeatures += "+18, ";
            if (isRed26) selectedFeatures += "+21, ";
            if (isRed27) selectedFeatures += "Family Friendly, ";
            if (isRed28) selectedFeatures += "Substance Use, ";
            if (isRed29) selectedFeatures += "Sexual Content, ";
            if (isRed30) selectedFeatures += "General Audience, ";
            if (isRed31) selectedFeatures += "Contains Violence, ";
            if (isRed32) selectedFeatures += "True Events, ";
            if (isRed33) selectedFeatures += "Contains Strong Language, ";
            if (isRed34) selectedFeatures += "Tragic, ";
            selectedFeatures = selectedFeatures.TrimEnd(',', ' ');

            string details = detail.Text.Trim();
            string posterPath = imagePath;

            if (string.IsNullOrWhiteSpace(name) ||
    imdbRating == 0 ||
    currentRating == 0 ||
    string.IsNullOrWhiteSpace(detail.Text) ||
    string.IsNullOrEmpty(imagePath) ||
    string.IsNullOrWhiteSpace(selectedFeatures) ||
    string.IsNullOrWhiteSpace(selectedFormats) ||
    string.IsNullOrWhiteSpace(selectedGenres) ||
    string.IsNullOrWhiteSpace(selectedDirectors) ||   
    string.IsNullOrWhiteSpace(selectedActors))       
            {
                ShowAlert("⚠️ Please fill all fields!", Color.IndianRed);
                return;
            }
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Movies (Name, ReleaseDate, ImdbRating, Directors, Actors, Genres, Formats, Details, Features, PosterPath,Duration) " +
                                            "VALUES (@Name, @ReleaseDate, @ImdbRating, @Directors, @Actors, @Genres, @Formats, @Details, @Features, @PosterPath,@Duration)", conn);

            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@ReleaseDate", releaseDate);
            cmd.Parameters.AddWithValue("@ImdbRating", imdbRating);
            cmd.Parameters.AddWithValue("@Directors", selectedDirectors);
            cmd.Parameters.AddWithValue("@Actors", selectedActors);
            cmd.Parameters.AddWithValue("@Genres", selectedGenres);
            cmd.Parameters.AddWithValue("@Formats", selectedFormats);
            cmd.Parameters.AddWithValue("@Details", details);
            cmd.Parameters.AddWithValue("@Features", selectedFeatures);
            cmd.Parameters.AddWithValue("@PosterPath", posterPath);
            cmd.Parameters.AddWithValue("@Duration", durationSpin.Value);

            cmd.ExecuteNonQuery();

            SqlCommand deleteCmd = new SqlCommand("DELETE FROM Choosen", conn);
            deleteCmd.ExecuteNonQuery();
            ((FastAccess)Application.OpenForms["FastAccess"]).UpdateStats();
            conn.Close();


            (Application.OpenForms.OfType<MovieList>().FirstOrDefault())?.RefreshMovieList();
            ShowAlert("✓ Movie added successfully!", Color.FromArgb(46, 204, 113));
            Refresh();
        }

        //Refresh
        public void Refresh()
        {

            posterUploadBtn.Text = "Upload";
            // Text alanlarını temizle
            txtMovieName.Text = "";
            detail.Text = "";

            // Tarihi sıfırla (bugünün tarihi olabilir)
            dateEdit1.DateTime = DateTime.Today;

            // Rating sıfırla
            currentRating = 0;
            Star_MouseLeave(null, null);

            // Oyuncu/Yönetmen seçimlerini temizle
            foreach (Control c in drPanel.Controls)
            {
                if (c is drListUserControl uc)
                    uc.directorPanel.BackColor = Color.Gray;
            }

            foreach (Control c in acPanel.Controls)
            {
                if (c is acListUserControl uc)
                    uc.actorPanel.BackColor = Color.Gray;
            }

            //format genre and feature refreshing staff
            isRed1 = isRed2 = isRed3 = isRed4 = isRed5 = isRed6 = isRed7 = isRed8 = isRed9 = isRed10 = false;
            isRed11 = isRed12 = isRed13 = isRed14 = isRed15 = isRed16 = isRed17 = isRed18 = isRed19 = isRed20 = isRed21 = isRed22 = false;
            isRed23 = isRed24 = isRed25 = isRed26 = isRed27 = isRed28 = isRed29 = isRed30 = isRed31 = isRed32 = isRed33 = isRed34 = false;

            // Genre/Format/Feature panellerini sıfırla
            ResetPanelColors(1, 34);

            // Poster sıfırla
            imagePath = null;
            PosterImage.Image = Properties.Resources.No_image;
        }
        private void ResetPanelColors(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                Control panel = this.Controls.Find("panel" + i, true).FirstOrDefault();
                Control picture = this.Controls.Find("picture" + i, true).FirstOrDefault();

                if (panel != null) panel.BackColor = Color.LightGray;
                if (picture != null) picture.BackColor = Color.LightGray;
            }
        }

        private void detail_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void detail_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(detail.Text))
            {
                detail.Properties.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
                detail.Properties.Appearance.ForeColor = Color.Gray;
            }
            else
            {
                detail.Properties.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                detail.Properties.Appearance.ForeColor = Color.Black;
            }


            int count = detail.Text.Length;
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

        private void AddMovies_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Open();
            SqlCommand deleteCmd = new SqlCommand("DELETE FROM Choosen", conn);
            deleteCmd.ExecuteNonQuery();
            conn.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            posterUploadBtn.Text = "Upload";
            PosterImage.Image = Properties.Resources.No_image;
            imagePath = "";
        }

        private void drPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
