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
        private int _rateUpdates = 0;

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
                Log.LogEvent(Log.LogType.Error, $"Failed to get logs: {ex.Message}", ex.StackTrace);
                return;
            }

            if (_logs != null)
            {
                dgvLogs.RowCount = _logs.Length;
                dgvLogs.ClearSelection();
                dgvLogs.Rows[dgvLogs.Rows.Count - 1].Selected = true;
                dgvLogs.FirstDisplayedScrollingRowIndex = dgvLogs.Rows.Count - 1;
            }

            UpdateStatsUI();
        }

        private void CalculateStats()
        {
            _totalEvents = _logs.Length;
            _totalSessions = 0;
            _totalFoodOrdersPayments = 0;
            _totalTablesPayments = 0;
            _rateUpdates = 0;

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
                    else if (log.Contains("[General]"))
                        _rateUpdates++;
                }
            }
        }

        private void UpdateStatsUI()
        {
            lblTotalEvents.Text = _totalEvents.ToString();
            lblTotalSessions.Text = _totalSessions.ToString();
            lblTotalOrdersPayments.Text = _totalFoodOrdersPayments.ToString();
            lblTotalTablesPayments.Text = _totalTablesPayments.ToString();
            lblRateUpdates.Text = _rateUpdates.ToString();
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
