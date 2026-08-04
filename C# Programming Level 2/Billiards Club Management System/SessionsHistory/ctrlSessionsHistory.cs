using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billiards_Club_Management_System.SessionsHistory
{
    public partial class ctrlSessionsHistory : UserControl
    {
        private int _totalEvents = 0;
        private int _totalSessions = 0;
        private int _totalFoodOrdersPayments = 0;
        private int _totalTablesPayments = 0;

        private string[] _logs;

        public string DateTime { set { lblDateTime.Text = value; } }

        public ctrlSessionsHistory()
        {
            InitializeComponent();
            dgvLogs.VirtualMode = true;
        }

        public async Task Initialize()
        {
            try
            {
                await Task.Run(() => { 
                    _logs = Log.GetLogs();
                    CalculateStats();
                });

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to get logs: {ex.Message}", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dgvLogs.RowCount = _logs.Length;
            UpdateStatsUI();
        }

        private void CalculateStats()
        {
            _totalEvents = _logs.Length;
            _totalSessions = 0;
            _totalFoodOrdersPayments = 0;
            _totalTablesPayments = 0;

            if (_logs != null)
            {
                foreach (var log in _logs)
                {
                    if (log.Contains("[Session]"))
                        _totalSessions++;
                    else if (log.Contains("[Food Payment]"))
                        _totalFoodOrdersPayments++;
                    else if (log.Contains("[Tables Payment]"))
                        _totalTablesPayments++;
                }
            }
        }

        private void UpdateStatsUI()
        {
            lblTotalEvents.Text = _totalEvents.ToString();
            lblTotalSessions.Text = _totalSessions.ToString();
            lblTotalOrdersPayments.Text = _totalFoodOrdersPayments.ToString();
            lblTotalTablesPayments.Text = _totalTablesPayments.ToString();
        }

        private void dgvLogs_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex < _logs.Length)
            {
                e.Value = _logs[e.RowIndex];
            }
        }
    }
}
