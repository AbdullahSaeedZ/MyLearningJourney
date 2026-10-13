
/*
====================================================================================================
               LINQ DATA PARTITIONING - SKIP(), SKIPWHILE(), SKIPLAST()
====================================================================================================

1. THE PROBLEM:
   You often need to bypass unwanted records at the boundary of a collection:
   - Discarding the first N records (e.g., jumping to a specific page).
   - Skipping leading records until a certain condition breaks (e.g., ignoring warmup values).
   - Dropping the last N records without manually checking collection count or index math.

2. THE CORE IDEA:
   Skip operators omit elements from a sequence and return only the remaining items:
   - Skip(n)         : Ignores the first 'n' elements, yields the rest.
   - SkipWhile(pred) : Ignores elements while condition is true; starts yielding on FIRST false.
   - SkipLast(n)     : Ignores the trailing 'n' elements from the end of the sequence.

   ASCII Diagrams:

   Skip(3):
   Input:  [ 01 ] [ 02 ] [ 03 ] | [ 04 ] [ 05 ] [ 06 ] [ 07 ]
           |--- Discarded (3) --|   |------- Yielded --------|

   SkipWhile(x < 5):
   Input:  [ 01 ] [ 03 ] [ 04 ] | [ 06 ] [ 02 ] [ 08 ]
           |- True: Discarded --|   |- False: Yields ALL remaining (even 02!) -|

   SkipLast(2):
   Input:  [ 01 ] [ 02 ] [ 03 ] [ 04 ] [ 05 ] | [ 06 ] [ 07 ]
           |------------- Yielded -----------||-Discarded (2)-|

3. HOW IT WORKS INTERNALLY:
   - Skip(n): Advances the enumerator 'n' times internally, then streams via `yield return`.
   - SkipWhile(predicate): Evaluates each element. Once the predicate returns false, it stops
     evaluating conditions entirely and yields all subsequent elements directly.
   - SkipLast(n): Maintains an internal ring buffer (queue) of size 'n'. It holds 'n' elements 
     in memory before it starts yielding, ensuring the trailing 'n' items are left behind.

4. COMMON PITFALLS:
   - SkipWhile vs Where: SkipWhile is NOT a filter. As soon as one item fails the condition,
     it never checks the condition again.
   - Negative Counts: Passing negative numbers to Skip(n) or SkipLast(n) does not throw;
     it simply returns the full sequence untouched.
   - SkipLast Buffering: SkipLast requires buffering 'n' items in memory, so huge counts
     add memory overhead compared to forward Skip.
====================================================================================================
*/


namespace _2__Skipping_Methods;

using System;
using System.Collections.Generic;
using System.Linq;
using DataPartitioning.Shared;

    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("               LINQ PARTITIONING: SKIPPING DEMO                   ");
            Console.WriteLine("==================================================================\n");

            // =========================================================================
            // 1. Skip(n)
            // Goal: Bypass the FIRST 95 employees and view only the remaining ones.
            // Why Skip(40): It drops records 1 through 40 so we only loop over 40 to 50.
            // =========================================================================
            Console.WriteLine("================ 1. Skip(40) ================");
            
            var afterSkippingFirst95 = employees.Skip(40);

            foreach (var emp in afterSkippingFirst95)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine();

            // =========================================================================
            // 2. SkipWhile(predicate)
            // Goal: Bypass records from the start as long as the employee has 3 or fewer skills.
            // Why SkipWhile: Discards each record while Skills.Count <= 3 is true.
            // The FIRST time an employee has more than 3 skills, it stops checking
            // and yields that employee plus EVERY employee that comes after.
            // =========================================================================
            Console.WriteLine("======= 2. SkipWhile(Skills.Count <= 3) =======");

            var afterSkillCondition = employees.SkipWhile(e => e.Skills.Count <= 3);

            foreach (var emp in afterSkillCondition)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine();

            // =========================================================================
            // 3. SkipLast(n)
            // Goal: Drop the final 40 employees and print only the leading ones.
            // Why SkipLast(40): Buffers and omits the trailing 40 records from the stream.
            // which will print first 10 out of 50
            // =========================================================================
            Console.WriteLine("============== 3. SkipLast(40) ==============");

            var withoutLast95 = employees.SkipLast(40);

            foreach (var emp in withoutLast95)
            {
                Console.WriteLine(emp);
            }
        }
    }
