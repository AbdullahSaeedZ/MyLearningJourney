using BusinessLayer;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer.Users.Controls
{
    public partial class ctrlAddEditUserPermissions : UserControl
    {
        public int PermissionsCardBorderThickness
        {
            set
            {
                pnlPermissions.BorderThickness = value;
            }
            get
            {
                return pnlPermissions.BorderThickness;
            }
        }
        public Color PermissionsCardBorderColor
        {
            set
            {
                pnlPermissions.BorderColor = value;
            }
            get
            {
                return pnlPermissions.BorderColor;
            }
        }

        clsBusinessSettings.enPermissions _permissions = 0;

        public ctrlAddEditUserPermissions()
        {
            InitializeComponent();
        }

        public void LoadPermissionsForUpdate(int Permissions)
        {
            if (Permissions == 0)
            {
                chbNone.Checked = true;
                return;
            }

            _permissions = (clsBusinessSettings.enPermissions)Permissions;

            if (_permissions.HasFlag(clsBusinessSettings.enPermissions.eAll))
            {
                chbAllPermissions.Checked = true;
                return;
            }

            // users
            if (_permissions.HasFlag(clsBusinessSettings.enPermissions.eListUsers))
                chbListUsers.Checked = true;

            if (_permissions.HasFlag(clsBusinessSettings.enPermissions.eAddUser))
                chbAddNewUsers.Checked = true;

            if (_permissions.HasFlag(clsBusinessSettings.enPermissions.eUpdateUser))
                chbUpdateUsers.Checked = true;

            if (_permissions.HasFlag(clsBusinessSettings.enPermissions.eDeleteUser))
                chbDeleteUsers.Checked = true;

            // people
            if (_permissions.HasFlag(clsBusinessSettings.enPermissions.eListPeople))
                chbListPeople.Checked = true;

            if (_permissions.HasFlag(clsBusinessSettings.enPermissions.eAddPerson))
                chbAddNewPeople.Checked = true;

            if (_permissions.HasFlag(clsBusinessSettings.enPermissions.eUpdatePerson))
                chbUpdatePeople.Checked = true;

            if (_permissions.HasFlag(clsBusinessSettings.enPermissions.eDeletePerson))
                chbDeletePeople.Checked = true;
        }

        public void LoadPermissionsForDisplay(int Permissions)
        {
            LoadPermissionsForUpdate(Permissions);
            pnlAllCheckBoxes.Enabled = false;
            chbAllPermissions.Enabled = false;
            chbNone.Enabled = false;
        }

        public int GetSelectedPermissions()
        {
            if (chbNone.Checked)
                return 0;

            if (chbAllPermissions.Checked)
                return -1;

            int Permissions = 0;

            // users
            if (chbListUsers.Checked)
                Permissions += (int)clsBusinessSettings.enPermissions.eListUsers;

            if (chbAddNewUsers.Checked)
                Permissions += (int)clsBusinessSettings.enPermissions.eAddUser;

            if (chbUpdateUsers.Checked)
                Permissions += (int)clsBusinessSettings.enPermissions.eUpdateUser;

            if (chbDeleteUsers.Checked)
                Permissions += (int)clsBusinessSettings.enPermissions.eDeleteUser;

            // people
            if (chbListPeople.Checked)
                Permissions += (int)clsBusinessSettings.enPermissions.eListPeople;

            if (chbAddNewPeople.Checked)
                Permissions += (int)clsBusinessSettings.enPermissions.eAddPerson;

            if (chbUpdatePeople.Checked)
                Permissions += (int)clsBusinessSettings.enPermissions.eUpdatePerson;

            if (chbDeletePeople.Checked)
                Permissions += (int)clsBusinessSettings.enPermissions.eDeletePerson;

            return Permissions;
        }

        // to disable all boxes when all permissions selectted
        private void chbAllPermissions_CheckedChanged(object sender, EventArgs e)
        {
            if (chbAllPermissions.Checked)
            {
                chbNone.Checked = false;
                chbNone.Enabled = false;

                pnlAllCheckBoxes.Enabled = false;
                chbListUsers.Checked = false;
                chbAddNewUsers.Checked = false;
                chbUpdateUsers.Checked = false;
                chbDeleteUsers.Checked = false;
                chbListPeople.Checked = false;
                chbAddNewPeople.Checked = false;
                chbUpdatePeople.Checked = false;
                chbDeletePeople.Checked = false;
            }
            else
            {
                pnlAllCheckBoxes.Enabled = true;
                chbNone.Enabled = true;
            }

        }

        private void chbNone_CheckedChanged(object sender, EventArgs e)
        {
            if (chbNone.Checked)
            {
                chbAllPermissions.Checked = false;
                chbAllPermissions.Enabled = false;

                pnlAllCheckBoxes.Enabled = false;
                chbListUsers.Checked = false;
                chbAddNewUsers.Checked = false;
                chbUpdateUsers.Checked = false;
                chbDeleteUsers.Checked = false;
                chbListPeople.Checked = false;
                chbAddNewPeople.Checked = false;
                chbUpdatePeople.Checked = false;
                chbDeletePeople.Checked = false;
            }
            else
            {
                pnlAllCheckBoxes.Enabled = true;
                chbAllPermissions.Enabled = true;
            }
        }
    }
}
