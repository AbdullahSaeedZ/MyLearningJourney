/*
====================================================================================================
                LINQ DATA PARTITIONING - TAKE(), TAKEWHILE(), TAKELAST()
====================================================================================================

1. THE PROBLEM:
   You need to extract a specific bounded slice from the edges or a continuous prefix of a stream
   without iterating the entire collection or loading unnecessary elements into memory:
   - Grabbing the top N records (e.g., first page, top results).
   - Reading leading records only while a specific business condition stays valid.
   - Grabbing the trailing N records from the end of a sequence.

2. THE CORE IDEA:
   Take operators capture elements from a sequence and terminate enumeration as soon as the limit is hit:
   - Take(n)         : Captures up to 'n' elements from the start, then immediately stops.
   - TakeWhile(pred) : Captures elements while condition is true; STOPS on the FIRST false.
   - TakeLast(n)     : Captures only the final 'n' elements from the tail.

   ASCII Diagrams:

   Take(3):
   Input:  [ 01 ] [ 02 ] [ 03 ] | [ 04 ] [ 05 ] [ 06 ] [ 07 ]
           |--- Yielded (3) ----|   |------- Ignored --------|

   TakeWhile(x < 5):
   Input:  [ 01 ] [ 03 ] [ 04 ] | [ 06 ] [ 02 ] [ 08 ]
           |- True: Yielded ----|   |- False: STOPS immediately (never sees 02!) -|

   TakeLast(2):
   Input:  [ 01 ] [ 02 ] [ 03 ] [ 04 ] [ 05 ] | [ 06 ] [ 07 ]
           |------------- Ignored -------------|   |-- Yielded (2) --|

3. HOW IT WORKS INTERNALLY:
   - Take(n): Maintains a counter decrementing from 'n' down to 0 using `yield return`.
     The moment the counter hits 0, it calls `yield break` (short-circuit execution).
   - TakeWhile(pred): Tests each element sequentially. The exact moment the predicate returns false,
     it halts enumeration immediately and ignores all remaining elements.
   - TakeLast(n): Maintains an internal circular buffer (queue) of size 'n'. It streams through the
     collection keeping only the latest 'n' items, and once the end is reached, it yields that buffer.

4. COMMON PITFALLS:
   - TakeWhile vs Where: TakeWhile stops testing at the first failing element. It is NOT a filter;
     any valid records occurring after the first failure are completely missed.
   - Negative Counts: Passing negative numbers or 0 to Take(n) or TakeLast(n) returns an empty sequence.
   - TakeLast Iteration: Unlike Take(n), TakeLast MUST traverse the entire sequence to know where
     the end is before it can yield anything.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using DataPartitioning.Shared;

namespace _3__Taking_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("                LINQ PARTITIONING: TAKING DEMO                    ");
            Console.WriteLine("==================================================================\n");

            // =========================================================================
            // 1. Take(n)
            // Goal: Grab only the first 10 employees from the collection.
            // Why Take(10): It captures items 1 through 10 and immediately halts
            // enumeration, ignoring the rest of the dataset.
            // =========================================================================
            Console.WriteLine("================ 1. Take(10) ================");

            var first10Employees = employees.Take(10);

            foreach (var emp in first10Employees)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine();

            // =========================================================================
            // 2. TakeWhile(predicate)
            // Goal: Grab employees from the start as long as they have 3 or fewer skills.
            // Why TakeWhile: Yields records while Skills.Count <= 3 is true.
            // The FIRST time an employee has more than 3 skills, it halts enumeration
            // immediately and stops checking any further records.
            // =========================================================================
            Console.WriteLine("======= 2. TakeWhile(Skills.Count <= 3) =======");

            var initialLowSkillCount = employees.TakeWhile(e => e.Skills.Count <= 3);

            foreach (var emp in initialLowSkillCount)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine();

            // =========================================================================
            // 3. TakeLast(n)
            // Goal: Grab only the final 10 employees from the end of the collection.
            // Why TakeLast(10): Uses an internal circular buffer to track the stream
            // and yields strictly the last 10 elements.
            // =========================================================================
            Console.WriteLine("============== 3. TakeLast(10) ==============");

            var last10Employees = employees.TakeLast(10);

            foreach (var emp in last10Employees)
            {
                Console.WriteLine(emp);
            }
        }
    }
}