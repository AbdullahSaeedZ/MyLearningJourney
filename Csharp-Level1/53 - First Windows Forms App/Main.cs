using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 The Form itself is a class that inherits from the .NET Form class.
   Example: public partial class Main : Form

 - When the program runs, an instance (object) of this class is created.
   Example: Application.Run(new Main());

 - "this" keyword refers to the current form object instance.

 - Each control (Button, Label, TextBox, etc.) is also an object
   created from its own class inside System.Windows.Forms.

 - Example:
     Button → class: System.Windows.Forms.Button
     Label  → class: System.Windows.Forms.Label
     TextBox → class: System.Windows.Forms.TextBox

 - So, the Form is an object that contains other control objects.


 form is a big control , and controls are objects, and here we are coding the controls of the form, so we are inside the form object that will be created when app is running.
 to access the Main form object itself that is an instance of Main class we inherited from super class Form, we use this keyword.

 in the program.cs file we find : Application.Run(new Main());  this when running the app, will create an object of the Main class we customized here.
 each new form we create is basically creating a new class inherited from super class Form
*/

// tag property: is a variable that is inside all controls (objects) its type is object, object data type used to store any kind of data , and then cast it to the needed type, by default its value is null
// for example we can store login info in the tag of login form and ask user to login , we validate the info by comparing with the info stored in the tag , but poor security for sure :)


namespace _53___First_Windows_Forms_App
{
    public partial class Main : Form // Form is the main forms class that is in the frame work, so here we inherit it.
    {
        public Main()
        {
            InitializeComponent();
            this.BackColor = Color.White;
        }

        // events are functions run or triggered when something happens like on-click and much more.


        private void button1_Click(object sender, EventArgs e) 
        {
            textBox2.Text = textBox1.Text; // all of properties are the same as the ones in design file menu;
            button1.Enabled = false;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = false;
            button1.Enabled = true;
            textBox2.Text = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = !textBox1.Enabled;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Visible = !textBox1.Visible;
            textBox2.Visible = !textBox2.Visible;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button1.Visible = !button1.Visible;
            button2.Visible = !button2.Visible;
            button3.Visible = !button3.Visible;
            button4.Visible = !button4.Visible;
        }

        private void button6_Click(object sender, EventArgs e)
        {
             textBox1.BackColor = textBox1.BackColor == Color.Red  ? Color.White : Color.Red;
             textBox2.BackColor = textBox2.BackColor == Color.Red  ? Color.White : Color.Red;
        }

        private void FormBackColor(object sender, EventArgs e)
        {
            this.BackColor = this.BackColor == Color.White ? Color.Violet : Color.White;
        }

        private void ChangeFormTitle(object sender, EventArgs e)
        {
            this.Text = textBox1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ChangeMainTitle(object sender, EventArgs e)
        {
            MainTitle.Text = textBox1.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }








        private void Form2Btn_Click(object sender, EventArgs e)
        {
            NewForm temp = new NewForm(); // the new form we added is basically a class created in the project, and we create an object here to use it  
            temp.Show();                  // once this event is fired, this method will send us there.
        }

        private void btnDialog_Click(object sender, EventArgs e)
        {

            NewForm temp = new NewForm(); 
            temp.ShowDialog(); // this will show the other form But will not allow user to access other forms unless he closes the current form
        }

        private void ShowMessageBox_Click(object sender, EventArgs e)
        {
            //message box is class that has static methods to be used like this :

            //                  //text inside the box                  title of box                   buttons
            MessageBox.Show("this is to show new box with message!", "this is the title of the box", MessageBoxButtons.OKCancel);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Warning!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                if (MessageBox.Show("Sure Sure Sure Sure?", "Warning!", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    this.Close();
        }

        private void btnMsgBoxWIthPic_Click(object sender, EventArgs e)
        { 
            MessageBox.Show("this is a message box with pic", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Hand,MessageBoxDefaultButton.Button2); // will give sound also
        }
    }
}
