using System;
using System.Linq; // LINQ = Language Integrated Query

namespace _44___Array_Operations_using_System.Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ===========================================
            // 📘 What is System.Linq ?
            // ===========================================
            // - LINQ stands for "Language Integrated Query".
            // - It’s a library (namespace), not a class.
            // - It allows us to query and manipulate data in C# 
            //   (like arrays, lists, or even databases) using clean, SQL-like syntax.
            //
            // Example idea:
            //     var result = numbers.Where(n => n > 10);
            // This is equivalent to a loop that filters numbers > 10.

            // ===========================================
            // 🧩 Why arrays have .Min() or .Max() ?
            // ===========================================
            // Arrays (like int[]) normally don’t have such methods.
            // But because LINQ adds “extension methods” to existing types,
            // it *looks like* arrays now have these methods.
            //
            // Extension methods = helper methods that get "attached" to
            // types without actually modifying them.
            // (They’re defined inside System.Linq and added at compile time.)

            // ===========================================
            // ⚙️ Common LINQ Methods:
            // ===========================================
            // Min()              -> returns smallest value
            // Max()              -> returns largest value
            // Sum()              -> returns total sum
            // Average()          -> returns average
            // Count()            -> number of elements
            // Where()            -> filters elements by a condition
            // Select()           -> transforms elements (like map)
            // OrderBy()          -> sort ascending
            // OrderByDescending()-> sort descending
            // Distinct()         -> removes duplicates
            // First() / Last()   -> first or last element
            // Any() / All()      -> boolean checks for conditions

            // ===========================================
            // 🧠 Example:
            // ===========================================

            int[] numbers = { 51, -1, 2, 14, 18, 40, 178 };

            // Find smallest element
            Console.WriteLine("Smallest Element: " + numbers.Min());

            // Find largest element
            Console.WriteLine("Largest Element: " + numbers.Max());

            // Get sum and average for demonstration
            Console.WriteLine("Sum of Elements: " + numbers.Sum());
            Console.WriteLine("Average Value: " + numbers.Average());

            // Example of filtering (Where)
            var positives = numbers.Where(n => n > 0); // see lambda expression in next lesson
            Console.WriteLine("Positive Numbers: " + string.Join(", ", positives));

            // Example of sorting (OrderBy)
            var sorted = numbers.OrderBy(n => n);
            Console.WriteLine("Sorted Numbers: " + string.Join(", ", sorted));

            // ===========================================
            // 🧩 Summary:
            // ===========================================
            // - System.Linq is a library that extends data types like arrays.
            // - It provides a cleaner, more expressive way to handle data.
            // - All these operations are built on top of extension methods.
            // - Think of it as SQL-like querying inside C# code.
        }
    }
}
