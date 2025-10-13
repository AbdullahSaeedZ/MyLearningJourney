using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31___Set_Date_and_Time
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //C# includes DateTime struct to work with dates and times.
            //To work with date and time in C#, create an object of the DateTime struct using the new keyword. The following creates a DateTime object with the default value.
            //The default and the lowest value of a DateTime object is January 1, 0001 00:00:00 (midnight). The maximum value can be December 31, 9999 11:59:59 P.M.

            //assigns default value 01/01/0001 00:00:00
            DateTime dt1 = new DateTime();

            //assigns year, month, day
            DateTime dt2 = new DateTime(2023, 12, 31);

            //assigns year, month, day, hour, min, seconds
            DateTime dt3 = new DateTime(2023, 12, 31, 5, 10, 20);

            //assigns year, month, day, hour, min, seconds, UTC timezone
            DateTime dt4 = new DateTime(2023, 12, 31, 5, 10, 20, DateTimeKind.Utc);

            Console.WriteLine(dt1);
            Console.WriteLine(dt2);
            Console.WriteLine(dt3);
            Console.WriteLine(dt4);


            // some methods of DateTime
            Console.WriteLine("\n\nsome methods:");

            DateTime CurrentDate = DateTime.Now; // assigning current time and date

            Console.WriteLine(CurrentDate);
            Console.WriteLine("\nprint datetime in string: {0}", CurrentDate.ToString());
            Console.WriteLine("\nprint date in string words: {0}", CurrentDate.ToLongDateString());
            Console.WriteLine("\nprint only date in string: {0}", CurrentDate.ToShortDateString());
            Console.WriteLine("\nprint short time in string: {0}", CurrentDate.ToShortTimeString());
            Console.WriteLine("\nprint long time in string: {0}", CurrentDate.ToLongTimeString());
            
        }
    }
}
