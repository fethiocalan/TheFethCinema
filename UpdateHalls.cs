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
using System.Xml.Linq;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CinemaProject
{
    public partial class UpdateHalls: Form
    {

        private string _oldType;
        private string _oldAccessibility;
        private string _oldLocation;
        private string _oldStatus;
        private int _hallId;
        private bool _isLoading = true;



        public UpdateHalls(int id, string hallName, int capacity, string screenTypes,
                   string accessibilityOptions, string location, string status, DateTime createdAt)
        {
            InitializeComponent();
            _isLoading = true;
            _hallId = id;
            HallNameUpdate.Text = hallName;
            HallCapacityUpdate.Value = capacity;

            hallAccessibilityUpdate.SetEditValue(accessibilityOptions);
            hallLocationUpdate.SetEditValue(location);
            hallTypeUpdate.SetEditValue(screenTypes);

          
            // Eskileri sakla (gerekirse)
            _oldAccessibility = accessibilityOptions;
            _oldLocation = location;
            _oldType = screenTypes;
            _oldStatus = status;
            
        }
       
        private void UpdateHalls_Load(object sender, EventArgs e)
        {
            // status checkbox'ları ayarla
            if (_oldStatus.Trim().ToLower() == "deactive")
            {
                checkEdit1.Checked = false;
                checkEdit2.Checked = true;
            }
            else
            {
                checkEdit1.Checked = true;
                checkEdit2.Checked = false;
            }

            // ComboBox item'ları doldur
            hallAccessibilityUpdate.Properties.Items.AddRange(new string[] {
        "Wheelchair Accessible", "Audio Description", "Braille Signage", "Ramp Entry",
        "Hearing Aid Compatible", "Large Print Materials", "Elevator Access",
        "Companion Seating", "Subtitled Screenings", "Closed Captioning System"
    });

            hallLocationUpdate.Properties.Items.AddRange(new string[] {
        "Ground Floor – Left Wing", "Ground Floor – Right Wing",
        "First Floor – East Side", "Second Floor – Center Area",
        "VIP Area"
    });

            hallTypeUpdate.Properties.Items.AddRange(new string[] {
        "Standard", "IMAX", "4DX", "Wide Screen", "LED Screen",
        "Curved Screen", "3D", "Dolby Cinema", "Laser Projection", "Dolby Atmos"
    });

            // Seçili değerleri ayarla
            ClearCheckedItems(hallAccessibilityUpdate);
            ClearCheckedItems(hallTypeUpdate);
            ClearCheckedItems(hallLocationUpdate);

            SetCheckedItems(hallAccessibilityUpdate, _oldAccessibility);
            SetCheckedItems(hallLocationUpdate, _oldLocation);
            SetCheckedItems(hallTypeUpdate, _oldType);

            // ❗❗❗ En son _isLoading = false ❗❗❗
            _isLoading = false;
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string newName = HallNameUpdate.Text.Trim();
            int newCapacity = (int)HallCapacityUpdate.Value;
            string newType = string.Join(", ", hallTypeUpdate.Properties.GetCheckedItems());
            string newAccessibility = string.Join(", ", hallAccessibilityUpdate.Properties.GetCheckedItems());
            string newLocation = string.Join(", ", hallLocationUpdate.Properties.GetCheckedItems());

            // ✅ Kullanıcının seçimine göre güncel değer
            string newStatus = checkEdit1.Checked ? "Active" : "Deactive";

            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS; Initial Catalog=CinemaProject; Integrated Security=True;"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
        UPDATE Halls SET 
            HallName = @name,
            Capacity = @capacity,
            ScreenType = @type,
            AccessibilityOptions = @access,
            Location = @location,
            Status = @status
        WHERE ID = @id", conn);

                cmd.Parameters.AddWithValue("@id", _hallId);
                cmd.Parameters.AddWithValue("@name", newName);
                cmd.Parameters.AddWithValue("@capacity", newCapacity);
                cmd.Parameters.AddWithValue("@type", newType);
                cmd.Parameters.AddWithValue("@access", newAccessibility);
                cmd.Parameters.AddWithValue("@location", newLocation);
                cmd.Parameters.AddWithValue("@status", newStatus); // ✅ artık bu güncel değer
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

            MessageBox.Show("Hall updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;

            if (checkEdit1.Checked)
            {
                checkEdit2.Checked = false;
            }
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (_isLoading) return;

            if (checkEdit2.Checked)
            {
                checkEdit1.Checked = false;
            }
        }
    }
}
