using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using PresentationLayer.DashboardControls;

namespace PresentationLayer.MainForm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            // to start app with overview
            MainOptionsButtonHandler_Click(btnOverview, EventArgs.Empty);
        }

        private void _RefreshControlsContainer()
        {
            if (pnlControlsContainer.Controls.Count > 0)
                pnlControlsContainer.Controls.Clear();
        }

        private void MainOptionsButtonHandler_Click(object sender, EventArgs e)
        {
            _RefreshControlsContainer();
            Guna2Button selectedButten = (Guna2Button)sender;
            
            switch (selectedButten.Tag.ToString())
            {
                case "Overview":
                    ctrlDashboard ctr = new ctrlDashboard();
                    pnlControlsContainer.Controls.Add(ctr);
                    pnlControlsContainer.Show();
                    break;

                case "Applications":
                    
                    break;

                case "People":
                    
                    break;

                case "Drivers":
                    
                    break;

                case "Users":
                   
                    break;

                case "Settings":
                   
                    break;

                default:
                    ctrlDashboard ct = new ctrlDashboard();
                    pnlControlsContainer.Controls.Add(ct);
                    pnlControlsContainer.Show();
                    break;
            }

            // to reset unchosen buttons color
            foreach (Guna2Button btn in pnlSideBar.Controls.OfType<Guna.UI2.WinForms.Guna2Button>())
                    btn.FillColor = Color.Transparent;

            // to highlight selected color
            selectedButten.FillColor = Color.FromArgb(242, 245, 250);
        }





        // PersonID Quick Search
        private void lblQuickSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbQuickSearch.Text , out int ID))
            {
                _FindPerson(ID);
            }
            else
            {
                MessageBox.Show("No Valid Value Entered", "Error", MessageBoxButtons.OK);
            }
            
        }
        private void tbQuickSearch_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                lblQuickSearch_Click(sender, EventArgs.Empty);
            }
        }
        private void _FindPerson(int ID)
        {
            MessageBox.Show("find person");
        }

        // Closing the app
        private void ControlBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
