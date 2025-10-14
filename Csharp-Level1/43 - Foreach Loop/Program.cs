using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _43___Foreach_Loop
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // same as ranged for loop in C++


            // ===============================
            // Example 1: foreach with char array
            // ===============================

            char[] myArray = { 'H', 'e', 'l', 'l', 'o' };

            // foreach iterates over each element in the array (read-only).
            // 'ch' temporarily holds a COPY of each value from myArray.
            foreach (char ch in myArray)
            {
                Console.WriteLine(ch); // prints each character on a new line
            }

            // ===============================
            // Example 2: foreach with counting logic
            // ===============================

            char[] gender = { 'm', 'f', 'm', 'm', 'm', 'f', 'f', 'm', 'm', 'f' };
            int male = 0, female = 0;

            // foreach gives a copy of each element (not a reference).
            foreach (char g in gender)
            {
                if (g == 'm')
                    male++;
                else if (g == 'f')
                    female++;
            }

            Console.WriteLine("\nNumber of male = {0}", male);
            Console.WriteLine("\nNumber of female = {0}", female);



         


        }
    }
}
