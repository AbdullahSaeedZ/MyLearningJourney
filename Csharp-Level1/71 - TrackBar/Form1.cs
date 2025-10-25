using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _71___TrackBar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int r = 0, b = 0, g = 0;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            r = trackBar1.Value;
            panel1.BackColor = Color.FromArgb(255, r, b, g);
            lblR.Text = $"r: {trackBar1.Value.ToString()}";
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            this.Opacity = trackBar4.Value / 100.00;   // opacity is from 1.0 to 2.0
            lblForm.Text = $"Form opacity: {trackBar4.Value}";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            b = trackBar1.Value;
            panel1.BackColor = Color.FromArgb(255, r, b, g);
            lblB.Text = $"b: {trackBar2.Value}";
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            g = trackBar3.Value;
            panel1.BackColor = Color.FromArgb(255, r, b, g);
            lblG.Text = $"g: {trackBar3.Value}";
        }
    }
}
