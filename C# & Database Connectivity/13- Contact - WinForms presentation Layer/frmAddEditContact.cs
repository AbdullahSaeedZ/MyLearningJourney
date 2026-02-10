using ContactsBusinessLayer;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace _13__Contact___WinForms_presentation_Layer
{
    public partial class frmAddEditContact : Form
    {
        clsContact Contact;

        public frmAddEditContact(int ID)
        {
            InitializeComponent();
            _FillCountriesComboBox();

            if (ID == -1)
            {
                Contact = new clsContact();
                cbCountry.SelectedIndex = 0;
                
            }
            else
            {
                Contact = clsContact.find(ID);

                if (Contact == null) // when multiple users call same ID and one of them delete it and dont get updated on time for the other user, app will look for deleted ID then null
                {
                    MessageBox.Show("Contact doesnt Exist, Form will close"); 
                    this.Close();
                }

                _FillContactInfo();
                cbCountry.SelectedIndex = cbCountry.FindString(clsCountries.Find(Contact.CountryID).CountryName);
            }
        }

        private void _FillCountriesComboBox()
        {
            DataTable dt = clsCountries.getAllCountries();

            foreach (DataRow row in dt.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }

        private void _FillContactInfo()
        {
            lblID.Text = Contact.ID.ToString();
            lblTitle.Text = $"Edit Contact with ID = {Contact.ID}";

            tbFirstName.Text = Contact.FirstName;
            tbLastName.Text  = Contact.LastName;
            tbEmail.Text = Contact.Email;
            dtpBirthDate.Value = Contact.DateOfBirth;
            mtbPhone.Text = Contact.Phone;
            tbAddress.Text = Contact.Address;
            cbCountry.SelectedIndex = cbCountry.FindString(clsCountries.Find(Contact.CountryID).CountryName);

            if (!string.IsNullOrEmpty(Contact.ImagePath))
            {
                pbImage.Image = Image.FromFile(Contact.ImagePath);
                llblRemoveImage.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Contact.FirstName = tbFirstName.Text;
            Contact.LastName = tbLastName.Text;
            Contact.Email = tbEmail.Text;
            Contact.DateOfBirth = dtpBirthDate.Value;
            Contact.Phone = mtbPhone.Text;
            Contact.CountryID = clsCountries.Find(cbCountry.SelectedItem.ToString()).ID;
            Contact.Address = tbAddress.Text;
            // image will be empty or saved by setImage method

            if (Contact.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Done", MessageBoxButtons.OK);
                lblID.Text = Contact.ID.ToString();
                lblTitle.Text = $"Edit Contact with ID = {Contact.ID}";
            }
            else
            {
                MessageBox.Show("Data was not Saved", "Error", MessageBoxButtons.OK);
            }
        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = @"C:\"; // which folder or place to show when dialog opens
            openFileDialog1.Title = "Choose a Picture";
            openFileDialog1.DefaultExt = "png"; // default extension of file to be saved, user just enters file name then .txt will be attached to it
            openFileDialog1.Filter = "png (*.png)|*.png";
            openFileDialog1.FilterIndex = 1; //which extension to be default when dialog opens.(starts from 1)

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = Image.FromFile(openFileDialog1.FileName);
                Contact.ImagePath = openFileDialog1.FileName;
            }
        }
        private void llblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImage.Visible = false;
            Contact.ImagePath = "";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
