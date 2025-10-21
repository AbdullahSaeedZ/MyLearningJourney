using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _59___ComboBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Add("Faris");
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e) // when changing selected items
        {
            MessageBox.Show(comboBox4.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //comboBox5.Text = "text shows when form loads";
            comboBox5.SelectedIndex = 0; // first option will be selected when form loads
        }
    }
}
