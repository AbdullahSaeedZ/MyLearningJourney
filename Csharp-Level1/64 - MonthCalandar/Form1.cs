using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _64___MonthCalandar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // we can use all methods of date and time to string 

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(monthCalendar1.SelectionRange.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(monthCalendar1.SelectionStart.ToShortDateString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(monthCalendar1.SelectionRange.End.ToString()); // or this way
        }
    }
}
