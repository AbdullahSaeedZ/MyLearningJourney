using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21___Implicitly_Typed_Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* Implicitly typed variables
             Alternatively in C#, we can declare a variable without knowing 
             its type using var keyword. 
             Such variables are called implicitly typed local variables.

             Variables declared using var keyword must be initialized at the time of declaration.
            */

            // var = auto in C++

            var x = 10;
            var y = 10.5;
            var z = "Mohammed";

            Console.WriteLine("x={0}, y={1}, z={2}", x, y, z);


        }
    }
}
