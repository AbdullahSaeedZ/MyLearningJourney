using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4__send_Data_from_form1_to_form2
{

    public partial class Form2 : Form
    {
        // prepare variable to save value coming from constructor:
        private int _PersonID;


        public Form2(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;

            // or just use value here
            label2.Text = PersonID.ToString();
        }

      
    }
}
