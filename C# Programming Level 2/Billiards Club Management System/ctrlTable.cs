using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billiards_Club_Management_System
{
    public partial class ctrlTable : UserControl
    {
        private int _moneyAmount = 0;
        private int _tableNumber = 0;
        public int TableNumber {
            get 
            {
                return _tableNumber;
            }
            set 
            {
                _tableNumber = value;
                lblTableNumber.Text = _tableNumber.ToString();
            } 
        }
        public int MoneyAmount { get { return _moneyAmount; } private set { _moneyAmount = value; } }

        public ctrlTable()
        {
            InitializeComponent();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {

        }
    }
}
