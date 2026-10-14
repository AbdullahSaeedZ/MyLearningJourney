/*
====================================================================================================
                LINQ DATA ORDERING - ORDERBY() & ORDERBYDESCENDING()
====================================================================================================

1. THE PROBLEM:
   Collections frequently arrive unordered or indexed by default storage keys (like database IDs).
   When presenting data to users, generating reports, or prioritizing tasks, you must arrange items
   by a specific field (e.g., lowest-to-highest salary, alphabetical name, earliest date) without
   writing manual sorting algorithms or altering the original source data structure.

2. THE CORE IDEA:
   Primary sorting operators evaluate a key-selector expression for each element and arrange the
   entire sequence based on that key:
   - OrderBy(keySelector)           : Sorts elements in ASCENDING order (A-Z, 0-9, lowest to highest).
   - OrderByDescending(keySelector) : Sorts elements in DESCENDING order (Z-A, 9-0, highest to lowest).

   ASCII Diagrams:

   OrderBy(e => e.Salary) [Ascending]:
   Input:  [ Cole: $103k ] [ Jaclyn: $192k ] [ Alex: $80k ]
   Output: [ Alex: $80k  ] [ Cole: $103k   ] [ Jaclyn: $192k ]

   OrderByDescending(e => e.Salary) [Descending]:
   Input:  [ Cole: $103k ] [ Jaclyn: $192k ] [ Alex: $80k ]
   Output: [ Jaclyn: $192k ] [ Cole: $103k ] [ Alex: $80k  ]

3. HOW IT WORKS INTERNALLY:
   - Stable Sort:
     LINQ's sorting algorithms are STABLE. If two elements have equal keys, their original relative
     order in the source collection is preserved.
   - Non-Streaming / Buffering (Eager Read):
     Unlike Where() or Take(), which can stream items lazily on demand, OrderBy CANNOT emit its first
     element until it has enumerated and buffered the ENTIRE sequence into memory. It must inspect
     every element to determine which one is truly minimal or maximal.
   - Return Type (IOrderedEnumerable<T>):
     OrderBy does not return a basic IEnumerable<T>; it returns an IOrderedEnumerable<T>. This type
     maintains internal sorting context so secondary sorting operators (ThenBy) know how to resolve ties.

4. COMMON PITFALLS:
   - Chaining OrderBy with OrderBy:
     Never chain two OrderBy calls: `employees.OrderBy(e => e.Name).OrderBy(e => e.Salary)`.
     The second OrderBy completely overrides and wipes out the first sort! (Secondary sorting requires ThenBy).
   - Large In-Memory Sets:
     Since sorting requires buffering all elements in memory, sorting massive collections over IEnumerable
     incurs a temporary memory spike.
   - Null Keys:
     When sorting reference types or nullable values, null values are treated as smaller than any non-null
     value (they appear first in Ascending, last in Descending).
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using DataSorting.Shared;

namespace _2__OrderBy_and_OrderByDescending
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("        LINQ ORDERING: ORDERBY & ORDERBYDESCENDING DEMO           ");
            Console.WriteLine("==================================================================\n");

            // =========================================================================
            // 1. OrderBy(keySelector) - Ascending Order
            // Goal: Sort employees by their Name in alphabetical order (A to Z).
            // Why OrderBy: Evaluates e.Name and sorts strings in standard ascending order.
            // =========================================================================
            Console.WriteLine("================ 1. OrderBy(e => e.Name) (A-Z) ================\n");

            var sortedByNameAsc = employees.OrderBy(e => e.Name); // OrderBy = ascending 

            foreach (var emp in sortedByNameAsc)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine();

            // =========================================================================
            // 2. OrderByDescending(keySelector) - Descending Order
            // Goal: Sort employees by Salary from highest earner to lowest earner.
            // Why OrderByDescending: Evaluates e.Salary and sorts numeric values largest first.
            // =========================================================================
            Console.WriteLine("======== 2. OrderByDescending(e => e.Salary) (Highest First) ========\n");

            var sortedBySalaryDesc = employees.OrderByDescending(e => e.Salary); // OrderByDescending = Descending 

            foreach (var emp in sortedBySalaryDesc)
            {
                Console.WriteLine(emp);
            }
            
            
            // Query Syntax: Ascending (orderby) vs Descending (orderby ... descending)
            // 1. Ascending by Name (A to Z)
            Console.WriteLine("\n\n================ 3A. Query Syntax (Ascending by Name) ================\n");
            var queryAsc = from emp in employees
                orderby emp.Name
                select emp;

            foreach (var emp in queryAsc)
                Console.WriteLine(emp);

            // 2. Descending by Salary (Highest first)
            Console.WriteLine("======== 3B. Query Syntax (Descending by Salary) ========\n");
            var queryDesc = from emp in employees
                orderby emp.Salary descending
                select emp;

            foreach (var emp in queryDesc)
                Console.WriteLine(emp);
        }
    }
}