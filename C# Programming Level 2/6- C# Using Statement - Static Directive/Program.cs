// directive is like giving a command or instruction for the compiler

// this is for using namespaces
using System;

// using static directive for static members of classes
// here, this line helps us to directly access the static methods of the Math class without the need of writing the class name
using static System.Math;

namespace Program
{

    class Program1
    {
        public static void Main(string[] args)
        {
            // useing the Sqrt() method directly without specifying the Math class.
            double n = Sqrt(9);
            Console.WriteLine("Square root of 9 is " + n);

        }
    }
}