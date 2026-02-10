using System;
using ContactsBusinessLayer;
using System.Windows.Forms;

namespace _13__Contact___WinForms_presentation_Layer
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
            _RefreshContactsList();
        }

        private void _RefreshContactsList()
        {
            // dataSource will receive a dataTable object:
            dgvAllContacts.DataSource = clsContact.GetAllContacts();
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            frmAddEditContact temp = new frmAddEditContact(-1);
            temp.ShowDialog();
            _RefreshContactsList();
        }

        private void tsmEditContact_Click(object sender, EventArgs e)
        {
            frmAddEditContact temp = new frmAddEditContact((int)dgvAllContacts.CurrentRow.Cells[0].Value);
            temp.ShowDialog();
            _RefreshContactsList();
        }

        private void tsmDeleteContact_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (clsContact.DeleteContact((int)dgvAllContacts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Contact Deleted Successfully!", "Done", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Contact was not Deleted", "Error", MessageBoxButtons.OK);
                }

                _RefreshContactsList();
            }

        }
    }
}
