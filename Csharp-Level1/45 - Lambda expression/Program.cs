using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // ================================================
        // 🔹 What is a Lambda Expression in C#
        // ================================================
        //
        // A Lambda Expression is an anonymous (nameless) function.
        // It allows you to write small, inline functions directly inside your code.
        //
        // Syntax:
        // (parameters) => expression
        //
        // Example:
        // n => n > 0
        // - n is the parameter (like a loop variable) temporarily created inside the Lambda expression scope
        // - => means "return the result of"
        // - n > 0 is the expression (the condition being evaluated)

        //
        // Equivalent long form:
        // (int n) => { return n > 0; }
        //
        // Lambdas are heavily used with LINQ methods
        // like Where(), Select(), OrderBy(), etc.
        // ================================================


        //------------------------------------------------------------------------
        // Example using Lambda with an array and the Where() method. compare this with the loop below:
        int[] numbers = { 51, -1, 2, 14, 18, 40, 178 };
        var positives = numbers.Where(n => n > 0);


        Console.WriteLine("Positive numbers:");
        Console.WriteLine(string.Join(", ", positives));

        // Here we use a Lambda Expression (n => n > 0)
        // to filter only positive numbers from the array.
        //
        // We use 'var' here because the exact type returned by Where() 
        // is not just a normal list — it's an IEnumerable<int>.
        // 'IEnumerable<int>' means "a sequence of integers that can be iterated over"
        // It doesn't store data itself — it just provides a way to loop through the elements.
        // 'var' automatically infers that type for us.
        //
        // Also, 'positives' holds **multiple values** (a collection),
        // not a single number. It stores all numbers that matched the condition.


        // Lambada and Linq is shorter than doing this:
        List<int> positives1 = new List<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > 0)
                positives1.Add(numbers[i]);
        }

        //------------------------------------------------------------------------
        // Another example: filter numbers greater than 20
        // Same thing — 'var' holds the filtered collection (multiple values)
        var greaterThan20 = numbers.Where(x => x > 20);
        Console.WriteLine("\nNumbers greater than 20:");
        Console.WriteLine(string.Join(", ", greaterThan20));
    }
}
