using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _82___Context_Menu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tsmClearTxtBox_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void tsmChangeFont_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = textBox1.Font;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }
        }

        private void tsmChangeColor_Click(object sender, EventArgs e)
        {
            

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }
        }
    }
}
