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
    public partial class SimpleCalc : UserControl
    {
        public SimpleCalc()
        {
            InitializeComponent();
        }

        //public int MyProperty { get; set; }

        //using a get property we expose values of this control to the form.
        public int result { get { return (int.Parse(label2.Text)); } }


        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = (int.Parse(textBox1.Text) + int.Parse(textBox2.Text)).ToString();
        }
    }
}
