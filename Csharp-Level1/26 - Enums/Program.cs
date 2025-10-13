using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26___Enums
{
    internal class Program
    {
      
       enum enWeekDays {
           Monday,     // 0
           Tuesday,    // 1
           Wednesday,  // 2
           Thursday,   // 3
           Friday,     // 4
           Saturday,   // 5
           Sunday      // 6
       }

       //if you set a value , it will auto number everything after it.
       enum enCategories {
           Electronics,    // 0
           Food,           // 1
           Automotive = 6, // 6
           Arts,           // 7
           BeautyCare,     // 8
           Fashion         // 9
       }

        // default type for enums is int
       //Enum can have any numarical data type byte, sbyte, short, ushort, int, uint, long, or ulong
       //but not string

       enum enCategories2 : byte {
           Electronics = 1,
           Food = 5,
           Automotive = 6,
           Arts = 10,
           BeautyCare = 11,
           Fashion = 15
       }


       static void Main(string[] args)
       {
           enWeekDays WeekDays;
           WeekDays = enWeekDays.Friday;
           Console.WriteLine(WeekDays); // it will print the enum member name , not the value !

           // we can use a lot of methods of datatypes
           string Day = enWeekDays.Monday.ToString(); // converts enum datatype to string
           Console.WriteLine(Day); 
       }

    }
}
