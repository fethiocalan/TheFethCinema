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

namespace CinemaProject
{
    public partial class SessionListUserControl: UserControl
    {
        public SessionListUserControl()
        {
            InitializeComponent();
        }

        private void SessionListUserControl_Load(object sender, EventArgs e)
        {

        }
        public bool IsCompactView
        {
            get => _isCompactView;
            set
            {
                _isCompactView = value;
                ApplyCompactStyle();
            }
        }
        private void ApplyCompactStyle()
        {
            if (_isCompactView)
            {
                this.Size = new Size(170, 80);
                deleteBtn.Visible = false;

                sessionPic.Size = new Size(50, 50);
                sessionPic.Location = new Point(10, 15);
                sessionPic.SizeMode = PictureBoxSizeMode.Zoom;

                // Film Adı
                sessionMovieName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                sessionMovieName.Location = new Point(55, 15);
                sessionMovieName.AutoSize = true;
                sessionMovieName.Visible = true;

                // Salon
                sessionHallName.Font = new Font("Segoe UI", 10);
                sessionHallName.Location = new Point(55, 40);
                sessionHallName.AutoSize = true;
                sessionHallName.Visible = true;

                // Saat
                sessionTime.Font = new Font("Segoe UI", 10);
                sessionTime.Location = new Point(55, 60);
                sessionTime.AutoSize = true;
                sessionTime.Visible = true;

                // Tarih (gerekliyse)
                sessionDate.Visible = false; // veya true yapabilirsin
            }
            else
            {
                // Normal görünüm ayarları
                this.Size = new Size(400, 150);
                deleteBtn.Visible = true;

                sessionPic.Size = new Size(100, 130);
                sessionPic.Location = new Point(10, 10);

                sessionMovieName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                sessionMovieName.Location = new Point(120, 10);

                sessionHallName.Location = new Point(120, 40);
                sessionTime.Location = new Point(120, 60);
                sessionDate.Visible = true;
            }
        }
        private bool _isCompactView = false;
        // Film bilgileri

        private string _movieName;
        private string _hallName;
        private DateTime _date;
        private DateTime _time;
        private int id;
        private string _posterPath;

        public void SetSession(int _id, string movieName, string hallName, DateTime _Sdate, DateTime _Stime, string posterPath)
        {
            id = _id;
            _movieName = movieName;
            _hallName = hallName;
            _date = _Sdate;
            _time = _Stime;
            _posterPath = posterPath;

            sessionMovieName.Text = _movieName;
            sessionHallName.Text = _hallName;
            sessionDate.Text = _date.ToShortDateString();
            sessionTime.Text = _time.ToShortTimeString();



            // Posteri yükle
            if (!string.IsNullOrEmpty(_posterPath) && System.IO.File.Exists(_posterPath))
            {
                sessionPic.Image = Image.FromFile(_posterPath);
            }
            else
            {
                sessionPic.Image = Properties.Resources.No_image; // varsayılan poster
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to Delete this Session?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DeleteSessionFromDatabase();

                // Kullanıcı kontrolünü kaldır (görsel olarak da silinsin)
                this.Parent.Controls.Remove(this);
            }
        }
        private void DeleteSessionFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=CinemaProject; Integrated Security=True;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Sessions WHERE ID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
