using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _70___ErrorProvider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        // one error provider can be used on multiple text boxes
        private void tbFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbFirstName.Text))
            {
                // cancel means cancel the moving event or prevent from moving to other events till we set e.cancel to false
                e.Cancel = true;  // this will not allow the user get out of the textbox till he type needed text, and will keep focus on the text box

                //                      control used         error message on tooltip (when u hover on the error icon)
                errorProvider1.SetError(tbFirstName, "First Name must have a value!");
            }
            else
            {
                e.Cancel = false; // this will allow user to leave the text box
                errorProvider1.SetError(tbFirstName, ""); // means clear the error icon and tooltip for that control.
            }    
        }

        private void tbLastName_Validating(object sender, CancelEventArgs e)
        {
            // we can do any kind of validating 
            if (tbLastName.Text.Length < 8)
            {
                e.Cancel = true; 
                errorProvider1.SetError(tbLastName, "Last Name must be 8 or more chars");
            }
            else
            {
                e.Cancel = false; 
                errorProvider1.SetError(tbLastName, ""); 
            }
        }
    }
}
