/*
====================================================================================================
                        LINQ GENERATION - Enumerable.Range()
====================================================================================================

1. THE PROBLEM:
   Workflows frequently require a sequential sequence of numbers—such as paging offsets, question 
   indexes, or iteration counters. The legacy imperative approach required pre-allocating an array 
   or list and filling it manually via an index loop:

       int[] numbers = new int[10];
       for (int i = 0; i < 10; i++)
       {
           numbers[i] = i + 1;
       }

   This legacy approach suffers from two drawbacks:
     - Verbose boilerplate to initialize and manage index boundaries.
     - Eager memory allocation: The entire array/list is allocated upfront in memory even if only a 
       fraction of the numbers will actually be consumed or if iteration terminates early.

2. THE CORE IDEA:
   Enumerable.Range(start, count) is a static factory method that manufactures a sequential progression 
   of integers on demand. It uses deferred execution, generating each integer on-the-fly during 
   iteration with zero upfront collection allocation.

   Legacy Loop vs. Enumerable.Range:
   new int[5] + for loop ──► Allocates 5 contiguous array slots on Heap ──► Populates imperatively
   Enumerable.Range(1, 5) ──► Allocates 0 array slots (yields 1, 2, 3, 4, 5 lazily via iterator)

3. HOW IT WORKS INTERNALLY:
   - Execution Model: Deferred execution via an iterator block (`yield return`).
   - Signature: `Enumerable.Range(int start, int count)`
     - `start`: The value of the first integer in the sequence.
     - `count`: The number of sequential integers to generate (NOT the end value).
   - Boundary Validation:
     - `count < 0` throws `ArgumentOutOfRangeException`.
     - `(long)start + count - 1 > int.MaxValue` throws `ArgumentOutOfRangeException` (prevents integer overflow).
   - Complexity: O(1) auxiliary memory space, O(N) linear time during traversal.

4. COMMON PITFALLS:
   - Confusing 'Count' with 'End Value': `Enumerable.Range(1, 10)` generates numbers 1 through 10 (10 numbers). 
     However, `Enumerable.Range(5, 10)` generates 5 through 14 (10 numbers), not 5 through 10.
   - Query Syntax Absence: Like all factory operators, there is no C# query syntax keyword for Range.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Generation.Shared;

namespace _5__Enumerable.Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------------
            // 1. The Legacy Imperative Way (Array + Loop)
            // -------------------------------------------------------------------------
            // Requires manual allocation, index bookkeeping, and eager heap storage:
            int[] legacyRange = new int[5];
            for (int i = 0; i < legacyRange.Length; i++)
            {
                legacyRange[i] = i; // generates indexes 0, 1, 2, 3, 4
            }

            Console.WriteLine("--- Legacy Imperative Array Output ---");
            foreach (int index in legacyRange)
            {
                Console.Write($"{index} ");
            }
            Console.WriteLine("\n");

            // -------------------------------------------------------------------------
            // 2. The Modern LINQ Way: Enumerable.Range()
            // -------------------------------------------------------------------------
            // Synthesizes sequence on-the-fly: Start at 0, generate 5 sequential integers:
            IEnumerable<int> questionIndexes = Enumerable.Range(0, 5);

            Console.WriteLine("--- Enumerable.Range Output ---");
            foreach (int index in questionIndexes)
            {
                Console.Write($"{index} ");
            }
            Console.WriteLine("\n");

            // -------------------------------------------------------------------------
            // 3. Real Use Case
            // -------------------------------------------------------------------------
            // Pass the generated range sequence directly into the repository slice method:
            List<Question> selectedQuestions = QuestionBank.GetQuestionRange(questionIndexes);

            Console.WriteLine("--- Loaded Questions Using Generated Range ---");
            selectedQuestions.ToQuiz();
        }
    }
}