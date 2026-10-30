/*
====================================================================================================
                        LINQ AGGREGATION - Average()
====================================================================================================

1. THE CORE IDEA:
   `Average()` calculates the arithmetic mean of numeric values in a sequence (Sum / Count).

   - It can calculate the mean directly on numeric collections (e.g., `IEnumerable<int>`).
   - It can extract a numeric property from objects using a selector lambda (e.g., `quiz.Average(q => q.Title.Length)`).
   - Return Types:
       - Running `Average()` on `int` or `long` automatically yields a `double`.
       - Running `Average()` on `decimal` yields a `decimal` to preserve financial precision.
       - Running `Average()` on `float` yields a `float`.

   The 2 Common Patterns:
   ┌──────────┬────────────────────────────────┬─────────────────────────────────────────────────┐
   │ Pattern  │ Syntax                         │ What It Does                                    │
   ├──────────┼────────────────────────────────┼─────────────────────────────────────────────────┤
   │ Direct   │ numbers.Average()              │ Directly averages numeric elements.             │
   │ Selector │ source.Average(x => x.Property)│ Extracts a numeric field, then averages it.     │
   └──────────┴────────────────────────────────┴─────────────────────────────────────────────────┘

   Data Flow (Calculating average title character count):
   
     [ Q1: Length 14 ] ──┐
     [ Q2: Length 13 ] ──┼──► Sum: 70, Count: 3 ──► (70 / 3) ──► Average: 23.333333333333336
     [ Q3: Length 43 ] ──┘

2. HOW IT WORKS INTERNALLY:
   - Execution Model: Immediate execution (O(N) single forward pass).
   - Tracks two accumulator values simultaneously during traversal: running sum and running count.
   - Divides the accumulated sum by the count on completion.
   - Non-Nullable Empty Sequence Crash:
     Unlike `Sum()`, which returns `0` on an empty collection, non-nullable `Average()` crashes with 
     `InvalidOperationException: "Sequence contains no elements"` because dividing by zero is mathematically 
     undefined.
   - Nullable Empty Sequence Handling:
     When invoked on nullable numeric sequences (e.g., `IEnumerable<int?>`), an empty sequence or a 
     sequence containing only nulls safely returns `null` instead of throwing an exception.

3. COMMON PITFALLS:
   - Crashing on Empty Data:
     Calling `.Average()` on collections that may be empty without guarding first (via `.Any()` 
     or casting to a nullable numeric type).
   - Casting Redundancy:
     There is no need to manually cast integers to `(double)` before averaging; the `Average(IEnumerable<int>)` 
     overload returns `double` by default.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Aggregate.Shared;

namespace _5__Average_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> quiz = QuestionBank.All;

            // =========================================================================
            // 1. Direct Average() on Numeric Collections
            // =========================================================================
            List<int> examScores = new List<int> { 85, 92, 78, 90, 88 };

            // Calculates the arithmetic mean; note that the return type is double:
            double averageScore = examScores.Average();

            Console.WriteLine("--- 1. Direct Average() ---");
            Console.WriteLine($"Average Score: {averageScore:F2}"); // 86.60

            // =========================================================================
            // 2. Average(selector) on Complex Objects
            // =========================================================================
            // Calculate the average title length across all questions:
            double averageTitleLength = quiz.Average((Question q) => q.Title.Length);

            // Calculate the average number of choices per question:
            double averageChoicesCount = quiz.Average((Question q) => q.Choices.Count);

            Console.WriteLine("\n--- 2. Average with Selector ---");
            Console.WriteLine($"Average Title Length: {averageTitleLength:F1} characters");
            Console.WriteLine($"Average Choices Per Question: {averageChoicesCount:F1}");

            // =========================================================================
            // 3. Handling Empty Collections Safely
            // =========================================================================
            List<int> unattemptedScores = new List<int>();

            // Pitfall: unattemptedScores.Average() -> Throws InvalidOperationException!

            // Defense Pattern A: Guard check with Any()
            double safeAverageA = unattemptedScores.Any() ? unattemptedScores.Average() : 0.0;

            // Defense Pattern B: Project to nullable int (int?)
            // Returns null instead of throwing an exception:
            double? safeAverageB = unattemptedScores.Average((int score) => (int?)score);

            Console.WriteLine("\n--- 3. Empty Sequence Defensive Handling ---");
            Console.WriteLine($"Safe Average via Any() guard: {safeAverageA}");
            Console.WriteLine($"Safe Average via Nullable selector: {safeAverageB?.ToString() ?? "N/A"}");
        }
    }
}