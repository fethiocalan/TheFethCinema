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
using DevExpress.XtraCharts.Native;

namespace CinemaProject
{
    public partial class MovieList: Form
    {
        public MovieList()
        {
            InitializeComponent();
            this.Shown += MovieList_Shown;
        }
        //we need an connection string to find the way of DB
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = CinemaProject; Integrated Security = True;");
        private void MovieList_Load(object sender, EventArgs e)
        {
            RefreshMovieList();
            mSearch.Properties.NullText = "🔍 Search movie title or genre...";
        }


        public void RefreshMovieList()
        {
            MovieListPanel.Controls.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Movies ORDER BY Name ASC", conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MovieListUserControl movie = new MovieListUserControl();
                movie.SetMovie(
                    Convert.ToInt32(reader["ID"]),
                    reader["Name"].ToString(),
                    Convert.ToDateTime(reader["ReleaseDate"]),
                    Convert.ToInt32(reader["ImdbRating"]),
                    reader["Directors"].ToString(),
                    reader["Actors"].ToString(),
                    reader["Genres"].ToString(),
                    reader["Formats"].ToString(),
                    reader["Details"].ToString(),
                    reader["Features"].ToString(),
                    reader["PosterPath"].ToString(),
                    reader["Duration"].ToString()
                );
                MovieListPanel.Controls.Add(movie);
            }

            conn.Close();
        }

        private void mSearch_TextChanged(object sender, EventArgs e)
        {
            MovieListPanel.Controls.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Movies WHERE Name LIKE @search OR Genres LIKE @search ORDER BY Name ASC", conn);
            cmd.Parameters.AddWithValue("@search", "%" + mSearch.Text.Trim() + "%");

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MovieListUserControl movie = new MovieListUserControl();
                movie.SetMovie(
                    Convert.ToInt32(reader["ID"]),
                    reader["Name"].ToString(),
                    Convert.ToDateTime(reader["ReleaseDate"]),
                    Convert.ToInt32(reader["ImdbRating"]),
                    reader["Directors"].ToString(),
                    reader["Actors"].ToString(),
                    reader["Genres"].ToString(),
                    reader["Formats"].ToString(),
                    reader["Details"].ToString(),
                    reader["Features"].ToString(),
                    reader["PosterPath"].ToString(),
                    reader["Duration"].ToString()
                );
                MovieListPanel.Controls.Add(movie);
            }

            conn.Close();
        }

        private void MovieList_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = focus2;
        }

        private void mSearch_EditValueChanged(object sender, EventArgs e)
        {
            string search = mSearch.Text.Trim();

            MovieListPanel.Controls.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Movies WHERE Name LIKE @search ORDER BY Name ASC", conn);
            cmd.Parameters.AddWithValue("@search", "%" + search + "%");

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                MovieListUserControl movie = new MovieListUserControl();
                movie.SetMovie(
                    Convert.ToInt32(reader["ID"]),
                    reader["Name"].ToString(),
                    Convert.ToDateTime(reader["ReleaseDate"]),
                    Convert.ToInt32(reader["ImdbRating"]),
                    reader["Directors"].ToString(),
                    reader["Actors"].ToString(),
                    reader["Genres"].ToString(),
                    reader["Formats"].ToString(),
                    reader["Details"].ToString(),
                    reader["Features"].ToString(),
                    reader["PosterPath"].ToString(),
                    reader["Duration"].ToString()
                );
                MovieListPanel.Controls.Add(movie);
            }

            conn.Close();
        }



       
    }
}
