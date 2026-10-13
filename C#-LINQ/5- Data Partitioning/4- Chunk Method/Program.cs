
/*
====================================================================================================
                        LINQ DATA PARTITIONING - CHUNK() (.NET 6+)
====================================================================================================

1. THE PROBLEM:
   You need to process data in fixed-size batches (e.g., sending batch emails, bulk DB inserts,
   calling external APIs with payload limits, or rendering grid rows).
   Before Chunk(), developers wrote boilerplate loops, nested Skip/Take combinations, or manual
   index tracking to split collections into batches.

2. THE CORE IDEA:
   Chunk(size) splits an entire sequence into fixed-size arrays without manual index tracking:
   - Chunk(size) : Returns an IEnumerable<T[]> where each inner array contains at most 'size' items.
   - The final chunk will contain whatever remains (it does not require padding).

   ASCII Diagram:

   Input (10 items): [ 01 ] [ 02 ] [ 03 ] [ 04 ] [ 05 ] [ 06 ] [ 07 ] [ 08 ] [ 09 ] [ 10 ]
   
   Chunk(3):
   Batch 1: [ 01 ] [ 02 ] [ 03 ]  (Full chunk: length = 3)
   Batch 2: [ 04 ] [ 05 ] [ 06 ]  (Full chunk: length = 3)
   Batch 3: [ 07 ] [ 08 ] [ 09 ]  (Full chunk: length = 3)
   Batch 4: [ 10 ]                (Remainder chunk: length = 1)

3. HOW IT WORKS INTERNALLY:
   - Iterates through the source sequence while maintaining a pooled or newly allocated array of 'size'.
   - Fills the array until it reaches capacity or the source sequence completes.
   - Uses `yield return` to stream out each filled `T[]` array lazily.
   - If the last partition does not completely fill the buffer, it resizes the array to fit
     only the actual remaining elements before yielding.

4. COMMON PITFALLS:
   - Size <= 0: Passing a size less than 1 throws an ArgumentOutOfRangeException.
   - Memory Allocation: Each chunk yielded is an actual array allocation (`T[]`).
   - Chunk vs GroupBy: Do not use GroupBy for sequential batching. GroupBy groups by keys;
     Chunk partitions sequentially by position.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using DataPartitioning.Shared;

namespace _4__Chunk_Method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> employees = Repository.LoadEmployees();

            Console.WriteLine("==================================================================");
            Console.WriteLine("                LINQ PARTITIONING: CHUNK DEMO                     ");
            Console.WriteLine("==================================================================\n");

            // =========================================================================
            // 1. Chunk(size)
            // Goal: Split the employee collection into batches of 10.
            // Why Chunk(10): Returns an IEnumerable<Employee[]> where each element
            // is an array of up to 10 employees, ready for batch processing.
            // =========================================================================
            Console.WriteLine("================ Chunk(10) ================\n");

            IEnumerable<Employee[]> employeeBatches = employees.Chunk(10);

            int batchNumber = 1;

            // Outer loop: iterates over each batch (Employee[] array)
            foreach (Employee[] batch in employeeBatches)
            {
                Console.WriteLine($"--- Processing Batch #{batchNumber} (Count: {batch.Length}) ---");

                // Inner loop: iterates over individual employees inside the current batch
                foreach (Employee emp in batch)
                {
                    Console.WriteLine(emp);
                }

                Console.WriteLine();
                batchNumber++;
            }
        }
    }
}