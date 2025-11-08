using System;
using System.Windows.Forms;


// we referenced the dll assembly of class library we made then use it directly 

// i can edit the code of the class library by solution -> add existing project then chose the class  .csproj file


using MyLibrary;


namespace WinForms_project_linked_with_dll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clsMyMath math = new clsMyMath();
            MessageBox.Show(math.Sum(10, 20).ToString());
        }
    }
}
