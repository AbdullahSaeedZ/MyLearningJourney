using Billiards_Club_Management_System.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Billiards_Club_Management_System.FoodOrders
{
    public partial class ctrlFoodItm : UserControl
    {
        public event Action<string, decimal> OnFoodItemAdded;

        private string _foodItemName = "";
        public string FoodItemName { get { return _foodItemName; }
            set { _foodItemName = value; lblFoodItemName.Text = _foodItemName; }
        }

        private decimal _foodItemPrice = 0m;
        public decimal FoodItemPrice { get { return _foodItemPrice; }
            set { _foodItemPrice = value; lblFoodItemPrice.Text = _foodItemPrice.ToString("F2"); }
        }

        private Image _foodItemPicture;

        
        public Image FoodItemPicture
        {
            get
            {
                return _foodItemPicture;
            }
            set
            {
                _foodItemPicture = value;

                if (pbFoodPicture != null)
                {
                    pbFoodPicture.Image = _foodItemPicture;
                }
            }
        }

        public ctrlFoodItm()
        {
            InitializeComponent();
        }

        private void btnAddFoodItem_Click(object sender, EventArgs e)
        {
            OnFoodItemAdded?.Invoke(_foodItemName, _foodItemPrice);
            
        }
    }
}
