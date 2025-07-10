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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static DevExpress.Skins.SolidColorHelper;

namespace CinemaProject
{
    public partial class UpdateMovie: Form
    {
        private int _movieId;
        private string _oldGenres;
        private string _oldFormats;
        private string _oldFeatures;
        private string _oldDirectors;
        private string _oldActors;
        private string _oldPosterPath = "";
        private string _newPosterPath = "";
        public UpdateMovie(int id, string name, DateTime releaseDate, int imdbRating, string directors,
                            string actors, string genres, string formats, string details, string features, string posterPath, int duration)
        {
            InitializeComponent();
            _movieId = id;

            movieNameUpdate.Text = name;
            movieReleaseUpdate.DateTime = releaseDate;
            movieRatingUpdate.Text = imdbRating.ToString();
            movieDetailUpdate.Text = details;
            movieDurationUpdate.Value = duration;
            _oldPosterPath = posterPath;
            _newPosterPath = ""; // Henüz yeni bir poster seçilmedi

            if (File.Exists(posterPath))
                movieImageUpdate.Image = Image.FromFile(posterPath);
            else
                movieImageUpdate.Image = Properties.Resources.No_image;

            movieGenreUpdate.SetEditValue(genres);
            movieDirectorUpdate.SetEditValue(directors);
            movieFormatUpdate.SetEditValue(formats);
            movieFeatureUpdate.SetEditValue(features);
            movieActorUpdate.SetEditValue(actors);

            _oldGenres = genres;
            _oldFormats = formats;
            _oldFeatures = features;
            _oldDirectors = directors;
            _oldActors = actors;
            _oldPosterPath = posterPath;
            movieImageUpdate.Tag = posterPath;

        }

        private void UpdateMovie_Load(object sender, EventArgs e)
        {
            movieGenreUpdate.Properties.Items.AddRange(new string[] { "Comedy", "Action", "Fantasy", "Horror", "Sci-Fi", "Mystery", "Romance", "Thriller", "Animation", "Western" });
            movieFormatUpdate.Properties.Items.AddRange(new string[] { "4K UHD", "1080p", "IMAX", "English CC", "Arabic CC", "Turkish CC", "Kurdish CC", "MP4", "MKV", "AVI", "Turkish Sound", "Original Audio" });
            movieFeatureUpdate.Properties.Items.AddRange(new string[] { "+7", "+13", "+18", "+21", "Family Friendly", "Substance Use", "Sexual Content", "General Audience", "Contains Violence", "True Events", "Contains Strong Language", "Tragic" });

            movieDirectorUpdate.Properties.Items.AddRange(GetDirectorsFromDb());
            movieActorUpdate.Properties.Items.AddRange(GetActorsFromDb());

            ClearCheckedItems(movieGenreUpdate);
            ClearCheckedItems(movieFormatUpdate);
            ClearCheckedItems(movieFeatureUpdate);
            ClearCheckedItems(movieDirectorUpdate);
            ClearCheckedItems(movieActorUpdate);

            SetCheckedItems(movieGenreUpdate, _oldGenres);
            SetCheckedItems(movieFormatUpdate, _oldFormats);
            SetCheckedItems(movieFeatureUpdate, _oldFeatures);
            SetCheckedItems(movieDirectorUpdate, _oldDirectors);
            SetCheckedItems(movieActorUpdate, _oldActors);
        }
        private void ClearCheckedItems(DevExpress.XtraEditors.CheckedComboBoxEdit combo)
        {
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in combo.Properties.Items)
                item.CheckState = CheckState.Unchecked;
        }

        private void SetCheckedItems(DevExpress.XtraEditors.CheckedComboBoxEdit combo, string csvValues)
        {
            var values = csvValues.Split(',').Select(x => x.Trim());
            foreach (DevExpress.XtraEditors.Controls.CheckedListBoxItem item in combo.Properties.Items)
                item.CheckState = values.Contains(item.Value.ToString()) ? CheckState.Checked : CheckState.Unchecked;
        }

        private string[] GetActorsFromDb()
        {
            List<string> list = new List<string>();
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=CinemaProject;Integrated Security=True;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT AcName, AcSurname FROM Casts", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add($"{reader["AcName"].ToString().Trim()} {reader["AcSurname"].ToString().Trim()}");
                conn.Close();
            }
            return list.ToArray();
        }

        private string[] GetDirectorsFromDb()
        {
            List<string> list = new List<string>();
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=CinemaProject;Integrated Security=True;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT drName, drSurname FROM Directors", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                    list.Add($"{reader["drName"].ToString().Trim()} {reader["drSurname"].ToString().Trim()}");
                conn.Close();
            }
            return list.ToArray();
        }
        private void save_Click(object sender, EventArgs e)
        {
            string finalPosterPath = _oldPosterPath;

            if (!string.IsNullOrWhiteSpace(_newPosterPath))
            {
                if (_newPosterPath == "No_image")
                {
                    finalPosterPath = "No_image";

                    if (File.Exists(_oldPosterPath))
                    {
                        try { File.Delete(_oldPosterPath); } catch { }
                    }
                }
                else
                {
                    string postersFolder = Path.Combine(Application.StartupPath, "Posters");
                    if (!Directory.Exists(postersFolder))
                        Directory.CreateDirectory(postersFolder);

                    string newFileName = Path.GetFileName(_newPosterPath);
                    finalPosterPath = Path.Combine(postersFolder, newFileName);

                    if (_oldPosterPath != finalPosterPath && File.Exists(_oldPosterPath))
                    {
                        try { File.Delete(_oldPosterPath); } catch { }
                    }

                    if (!File.Exists(finalPosterPath))
                    {
                        try { File.Copy(_newPosterPath, finalPosterPath); }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Poster kopyalanamadı: " + ex.Message);
                        }
                    }
                }
            }

            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=CinemaProject;Integrated Security=True;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE Movies SET 
            Name=@name, ReleaseDate=@releaseDate, ImdbRating=@imdb,
            Directors=@directors, Actors=@actors, Genres=@genres,
            Formats=@formats, Details=@details, Features=@features,
            Duration=@duration,
            PosterPath=@posterPath WHERE ID=@id", conn);

                cmd.Parameters.AddWithValue("@id", _movieId);
                cmd.Parameters.AddWithValue("@posterPath", finalPosterPath);
                cmd.Parameters.AddWithValue("@name", movieNameUpdate.Text.Trim());
                cmd.Parameters.AddWithValue("@releaseDate", movieReleaseUpdate.DateTime);
                cmd.Parameters.AddWithValue("@imdb", Convert.ToInt32(movieRatingUpdate.Text));
                cmd.Parameters.AddWithValue("@actors", string.Join(", ", movieActorUpdate.Properties.GetCheckedItems()));
                cmd.Parameters.AddWithValue("@directors", string.Join(", ", movieDirectorUpdate.Properties.GetCheckedItems()));
                cmd.Parameters.AddWithValue("@genres", string.Join(", ", movieGenreUpdate.Properties.GetCheckedItems()));
                cmd.Parameters.AddWithValue("@formats", string.Join(", ", movieFormatUpdate.Properties.GetCheckedItems()));
                cmd.Parameters.AddWithValue("@features", string.Join(", ", movieFeatureUpdate.Properties.GetCheckedItems()));
                cmd.Parameters.AddWithValue("@details", movieDetailUpdate.Text.Trim());
                cmd.Parameters.AddWithValue("@duration", (int)movieDurationUpdate.Value);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MessageBox.Show("Movie updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        

        private void movieDetailUpdate_EditValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(movieDetailUpdate.Text))
            {
                movieDetailUpdate.Properties.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
                movieDetailUpdate.Properties.Appearance.ForeColor = Color.Gray;
            }
            else
            {
                movieDetailUpdate.Properties.Appearance.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                movieDetailUpdate.Properties.Appearance.ForeColor = Color.Black;
            }


            int count = movieDetailUpdate.Text.Length;
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

        private void uploadBtn_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Choose a poster";
            dialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _newPosterPath = dialog.FileName;
                using (var stream = new FileStream(_newPosterPath, FileMode.Open, FileAccess.Read))
                {
                    movieImageUpdate.Image = Image.FromStream(stream);
                }
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            movieImageUpdate.Image = Properties.Resources.No_image;
            _newPosterPath = "No_image"; // Kullanıcı resmi silmek istiyor
        }
    }
}
