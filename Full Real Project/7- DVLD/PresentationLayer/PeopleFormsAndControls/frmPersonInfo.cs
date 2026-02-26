using BusinessLayer;
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
    public partial class frmPersonInfo : Form
    {
        public frmPersonInfo(int personID)
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            ctrlPersonInfo1.LoadInfo(personID);
        }
    }
}
