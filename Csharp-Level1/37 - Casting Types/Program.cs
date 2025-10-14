using System;

namespace TypeCastingExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===== Implicit Casting (Automatic) =====
            // Happens automatically when converting from a smaller type to a larger type.
            // Example: int → double

            int i = 5;
            double d = i; // The compiler automatically converts int to double

            Console.WriteLine("Implicit Casting:");
            Console.WriteLine($"int i = {i}");
            Console.WriteLine($"double d = {d}");
            Console.WriteLine("-----------------------------------");



            // ===== Explicit Casting (Manual) =====
            // Happens manually when converting from a larger type to a smaller type.
            // This may cause data loss (for example, losing decimals).
            // Example: double → int


            float f = 5.50f;
         // int x = f;        // compiler will give error, as a warning that data might be lost if casted, so we have to explicitly cast it:
            int x = (int)f;   // Manual conversion (casting) from float to int → result will be 5

            Console.WriteLine("Explicit Casting:");
            Console.WriteLine($"float f = {f}");
            Console.WriteLine($"int x = (int)f → {x}");
            Console.WriteLine("-----------------------------------");

            // ===== Type Conversion Methods =====
            // It is also possible to convert data types explicitly by using built-in methods.
            // Common methods include:
            // Convert.ToBoolean(), Convert.ToDouble(), Convert.ToString(), Convert.ToInt32(), and Convert.ToInt64()
            // rounding is used when using casting by methods

            string strNumber = "1234";
            int number = Convert.ToInt32(strNumber); // Converts string to int
            double doubleNumber = Convert.ToDouble(number); // Converts int to double
            string strFromDouble = Convert.ToString(doubleNumber); // Converts double to string
            bool boolValue = Convert.ToBoolean(1); // Converts 1 to true

            Console.WriteLine("Type Conversion Methods:");
            Console.WriteLine($"string → int: {number}");
            Console.WriteLine($"int → double: {doubleNumber}");
            Console.WriteLine($"double → string: {strFromDouble}");
            Console.WriteLine($"int → bool: {boolValue}");

        }
    }
}
