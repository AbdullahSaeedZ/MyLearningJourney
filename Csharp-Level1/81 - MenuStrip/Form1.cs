using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _81___MenuStrip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void findClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this is a click event triggered by this option in menu, we can show forms from here or any code");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("you pressed Exit, or you used the shortcut. edit it from shortcutKeys property");
        }
    }
}
