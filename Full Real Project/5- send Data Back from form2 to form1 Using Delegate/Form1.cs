using System;
using System.Windows.Forms;


// to bring data from form2 to form1, i can send the reference of form1 to form2 constructor then access form1 controls from inside form2,
// but what if i need multiple forms to open form2 ? i will have to do if-else statements to determine which form reference is coming.
 
// so better use Delegate..


namespace _5__send_Data_Back_from_form2_to_form1_Using_Delegate
{
    public partial class Form1 : Form
    {

  


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();


            // we access the EVENT we declared using the delegate, then we add reference of the needed function, it is called subscribing to the event:
            frm2.dataBack += DataHandler;

            frm2.ShowDialog();
        }

        // this method is used to handle data coming from form2 using delegate and event
        // parameters must match the ones declared in the delegate:
        private void DataHandler(object sender, int color)
        {
            lblColor.Text = color == 1 ? "Red" : color == 2 ? "Blue" : "Yellow";
        }
    }
}
