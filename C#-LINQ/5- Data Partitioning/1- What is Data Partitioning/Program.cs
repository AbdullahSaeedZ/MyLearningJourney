/*
====================================================================================================
                        LINQ DATA PARTITIONING - OVERVIEW & INTRO
====================================================================================================

1. THE PROBLEM:
   Pulling entire datasets (thousands of rows) into memory crushes RAM, saturates bandwidth, and slows
   down apps when the client only needs a small slice (like a single UI page or batch).

2. THE CORE IDEA:
   Partitioning divides a sequence into sub-segments without mutating the source:
   - Skip / SkipLast / SkipWhile : Bypass leading, trailing, or condition-matching records.
   - Take / TakeLast / TakeWhile : Extract leading, trailing, or condition-matching records.
   - Chunk                       : Divide a collection into fixed-size arrays.

   ASCII Conceptual Layout:
   Source: [ 01 ] [ 02 ] [ 03 ] [ 04 ] [ 05 ] [ 06 ] [ 07 ] [ 08 ] [ 09 ] [ 10 ]
           |---------- Skip(3) ---------| |--------- Take(4) ----------|
                     (Discarded)                 (Target Slice)

   Chunk(3) Layout:
   Source: [ 01 ] [ 02 ] [ 03 ] | [ 04 ] [ 05 ] [ 06 ] | [ 07 ] [ 08 ] [ 09 ] | [ 10 ]
           |--- Array #1 -----|   |--- Array #2 -----|   |--- Array #3 -----|   |- Array #4 -|

3. HOW LINQ HANDLES IT:
   - Lazy Evaluation: Slices are computed on demand as you iterate, not up front.
   - Pipeline Composability: Chains smoothly with filtering (Where) and sorting (OrderBy).
   - Database Awareness: In ORMs (EF Core), partitioning expressions map directly to 
     native SQL offset/limit clauses so unused rows never leave the database server.

====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using DataPartitioning.Shared;

namespace LINQTut06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("              LINQ DATA PARTITIONING INTRO DEMO                   ");
            Console.WriteLine("==================================================================\n");

            // Goal:
            // We want to extract only records 6 through 10 from the collection.
            // We do NOT want to load or print the first 5 records or anything after record 10.

            // How we achieve this:
            // 1. Skip(5): Bypasses the first 5 employees (records 1 to 5).
            // 2. Take(5): Grabs the next 5 employees directly after the skipped ones (records 6 to 10).
            var employeeSlice = employees
                .Skip(5)   // Used here to discard the leading 5 elements we don't need
                .Take(5);  // Used here to capture only the next 5 elements and stop

            Console.WriteLine("Displaying targeted slice (Records 6 to 10):\n");
            Console.WriteLine("Idx   EmpNo            Name                  Email                             Salary");
            Console.WriteLine(new string('-', 85));

            // Only the 5 targeted records are iterated here
            foreach (var emp in employeeSlice)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine(new string('-', 85));
            Console.WriteLine("\nIntro complete. Ready for Section 1: Skip(), SkipWhile(), SkipLast().");
        }
    }
}