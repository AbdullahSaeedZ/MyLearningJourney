using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;

        }


        // Price Updating
        int GetToppingsTotalPrice()
        {
            int Total = 0;

            if (chbExtraChees.Checked)
                Total += Convert.ToInt32(chbExtraChees.Tag);

            if (chbMushroom.Checked)
                Total += Convert.ToInt32(chbMushroom.Tag);

            if (chbOlives.Checked)
                Total += Convert.ToInt32(chbOlives.Tag);

            if (chbOnions.Checked)
                Total += Convert.ToInt32(chbOnions.Tag);

            if (chbGreenPeppers.Checked)
                Total += Convert.ToInt32(chbGreenPeppers.Tag);

            if (chbTomatoes.Checked)
                Total += Convert.ToInt32(chbTomatoes.Tag);

            return Total;

        }

        int GetCrustTotalPrice()
        {
            if (rbThin.Checked)
                return Convert.ToInt32(rbThin.Tag);
            else if (rbThick.Checked)
                return Convert.ToInt32(rbThick.Tag);
            else
                return 0;
        }

        int GetSizeTotalPrice()
        {
            if (rbSmall.Checked)
                return Convert.ToInt32(rbSmall.Tag);
            else if (rbMid.Checked)
                return Convert.ToInt32(rbMid.Tag);
            else if (rbLarge.Checked)
                return Convert.ToInt32(rbLarge.Tag);
            else
                return 0;

        }

        int CalculateTotalPrices()
        {
            return GetSizeTotalPrice() + GetCrustTotalPrice() + GetToppingsTotalPrice();
        }

        void UpdateTotalPrice()
        {
            lblPrice.Text = "$" + CalculateTotalPrices().ToString();
        }




        // Summary Txt Updating 
        void UpdateSize()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return;
            }

            if (rbMid.Checked)
            {
                lblSize.Text = "Medium";
                return;
            }

            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return;
            }
        }

        void UpdateToppings()
        {
            UpdateTotalPrice();

            string ToppingsStr = "";

            if (chbExtraChees.Checked)
                ToppingsStr += ", Extra Chees";

            if (chbMushroom.Checked)
                ToppingsStr += ", Mushroom";

            if (chbOlives.Checked)
                ToppingsStr += ", Olives";

            if (chbOnions.Checked)
                ToppingsStr += ", Onions";

            if (chbGreenPeppers.Checked)
                ToppingsStr += ", GreenPeppers";

            if (chbTomatoes.Checked)
                ToppingsStr += ", Tomatoes";


            if (ToppingsStr.StartsWith(","))
                ToppingsStr = ToppingsStr.TrimStart(',');

            if (ToppingsStr == "")
                lblToppings.Text = "None";
            else
                lblToppings.Text = ToppingsStr;
        }

        void UpdateCrust()
        {
            UpdateTotalPrice();

            if (rbThin.Checked)
            {
                lblCrustType.Text = "Thin Crust";
                return;
            }
            else if (rbThick.Checked)
            {
                lblCrustType.Text = "Thick Crust";
                return;
            }
            else
            {
                lblCrustType.Text = "None";
            }
        }

        void UpdateWhereToEat()
        {
            UpdateTotalPrice();

            if (rbTakeOut.Checked)
            {
                lblWhereToEat.Text = "Take Out";
                return;
            }
            else if (rbEatin.Checked)
            {
                lblWhereToEat.Text = "Eat In";
                return;
            }
            else
            {
                lblWhereToEat.Text = "None";
            }
        }



        // ==== events ====

        // Toppings
        private void chbExtraChees_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chbMushroom_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chbTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chbOnions_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chbOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chbGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }


        // Crust Type
        private void rbThin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThick_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }



        // Size
        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMid_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }
            

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }


        // Where To Eat
        private void rbEatin_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateWhereToEat();
        }



        // Reset Order
        private void btnResetOrder_Click(object sender, EventArgs e)
        {
            btnConfirmOrder.Enabled = true;

            // re enable all groups
            gbSize.Enabled = true;
            gbCrust.Enabled = true;
            gbToppings.Enabled = true;
            gbWhereToEat.Enabled = true;
            gbSummary.Enabled = true;

            // resetting toppings
            chbExtraChees.Checked = false;
            chbGreenPeppers.Checked = false;
            chbMushroom.Checked = false;
            chbOlives.Checked = false;
            chbOnions.Checked = false;
            chbTomatoes.Checked = false;

            // resetting Size
            rbSmall.Checked = false;
            rbMid.Checked = false;
            rbLarge.Checked = false;

            // resetting where to eat
            rbTakeOut.Checked = false;
            rbEatin.Checked = false;

            // resetting Crust
            rbThick.Checked = false;
            rbThin.Checked = false;
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {

            if (lblPrice.Text != "$0")
            {
                if ((MessageBox.Show("Please Confirm Your Order!", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)) == DialogResult.OK)
                {
                    MessageBox.Show("Take a seat while we do our magic !!", "Order Confirmed!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gbSize.Enabled = false;
                    gbCrust.Enabled = false;
                    gbToppings.Enabled = false;
                    gbWhereToEat.Enabled = false;
                    gbSummary.Enabled = false;

                    btnConfirmOrder.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Your Order is Not Complete!!", "Order Not Complete!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            LandingForm Landing = new LandingForm();
            Landing.Close();

            this.Close();
        }
    }
}
