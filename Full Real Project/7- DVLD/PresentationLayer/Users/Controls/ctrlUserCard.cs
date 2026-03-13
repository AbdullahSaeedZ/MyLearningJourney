using BusinessLayer;
using PresentationLayer.MainForm;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Users.Controls
{
    public partial class ctrlUserCard : UserControl
    {
        public event EventHandler<frmMain.clsBreadcrumbData> delUpdateBreadcrumbFromUserCard;
        public int PersonCardBorderThickness
        {
            set
            {
                pnlPersonCard.BorderThickness = value;
            }
            get
            {
                return pnlPersonCard.BorderThickness;
            }
        }
        public int LoginInfoCardBorderThickness
        {
            set
            {
                pnlLoginInfo.BorderThickness = value;
            }
            get
            {
                return pnlLoginInfo.BorderThickness;
            }
        }
        public Color PersonCardBorderColor
        {
            set
            {
                pnlPersonCard.BorderColor = value;
            }
            get
            {
                return pnlPersonCard.BorderColor;
            }
        }
        public Color LoginInfoCardBorderColor
        {
            set
            {
                pnlLoginInfo.BorderColor = value;
            }
            get
            {
                return pnlLoginInfo.BorderColor;
            }
        }


        private clsUserBusiness _user;
        public clsUserBusiness SelectedUser { get { return _user; } }

        public ctrlUserCard()
        {
            InitializeComponent();
            ctrlPersonCard1.delUpdateBreadcrumbFromPersonCard += (se, ev) => delUpdateBreadcrumbFromUserCard(se, ev); // to update breadcrumb when edit person info is pressed
        }

        public void LoadInfo(int UserID)
        {
            if((_user = clsUserBusiness.FindUser(UserID)) == null)
            {
                MessageBox.Show($"User ID = {UserID} was not found, check again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ctrlPersonCard1.LoadInfo(_user.PersonID);
            _FillLoginInfo();
        }

        private void _FillLoginInfo()
        {
            lblUserID.Text = _user.UserID.ToString();
            lblUsername.Text = _user.Username;
            lblIsActive.Text = _user.isActive == false ? "No" : "Yes";
        }
    }
}
