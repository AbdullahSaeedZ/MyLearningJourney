using Billiards_Club_Management_System.FoodOrders;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Billiards_Club_Management_System
{
    public partial class ctrlFoodOrders : UserControl
    {
        public event Action<decimal> OnFoodOrderConfirmed;
        public string DateTime { set { lblDateTime.Text = value; } }

        private decimal _totalPrice = 0m;
        public decimal TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
                lblTotalPrice.Text = _totalPrice.ToString("F2");
            }
        }


        private ctrlFoodItm[] _foodItems;
        private List<ctrlOrderItem> _orderItems;

        public ctrlFoodOrders()
        {
            InitializeComponent();
        }

        private void ctrlFoodOrders_Load(object sender, EventArgs e)
        {
            _foodItems = new ctrlFoodItm[] { ctrlFoodItm1, ctrlFoodItm2, ctrlFoodItm3, ctrlFoodItm4, ctrlFoodItm5, ctrlFoodItm6};
            _orderItems = new List<ctrlOrderItem>();

            foreach (ctrlFoodItm item in _foodItems)
            {
                item.OnFoodItemAdded += OnOrderItemAdded;
            }
        }

        private void OnOrderItemAdded(string name, decimal price)
        {
            TotalPrice += price;

            if (_orderItems != null)
            {
                foreach (ctrlOrderItem item1 in _orderItems)
                {
                    if (name == item1.FoodItemName)
                    {
                        item1.FoodItemCounter++;
                        return;
                    }
                }
            }
            ctrlOrderItem orderItem = new ctrlOrderItem(name, 1, price);
            orderItem.OnOrderItemRemoved += OnOrderItemRemoved;

            _orderItems.Add(orderItem);
            flpOrdersItemsContainer.Controls.Add(orderItem);
        }

        private void OnOrderItemRemoved(string name, int counter, decimal price)
        {
            TotalPrice -= price;

            foreach (ctrlOrderItem item1 in _orderItems)
            {
                if (name == item1.FoodItemName)
                {
                    if (counter > 1)
                    {
                        item1.FoodItemCounter--;
                        return;
                    }
                    _orderItems.Remove(item1);
                    flpOrdersItemsContainer.Controls.Remove(item1);
                    return;
                }
            }
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            OnFoodOrderConfirmed?.Invoke(_totalPrice);
            ResetOrder();
            ShowConfirmationNotification();
        }

        private void ResetOrder()
        {
            TotalPrice = 0m;
            flpOrdersItemsContainer.Controls.Clear();
            _orderItems.Clear();
        }
        private void ShowConfirmationNotification()
        {
            pnlConfirmedNotification.Visible = true;
            NotificationTimer.Start();
        }
        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            pnlConfirmedNotification.Visible = false;
            NotificationTimer.Stop();
        }
        private void lblTotalPrice_TextChanged(object sender, EventArgs e)
        {
            if (_totalPrice > 0)
                btnConfirmOrder.Enabled = true;
            else
                btnConfirmOrder.Enabled = false;
        }
    }
}
