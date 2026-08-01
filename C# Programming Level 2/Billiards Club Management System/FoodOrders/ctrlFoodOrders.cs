using System;
using System.Windows.Forms;

namespace Billiards_Club_Management_System
{
    public partial class ctrlFoodOrders : UserControl
    {
        public string DateTime { set { lblDateTime.Text = value; } }
        public ctrlFoodOrders()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
