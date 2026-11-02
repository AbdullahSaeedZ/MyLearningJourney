/*
================================================================================
Lesson 3: ToArray vs. ToList (Eager Concrete Materialization)
================================================================================

1. PROBLEM (WHY THEY EXIST):
   - LINQ sequences (IEnumerable<T>) are forward-only and lazily evaluated.
   - You cannot index them directly (e.g., source[0]), cannot check their size
     without enumerating them, and re-iterating them re-executes the query logic.
   - You need to evaluate the sequence immediately, cache the results in memory,
     and access elements by index.

2. CORE IDEA:
   - Both .ToArray() and .ToList() are EAGER conversion operators.
   - They immediately iterate the entire sequence and allocate concrete storage in RAM.
   - The choice comes down to data mutability and sizing:
       * .ToArray(): Fixed size, lowest memory overhead, read-only/fixed buffers.
       * .ToList(): Resizable, allows adding/removing items dynamically.

+--------------+-------------------+------------------+------------------+------------------------------------+
| Method       | Output Type       | Capacity Model   | Memory Overhead  | Best Used When                     |
+--------------+-------------------+------------------+------------------+------------------------------------+
| .ToArray()   | T[] (Array)       | Fixed length     | Minimal (Exact)  | You only need to read/index items  |
|              |                   | Cannot resize    |                  | and will not add/remove elements.  |
+--------------+-------------------+------------------+------------------+------------------------------------+
| .ToList()    | List<T>           | Resizable        | Dynamic buffer   | You need to add, insert, or remove |
|              |                   | Doubles capacity | (Extra capacity) | elements after materialization.    |
+--------------+-------------------+------------------+------------------+------------------------------------+

3. HOW IT WORKS INTERNALLY:
   - .ToArray(): Allocates an array of the exact size needed (or resizes internally
     using an array pool / exponential growth if length is unknown) and returns T[].
   - .ToList(): Constructs an internal List<T> and populates it via an enumerator.

4. WHEN NOT TO USE & COMMON PITFALLS:
   - Calling .ToArray() or .ToList() prematurely in a query pipeline: doing so
     terminates deferred execution and buffers unnecessary records into RAM.
   - Calling .ToList() just to read data: if you never call .Add() or .Remove(),
     an array (ToArray) or staying on IEnumerable avoids unused capacity overhead.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Conversion.Shared;

namespace LinqDeepDive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Initial deferred sequence
            IEnumerable<Shipping> shippings = ShippingRepository.AllAsList;

            // =============================================================
            // 1. .ToArray() - Fixed-size Memory Buffer
            // =============================================================
            // Immediately enumerates 'shippings' and stores them in an array.
            // Uses .Length and supports direct indexer access.
            Console.WriteLine("=== 1. Materializing into an Array ===");
            Shipping[] shippingArray = shippings.ToArray();
            Console.WriteLine($"Total shippings : {shippingArray.Length}");
            Console.WriteLine("First shipping  :");
            shippingArray[0].Start();

            // =============================================================
            // 2. .ToList() - Resizable Dynamic Collection
            // =============================================================
            // Immediately enumerates 'shippings' and stores them in a List<T>.
            // Uses .Count and allows future additions/removals.
            Console.WriteLine("\n=== 2. Materializing into a List ===");
            List<Shipping> shippingList = shippings.ToList();
            Console.WriteLine($"Total shippings : {shippingList.Count}");
            Console.WriteLine("First shipping  :");
            shippingList[0].Start();
        }
    }
}