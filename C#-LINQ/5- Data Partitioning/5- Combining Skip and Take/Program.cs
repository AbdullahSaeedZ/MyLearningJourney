/*
====================================================================================================
                LINQ DATA PARTITIONING - COMBINING SKIP() AND TAKE()
====================================================================================================

1. THE PROBLEM:
   Real-world consumers (APIs, UI grids, mobile lists) rarely want data from index 0 to N.
   They want an arbitrary contiguous "window" located somewhere in the middle of a large dataset
   without loading everything before or after it.

2. THE CORE IDEA:
   Chaining `Skip(offset).Take(size)` creates a sliding window over any sequence:
   - Step 1: Skip(offset) discards the leading records you do not care about.
   - Step 2: Take(size) grabs only the target batch and halts immediately.

   ASCII Diagram (Window of 3 starting at offset 4):

   Sequence: [ 01 ] [ 02 ] [ 03 ] [ 04 ] | [ 05 ] [ 06 ] [ 07 ] | [ 08 ] [ 09 ] [ 10 ]
             |-------- Skip(4) --------|   |----- Take(3) -----|   |--- Unread (Halt) ---|
                     (Discarded)              (Target Window)

3. HOW IT WORKS INTERNALLY:
   - Order Matters: `Skip(4).Take(3)` advances 4 items, then yields 3 items and halts.
     Reversing them to `Take(3).Skip(4)` would take 3 items, try to skip 4 of those 3,
     and return an empty collection.
   - Pipeline Efficiency: Enumeration stops the instant `Take` hits its limit.
     Records 8, 9, and 10 are never touched in memory.
   - In ORMs (EF Core): Translates directly to SQL `OFFSET 4 ROWS FETCH NEXT 3 ROWS ONLY`.

4. COMMON PITFALLS:
   - Swapping Method Order: Always `Skip` first to reach the window, then `Take` the slice.
   - Non-Deterministic Order: Slicing without an ordered dataset leads to random windows
     if the underlying data order ever shifts.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using DataPartitioning.Shared;

namespace lesson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("             LINQ PARTITIONING: SKIP + TAKE WINDOWING             ");
            Console.WriteLine("==================================================================\n");

            // =========================================================================
            // Goal:
            // Extract a window of exactly 5 employees starting from index 20 (records 21 to 25).
            //
            // How it works:
            // 1. Skip(20) : Discards the first 20 employees.
            // 2. Take(5)  : Pulls the next 5 employees directly after and halts.
            // =========================================================================
            int offset = 20;
            int windowSize = 5;

            Console.WriteLine($"Window: Offset = {offset}, Size = {windowSize}\n");

            var employeeWindow = employees
                .Skip(offset)
                .Take(windowSize);

            foreach (var emp in employeeWindow)
            {
                Console.WriteLine(emp);
            }
        }
    }
}