using System;


// generic = template

namespace _5__Generic_Delegates
{


    // declare one generic delegate:
    delegate T delGeneric<T>(T x, T y);

    internal class Program
    {
        static void Main(string[] args)
        {

            // purpose is to have one delegate definition that can declare for multiple delegate instances to reference to multiple methods
            delGeneric<int> delSum = (int x, int y) => x + y;
            Console.WriteLine(delSum(2,5));

            delGeneric<string> delConcat = (string a, string b) => a + " " + b;
            Console.WriteLine(delConcat("Abdullah", "Alzahrani"));

        }
    }
}
