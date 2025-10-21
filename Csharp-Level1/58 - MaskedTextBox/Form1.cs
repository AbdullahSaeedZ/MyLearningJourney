using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _58___MaskedTextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           // maskedTextBox1.MaskFull // this return boolean to indicate if user entered full required info or not
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
           

        }


        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (!maskedTextBox2.MaskFull)
        //    {
        //        MessageBox.Show("Not filled");
        //    }
        //    else
        //    {
        //        MessageBox.Show("all info filled");
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (!maskedTextBox2.MaskFull)
            {
                maskedTextBox2.BackColor = Color.Red;
            }
            else
            {
                maskedTextBox2.BackColor = Color.Green;
            }
        }

    }


}
