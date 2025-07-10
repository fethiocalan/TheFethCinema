using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraCharts;

namespace CinemaProject
{
    public partial class ProfitLoss: Form
    {
        public ProfitLoss()
        {
            InitializeComponent();
        }
        //we need an connection string to find the way of DB
        SqlConnection conn = new SqlConnection("Data Source = .\\SQLEXPRESS; Initial Catalog = CinemaProject; Integrated Security = True;");
        private void ProfitLoss_Load(object sender, EventArgs e)
        {

            LoadMonths();
            InitializeYearPicker();

            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
           

            LoadMonthlyChart(currentMonth, currentYear);
           
        }


       

        public void LoadMonths()
        {
            comboBoxEditMonth.Properties.Items.Clear();
            for (int i = 1; i <= 12; i++)
            {
                comboBoxEditMonth.Properties.Items.Add(CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat.GetMonthName(i));
            }
            comboBoxEditMonth.SelectedIndex = DateTime.Now.Month - 1;
        }

        public void InitializeYearPicker()
        {
            dateEditYear.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            dateEditYear.Properties.Mask.EditMask = "yyyy";
            dateEditYear.Properties.Mask.UseMaskAsDisplayFormat = true;

            dateEditYear.DateTime = DateTime.Now;
        }



        public void LoadMonthlyChart(int month, int year)
        {
            chartControlMonthly.Series.Clear();

            try
            {
                conn.Open();

                // Gider: A tipi kullanıcıların maaşları (her ay düzenli ödeme varsayımıyla)
                SqlCommand cmdExpenses = new SqlCommand("SELECT SUM(salary) FROM Users WHERE Type = @type", conn);
                cmdExpenses.Parameters.AddWithValue("@type", "A");
                object expenseResult = cmdExpenses.ExecuteScalar();
                decimal totalExpenses = expenseResult != DBNull.Value ? Convert.ToDecimal(expenseResult) : 0;

                // Gelir: Seçilen yıl ve aydaki bilet satışlarının toplamı
                SqlCommand cmdIncome = new SqlCommand("SELECT SUM(Price) FROM Ticket WHERE MONTH(ProcessTime) = @Month AND YEAR(ProcessTime) = @Year", conn);
                cmdIncome.Parameters.AddWithValue("@Month", month);
                cmdIncome.Parameters.AddWithValue("@Year", year);
                object incomeResult = cmdIncome.ExecuteScalar();
                decimal totalIncome = incomeResult != DBNull.Value ? Convert.ToDecimal(incomeResult) : 0;

                decimal profit = totalIncome - totalExpenses;

                // Grafik serisini oluştur
                Series series = new Series("Monthly Profit - Loss", ViewType.Bar);
                series.Points.Add(new SeriesPoint("Income", totalIncome));
                series.Points.Add(new SeriesPoint("Expenses", totalExpenses));
                series.Points.Add(new SeriesPoint("Profit / Loss", profit));

                chartControlMonthly.Series.Add(series);

                // Görünüm ayarları
                BarSeriesView view = (BarSeriesView)series.View;
                view.BarWidth = 0.6;
                view.FillStyle.FillMode = FillMode.Gradient;
                view.ColorEach = true;

                series.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;
                series.LegendTextPattern = "{A} : {V} $";

                chartControlMonthly.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;

                string monthName = CultureInfo.CreateSpecificCulture("en-US").DateTimeFormat.GetMonthName(month);
                chartControlMonthly.Titles.Clear();
                chartControlMonthly.Titles.Add(new ChartTitle() { Text = $"{monthName} {year} - Monthly Profit / Loss" });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading chart: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

     

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            int selectedMonth = comboBoxEditMonth.SelectedIndex + 1;
            int selectedYear = dateEditYear.EditValue != null ? dateEditYear.DateTime.Year : DateTime.Now.Year;

            LoadMonthlyChart(selectedMonth, selectedYear);
        }
    }
}
