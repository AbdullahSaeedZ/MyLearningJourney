using System;


namespace Variables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // In C#, string is a reference type (class) defined in System namespace.
            // Unlike C++, where std::string is part of the STL library.
            string MyName = "Abdullah";
            Console.WriteLine(MyName);

            int x = 1, y = 2;

            // The '+' operator is overloaded — it concatenates with strings,
            // and adds numbers when operands(values next to the operator) are numeric. Brackets just change the order.
            Console.WriteLine("x+y = " + x + y);
            Console.WriteLine("x+y = " + (x + y));

            // Any literal with a decimal point is considered a double by default.
            // Use suffixes to specify the type: D (double), F (float), M (decimal).
            double D = 23.3D;

            // A char in C# is a 16-bit Unicode character (not 8-bit like in C++).
            char Letter = 'f';

            // Boolean values can only be true or false — assigning numbers is invalid.
            bool MyBool = true;



        }
    }
}
