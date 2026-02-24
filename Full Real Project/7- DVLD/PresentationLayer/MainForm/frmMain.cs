using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.MainForm
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void ControlBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

       
    }
}
