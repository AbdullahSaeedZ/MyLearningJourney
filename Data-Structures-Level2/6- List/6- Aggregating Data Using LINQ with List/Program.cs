/*
 * ============================================================================
 * LESSON: AGGREGATING DATA USING LINQ WITH LIST IN C#
 * ============================================================================
 * 
 * 1. WHAT IS AGGREGATION?
 * -----------------------
 * Aggregation operations process an entire collection and collapse it down 
 * into a single cumulative scalar value (e.g., total sum, average, min, max).
 * 
 * 
 * 2. CORE LINQ AGGREGATION OPERATORS
 * -----------------------------------
 * - Sum()     : Calculates the mathematical sum of the sequence.
 * - Min()     : Finds the smallest value.
 * - Max()     : Finds the largest value.
 * - Average() : Calculates the arithmetic mean.
 * - Count()   : Counts elements (Note: For List<T>, use the list.Count property for O(1)).
 * 
 * 
 * 3. AGGREGATING NON-NUMERIC TYPES (TRANSFORMATION SELECTORS)
 * -----------------------------------------------------------
 * When items are not numbers, we must pass a selector lambda so the method 
 * knows which numeric property to use for the calculation.
 * 
 * 
 * 4. CUSTOM AGGREGATION: Aggregate()
 * ----------------------------------
 * The Aggregate() method performs a custom running accumulation across items, 
 * passing the accumulated result and the next element into a reduction function.
 */

namespace _6__Aggregating_Data_Using_LINQ_with_List;

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
        
        // Linq aggregate functions on numeric items:
        Console.WriteLine("Sum: " + numbers.Sum());
        Console.WriteLine("Min: " + numbers.Min());
        Console.WriteLine("Max: " + numbers.Max());
        Console.WriteLine("Count: " + numbers.Count());
        Console.WriteLine("Average: " + numbers.Average());
        
        // On a list of strings:
        List<string> names = new List<string>() { "Abdullah", "Ahmed", "Ali", "Nasser", "Nora" };
        
        // Since items are not numbers, we have to provide a selector to evaluate based on:
        Console.WriteLine("\n\nSum of all names' lengths: " + names.Sum(name => name.Length));
        Console.WriteLine("Min length of all names: " + names.Min(name => name.Length));
        Console.WriteLine("Max length of all names: " + names.Max(name => name.Length));
        Console.WriteLine("Average length of all names: " + names.Average(name => name.Length));
        
        // Linq Aggregate method (explained in the LINQ course)
        string concatNames = names.Aggregate((accumulated, nameItem) =>
        {
            return $"{accumulated}, {nameItem}";
        });
        Console.WriteLine("\n\nConcatenated names (via Aggregate):\n" + concatNames);
    }
}