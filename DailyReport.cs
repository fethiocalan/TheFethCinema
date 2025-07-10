using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;
using System.Data.SqlClient;

namespace CinemaProject
{
    public partial class DailyReport: Form
    {
        public DailyReport()
        {
            InitializeComponent();
        }
        //we need an connection string to find the way of DB
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = CinemaProject; Integrated Security = True;");
        private void DailyReport_Load(object sender, EventArgs e)
        {
            LoadSummaryChart();
        }
        public void LoadSummaryChart()
        {
            chartControl1.Series.Clear();

            conn.Open();

            int movieCount = Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM Movies", conn).ExecuteScalar());
            int actorCount = Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM Casts", conn).ExecuteScalar());
            int directorCount = Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM Directors", conn).ExecuteScalar());
            int hallCount = Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM Halls", conn).ExecuteScalar());
            int sessionCount = Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM Sessions", conn).ExecuteScalar());
            int ticketCount = Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM Ticket", conn).ExecuteScalar());
            int userCount = Convert.ToInt32(new SqlCommand("SELECT COUNT(*) FROM [Users]", conn).ExecuteScalar());

            conn.Close();

            Series pieSeries = new Series("Cinema Statistics", ViewType.Pie);

            pieSeries.Points.Add(new SeriesPoint("Movie(s)", movieCount));
            pieSeries.Points.Add(new SeriesPoint("Actor(s)", actorCount));
            pieSeries.Points.Add(new SeriesPoint("Director(s)", directorCount));
            pieSeries.Points.Add(new SeriesPoint("Hall(s)", hallCount));
            pieSeries.Points.Add(new SeriesPoint("Session(s)", sessionCount));
            pieSeries.Points.Add(new SeriesPoint("Ticket(s)", ticketCount));
            pieSeries.Points.Add(new SeriesPoint("User(s)", userCount));

            chartControl1.Series.Add(pieSeries);

            // 🎨 Görsel Ayarlar
            PieSeriesView view = (PieSeriesView)pieSeries.View;
           
            view.ExplodedDistancePercentage = 5; // Hafif patlama efekti
            view.RuntimeExploding = true;

            pieSeries.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            // 🎯 Etiketler: Kategori adı + yüzde
            PieSeriesLabel label = (PieSeriesLabel)pieSeries.Label;
            label.TextPattern = "{A}: {VP:P0}"; // Örn: Movie(s): %16
            label.Position = PieSeriesLabelPosition.TwoColumns; // Dışarı yaz
            label.ResolveOverlappingMode = ResolveOverlappingMode.Default;
            label.Font = new Font("Tahoma", 10, FontStyle.Bold);

            // 📘 Legend (sağda açıklama kutusu)
            chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartControl1.Legend.AlignmentHorizontal = LegendAlignmentHorizontal.Right;
            chartControl1.Legend.AlignmentVertical = LegendAlignmentVertical.Center;

            // 🏷 Başlık
            chartControl1.Titles.Clear();
            chartControl1.Titles.Add(new ChartTitle()
            {
                Text =" Summary Report",
                Font = new Font("Tahoma", 12, FontStyle.Bold),
                Dock = ChartTitleDockStyle.Top,
                Alignment = StringAlignment.Center
            });
        }



    }
}
