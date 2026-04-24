using System;
using System.Drawing;
using System.Windows.Forms;

namespace PresentationLayer.Dashboard
{
    public partial class ctrlTodayAppointments : UserControl
    {
        int _ID = -1;
        DateTime _Date = DateTime.MinValue;
        bool _IsLocked = false;

        public int BorderThickness
        {
            set
            {
                pnlOuterBorder.BorderThickness = value;
            }
            get
            {
                return pnlOuterBorder.BorderThickness;
            }
        }
        public Color BorderColor
        {
            set
            {
                pnlOuterBorder.BorderColor = value;
            }
            get
            {
                return pnlOuterBorder.BorderColor;
            }
        }

        public ctrlTodayAppointments()
        {
            InitializeComponent();
        }

        public void LoadInfo(int ID, DateTime Date, bool IsLocked)
        {
            _ID = ID;
            _Date = Date;
            _IsLocked = IsLocked;

            lblID.Text = "ID " + _ID.ToString();
            lblDate.Text = _Date.ToShortDateString();
            if (_IsLocked)
            {
                lblStatus.Text = "Completed";
                lblStatus.ForeColor = Color.LimeGreen;
            }
            else
            {
                lblStatus.Text = "Upcoming";
                lblStatus.ForeColor = Color.Orange;
            }

        }
    }
}
