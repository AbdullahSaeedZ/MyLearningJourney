using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _36___String_Interpolation
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // An interpolated string is a combination of static text and dynamic expressions.
            // Variables or expressions inside an interpolated string are written within { } brackets.

            //  String Interpolation

            string firstName = "Abdullah";
            string lastName = "ALzahrani";
            string code = "100";

            //You should use $ to identify an interpolated string 
            string fullName = $"Mr. {firstName} {lastName}, Code: {code}";
            Console.WriteLine(fullName);

            // can also do calculation inside the expression
            int x = 1;
            int y = 2;
            string sum = $"\nclient name:  {firstName} {lastName}, cars : {x + y}";
            Console.WriteLine(sum);

        }
    }
}
