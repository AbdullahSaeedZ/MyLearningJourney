using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _78___FileOpenDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        // one file selection only
        private void button1_Click(object sender, EventArgs e)
        {
            // optional settings


            // which folder or place to show when dialog opens
            openFileDialog1.InitialDirectory = @"C:\";

            // title name of the dialog (which is a form)
            openFileDialog1.Title = "this is the dialog title";

            // default extension of file to be saved, user just enters file name then .txt will be attached to it
            openFileDialog1.DefaultExt = "txt";

            // the types of files to be shown in the big bar
            //                        any name to show|real extension   |   any name to show|real extension
            openFileDialog1.Filter = "text files (*.txt)|*.txt|All files (*.*)|*.*|png (*.png)|*.png";
            openFileDialog1.FilterIndex = 2; //which extension to be default when dialog opens.(starts from 1)


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // will return the path of the needed file
                MessageBox.Show(openFileDialog1.FileName);
            }
        }


        // multiple files selection
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach(string file in openFileDialog1.FileNames)
                {
                    // need a loop to get paths of multiple files
                    // will return the path of the needed file
                    MessageBox.Show(file);
                }
            }
        }
    }
}
