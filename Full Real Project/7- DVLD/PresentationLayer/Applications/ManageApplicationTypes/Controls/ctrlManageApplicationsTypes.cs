using BusinessLayer;
using PresentationLayer.Applications.ManageApplicationTypes.Forms;
using System;
using System.Data;
using System.Windows.Forms;

namespace PresentationLayer.Applications.ManageApplicationTypes.Controls
{
    public partial class ctrlManageApplicationsTypes : UserControl
    {
        public event Action<UserControl> delRemoveFromMainFormContainer_AppTypes;
        private DataTable dt;

        public ctrlManageApplicationsTypes()
        {
            InitializeComponent();
        }

        private void ctrlManageApplicationsTypes_Load(object sender, EventArgs e)
        {
            _RefreshDgv();
        }

        private void _RefreshDgv()
        {
            dt = clsApplicationTypesBusiness.GetAllApplicationTypes();
            dgvApplicationTypes.DataSource = dt;
            lblNumberOfRecords.Text = dgvApplicationTypes.RowCount.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            delRemoveFromMainFormContainer_AppTypes?.Invoke(this);
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType editApplicationType = new frmEditApplicationType((int)dgvApplicationTypes.SelectedCells[0].Value);
            editApplicationType.delRefreshDgv += _RefreshDgv;
            editApplicationType.ShowDialog();
        }

    }
}
