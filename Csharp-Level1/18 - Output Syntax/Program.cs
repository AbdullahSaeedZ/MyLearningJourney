using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18___Output_Syntax
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // prints arguments then goes to new line
            Console.WriteLine("-first line");
            Console.WriteLine("-second line");
            Console.WriteLine("-third line");

            // without new lines
            Console.Write("-this is Write function: ");
            Console.Write("-using another write function (which doesnt give new line)");


            // dealing with more args, if they were all numbers, then it will calculate, but if mixed with strings , it will do concatenation
            Console.WriteLine("\n-giving more args in one function, will do concatenation, unless put inside brackets, Sum of 10 + 20 = " + 10 + 20);
            Console.WriteLine("-now with brackets, Sum of 10 + 20 = " + (10 + 20));
            Console.WriteLine(10 + 10 + 10 + 10);

            // or using $ and numbers in curly brackets which makes one string having calculations.
            // it is called string interpolation symbol
            Console.WriteLine($"Sum is = {10 + 10 + 10 + 10} dollars");

            // we can use formatted string using {0} then {1} and so on, then it will be replaced with next args
            Console.WriteLine("{0} {1}", "Hi", "Im Abdullah");

            int x = 1, y = 2;
            Console.WriteLine(" x = {0} , y = {1} , their sum is = {2}", x, y, x + y);



            // escape sequences are the same as C++
            Console.WriteLine("New Line:");
            Console.WriteLine("my name is Abdullah\n");

            Console.WriteLine("Tab:");
            Console.WriteLine("my name is \tAbdullah\n");

            Console.WriteLine("backspace:");
            Console.WriteLine("my name is \bAbdullah\n");

            Console.WriteLine("dbl quote:");
            Console.WriteLine("my name is \"Abdullah\n");

            Console.WriteLine("single quote:");
            Console.WriteLine("my name is \'Abdullah\n");

            Console.WriteLine("backslash:");
            Console.WriteLine("my name is \\Abdullah\n");

            Console.WriteLine("alert:");
            Console.WriteLine("\a");



        }
    }
}
