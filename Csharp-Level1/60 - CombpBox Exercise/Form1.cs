using _60___CombpBox_Exercise.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace _60___CombpBox_Exercise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (comboBox1.SelectedIndex)
            {
                case 0: pictureBox1.Image = Resources.Book; break;
                case 1: pictureBox1.Image = Resources.Boy; break;
                case 2: pictureBox1.Image = Resources.Girl; break;
                case 3: pictureBox1.Image = Resources.Pen; break;
            }
        }
    }
}
