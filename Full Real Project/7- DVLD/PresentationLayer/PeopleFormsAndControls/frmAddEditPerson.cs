using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class frmAddEditPerson : Form
    {

        public frmAddEditPerson()
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
