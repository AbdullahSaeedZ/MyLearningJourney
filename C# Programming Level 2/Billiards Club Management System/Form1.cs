using Billiards_Club_Management_System.Properties;
using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace Billiards_Club_Management_System
{
    public partial class Form1 : Form
    {
        // temp for flow panel to render smoothly
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }


        private int _totalTables = 8;
        private int _freeTables = 8;
        private int _busyTables = 0;
        private int _revenue = 0;
        private int _foodOrders = 0;
        private int _hourlyRate = 35;

        private Guna2Button[] _buttons;


        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            _buttons = new Guna2Button[] { btnTables, btnFoodOrders, btnSessionsHistory };
            btnTables.PerformClick();
            lblDateTime.Text = Utility.GetCurrentDateTimeFormatted();
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
        }

        private void btnFoodOrders_Click(object sender, System.EventArgs e)
        {
            ClearSelectionFromButtons();
            SetSelectedButton((Guna2Button)sender);
        }

        private void btnSessionsHistory_Click(object sender, System.EventArgs e)
        {
            ClearSelectionFromButtons();
            SetSelectedButton((Guna2Button)sender);
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            lblDateTime.Text = Utility.GetCurrentDateTimeFormatted();
        }



        private void IncreaseFreeTables(int number)
        {
            ++_freeTables;
            lblFreeTables.Text = _freeTables.ToString();
        }
        private void DencreaseFreeTables(int number)
        {
            --_freeTables;
            lblFreeTables.Text = _freeTables.ToString();
        }

        private void IncreaseBusyTables(int number)
        {
            ++_busyTables;
            lblFreeTables.Text = _busyTables.ToString();
        }

        private void DencreaseBusyTables(int number)
        {
            --_busyTables;
            lblBusyTables.Text = _busyTables.ToString();
        }

        private void IncreaseFoodOrders()
        {
            ++_foodOrders;
            lblFoodOrders.Text = _foodOrders.ToString();
        }
        private void IncreaseRevenue(int number)
        {
            _revenue+= number;
            lblRevenue.Text = _revenue.ToString();
        }
        private void UpdateHourlyRate(int number)
        {
            _hourlyRate = number;
            lblHourlyRate.Text = $"{_hourlyRate} / Hour";
        }

    }
}