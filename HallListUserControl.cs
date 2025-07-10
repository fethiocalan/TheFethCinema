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
using DevExpress.Utils;
using static DevExpress.XtraBars.Docking2010.Views.BaseRegistrator;
using static DevExpress.Data.Filtering.Helpers.SubExprHelper.ThreadHoppingFiltering;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.IO;

namespace CinemaProject
{
    public partial class HallListUserControl: UserControl
    {
        public HallListUserControl()
        {
            InitializeComponent();
        }

        private void HallListUserControl_Load(object sender, EventArgs e)
        {

        }
        private int _HallId;
        private string _HallName;
        private int _Capacity;
        private string _Status;
        private string _Types;
        private string _accessibility;
        private string _location;
        private DateTime _createdAt;


        public void SetHall(int id, string name, int capacity, string status, DateTime createdAt, string types, string accessibility, string location)
        {
            _HallId = id;
            _HallName = name;
            _Capacity = capacity;
            _Status = status;
            _createdAt = createdAt;
            _Types = types;
            _accessibility = accessibility;
            _location = location;

            // UI bileşenlerini güncelle
            hallName.Text = _HallName;
            hallCapacity.Text = _Capacity.ToString();
            hallStatus.Text = _Status;
            createdTime.Text = _createdAt.ToString("dd.MM.yyyy HH:mm:ss");

            // ID değerini Tag olarak ata (Update/Delete için)
            this.Tag = _HallId;
        }

        private void detailsBtn_Click(object sender, EventArgs e)
        {
            string info = $"📌 Hall Name: {hallName.Text}\n" +
               $"👥 Capacity: {hallCapacity.Text} seats\n" +
               $"🎞 Screen Type: {_Types}\n" +
               $"♿ Accessibility: {_accessibility}\n" +
               $"📍 Location: {_location}\n" +
               $"📅 Created: {createdTime.Text}\n" +
               $"🟢 Status: {hallStatus.Text}";

            MessageBox.Show(info, "Hall Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("🗑️ Are you sure you want to delete this hall?", "Confirm Delete",
        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Veritabanından sil
                using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=CinemaProject; Integrated Security=True;"))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM Halls WHERE ID = @id", conn);
                    cmd.Parameters.AddWithValue("@id", _HallId);
                    cmd.Parameters.AddWithValue("@name", hallName.Text);
                    cmd.Parameters.AddWithValue("@cap", int.Parse(hallCapacity.Text));
                    cmd.ExecuteNonQuery();

                    conn.Close();
                }

                // Ekrandan sil
                this.Parent.Controls.Remove(this);

                MessageBox.Show("✅ Hall successfully deleted!", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // FastAccess güncelle (isteğe bağlı)
                if (Application.OpenForms["FastAccess"] is FastAccess fastAccess)
                {
                    fastAccess.UpdateStats();
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            UpdateHalls updateForm = new UpdateHalls(
         _HallId,
         _HallName,
         _Capacity,
         _Types,
         _accessibility,
         _location,
         _Status,
         _createdAt
     );

            updateForm.Owner = this.FindForm();
            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                // 🎯 Ana formu bul ve yeniden yükle
                Form parentForm = this.FindForm();
                if (parentForm is HallList hallListForm)
                {
                    hallListForm.LoadHalls(); // 💥 Listeyi tazele
                }
            }


        }

    }
}
