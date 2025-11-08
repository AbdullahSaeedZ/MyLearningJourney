using System;


// Enums = 

// enums are strongly typed constants (first example in main)
// enum is a value type


namespace _42___Enums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // constants
            const int Jan = 1;
            const int Feb = 2;
            // but since they are constants and related to each other, we group those constants into Enums and deal with them as one thing


            // flag enums examples:

            Day day = (Day.Saturday | Day.Friday);

            if (day.HasFlag(Day.Weekend)) // hasFlag checks if the day is of the bitwise combination
            {
                Console.WriteLine("enjoy your weekend brooo!");
            }



            // enums parsing (converting to another data type from different category, ex int to string)

            // by default, printing an enum displays its name (the identifier), not its numeric value.
            Console.WriteLine(Month.Dec);
            // or 
            Console.WriteLine(Month.Dec.ToString());
            //to print the value of the enum, we cast it
            Console.WriteLine((int)Month.Dec);

            int monthNum = 9;
            Console.WriteLine((Month)monthNum);

            // to parse from string to enum

            string exMonth = "Feboo";

            // using tryparse will try to convert the given string to enum
            if (Enum.TryParse(exMonth, out Month month))
            {
                Console.WriteLine("yes {0} is a month", month);
            }
            else
            {
                Console.WriteLine("invalid entry");
            }


            // to check if it is in my enums

            string anyMonth = "Feb"; // or i can put the value of the enum, IsDefined can deal with both

            if (Enum.IsDefined(typeof(Month), anyMonth))
            {
                Console.WriteLine("yes {0} is a month", anyMonth);
            }
            else
            {
                Console.WriteLine("no {0} is not a month", anyMonth);
            }




            // looping 
            foreach (string monthItem in Enum.GetNames(typeof(Month)))  // Enum.GetNames(typeof(Month)) will return list of enums in string (collection)
            {
                Console.WriteLine($"{monthItem} = {(long)Enum.Parse(typeof(Month), monthItem)}");
            }

            foreach (long monthItem in Enum.GetValues(typeof(Month)))  // Enum.GetValues(typeof(Month) will return list of enums values (collection)
            {
                Console.WriteLine($"{monthItem} = {(Month)monthItem}");
            }

        }
    }

    // this is a simple use of enums
    enum Month : long  // this way i can change the default enums type from int to any NUMERIC type
    {
        // they are given initial values starting from 0
        // 0    1    2    3    4    5    6   7     8    9    10   11 

        // but i will give Jan 1 , then next ones will increase
          Jan = 1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec

        // or if i give certain number, then following enums will increase that number
    }


    // this is flag enums, another usage of enums (bitwise operations)
    // The [Flags] attribute tells the compiler that this enum is intended to be treated as a set of bit fields that can be combined with bitwise OR.
    [Flags]
    enum Day
    {
        None = 0,
        Monday = 1, 
        Tuesday = 2, 
        Wednesday = 4, 
        Thursday = 8, 
        Friday = 16, 
        Saturday = 32, 
        Sunday = 64,
        Weekdays = Monday | Tuesday | Wednesday | Thursday | Sunday,
        Weekend = Friday | Saturday

    }
}
