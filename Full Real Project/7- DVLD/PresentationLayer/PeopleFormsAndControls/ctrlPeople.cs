using System;
using System.Windows.Forms;
using PresentationLayer.PeopleFormsAndControls;

namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class ctrlPeople : UserControl
    {
        public ctrlPeople()
        {
            InitializeComponent();
        }


        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson addPersonForm = new frmAddEditPerson();
            addPersonForm.ShowDialog();
        }
    }
}
