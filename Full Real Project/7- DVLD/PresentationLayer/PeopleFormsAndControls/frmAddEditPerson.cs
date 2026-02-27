using BusinessLayer;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class frmAddEditPerson : Form
    {
        clsPeopleBusiness person;
        private string _defaultMalePic = @"D:\defaultMaleProfile.png";
        private string _defaultFemalePic = @"D:\defaultFemaleProfile.png";


        public frmAddEditPerson(int personID)
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            _FillCountriesComboBox();
            rbMale.Checked = true;

            if (personID == -1)
            {
                person = new clsPeopleBusiness();
            }
            else
            {
                person = clsPeopleBusiness.FindPerson(personID.ToString(), "PersonID");
                _FillPersonInfoInForm();
            }
        }

        private void _FillCountriesComboBox()
        {
            DataTable dt = clsCountriesBusiness.GetAllCountries();

            foreach (DataRow row in dt.Rows)
            {
                cbCountry.Items.Add(row["CountryName"]);
            }
        }
        private void _FillPersonInfoInForm()
        {

            lblPersonID.Text = person.PersonID.ToString();
            lblFormTitle.Text = $"Edit person with ID = {person.PersonID}";

            tbNationalNumber.Text = person.NationalID;
            tbFirstName.Text = person.FirstName;
            tbSecondName.Text = person.SecondName;
            tbThirdName.Text = person.ThirdName;
            tbLastName.Text = person.LastName;
            tbEmail.Text = person.Email;
            dtpBirthDate.Value = person.BirthDate;
            tbPhone.Text = person.Phone;
            tbAddress.Text = person.Address;
            cbCountry.SelectedIndex = cbCountry.FindString(person.Country);

            if (person.Gender == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;


            if (!string.IsNullOrEmpty(person.ImagePath))
            {
                pbImage.Image = Image.FromFile(person.ImagePath);

                if(person.ImagePath != _defaultMalePic && person.ImagePath != _defaultFemalePic)
                btnRemoveImage.Visible = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            person.NationalID = tbNationalNumber.Text;
            person.FirstName = tbFirstName.Text;
            person.SecondName = tbSecondName.Text;
            person.ThirdName = tbThirdName.Text;
            person.LastName = tbLastName.Text;
            person.Email = tbEmail.Text;
            person.BirthDate = dtpBirthDate.Value;
            person.Phone = tbPhone.Text;
            person.Address = tbAddress.Text;
            person.Country = cbCountry.SelectedItem.ToString();
            person.Gender = rbMale.Checked ? (byte)0 : (byte)1;

            if (btnRemoveImage.Visible == false)// set default if pic not added
            {
                pbImage.Image = rbMale.Checked ? Image.FromFile(_defaultMalePic) : Image.FromFile(_defaultFemalePic);
                person.ImagePath = rbMale.Checked ? _defaultMalePic : _defaultFemalePic;
            }
                  
            // saving process...

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = @"D:\"; // which folder or place to show when dialog opens
            openFileDialog1.Title = "Choose a Profile Picture";
            openFileDialog1.DefaultExt = "png"; // default extension of file to be saved, user just enters file name then .txt will be attached to it
            openFileDialog1.Filter = "png (*.png)|*.png";
            openFileDialog1.FilterIndex = 1; //which extension to be default when dialog opens.(starts from 1)

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbImage.Image = Image.FromFile(openFileDialog1.FileName);
                person.ImagePath = openFileDialog1.FileName;
                btnRemoveImage.Visible = true;
            }
        }

        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            btnRemoveImage.Visible = false;
            person.ImagePath = string.Empty;
            pbImage.Image = rbMale.Checked ? Image.FromFile(_defaultMalePic) : Image.FromFile(_defaultFemalePic);
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRemoveImage.Visible == false) // set default if pic not added
                pbImage.Image = rbMale.Checked ? Image.FromFile(_defaultMalePic) : Image.FromFile(_defaultFemalePic);
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (btnRemoveImage.Visible == false) // set default if pic not added
                pbImage.Image = rbMale.Checked ? Image.FromFile(_defaultMalePic) : Image.FromFile(_defaultFemalePic);
        }
    }
}
