using System;

namespace _48___by_ref
{
    internal class Program
    {

        //ref → Passes variable by reference(read & write)
        //- Variable must be initialized before passing
        //- Caller & method both use "ref"
        //- Method can modify caller's value directly
        static void Increment(ref int number)
        {
            number++; // changes original variable
        }


        //out → Passes variable by reference(write only)
        //- Variable doesn’t need to be initialized
        //- Method MUST assign before returning , because it is in write mode
        //- Often used in TryParse patterns
        static bool TryParseAge(string input, out int age)
        {
            if (int.TryParse(input, out age) && age > 0)
                return true;

            age = 0; // must assign before returning
            return false;
        }


        //in → Passes variable by reference(read-only)
        //- Variable is passed by ref for performance
        //- Method CANNOT modify it(compiler enforces)
        //- Useful for large structs or when safety matters
        static void PrintLength(in string text)
        {
            Console.WriteLine($"Length = {text.Length}");
            // if we try :   text = "new value"; ❌ Not allowed — read-only reference
        }



        static void Main(string[] args)
        {

            // -------- ref example --------
            int x = 10;
            Increment(ref x);             // must use "ref" here too
            Console.WriteLine(x);         // 11 — value changed inside method

            // -------- out example --------
            if (TryParseAge("25", out int personAge)) // the out in personAge will have it initialized
                Console.WriteLine($"Age: {personAge}"); // 25 — assigned inside method

            // -------- in example --------
            string s = "Hello World";
            PrintLength(in s);            // passes by ref, method can’t modify

        }
    }
}
