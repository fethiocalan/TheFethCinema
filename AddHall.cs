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
using DevExpress.XtraEditors;

namespace CinemaProject
{
    public partial class AddHall: Form
    {
        public AddHall()
        {
            InitializeComponent();
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }

        private void AddHall_Load(object sender, EventArgs e)
        {

        }

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
        bool isRed23 = false;
        bool isRed24 = false;
        bool isRed25 = false;
        bool isRed26 = false;
        bool isRed27 = false;
        bool isRed28 = false;
        bool isRed29 = false;

        private void panel11_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed11)
            {
                panel11.BackColor = Color.LightGray; // Orijinal renk (gri)
                
                isRed11 = false;
            }
            else
            {
                panel11.BackColor = Color.IndianRed;
              
                isRed11 = true;
            }
        }

        private void panel12_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed12)
            {
                panel12.BackColor = Color.LightGray;
               
                isRed12 = false;
            }
            else
            {
                panel12.BackColor = Color.IndianRed;
               
                isRed12 = true;
            }
        }

        private void panel13_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed13)
            {
                panel13.BackColor = Color.LightGray;
              
                isRed13 = false;
            }
            else
            {
                panel13.BackColor = Color.IndianRed;
               
                isRed13 = true;
            }
        }

        private void panel14_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed14)
            {
                panel14.BackColor = Color.LightGray;
             
                isRed14 = false;
            }
            else
            {
                panel14.BackColor = Color.IndianRed;
              
                isRed14 = true;
            }
        }

        private void panel15_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed15)
            {
                panel15.BackColor = Color.LightGray;
               
                isRed15 = false;
            }
            else
            {
                panel15.BackColor = Color.IndianRed;
             
                isRed15 = true;
            }
        }

        private void panel16_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed16)
            {
                panel16.BackColor = Color.LightGray;
                ;
                isRed16 = false;
            }
            else
            {
                panel16.BackColor = Color.IndianRed;
               
                isRed16 = true;
            }
        }

        private void panel20_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed20)
            {
                panel20.BackColor = Color.LightGray;
               
                isRed20 = false;
            }
            else
            {
                panel20.BackColor = Color.IndianRed;
             
                isRed20 = true;
            }
        }

        private void panel17_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed17)
            {
                panel17.BackColor = Color.LightGray;
              
                isRed17 = false;
            }
            else
            {
                panel17.BackColor = Color.IndianRed;
               
                isRed17 = true;
            }
        }

        private void panel18_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed18)
            {
                panel18.BackColor = Color.LightGray;
                
                isRed18 = false;
            }
            else
            {
                panel18.BackColor = Color.IndianRed;
               
                isRed18 = true;
            }
        }

        private void panel19_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed19)
            {
                panel19.BackColor = Color.LightGray;
               
                isRed19 = false;
            }
            else
            {
                panel19.BackColor = Color.IndianRed;
               
                isRed19 = true;
            }
        }

        private void panel8_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed8)
            {
                panel8.BackColor = Color.LightGray; // Orijinal renk (gri)
               
                isRed8 = false;
            }
            else
            {
                panel8.BackColor = Color.IndianRed;
                
                isRed8 = true;
            }
        }

        private void panel6_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed6)
            {
                panel6.BackColor = Color.LightGray; // Orijinal renk (gri)
               
                isRed6 = false;
            }
            else
            {
                panel6.BackColor = Color.IndianRed;
               
                isRed6 = true;
            }
        }

        private void panel5_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed5)
            {
                panel5.BackColor = Color.LightGray; // Orijinal renk (gri)
                
                isRed5 = false;
            }
            else
            {
                panel5.BackColor = Color.IndianRed;
                
                isRed5 = true;
            }
        }

        private void panel3_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed3)
            {
                panel3.BackColor = Color.LightGray; // Orijinal renk (gri)
                
                isRed3 = false;
            }
            else
            {
                panel3.BackColor = Color.IndianRed;
               
                isRed3 = true;
            }
        }

        private void panel9_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed9)
            {
                panel9.BackColor = Color.LightGray; // Orijinal renk (gri)
                
                isRed9 = false;
            }
            else
            {
                panel9.BackColor = Color.IndianRed;
              
                isRed9 = true;
            }
        }

        

        private void panel7_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed7)
            {
                panel7.BackColor = Color.LightGray; // Orijinal renk (gri)
             
                isRed7 = false;
            }
            else
            {
                panel7.BackColor = Color.IndianRed;
               
                isRed7 = true;
            }
        }

        private void panel4_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed4)
            {
                panel4.BackColor = Color.LightGray; // Orijinal renk (gri)
                
                isRed4 = false;
            }
            else
            {
                panel4.BackColor = Color.IndianRed;
                
                isRed4 = true;
            }
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed1)
            {
                panel1.BackColor = Color.LightGray; // Orijinal renk (gri)
              
                isRed1 = false;
            }
            else
            {
                panel1.BackColor = Color.IndianRed;
               
                isRed1 = true;
            }
        }

        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed2)
            {
                panel2.BackColor = Color.LightGray; // Orijinal renk (gri)
               
                isRed2 = false;
            }
            else
            {
                panel2.BackColor = Color.IndianRed;
               
                isRed2 = true;
            }
        }

        private void panel10_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed10)
            {
                panel10.BackColor = Color.LightGray; // Orijinal renk (gri)
               
                isRed10 = false;
            }
            else
            {
                panel10.BackColor = Color.IndianRed;
              
                isRed10 = true;
            }
        }

        private void panel24_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed24)
            {
                panel24.BackColor = Color.LightGray;
                
                isRed24 = false;
            }
            else
            {
                panel24.BackColor = Color.IndianRed;
               
                isRed24 = true;
            }
        }

        private void panel23_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed23)
            {
                panel23.BackColor = Color.LightGray;
               
                isRed23 = false;
            }
            else
            {
                panel23.BackColor = Color.IndianRed;
                
                isRed23 = true;
            }
        }

        private void panel27_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed27)
            {
                panel27.BackColor = Color.LightGray;
               
                isRed27 = false;
            }
            else
            {
                panel27.BackColor = Color.IndianRed;
                
                isRed27 = true;
            }
        }

        private void panel26_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed26)
            {
                panel26.BackColor = Color.LightGray;
               
                isRed26 = false;
            }
            else
            {
                panel26.BackColor = Color.IndianRed;
                
                isRed26 = true;
            }
        }

        private void panel25_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed25)
            {
                panel25.BackColor = Color.LightGray;
                
                isRed25 = false;
            }
            else
            {
                panel25.BackColor = Color.IndianRed;
               
                isRed25 = true;
            }
        }

        private void panel22_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed22)
            {
                panel22.BackColor = Color.LightGray;
               
                isRed22 = false;
            }
            else
            {
                panel22.BackColor = Color.IndianRed;
                
                isRed22 = true;
            }
        }

        private void panel21_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed21)
            {
                panel21.BackColor = Color.LightGray;
               
                isRed21 = false;
            }
            else
            {
                panel21.BackColor = Color.IndianRed;
                
                isRed21 = true;
            }
        }

        private void panel28_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed28)
            {
                panel28.BackColor = Color.LightGray;
                isRed28 = false;
               
            }
            else
            {
                panel28.BackColor = Color.IndianRed;
                panel29.BackColor = Color.LightGray;
                isRed29 = false;
                isRed28 = true;
               
            }
        }

        private void panel29_MouseClick(object sender, MouseEventArgs e)
        {
            if (isRed29)
            {
                panel29.BackColor = Color.LightGray;
                isRed29 = false;
             
            }
            else
            {
                panel29.BackColor = Color.IndianRed;
                panel28.BackColor = Color.LightGray;
                isRed28 = false;
                isRed29 = true;
               
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            string selectedAccessibilityOptions = ""; 
            if (isRed1) selectedAccessibilityOptions += "Closed Captioning System, ";
            if (isRed2) selectedAccessibilityOptions += "Large Print Materials, ";
            if (isRed3) selectedAccessibilityOptions += "Audio Description, ";
            if (isRed4) selectedAccessibilityOptions += "Hearing Aid Compatible, ";
            if (isRed5) selectedAccessibilityOptions += "Subtitled Screenings, ";
            if (isRed6) selectedAccessibilityOptions += "Ramp Entry, ";
            if (isRed7) selectedAccessibilityOptions += "Elevator Access, ";
            if (isRed8) selectedAccessibilityOptions += "Wheelchair Accessible, ";
            if (isRed9) selectedAccessibilityOptions += "Braille Signage, ";
            if (isRed10) selectedAccessibilityOptions += "Companion Seating, ";
            selectedAccessibilityOptions = selectedAccessibilityOptions.TrimEnd(',', ' ');

            //format
            string selectedScreenTypes = "";
            if (isRed11) selectedScreenTypes += "Standard, ";
            if (isRed12) selectedScreenTypes += "IMAX, ";
            if (isRed13) selectedScreenTypes += "4DX, ";
            if (isRed14) selectedScreenTypes += "Wide Screen, ";
            if (isRed15) selectedScreenTypes += "LED Screen, ";
            if (isRed16) selectedScreenTypes += "Curved Screen, ";
            if (isRed17) selectedScreenTypes += "3D, ";
            if (isRed18) selectedScreenTypes += "Dolby Cinema, ";
            if (isRed19) selectedScreenTypes += "Laser Projection, ";
            if (isRed20) selectedScreenTypes += "Dolby Atmos, ";
           
            selectedScreenTypes = selectedScreenTypes.TrimEnd(',', ' ');

            //feature
            string selectedLocation = "";
            if (isRed21) selectedLocation += "VIP Area, ";
            if (isRed22) selectedLocation += "Basement Level 1, ";
            if (isRed23) selectedLocation += "Ground Floor - Right Wing, ";
            if (isRed24) selectedLocation += "Ground Floor - Left Wing, ";
            if (isRed25) selectedLocation += "Second Floor - Center Area, ";
            if (isRed26) selectedLocation += "First Floor - West Side, ";
            if (isRed27) selectedLocation += "First Floor - East Side, ";
            selectedLocation = selectedLocation.TrimEnd(',', ' ');

            string selectedStatus = "";
            if (isRed28) selectedStatus += "Active";
            if (isRed29) selectedStatus += "Deactive";
            selectedStatus = selectedStatus.TrimEnd(',', ' ');


            // 1. Gerekli alan kontrolü
            if (string.IsNullOrWhiteSpace(HallName.Text) ||
                string.IsNullOrWhiteSpace(selectedScreenTypes) ||
                string.IsNullOrWhiteSpace(selectedAccessibilityOptions) ||
                string.IsNullOrWhiteSpace(selectedLocation) ||
                string.IsNullOrWhiteSpace(selectedStatus) ||
                HallCapacity.Value <= 0)
            {
                MessageBox.Show("⚠️ Please fill in all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Değerleri al
            string hallName = HallName.Text.Trim();
            int capacity = (int)HallCapacity.Value;
            string screenTypes = selectedScreenTypes.TrimEnd(',', ' ');
            string accessibility = selectedAccessibilityOptions.TrimEnd(',', ' ');
            string location = selectedLocation;
            string status = "";
            if (isRed28 && !isRed29)
                status = "Active";
            else if (isRed29 && !isRed28)
                status = "Deactive";
            else
            {
                MessageBox.Show("Please select either 'Active' or 'Deactive' for the hall status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime createdAt = DateTime.Now;

            // 3. Database kaydet
            using (SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=CinemaProject;Integrated Security=True;"))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
            INSERT INTO Halls (HallName, Capacity, ScreenType, AccessibilityOptions, Location, Status, CreatedAt)
            VALUES (@HallName, @Capacity, @ScreenType, @AccessibilityOptions, @Location, @Status, @CreatedAt)", conn);

                cmd.Parameters.AddWithValue("@HallName", hallName);
                cmd.Parameters.AddWithValue("@Capacity", capacity);
                cmd.Parameters.AddWithValue("@ScreenType", screenTypes);
                cmd.Parameters.AddWithValue("@AccessibilityOptions", accessibility);
                cmd.Parameters.AddWithValue("@Location", location);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@CreatedAt", createdAt);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            RefreshForm();

            MessageBox.Show("✅ Hall successfully added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (Application.OpenForms["HallList"] != null)
            {
                ((HallList)Application.OpenForms["HallList"]).ReloadData();
            }
            // İsteğe bağlı: Formu sıfırla

        }

        public void RefreshForm()
        {
            HallName.Text = "";
            HallCapacity.Value = 0;

            isRed1 = isRed2 = isRed3 = isRed4 = isRed5 = isRed6 = isRed7 = isRed8 = isRed9 = isRed10 = false;
            isRed11 = isRed12 = isRed13 = isRed14 = isRed15 = isRed16 = isRed17 = isRed18 = isRed19 = isRed20 = false;
            isRed21 = isRed22 = isRed23 = isRed24 = isRed25 = isRed26 = isRed27 = isRed28 = isRed29 = false;

            // Tüm panelleri griye döndür
            ResetPanelColors(1, 29);
        }

        // Panel rengini sıfırlamak için:
        private void ResetPanelColors(int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                var pnl = this.Controls.Find($"panel{i}", true).FirstOrDefault();
                if (pnl is Panel panel)
                    panel.BackColor = Color.LightGray;
            }
        }


    }
}
