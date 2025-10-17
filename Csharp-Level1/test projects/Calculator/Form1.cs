using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        protected string str;

        

        public Form1()
        {
            InitializeComponent();
            str = "";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            str += "0";
            OperationTxt.Text = str;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            str += "1";
            OperationTxt.Text = str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            str += "2";
            OperationTxt.Text = str;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            str += "3";
            OperationTxt.Text = str;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            str += "4";
            OperationTxt.Text = str;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            str += "5";
            OperationTxt.Text = str;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            str += "6";
            OperationTxt.Text = str;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            str += "7";
            OperationTxt.Text = str;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            str += "8";
            OperationTxt.Text = str;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            str += "9";
            OperationTxt.Text = str;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            str = "";
            OperationTxt.Text = "0";
            Result.Text = "0";
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            str += "+";
            OperationTxt.Text = str;
        }

        private void button_Minus_Click(object sender, EventArgs e)
        {
            str += "-";
            OperationTxt.Text = str;
        }

        private void button_Multiply_Click(object sender, EventArgs e)
        {
            str += "*";
            OperationTxt.Text = str;
        }

        private void button_Divide_Click(object sender, EventArgs e)
        {
            str += "/";
            OperationTxt.Text = str;
        }

        private void button_Mod_Click(object sender, EventArgs e)
        {
            str += "%";
            OperationTxt.Text = str;
        }

        private void Result_btn_Click(object sender, EventArgs e)
        {

            try // i use it because if user tried to compute (34 - no number here) it will crash.
            {
                var OpResult = new DataTable().Compute(str, "");
                Result.Text = OpResult.ToString();
                OperationTxt.Text = str;
                str = Result.Text;
            }
            catch
            {
                OperationTxt.Text = "Error !!";
                Result.Text = "0";
            }
            
        }

        private void DeleteDigit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(str) && str.Length > 0)
            {
                str = str.Substring(0, (str.Length - 1));
                OperationTxt.Text = str;
            }
        }

        private void button_MinusSign_Click(object sender, EventArgs e)
        {
            str += "-";
            OperationTxt.Text = str;
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            str += ".";
            OperationTxt.Text = str;
        }

        private void Result_Click(object sender, EventArgs e)
        {

        }
    }
}
