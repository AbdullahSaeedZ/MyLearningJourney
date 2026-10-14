/*
====================================================================================================
                       LINQ DATA ORDERING - CUSTOM COMPARER (IComparer<T>)
====================================================================================================

1. THE PROBLEM:
   Default LINQ sorting (`OrderBy(e => e.Property)`) works out of the box only for types that
   implement `IComparable` (like ints, strings, dates) using standard comparisons (0-9, A-Z).
   However, real-world business domains present complex requirements:
   - Composite keys stored as a single string (e.g., EmployeeNo like "2017-FI-1343", where the year
     must be sorted numerically first, and the trailing sequence number breaks ties).
   - Inlining string splits and parsing inside lambda selectors (`e => e.EmployeeNo.Split('-')[0]`)
     pollutes queries, duplicates logic across layers, and causes redundant string allocations.
   - You need a dedicated, testable, and reusable contract for domain entity sorting.

2. THE CORE IDEA:
   LINQ's `OrderBy` and `OrderByDescending` overloads accept a custom `IComparer<TKey>` instance.
   Instead of selecting an individual property, you pass the whole entity selector (`e => e`) and hand
   full control over sorting decisions to your dedicated `EmployeeComparer` custom class as a comparer.

   ASCII Diagram (How LINQ Delegates to EmployeeComparer):

   employees.OrderBy(e => e, new EmployeeComparer())
                     |                |
                     |                +---> 2. Delegates every pairwise comparison here
                     +---> 1. Selects Employee reference

      [ Emp A: 2018-FI-1002 ]  vs  [ Emp B: 2017-FI-9050 ]
                                 |
                                 v
                 EmployeeComparer.Compare(Emp A, Emp B)
                 - Compares Year: 2018 vs 2017 -> 2018 > 2017 (+1)
                 - Result: Emp B comes before Emp A in Ascending order.

3. HOW WE RELY ON THE COMPARER CLASS MAINLY:
   - The Query Becomes a Thin Shell:
     Notice the call: `employees.OrderBy(e => e, new EmployeeComparer());`.
     The LINQ pipeline does not know (or care) that `EmployeeNo` is split by hyphens or converted to ints.
     The query's only job is to stream the sequence; the entire custom sorting algorithm is encapsulated inside
     `EmployeeComparer`.
   - Returns IOrderedEnumerable<T>:
     Custom comparers work strictly with sorting operators (`OrderBy`, `OrderByDescending`, `ThenBy`, `ThenByDescending`).
     These methods return `IOrderedEnumerable<T>`, which is required to preserve sorting state and chain secondary sorts.
   - The Compare Contract:
     Your comparer implements `IComparer<Employee>` with a single method: `Compare(Employee e1, Employee e2)`.
     It returns an integer protocol expected by sorting algorithms (like Quicksort/Introsort):
     * Return < 0  : e1 is smaller than e2  -> e1 precedes e2.
     * Return == 0 : e1 equals e2           -> keeps relative order (stable sort).
     * Return > 0  : e1 is greater than e2  -> e2 precedes e1.

4. HOW IT WORKS INTERNALLY:
   - When no comparer is passed, LINQ looks up `Comparer<TKey>.Default`.
   - When you supply `new EmployeeComparer()`, LINQ replaces the default comparer entirely.
     During the sort phase, LINQ buffers elements into an internal array and calls your
     `EmployeeComparer.Compare(e1, e2)` method whenever two elements must be ranked.

5. COMMON PITFALLS:
   - Expensive Operations in Compare():
     Compare() runs O(N log N) times. Avoid allocations, parsing, or heavy logic inside it; precalculate values beforehand instead.
   - Sorting Before Filtering:
     OrderBy buffers the whole dataset in memory. Always apply Where() first to shrink the dataset before sorting.
   - Inconsistent Comparison Logic:
     Comparers must be mathematically consistent (if A < B and B < C, then A < C). Inconsistent logic yields erratic order or runtime crashes.
   - Missing Null Checks:
     Always handle null inputs explicitly, or a single null element will throw a NullReferenceException.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using DataSorting.Shared;

namespace _4__Custom_Comparer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("          LINQ ORDERING: CUSTOM ICOMPARER<T> DEMO                 ");
            Console.WriteLine("==================================================================\n");

            // =========================================================================
            // Sorter Invocation:
            // Notice:
            // 1. Selector is `e => e` (we pass the entire Employee object).
            // 2. The second argument is `new EmployeeComparer()`.
            // 3. Explicit return type: OrderBy produces IOrderedEnumerable<Employee>,
            //    which holds the sorted state and allows chaining further ThenBy calls.
            // =========================================================================
            Console.WriteLine("--- Sorting using EmployeeComparer (Year ASC, then Seq ASC) ---\n");

            IOrderedEnumerable<Employee> sortedEmployees = employees.OrderBy(e => e, new EmployeeComparer());

            foreach (Employee emp in sortedEmployees)
            {
                Console.WriteLine(emp);
            }
        }
    }
}