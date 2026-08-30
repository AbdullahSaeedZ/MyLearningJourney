using Billiards_Club_Management_System.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace Billiards_Club_Management_System
{
    public partial class ctrlTable : UserControl
    {
        public event Action OnSessionStarted;
        public event Action OnSessionEnded;
        public event Action<decimal> OnCompleteSession;

        private decimal _moneyAmount = 0;
        private int _foodOrders = 0;
        private string _tableNumber = "00";
        private bool _isActive;
        public string TableNumber {
            get 
            {
                return _tableNumber;
            }
            set 
            {
                _tableNumber = value;
                lblTableNumber.Text = _tableNumber;
            } 
        }
        public decimal MoneyAmount { get { return _moneyAmount; } private set { _moneyAmount = value; } }
        public bool IsActive { get { return _isActive; } private set { _isActive = value; } }
        public int FoodOrders { get { return _foodOrders; } set { _foodOrders = value; lblFoodOrders.Text = $"{_foodOrders} FOOD ORDER(S)"; } }


        private int _seconds = 0;
        private int _minutes = 0;

        public ctrlTable()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_minutes >= 60)
            {
                EndTableSession();
                return;
            }

            if (_seconds < 59)
                ++_seconds;
            else
            {
                _seconds = 0;
                ++_minutes;
                pbTimeProgress.Increment(1);

                _moneyAmount = ( _minutes / 60.0m ) * Form1.HourlyRate;
                lblMonyAmount.Text = _moneyAmount.ToString("F2");
            }

            string minutes = _minutes < 10 ? $"0{_minutes}:" : $"{_minutes}:";
            string seconds = _seconds < 10 ? $"0{_seconds}" : $"{_seconds}";
            lblTimer.Text = minutes + seconds;
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            switch (btnStartStop.Text)
            {
                case "START":

                    StartTableSession();
                    break;

                case "END":

                    EndTableSession();
                    break;

                default:
                    break;
            }
        }

        private void StartTableSession()
        {
            ActivateTable();
            OnSessionStarted?.Invoke();
            timer1.Start();
            
            _ = Log.LogEvent(Log.LogType.Session, $"Table {TableNumber} session started");
        }

        private void EndTableSession()
        {
            ShowSessionSummary();
            OnSessionEnded?.Invoke();
            timer1.Stop();
            
            _ = Log.LogEvent(Log.LogType.Session, $"Table {TableNumber} session ended");
        }

        private void ShowSessionSummary()
        {
            btnStartStop.Visible = false;
            pnlSessionSummary.Visible = true;
            lblSummaryTime.Text = lblTimer.Text;
            lblSummaryPayment.Text = lblMonyAmount.Text;
        }

        private void ActivateTable()
        {
            btnStartStop.Text = "END";
            btnStartStop.ForeColor = Color.FromArgb(250, 249, 246);
            btnStartStop.FillColor = Color.FromArgb(117, 90, 37);
            btnStartStop.Image = Resources.stopWhite512;
            btnStartStop.HoverState.Image = Resources.stopWhite512;

            lblStatus.Text = "BUSY";
            pbStatus.Image = Resources.busyDark512;
            pnlStatusColor.FillColor = Color.FromArgb(117, 90, 37);
        }

        private void ResetTable()
        {
            btnStartStop.Text = "START";
            btnStartStop.ForeColor = Color.DimGray;
            btnStartStop.FillColor = Color.Transparent;
            btnStartStop.Image = Resources.startDark512;
            btnStartStop.HoverState.Image = Resources.start1White512;
            lblStatus.Text = "FREE";
            pbStatus.Image = Resources.freeTablesDark512;
            FoodOrders = 0;
            lblMonyAmount.Text = "0.00";
            lblTimer.Text = "00:00";
            pbTimeProgress.Value = 0;
            pnlStatusColor.FillColor = Color.DarkSeaGreen;

            pnlSessionSummary.Visible = false;
            btnStartStop.Visible = true;
            _moneyAmount = 0m;
            _minutes = 0;
            _seconds = 0;
        }

        private void btnCompleteSession_Click(object sender, EventArgs e)
        {
            _ = Log.LogEvent(Log.LogType.TablesPayment, $"Table {TableNumber} session completed with payment of {_moneyAmount.ToString("F2")}");

            OnCompleteSession?.Invoke(_moneyAmount);
            pnlSessionSummary.Visible = false;
            ResetTable();
        }

        private void btnDiscardSession_Click(object sender, EventArgs e)
        {
            _ = Log.LogEvent(Log.LogType.Session, $"Table {TableNumber} session discarded");

            pnlSessionSummary.Visible = false;
            ResetTable();
        }
    }
}
