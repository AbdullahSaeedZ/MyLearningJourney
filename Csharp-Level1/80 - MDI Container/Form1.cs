using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _80___MDI_Container
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private Form2 frm2 = new Form2();
        private void button1_Click(object sender, EventArgs e)
        {
            // An MDI container is the main, parent window in a Multiple Document Interface (MDI) application that holds and organizes multiple child forms
            // mdi is a parent form that has child forms, all child forms will be contained inside the mdi container and work under the mdi parent form
            // it has the same properties as a normal form

            if (frm2.IsDisposed) // when we close the child form and reopen it using the button, it will throw exception, so we handle it this way
            {
                frm2 = new Form2();
            }

            frm2.MdiParent = this;
            frm2.Show();
        }
    }
}
