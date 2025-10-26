using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _79___FolderBrowserDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // property of creating new folders while browsing
            folderBrowserDialog1.ShowNewFolderButton = true;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {

                MessageBox.Show(folderBrowserDialog1.SelectedPath);
            }
        }
    }
}
