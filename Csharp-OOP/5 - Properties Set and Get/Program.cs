using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5___Properties_Set_and_Get
{

    class clsEmployee
    {
        private int _ID;
        private string _Name;

        public int ID
        {
            get
            {
                return _ID;
            }
            set 
            {
                // can put any code here
                // ex save date of edit to data base
                _ID = value;
            }
        }

        public string Name
        {
            // as read-only property
            get { return _Name; }
        }

        // using auto implemented properties:
        // if no code needed inside the getters and setters
        // no need to decalre the members, we only declare the properties then CLR will implicitly declare the variables based on the property we declared
        // the property is public, but the fields that will be created will be private;
        public int Age { set; get; }
        public string Segment { get; } // as read-only; can add initial value directly or through constructor
        
        // this will make it read-only for outside the class, but can be edited inside the class
        public int Score { get; private set; }

    }


    internal class Program
    {
        static void Main(string[] args)
        {
            

        }
    }
}
