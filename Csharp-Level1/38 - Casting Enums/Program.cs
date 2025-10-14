using System;

namespace Main
{
    internal class Program
    {
        // ===== Enum Declaration =====
        // Enum represents a set of named constants.
        // By default, the underlying type of each element in the enum is int.
        enum WeekDays
        {
            Monday,     // 0
            Tuesday,    // 1
            Wednesday,  // 2
            Thursday,   // 3
            Friday,     // 4
            Saturday,   // 5
            Sunday      // 6
        }

        static void Main(string[] args)
        {
            // ===== Enum to String =====
            Console.WriteLine(WeekDays.Friday); // Output: Friday

            // ===== Enum to Int Conversion =====
            int day = (int)WeekDays.Friday;
            Console.WriteLine(day); // Output: 4

            // ===== Int to Enum Conversion =====

            // var to store enums
            // or use the enum as a data type

            var wd = (WeekDays)5;
            Console.WriteLine(wd); // Output: Saturday

            Console.ReadKey();
        }
    }
}
