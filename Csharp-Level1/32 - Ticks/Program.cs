using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _32___Ticks
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*
             
                |< -----------------------------------------timeline---------------------------------------- >|
            1 / 1 / 0001 00:00:00                              now                                     31 / 12 / 9999
              Ticks = 0                                     Ticks = billions                      Ticks = 3155378975999999999
            */


            // tick is the smallest time unit in C# inside the DateTime struct
            // Each tick = 100 nanoseconds (0.0000001 sec)
            // Ticks count from 1 Jan, 0001 (Gregorian calendar)

            Console.WriteLine(DateTime.MinValue.Ticks); // 0 → start of time range
            Console.WriteLine(DateTime.MaxValue.Ticks); // 3155378975999999999 → end of time range




            // lets see hom much time it takes for a printing method to execute:

            DateTime Start = DateTime.Now;
            Console.WriteLine("Hello world");
            DateTime End = DateTime.Now;

            long Duration = End.Ticks - Start.Ticks;

            Console.WriteLine("how many ticks to run printing function: " + Duration);


        }
    }
}
