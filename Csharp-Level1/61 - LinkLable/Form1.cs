using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _61___LinkLable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true; // once the link lable is clicked, this will change its color to indicate it has been clicked before.
            System.Diagnostics.Process.Start("https://www.Abdullahsz.com"); // this will open a link. // this can open any thing even folders.
        }
    }
}
