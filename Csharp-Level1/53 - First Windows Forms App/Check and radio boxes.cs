using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _53___First_Windows_Forms_App
{
    public partial class NewForm : Form
    {
        public NewForm()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            Main Form1 = new Main();
            Form1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(checkBox1.Checked.ToString()); // checked will return boolean
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = checkBox1.Checked; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Convert.ToString(radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)); // to show message of true if any is checked
        }

        private void btnShowgb_Click(object sender, EventArgs e)
        {
            gb1.Visible = !gb1.Visible;
        }
    }
}
