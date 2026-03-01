using BusinessLayer;
using Guna.UI2.WinForms;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class frmAddEditPerson : Form
    {
        clsPeopleBusiness person;
        private const string _defaultMalePic = @"D:\defaultMaleProfile.png";
        private const string _defaultFemalePic = @"D:\defaultFemaleProfile.png";
        private const string _defaultComboBoxCountry = "Saudi Arabia";
        private DateTime _defaultMaxAllowedAge = DateTime.Now.AddYears(-18);
        private bool _isEmailValid = false, _isNationalIDValid = false;
   

        public frmAddEditPerson(int personID)
        {
            InitializeComponent();
            guna2ShadowForm1.SetShadowForm(this);
            _FillCountriesComboBox();
            rbMale.Checked = true;
            dtpBirthDate.MaxDate = _defaultMaxAllowedAge;

            if (personID == -1)
            {
                person = new clsPeopleBusiness();
            }
            else 
            {
                person = clsPeopleBusiness.FindPerson(personID.ToString(), "PersonID");
                if (person == null)
                {
                    MessageBox.Show("Person Does Not Exist, Form will close", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
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
            cbCountry.SelectedItem = _defaultComboBoxCountry;
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
            cbCountry.SelectedIndex = person.CountryID - 1; //////

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

        private bool AreAllFieldsFilledAndValidated()
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text) || string.IsNullOrWhiteSpace(tbSecondName.Text) || string.IsNullOrWhiteSpace(tbLastName.Text) ||
                string.IsNullOrWhiteSpace(tbAddress.Text) || string.IsNullOrWhiteSpace(tbPhone.Text) || string.IsNullOrWhiteSpace(tbNationalNumber.Text) ||
                !_isEmailValid || !_isNationalIDValid)
                return false;
            else
                return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!AreAllFieldsFilledAndValidated())
            {
                MessageBox.Show("Fields with * must be filled with valid data and not empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            person.NationalID = tbNationalNumber.Text;
            person.FirstName = tbFirstName.Text;
            person.SecondName = tbSecondName.Text;
            person.ThirdName = string.IsNullOrEmpty(tbThirdName.Text) ? "" : tbThirdName.Text;
            person.LastName = tbLastName.Text;
            person.Email = tbEmail.Text;
            person.BirthDate = dtpBirthDate.Value;
            person.Phone = tbPhone.Text;
            person.Address = tbAddress.Text;
            person.CountryID = cbCountry.SelectedIndex + 1;
            person.Gender = rbMale.Checked ? (byte)0 : (byte)1;

            if (btnRemoveImage.Visible == false)// set default if pic not added
            {
                pbImage.Image = rbMale.Checked ? Image.FromFile(_defaultMalePic) : Image.FromFile(_defaultFemalePic);
                person.ImagePath = rbMale.Checked ? _defaultMalePic : _defaultFemalePic;
            }
                  
            if (person.Save())
            {
                MessageBox.Show($"Data Saved Successfully, PersonID {person.PersonID}","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                lblPersonID.Text = person.PersonID.ToString();
                lblFormTitle.Text = $"Edit person with ID = {person.PersonID}";
            }
            else
            {
                MessageBox.Show("Data Was Not Saved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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



        // textBoxes error Validation
        private void tbNationalNumber_Validating(object sender, CancelEventArgs e)
        {
            // if not empty, go to next validation
            if (string.IsNullOrWhiteSpace(((Guna2TextBox)sender).Text))
            {
                tbNationalNumber.BorderColor = Color.Red;
                _isNationalIDValid = false; // to flag the save button
                return;
            }
            else
                tbNationalNumber.BorderColor = Color.Silver;

            // if ID is used 
            if (clsPeopleBusiness.DoesExist(tbNationalNumber.Text, "NationalNo"))
            {
                tbNationalNumber.BorderColor = Color.Red;
                lblIDExistsError.Visible = true;
                _isNationalIDValid = false;
            }
            else
            {
                tbNationalNumber.BorderColor = Color.Silver;
                lblIDExistsError.Visible = false;
                _isNationalIDValid = true;
            }
        }

        // not required, but if email entered, needs validation
        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            string Email = tbEmail.Text.Trim(); // if user forgets space in the end, it will give false
            bool isFormatValid = Regex.IsMatch(Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]+$",RegexOptions.IgnoreCase); //RegularExpressions same as Java

            if (!string.IsNullOrWhiteSpace(tbEmail.Text) && !isFormatValid)
            {
                tbEmail.BorderColor = Color.Red;
                lblEmailFormatError.Visible = true;
                _isEmailValid = false; // to flag the save button
            }
            else
            {
                tbEmail.BorderColor = Color.Silver;
                lblEmailFormatError.Visible = false;
                _isEmailValid = true;
            }    
        }

        // multiple textBoxes subscribed to this event
        private void EmptyTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((Guna2TextBox)sender).Text))
                ((Guna2TextBox)sender).BorderColor = Color.Red;
            else
                ((Guna2TextBox)sender).BorderColor = Color.Silver;
        }

        private void tbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)// prevent non digit and backspace
            {
                e.Handled = true; // will make the event handled which will prevent any input in text box
            }
        }
    }
}
