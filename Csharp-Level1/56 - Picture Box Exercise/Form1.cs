using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _56___Picture_Box_Exercise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        void UpdatePicture(object sender)
        {
            RadioButton rb = ((RadioButton)sender);

            if (rb == null || !rb.Checked) // when the radio button gets unchecked, it will start an event, so this will avoid the function from running when unchecked event triggers
                return;

            pictureBox1.Image = Image.FromFile($@"C:\Users\asz14\Downloads\{rb.Tag.ToString()}.png");
            label1.Text = rb.Tag.ToString();
        }

        private void rbBoy_CheckedChanged(object sender, EventArgs e) // sender is the controller that triggered the event, as object data type (general type), we cast to needed type like above
        {
            
            UpdatePicture(sender);
        }

        private void rbGirl_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePicture(sender);
        }

        private void rbBook_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePicture(sender);
        }

        private void rbPen_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePicture(sender);
        }
    }
}
