using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3__User_Controls_Expose_Property
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // taking values from controls through getters then use them in the form
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = simpleCalc1.result.ToString();
            label2.Text = simpleCalc2.result.ToString();
        }
    }
}
