using Billiards_Club_Management_System.Properties;
using Billiards_Club_Management_System.SessionsHistory;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Management.Instrumentation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billiards_Club_Management_System
{
    public partial class Form1 : Form
    {
        private int _totalTables = 8;
        private int _freeTables = 8;
        private int _busyTables = 0;
        private decimal _revenue = 0;
        private int _foodOrders = 0;
        public static int HourlyRate { private set; get; } = 35;

        private Dictionary<string, ctrlTable> _tables;
        private Guna2Button[] _buttons;
        private ctrlFoodOrders ctrlfoodOrders;
        private ctrlSessionsHistory ctrlSessionsHistory;

        

        public Form1()
        {
            InitializeComponent();
        }
        
        private void InitializeTables()
        {
            _tables = new Dictionary<string, ctrlTable> { { ctrlTable1.TableNumber, ctrlTable1 }, { ctrlTable2.TableNumber, ctrlTable2 }, 
                { ctrlTable3.TableNumber, ctrlTable3 }, { ctrlTable4.TableNumber, ctrlTable4 }, { ctrlTable5.TableNumber, ctrlTable5 },
                { ctrlTable6.TableNumber, ctrlTable6 }, { ctrlTable7.TableNumber, ctrlTable7 }, { ctrlTable8.TableNumber, ctrlTable8 } };

            foreach (ctrlTable table in _tables.Values)
            {
                table.OnSessionStarted += () => {

                    --_freeTables;
                    ++_busyTables;
                    lblFreeTables.Text = _freeTables.ToString();
                    lblBusyTables.Text = _busyTables.ToString();
                    lblFreeBusyTables.Text = $"{_busyTables} / {_totalTables} BUSY";
                    ctrlfoodOrders.AddActiveTableToComboBox(table.TableNumber);
                };
                table.OnSessionEnded += () => {

                    ++_freeTables;
                    --_busyTables;
                    lblFreeTables.Text = _freeTables.ToString();
                    lblBusyTables.Text = _busyTables.ToString();
                    lblFreeBusyTables.Text = $"{_busyTables} / {_totalTables} BUSY";
                    ctrlfoodOrders.RemoveActiveTableFromComboBox(table.TableNumber);
                };
                table.OnCompleteSession += IncreaseRevenue;
            }
        }

        private void InitializeFoodOrdersCtrl()
        {
            ctrlfoodOrders = new ctrlFoodOrders();
            pnlSectionsContainer.Controls.Add(ctrlfoodOrders);

            ctrlfoodOrders.OnFoodOrderConfirmed += (revenue, tableNumber) =>
            {
                IncreaseFoodOrders();
                IncreaseRevenue(revenue);

                if (tableNumber != null && tableNumber != "TAKE AWAY")
                {
                    _tables[$"{tableNumber}"].FoodOrders++;
                }
            };
        }
        private void InitializeSessionsHistoryCtrl()
        {
            ctrlSessionsHistory = new ctrlSessionsHistory();
            pnlSectionsContainer.Controls.Add(ctrlSessionsHistory);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            _buttons = new Guna2Button[] { btnTables, btnFoodOrders, btnSessionsHistory };

            InitializeTables();
            InitializeFoodOrdersCtrl();
            InitializeSessionsHistoryCtrl();

            btnTables.PerformClick();
            timer1_Tick(null, System.EventArgs.Empty);
            timer1.Start();
        }

        private void SetSelectedButton(Guna2Button button)
        {
            button.ForeColor = Color.FromArgb(250, 249, 246);
            button.FillColor = Color.FromArgb(117, 90, 37);
            button.Image = button.HoverState.Image;
        }
        private void ClearSelectionFromButtons()
        {
            foreach (var btn in _buttons)
            {
                btn.ForeColor = Color.DimGray;
                btn.FillColor = Color.Transparent;
                btn.Image = (string)btn.Tag == "Tables" ? Resources.tables1BlackNoFill512 :
                               (string)btn.Tag == "FoodOrders" ? Resources.foodBlackNoFIll512 :
                               Resources.history3NoFillBlack512;
            }
        }

        private void btnTables_Click(object sender, System.EventArgs e)
        {
            ClearSelectionFromButtons();
            SetSelectedButton((Guna2Button)sender);

            ctrlfoodOrders.SendToBack();
            ctrlSessionsHistory.SendToBack();
        }

        private void btnFoodOrders_Click(object sender, System.EventArgs e)
        {
            ClearSelectionFromButtons();
            SetSelectedButton((Guna2Button)sender);

           ctrlfoodOrders.BringToFront();
           ctrlSessionsHistory.SendToBack();
        }

        private void btnSessionsHistory_Click(object sender, System.EventArgs e)
        {
            ClearSelectionFromButtons();
            SetSelectedButton((Guna2Button)sender);

            ctrlSessionsHistory.BringToFront();
            ctrlfoodOrders.SendToBack();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            lblDateTime.Text = ctrlfoodOrders.DateTime = ctrlSessionsHistory.DateTime = Utility.GetCurrentDateTimeFormatted();
        }


        private void IncreaseFoodOrders()
        {
            ++_foodOrders;
            lblFoodOrders.Text = _foodOrders.ToString();
        }
        private void IncreaseRevenue(decimal amount)
        {
            _revenue+= amount;
            lblRevenue.Text = _revenue.ToString("F2");
        }
        private void UpdateHourlyRate(int newRate)
        {
            HourlyRate = newRate;
            lblHourlyRate.Text = $"{HourlyRate} / Hour";
        }

        private void tbEditRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter;

            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrWhiteSpace(tbEditRate.Text))
            {
                UpdateHourlyRate(Convert.ToInt32(tbEditRate.Text));
                tbEditRate.Text = "";
                tbEditRate.Visible = false;
                lblEditRateText.Visible = false;
            }
        }

        private void btnEditHourlyRate_Click(object sender, EventArgs e)
        {
            tbEditRate.Visible = !tbEditRate.Visible;
            lblEditRateText.Visible = !lblEditRateText.Visible;
            tbEditRate.Focus();
        }
    }
}