/*
====================================================================================================
                             LINQ DATA ORDERING - REVERSE()
====================================================================================================

1. THE PROBLEM:
   You already have an ordered sequence (from an existing query, an indexed list, or an incoming
   data stream), and you simply need to flip it from tail to head:
   - Showing most recent activity first when items are appended chronologically.
   - Inverting a pre-sorted dataset without paying the cost of re-evaluating property keys or comparers.
   Writing manual backward loops (`for (int i = list.Count - 1; i >= 0; i--)`) creates extra state
   and doesn't work on forward-only `IEnumerable<T>` streams.

2. THE CORE IDEA:
   `Reverse()` inverts the order of elements in a sequence:
   - Does NOT inspect properties or evaluate comparison logic; it simply walks the sequence backward.
   - Return type is `IEnumerable<T>`, NOT `IOrderedEnumerable<T>`.

   ASCII Diagram:

   Source Sequence: [ 01 ] -> [ 02 ] -> [ 03 ] -> [ 04 ]
                                    |
                                    v Reverse()
   Reversed Stream: [ 04 ] -> [ 03 ] -> [ 02 ] -> [ 01 ]

3. HOW IT WORKS INTERNALLY:
   - Instance vs. Extension Method:
     * `List<T>.Reverse()`: Mutates (inverts) the list in place and returns `void`.
     * `Enumerable.Reverse()`: LINQ extension method that leaves the original sequence untouched
       and yields a new inverted sequence lazily.
   - Eager Buffering:
     Because forward-only enumerators cannot traverse backward, LINQ's `Reverse()` must read the
     entire sequence into an internal buffer before yielding the very first element.
   - No Query Syntax:
     There is no query syntax keyword for `Reverse()`; it is method-syntax only.

4. COMMON PITFALLS:
   - Reverse() vs. OrderByDescending():
     * `OrderByDescending(e => e.Salary)` actually compares values and sorts high-to-low.
     * `Reverse()` blindly flips whatever order the data is already in. If input is unsorted,
       output remains unsorted.
   - Memory Consumption on Streams:
     Like `OrderBy`, `Reverse()` buffers everything into memory before producing the first item.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using DataSorting.Shared;

namespace _5__Reverse_Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("                    LINQ ORDERING: REVERSE()                      ");
            Console.WriteLine("==================================================================\n");

            // =========================================================================
            // Example 1: Inverting an Existing Sequence
            // Goal: Take the first 5 employees and flip their display order backward.
            // Notice: We use explicit types instead of 'var'.
            // =========================================================================
            Console.WriteLine("--- 1. Original First 5 Records ---\n");

            IEnumerable<Employee> topFive = employees.Take(5);

            foreach (Employee emp in topFive)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("\n--- 2. Reversed First 5 Records (Inverted) ---\n");

            // Reverse() consumes topFive, buffers it, and yields from index 4 down to 0:
            IEnumerable<Employee> reversedTopFive = topFive.Reverse();

            foreach (Employee emp in reversedTopFive)
            {
                Console.WriteLine(emp);
            }

            // =========================================================================
            // Example 2: In-Place List.Reverse() vs LINQ Enumerable.Reverse()
            // =========================================================================
            Console.WriteLine("\n--- 3. Instance List.Reverse() vs LINQ Extension ---");

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            // LINQ: Non-destructive, leaves 'numbers' list intact
            IEnumerable<int> linqReversed = numbers.Reverse<int>();
            Console.WriteLine($"LINQ result:    {string.Join(", ", linqReversed)}");
            Console.WriteLine($"Original list:  {string.Join(", ", numbers)} (Unchanged)");

            // Instance method: Mutates the actual list in place
            numbers.Reverse();
            Console.WriteLine($"After .Reverse(): {string.Join(", ", numbers)} (Mutated!)");
        }
    }
}