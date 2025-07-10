using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace CinemaProject
{
	public partial class MainForm: DevExpress.XtraBars.Ribbon.RibbonForm
	{


        public MainForm()
		{
            InitializeComponent();
            this.IsMdiContainer = true;
           

        }


    
        private void MainForm_Load(object sender, EventArgs e)
        {

            if (LogIn.userType == "A")
            {
                ribbonPage5.Visible = false;
                ribbonPage7.Visible = false;
                ribbonPageGroup22.Visible = false;
                ribbonPageGroup23.Visible = false;
               
            }
            else
            {
                ribbonPage5.Visible = true;
                ribbonPage7.Visible = true;
            }
            OpenOrFocusForm<FastAccess>();
         
            
        }

        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<AddDirector>();
        }

        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<AddActors>();
        }

        private void OpenOrFocusForm<T>() where T : Form, new()
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is T)
                {
                    openForm.Focus();
                    return;
                }
            }

            T form = new T();
            form.MdiParent = this;
            form.Show();
        
        }

        private void barButtonItem26_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<DirectorList>();
        }

        private void barButtonItem27_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<ActorList>();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<MovieList>();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<AddMovies>();
        }

        private void barButtonItem14_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<AddHall>();
        }

        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<HallList>();
        }

        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<AddSession>();
        }

        private void barButtonItem20_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<SessionList>();
        }

        private void barButtonItem28_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<AddMovies>();
        }

        private void barButtonItem29_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<AddActors>();
        }

        private void barButtonItem30_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<AddDirector>();
        }

        private void barButtonItem31_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<MovieList>();
        }

        private void barButtonItem32_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<ActorList>();
        }

        private void barButtonItem33_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<DirectorList>();
        }

        private void barButtonItem34_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<AddHall>();
        }

        private void barButtonItem35_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<HallList>();
        }

        private void barButtonItem36_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<AddSession>();
        }

        private void barButtonItem37_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<SessionList>();
        }

        private void barButtonItem19_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<CreateTicket>();
        }

        private void barButtonItem38_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<CreateTicket>();
        }

        private void barButtonItem22_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<DailyReport>();
        }

        private void barButtonItem39_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<TicketCheck>();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<TicketCheck>();
        }

        private void barButtonItem18_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<AddUser>();
        }

        private void barButtonItem42_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<AddUser>();
        }

        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<UserList>();
        }

        private void barButtonItem43_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<UserList>();
        }

        private void barButtonItem40_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<DailyReport>();
        }

        private void barButtonItem41_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<ProfitLoss>();
        }

        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenOrFocusForm<ProfitLoss>();
        }
    }
}