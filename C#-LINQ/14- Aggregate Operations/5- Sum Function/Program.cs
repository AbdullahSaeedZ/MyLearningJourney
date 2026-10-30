/*
====================================================================================================
                        LINQ AGGREGATION - Sum()
====================================================================================================

1. THE CORE IDEA:
   `Sum()` calculates the total numeric sum of all values in a sequence.

   - It can sum primitive numeric collections directly (e.g., `IEnumerable<int>`).
   - It can extract and sum a specific numeric property from a sequence of objects using a selector 
     lambda (e.g., `quiz.Sum(q => q.Choices.Count)`).

   The 2 Common Patterns:
   ┌──────────┬─────────────────────────────┬────────────────────────────────────────────────────────┐
   │ Pattern  │ Syntax                      │ What It Does                                           │
   ├──────────┼─────────────────────────────┼────────────────────────────────────────────────────────┤
   │ Direct   │ numbers.Sum()               │ Adds all numeric elements together directly.           │
   │ Selector │ source.Sum(item => item.Num)│ Projects each object to a number, then sums them up.   │
   └──────────┴─────────────────────────────┴────────────────────────────────────────────────────────┘

   Data Flow (Summing all choices across questions):
   
     [ Q1: 2 Choices ] ──► selector: q.Choices.Count ──► 2 ──┐
     [ Q2: 2 Choices ] ──► selector: q.Choices.Count ──► 2 ──┼──► Sum() ──► Total: 6
     [ Q3: 2 Choices ] ──► selector: q.Choices.Count ──► 2 ──┘

2. HOW IT WORKS INTERNALLY:
   - Execution Model: Immediate execution (O(N) single forward pass).
   - Empty Sequence Handling:
     Unlike `Average()`, `Min()`, or `Max()` (which crash on empty sequences), `Sum()` on an 
     empty collection safely returns `0`.
   - Nullable Handling:
     `Sum()` has overloads for nullable numerics (e.g., `int?`). Any `null` value encountered 
     during enumeration is simply skipped (treated as 0) without throwing a NullReferenceException.

3. COMMON PITFALLS:
   - Arithmetic Overflow:
     Standard `Sum()` on `int` values accumulates inside an un-checked 32-bit integer block. If the 
     accumulated total exceeds `int.MaxValue` (2,147,483,647), it throws an `OverflowException`.
     To prevent this on large sets, cast or project to `long`: `source.Sum(x => (long)x.Amount)`.
   - Unnecessary Intermediate Select:
     Writing `quiz.Select(q => q.Choices.Count).Sum()` works, but passing the selector directly 
     into `quiz.Sum(q => q.Choices.Count)` eliminates the intermediate `Select` iterator allocation.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Aggregate.Shared;

namespace _4__Sum_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> quiz = QuestionBank.All;

            // =========================================================================
            // 1. Direct Sum() on Numeric Collections
            // =========================================================================
            List<int> pointsPerQuestion = new List<int> { 10, 20, 15, 25 };

            int totalExamScore = pointsPerQuestion.Sum();

            Console.WriteLine("--- 1. Direct Sum() ---");
            Console.WriteLine($"Total Exam Score: {totalExamScore}"); // 70

            // =========================================================================
            // 2. Sum(selector) on Complex Objects
            // =========================================================================
            // Sum all available choices across the entire quiz:
            int totalChoicesOffered = quiz.Sum((Question q) => q.Choices.Count);

            // Sum the total character count of all question titles:
            int totalTitleCharacters = quiz.Sum((Question q) => q.Title.Length);

            Console.WriteLine("\n--- 2. Sum with Selector ---");
            Console.WriteLine($"Total Choices Across All Questions: {totalChoicesOffered}");
            Console.WriteLine($"Total Title Character Count: {totalTitleCharacters}");

            // =========================================================================
            // 3. Empty Sequence Behavior (Safe Default)
            // =========================================================================
            List<int> emptyList = new List<int>();

            // Returns 0 without throwing an InvalidOperationException:
            int emptyTotal = emptyList.Sum();

            Console.WriteLine("\n--- 3. Empty Sequence Safety ---");
            Console.WriteLine($"Sum on Empty Collection: {emptyTotal}"); // 0

            // =========================================================================
            // 4. Large Data / Overflow Prevention Pattern
            // =========================================================================
            List<int> largeValues = new List<int> { int.MaxValue - 10, 20 };

            // Project to long so the sum accumulates safely inside a 64-bit container:
            long safeTotal = largeValues.Sum((int n) => (long)n);

            Console.WriteLine("\n--- 4. Overflow Safe Sum ---");
            Console.WriteLine($"Safe 64-bit Sum: {safeTotal}");
        }
    }
}