using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billiards_Club_Management_System.FoodOrders
{
    public partial class ctrlOrderItem : UserControl
    {
        public event Action<string, int, decimal> OnOrderItemRemoved;
        private string _foodItemName;
        private int _FoodItemCounter;
        private decimal _FoodItemPrice;

        public string FoodItemName { 
            get { return _foodItemName; }
            set { _foodItemName = value; lblFoodItemName.Text = value; }
        }
        public int FoodItemCounter { 
            get { return _FoodItemCounter; }
            set { _FoodItemCounter = value; lblFoodItemCounter.Text = value.ToString() + "x"; }
        }
        public decimal FoodItemPrice {
            get { return _FoodItemPrice; }
            set { _FoodItemPrice = value; }
        }

        public ctrlOrderItem(string foodItemName, int foodItemCounter, decimal foodItemPrice)
        {
            InitializeComponent();
            FoodItemName = foodItemName;
            FoodItemCounter = foodItemCounter;
            FoodItemPrice = foodItemPrice;
        }

        private void btnRemoveOrderItem_Click(object sender, EventArgs e)
        {
            OnOrderItemRemoved?.Invoke(FoodItemName, FoodItemCounter, FoodItemPrice);
        }
    }
}
