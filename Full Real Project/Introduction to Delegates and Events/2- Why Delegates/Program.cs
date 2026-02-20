using System;
using System.Collections.Generic;


namespace Introduction_to_Delegates_and_Events
{

    // one way to use Delegates, is to parameterize a code or a method, instead of passing a value or a variable as parameter.

    delegate bool delExpression(int a, int b);


    internal class Program
    {
        static void Main(string[] args)
        {
            // 1-
            List<int> list = new List<int>() { 1, 6, 8, 3, 11, 14, 23, 55 };
            var output = GetValuesGreaterThan10(list);

            foreach (int n in output)
                Console.WriteLine(n);


            Console.WriteLine();
            //2-

            var output2 = GetValuesLessThan10(list, 10);

            foreach (int n in output2)
                Console.WriteLine(n);

            // ---------------------------------
            //6-

            var output3 = GetFilteredValues(list, 10, isGreater);  //see i passed a function!!! i can use the isLess method also, but will use Lambda in next lesson

            foreach (int n in output3)
                Console.WriteLine(n);
        }

        // 1- i want to filter numbers in the list to be only greater than 10:
        static List<int> GetValuesGreaterThan10(List<int> list1)
        {
            List<int> list = new List<int>();

            foreach(int n in list1)
            {
                if (n > 10)
                    list.Add(n);
            }

            return list;
        }


        // 2- and now i want to filter numbers in the list to be only LESS than , and i want the number to be a parameter.
        // so i will have to repeat the code to only change the relational operator to be <  and add a parameter!!
        static List<int> GetValuesLessThan10(List<int> list1, int number)
        {
            List<int> list = new List<int>();

            foreach (int n in list1)
            {
                if (n < number)
                    list.Add(n);
            }

            return list;
        }



        // -------------------------------
        // 3- note that i have two methods that are similar, but differ in the if expression!! which led me to repeat the method, and can continue to repeat with every new requirement!
        // solution is to use Delegate and pass a code (pass the expression as parameter to the GetValues method) then become flexible:



        // 4- Expression is method ! it takes two values (parameter list) and it returns false or true (return type) so we have the delegate method signature!
        static List<int> GetFilteredValues(List<int> list1, int number, delExpression operation)
        {
            List<int> list = new List<int>();

            foreach (int n in list1)
            {
                if (operation(n, number)) // invoke the delegate and pass required parameters
                    list.Add(n);
            }

            return list;
        }

        // 5-
        // use these methods for delegate to point at, to be passed as parameter in GetFilteredValues
        // next lesson we learn Lambda to get rid of these two methods.
        static bool isGreater(int a, int b)
        {
            return a > b;
        }
        static bool isLess(int a, int b)
        {
            return a < b;
        }

    }

}
