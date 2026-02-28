using BusinessLayer;
using Guna.UI2.WinForms;
using PresentationLayer.DashboardControls;
using PresentationLayer.MainForm;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;


namespace PresentationLayer.PeopleFormsAndControls
{
    public partial class ctrlPeople : UserControl
    {
        private enum enSearchOptions { None, PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, CountryName, Gender, Phone, Email }; // matching database names, not dgv
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumb;
        private enum enGender { Male = 0, Female = 1 };
        private DataTable dt;
        private string _searchFilter; // to use in search filters and match DT and DB column names, not dgv names


        public ctrlPeople()
        {
            InitializeComponent();
            RefreshDataGridView();
        }


        private void RefreshDataGridView()
        {
            dt = clsPeopleBusiness.GetAllPeople();
            dt.Columns.Add("Pic", typeof(byte[]));
            dt.Columns.Add("GenderString", typeof(string));

            foreach (DataRow row in dt.Rows)
            {
                // replace imagePath column with new column contain pic as bits
                row["Pic"] = File.ReadAllBytes(row["ImagePath"].ToString());

                string genderType = (byte)row["Gender"] == (byte)enGender.Male ? enGender.Male.ToString() : enGender.Female.ToString();
                row["GenderString"] = genderType;
            }

            dgvPeople.DataSource = dt;
            dgvPeople.Columns["ImagePath"].Visible = false; //hide unneeded columns
            dgvPeople.Columns["Gender"].Visible = false;
            lblNumberOfRecords.Text = dgvPeople.RowCount.ToString();
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            delUpdateBreadcrumb(sender,new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Add"});
            frmAddEditPerson addPersonForm = new frmAddEditPerson(-1);
            addPersonForm.ShowDialog();
            delUpdateBreadcrumb(sender, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Remove" });
            RefreshDataGridView();
        }
        private void _EditPerson()
        {
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Add" });
            frmAddEditPerson addPersonForm = new frmAddEditPerson((int)dgvPeople.SelectedCells[0].Value);
            addPersonForm.ShowDialog();
            delUpdateBreadcrumb(this, new frmMain.clsBreadcrumbData() { title = "> Add-Edit Person", operationType = "Remove" });
        }
        private void _DeletePerson(int PersonID)
        {
            if (MessageBox.Show($"Are you sure to delete person wIth ID{PersonID}?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
            {
                if (clsPeopleBusiness.DeletePerson(PersonID))
                {
                    MessageBox.Show($"Person with ID {PersonID} was successfully deleted.", "Success", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show($"Person with ID{PersonID} CAN NOT be deleted due to linked data to be deleted first.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void AllToolStripMenuHandler_Click(object sender, EventArgs e)
        {
            ToolStripItem toolStripItem = (ToolStripItem)sender;
            int PersonID = (int)dgvPeople.SelectedCells[0].Value;

            switch (toolStripItem.Text)
            {
                case "Show Details":
                    frmPersonInfo personInfo = new frmPersonInfo(PersonID);
                    personInfo.ShowDialog();
                    break;

                case "Add New Person":
                    btnAddPerson_Click(sender, EventArgs.Empty);
                    break;

                case "Edit":
                    _EditPerson();
                    break;

                case "Delete":
                    _DeletePerson(PersonID);
                    break;
                default:
                    MessageBox.Show("No option chosen from toolstrip");
                    break;
            }
            RefreshDataGridView();
        }



        private void dgvPeople_DoubleClick(object sender, EventArgs e)
        {
            frmPersonInfo personInfo = new frmPersonInfo(Convert.ToInt32(dgvPeople.SelectedCells[0].Value));
            personInfo.ShowDialog();
        }


        // search people by..
        // controlling textBox based on comboBox option
        private void cbSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSearchPerson.Enabled = true;
            switch (cbSearchBy.SelectedIndex)
            {
                case (byte)enSearchOptions.None:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.Enabled = false;
                    break;

                case (byte)enSearchOptions.PersonID:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.PlaceholderText = "Only numbers allowed";
                    _searchFilter = enSearchOptions.PersonID.ToString();
                    break;

                case (byte)enSearchOptions.NationalNo:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.PlaceholderText = "Text and numbers allowed";
                    _searchFilter = enSearchOptions.NationalNo.ToString();
                    break;

                case (byte)enSearchOptions.FirstName:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.PlaceholderText = "Search Person";
                    _searchFilter = enSearchOptions.FirstName.ToString();
                    break;

                case (byte)enSearchOptions.SecondName:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.PlaceholderText = "Search Person";
                    _searchFilter = enSearchOptions.SecondName.ToString();
                    break;

                case (byte)enSearchOptions.ThirdName:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.PlaceholderText = "Search Person";
                    _searchFilter = enSearchOptions.ThirdName.ToString();
                    break;

                case (byte)enSearchOptions.LastName:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.PlaceholderText = "Search Person";
                    _searchFilter = enSearchOptions.LastName.ToString();
                    break;

                case (byte)enSearchOptions.CountryName:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.PlaceholderText = "Only text allowed";
                    _searchFilter = enSearchOptions.CountryName.ToString();
                    break;

                case (byte)enSearchOptions.Gender:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.PlaceholderText = "Only text allowed";
                    _searchFilter = enSearchOptions.Gender.ToString();
                    break;

                case (byte)enSearchOptions.Phone:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.PlaceholderText = "Only numbers allowed";
                    _searchFilter = enSearchOptions.Phone.ToString();
                    break;

                case (byte)enSearchOptions.Email:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.PlaceholderText = "Search Email";
                    _searchFilter = enSearchOptions.Email.ToString();
                    break;
                
                default:
                    tbSearchPerson.Text = "";
                    tbSearchPerson.Enabled = false;
                    break;
            }
        }
        // adding constraints on searching based on comboBox option
        private void tbSearchPerson_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbSearchPerson.FocusedState.BorderColor = Color.DimGray;
            switch (cbSearchBy.SelectedIndex)
            {
                case (byte)enSearchOptions.PersonID:
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)// prevent non digit and backspace
                    {
                        tbSearchPerson.FocusedState.BorderColor = Color.Red;
                        e.Handled = true; // will make the event handled which will prevent any input in text box
                    }
                    break;

                case (byte)enSearchOptions.FirstName:
                    if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
                    {
                        tbSearchPerson.FocusedState.BorderColor = Color.Red;
                        e.Handled = true;
                    }
                    break;

                case (byte)enSearchOptions.SecondName:
                    if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
                    {
                        tbSearchPerson.FocusedState.BorderColor = Color.Red;
                        e.Handled = true;
                    }
                    break;

                case (byte)enSearchOptions.ThirdName:
                    if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
                    {
                        tbSearchPerson.FocusedState.BorderColor = Color.Red;
                        e.Handled = true;
                    }
                    break;

                case (byte)enSearchOptions.LastName:
                    if (!char.IsLetter(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != (char)Keys.Back)
                    {
                        tbSearchPerson.FocusedState.BorderColor = Color.Red;
                        e.Handled = true;
                    }
                    break;

                case (byte)enSearchOptions.CountryName:
                    if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        tbSearchPerson.FocusedState.BorderColor = Color.Red;
                        e.Handled = true;
                    }
                    break;

                case (byte)enSearchOptions.Gender:
                    if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        tbSearchPerson.FocusedState.BorderColor = Color.Red;
                        e.Handled = true;
                    }
                    break;

                case (byte)enSearchOptions.Phone:
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    {
                        tbSearchPerson.FocusedState.BorderColor = Color.Red;
                        e.Handled = true;
                    }
                    break;
                default:
                    //
                    break;
            }
        }
        private void _FindSearchResult()
        {
            if (string.IsNullOrEmpty(tbSearchPerson.Text))
            {
                RefreshDataGridView(); // when deleting text
                return;
            }

            DataView view = dt.DefaultView;
            string value = tbSearchPerson.Text;

            // filtering expression uses DataColumn Expression Language
            // it takes column names from dataTable that took them from Database, not names in dgv
            //since like is for strings only, we cast column type from int to string using this method from DT special language
                view.RowFilter = $"Convert({_searchFilter}, 'System.String') LIKE '{value}%'"; 

            dgvPeople.DataSource = view;
        }

        private void tbSearchPerson_TextChanged(object sender, EventArgs e)
        {
            _FindSearchResult();
        }
    }
}
