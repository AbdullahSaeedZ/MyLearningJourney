using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25___Default_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // numeric types have a default 0 value 
            // bool has a default false value 
            // char has a default '\0 value 

            // reference types (string, class,...) has a default null value 

            //get default value using default(type)
            int i = default(int); // 0
            float f = default(float);// 0
            decimal d = default(decimal);// 0
            bool b = default(bool);// false
            char c = default(char);// '\0'

            // C# 7.1 onwards
            //get default value using default
            int i2 = default; // 0
            float f2 = default;// 0
            decimal d2 = default;// 0
            bool b2 = default;// false
            char c2 = default;// '\0'
            string s1 = default; // null

            


        }
    }
}
