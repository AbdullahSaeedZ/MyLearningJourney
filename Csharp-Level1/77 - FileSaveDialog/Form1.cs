using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _77___FileSaveDialog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // optional settings


            // which folder or place to show when dialog opens
            saveFileDialog1.InitialDirectory = @"C:\";

            // title name of the dialog (which is a form)
            saveFileDialog1.Title = "this is the dialog title";

            // default extension of file to be saved, user just enters file name then .txt will be attached to it
            saveFileDialog1.DefaultExt = "txt";

            // the types of files to be shown in the big bar
            //                        any name to show|real extension   |   any name to show|real extension
            saveFileDialog1.Filter = "text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2; //which extension to be default when dialog opens.(starts from 1)

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(saveFileDialog1.FileName); // this dialog purpose is to only return the file path then we deal with it. 
            }
        }
    }
}
