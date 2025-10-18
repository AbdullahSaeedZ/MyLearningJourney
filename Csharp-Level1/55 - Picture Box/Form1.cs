using _55___Picture_Box.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _55___Picture_Box
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.weak;  // Resources is where we saved the pics, we can navigate the pic names here.
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Resources.strong;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"c:\logo.png"); // this loads from any drive, use the @ to ignore any escape sequens in the path.
        }
    }
}
