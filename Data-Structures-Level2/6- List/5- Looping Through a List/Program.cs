/*
 * ============================================================================
 * LESSON: LOOPING THROUGH A LIST IN C#
 * ============================================================================
 *
 * 1. ITERATION STRATEGIES
 * -----------------------
 * - for loop:
 *   * Direct index-based iteration using [i].
 *   * Fast and allows mutating elements or collection structure during the loop.
 *
 * - foreach loop:
 *   * Idiomatic, clean iteration over any collection implementing IEnumerable<T>.
 *   * Read-only iteration: modifying the list structure (e.g., Add, Remove) during
 *     enumeration throws an InvalidOperationException (collection modified).
 *
 * - List<T>.ForEach(Action<T>):
 *   * Built-in method on List<T> accepting an Action<T> delegate/lambda.
 *   * Executes in-line; does not return a new collection.
 */

namespace _5__Looping_Through_a_List;

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>() { 1, 2, 3, 4 };

        // 1. Standard for loop (Index-based, allows element mutation)
        Console.WriteLine("using For Loop:");
        for (int i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine(numbers[i]);
        }

        // 2. Foreach loop (IEnumerable-based, read-only iteration)
        Console.WriteLine("\nusing Foreach loop:");
        foreach (int item in numbers)
        {
            Console.WriteLine(item);
        }

        // 3. List<T>.ForEach method (Executes an Action<T> lambda on each item)
        Console.WriteLine("\nusing ForEach method:");
        numbers.ForEach(item =>
        {
            ++item;
            Console.WriteLine(item);
        });
    }
}