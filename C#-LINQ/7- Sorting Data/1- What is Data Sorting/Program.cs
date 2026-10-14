

/*
====================================================================================================
                             LINQ DATA ORDERING - HIGH-LEVEL INTRO
====================================================================================================

1. THE PROBLEM:
   Raw datasets from databases, files, or external APIs rarely arrive in the exact order you need:
   - UI tables need sorting by name, hire date, or salary.
   - Paging algorithms (Skip/Take) produce non-deterministic, buggy results if data isn't ordered.
   - Business priorities require multi-level hierarchy (e.g., sort by Department, then by Salary).
   Writing manual sorting algorithms (like Quicksort or Mergesort) or juggling manual `IComparable`
   implementations for every single ad-hoc property requirement is tedious and error-prone.

2. THE CORE IDEA:
   LINQ ordering operators return a new sequence arranged in a deterministic sequence without mutating
   the underlying source collection:
   - Primary Sort   : OrderBy (ascending), OrderByDescending (descending).
   - Secondary Sort : ThenBy, ThenByDescending (resolves ties from the primary sort).
   - Custom Ordering: Passing an IComparer<T> to control matching rules (e.g., case-insensitive, string length).
   - Reversal       : Reverse() to invert the current sequence order.

   ASCII Diagrams:

   Primary Sorting (OrderBy Salary Ascending):
   Input:  [ Cole: $103k ] [ Jaclyn: $192k ] [ Alex: $80k ]
   Output: [ Alex: $80k  ] [ Cole: $103k   ] [ Jaclyn: $192k ]

   Secondary Sorting (OrderBy Department THEN ThenBy Salary Descending):
   Input:  [ IT: $60k ] [ HR: $50k ] [ IT: $90k ] [ HR: $70k ]
   Step 1 (Dept)   : [ HR: $50k, HR: $70k ]  |  [ IT: $60k, IT: $90k ]
   Step 2 (Salary) : [ HR: $70k, HR: $50k ]  |  [ IT: $90k, IT: $60k ]

3. HOW LINQ HANDLES IT:
   - Deferred Execution (Yields on demand):
     The query does not execute when defined; it waits until enumeration starts (e.g., `foreach`).
   - Eager Evaluation of the Sequence:
     Unlike `Where` or `Take` which stream element-by-element immediately, ordering methods CANNOT emit
     the very first item until they have read the ENTIRE sequence into memory to determine the minimum/maximum.
   - The Return Type (`IOrderedEnumerable<T>`):
     `OrderBy` does not return `IEnumerable<T>`; it returns `IOrderedEnumerable<T>`. This specific interface
     is what allows secondary operators like `ThenBy` to preserve the previous sorting keys.
   - Database Awareness (EF Core):
     Translates directly into SQL `ORDER BY Column1 ASC, Column2 DESC`.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using DataSorting.Shared;

namespace _1__What_is_Data_Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("                  LINQ ORDERING: INTRO PREVIEW                    ");
            Console.WriteLine("==================================================================\n");

            // High-Level Preview:
            // Goal: Sort employees by Salary in ascending order, then inspect the top 5 lowest earners.
            // 1. OrderBy(e => e.Salary): Sorts the sequence from lowest to highest salary.
            // 2. Take(5): Takes only the first 5 records after ordering.
            var lowestEarners = employees
                .OrderBy(e => e.Salary)
                .Take(5);

            Console.WriteLine("Top 5 Lowest Earners Preview:\n");
            Console.WriteLine("EmpNo            Name                  Email                             Salary       Skills");
            Console.WriteLine(new string('-', 100));

            foreach (var emp in lowestEarners)
            {
                Console.WriteLine(emp);
            }

        }
    }
}