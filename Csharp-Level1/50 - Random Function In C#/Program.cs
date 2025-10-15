using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _50___Random_Function_In_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // using Random class then creating an object
            Random rnd = new Random();

            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine(rnd.Next(10, 20)); // returns random integers >= 10 and < 20
            }

            Console.WriteLine();

            // or 

            for (int j = 0; j < 4; j++)
            {
                Console.WriteLine(rnd.Next(20)); // returns random integers from 0 to < 20
            }

        }
    }
}
