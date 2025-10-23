using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _63___DateTimePicker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToLongDateString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToShortDateString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dateTimePicker1.Value.ToLocalTime().ToString());
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = dateTimePicker1.Text + Environment.NewLine; //this is same as \n but for the apps
            label2.Text += dateTimePicker1.Value.ToString("d") + Environment.NewLine;
            label2.Text += dateTimePicker1.Value.ToString("g") + Environment.NewLine;
            label2.Text += dateTimePicker1.Value.ToString("s") + Environment.NewLine;
            label2.Text += dateTimePicker1.Value.ToString("dd/MM/yy") + Environment.NewLine;
            label2.Text += dateTimePicker1.Value.ToString("dddd,dd-MMM-yyyy") + Environment.NewLine;

            // we can use letters to indicate certain formats, or type the format
            // mm gives month number , mmm gives month name
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label3.Text = Environment.CommandLine + Environment.NewLine;
            label3.Text += Environment.TickCount + Environment.NewLine;
            label3.Text += Environment.MachineName + Environment.NewLine;
            label3.Text += Environment.OSVersion + Environment.NewLine;
            label3.Text += Environment.Is64BitOperatingSystem + Environment.NewLine;
            label3.Text += Environment.CurrentDirectory + Environment.NewLine;
            label3.Text += Environment.ProcessorCount + Environment.NewLine;
        }
    }
}
