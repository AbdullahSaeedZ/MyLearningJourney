using System;
using System.Windows.Forms;

namespace Billiards_Club_Management_System.FoodOrders
{
    public partial class ctrlFoodItm : UserControl
    {
        private string _foodItemName = "";
        public string FoodItemName { get { return _foodItemName; }
            set { _foodItemName = value; lblFoodItemName.Text = _foodItemName; }
        }

        private decimal _foodItemPrice = 0m;
        public decimal FoodItemPrice { get { return _foodItemPrice; }
            set { _foodItemPrice = value; lblFoodItemPrice.Text = _foodItemPrice.ToString("F2"); }
        }

        public ctrlFoodItm()
        {
            InitializeComponent();
        }
    }
}
