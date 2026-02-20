using System;
using System.Windows.Forms;



//  here we declare the delegate and event:

namespace _5__send_Data_Back_from_form2_to_form1_Using_Delegate
{
    public partial class Form2 : Form
    {

        // define and declare the delegate with needed parameters (must match event method that will be used)
        public delegate void sendColorBack(object sender, int color);

        // declare an event with the delegate 
        public event sendColorBack dataBack;

        public Form2()
        {
            InitializeComponent();

        }



        // once we need to send the data to subscribed function int other forms, we invoke the event 
        private void btnRed_Click(object sender, EventArgs e)
        {
            int color = 1;
            dataBack?.Invoke(this, color);// now color variable is sent to the subscribed function

            this.Close();
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            int color = 2;
            dataBack?.Invoke(this, color); 

            this.Close();
        }

        private void btnYellow_Click(object sender, EventArgs e)
        {
            int color = 3;
            dataBack?.Invoke(this, color);

            this.Close();
        }
    }
}
