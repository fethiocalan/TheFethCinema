using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace CinemaProject
{
    public partial class MovieListUserControl: UserControl
    {
        public MovieListUserControl()
        {
            InitializeComponent();
        }

        private void MovieListUserControl_Load(object sender, EventArgs e)
        {

        }

        // Film bilgileri
        private int _id;
        private string _name;
        private string _releaseDate;
        private int _imdbRating;
        private string _directors;
        private string _actors;
        private string _genres;
        private string _formats;
        private string _details;
        private string _features;
        private string _posterPath;
        private string _duration;

        public void SetMovie(int id, string name, DateTime releaseDate, int imdbRating, string directors,
                             string actors, string genres, string formats, string details, string features, string posterPath,string duration)
        {
            _id = id;
            _name = name;
            _releaseDate = releaseDate.ToShortDateString();
            _imdbRating = imdbRating;
            _directors = directors;
            _actors = actors;
            _genres = genres;
            _formats = formats;
            _details = details;
            _features = features;
            _posterPath = posterPath;
            _duration = duration;

            // Label'lara set et
            MovieTitle.Text = _name;
            MovieRelease.Text = _releaseDate;
            MovieDuration.Text = $"{_duration} min";
            MovieGenre.Text = _genres;

            // Poster
            if (!string.IsNullOrEmpty(posterPath) && posterPath != "No_image" && File.Exists(posterPath))
                MovieImage.Image = Image.FromFile(posterPath);
            else
                MovieImage.Image = Properties.Resources.No_image;
        }

        private void DetailsBtn_Click(object sender, EventArgs e)
        {
            string info = $"🎬 Title: {_name}\n" +
                         $"📅 Release Date: {_releaseDate}\n" +
                         $"⭐ IMDB: {_imdbRating}/10\n" +
                         $"⏱ Duration: {_duration} min\n" +
                         $"🎭 Actors: {_actors}\n" +
                         $"🎬 Directors: {_directors}\n" +
                         $"🎞 Genres: {_genres}\n" +
                         $"💾 Formats: {_formats}\n" +
                         $"🔍 Features: {_features}\n\n" +
                         $"📖 Details:\n{_details}";

            MessageBox.Show(info, "Movie Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this movie?", "Confirm Delete",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=CinemaProject; Integrated Security=True;");
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM Movies WHERE ID = @id", conn);
                cmd.Parameters.AddWithValue("@id", _id);
                cmd.ExecuteNonQuery();

                conn.Close();

                // Posteri de sil (eğer özel bir resimse)
                if (!string.IsNullOrEmpty(_posterPath) && _posterPath != "No_image" && File.Exists(_posterPath))
                {
                    try { File.Delete(_posterPath); } catch { }
                }

                this.Parent.Controls.Remove(this);
                MessageBox.Show("Successfully deleted!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((FastAccess)Application.OpenForms["FastAccess"]).UpdateStats();
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateMovie updateForm = new UpdateMovie(
    
        _id,
        _name,
        Convert.ToDateTime(_releaseDate), // DateTime tipindeyse direkt gönder
        _imdbRating,
        _directors,
        _actors,
        _genres,
        _formats,
        _details,
        _features,
        _posterPath,
        Convert.ToInt32(_duration)
    );


            updateForm.Owner = this.FindForm();

            // 🔁 ShowDialog sonrası güncellemeyi tetikle
            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                // Bu kartı güncelleme yerine, tüm listeyi yenileyebilirsin:
                MovieList parent = this.FindForm() as MovieList;
                if (parent != null)
                    parent.RefreshMovieList(); // Listeyi yeniden çek
            }
        }
    }
}
