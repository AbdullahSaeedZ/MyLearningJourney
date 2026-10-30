/*
====================================================================================================
               LINQ AGGREGATION - Max, MaxBy, Min, and MinBy
====================================================================================================

1. THE CORE IDEA:
   These operators find the boundary values (highest or lowest) in a sequence.

   - Max() / Min():
     Returns the actual maximum or minimum VALUE (scalar). 
     Example: "What is the longest title length?" -> Returns 43 (an int).

   - MaxBy() / MinBy() (.NET 6+):
     Returns the entire OBJECT that holds that maximum or minimum value.
     Example: "Which question has the longest title?" -> Returns the entire Question object.

   Comparison:
   ┌───────────┬───────────────────────────────┬──────────────────────────────────────────────┐
   │ Method    │ What It Evaluates             │ What It Returns                              │
   ├───────────┼───────────────────────────────┼──────────────────────────────────────────────┤
   │ Max(x=>k) │ The selector key (e.g., int)  │ The largest scalar key value (int)           │
   │ MaxBy(x=>k│ The selector key (e.g., int)  │ The entire entity (TSource) owning that key  │
   │ Min(x=>k) │ The selector key (e.g., int)  │ The smallest scalar key value (int)          │
   │ MinBy(x=>k│ The selector key (e.g., int)  │ The entire entity (TSource) owning that key  │
   └───────────┴───────────────────────────────┴──────────────────────────────────────────────┘

   Visualizing Max vs. MaxBy:
   
     quiz: [
       Q1 (Title: "What is LINQ?", Length: 13),
       Q2 (Title: "What is C#?", Length: 10),
       Q3 (Title: "What is the Common Language Runtime (CLR)?", Length: 42)
     ]
     
     quiz.Max(q => q.Title.Length)   ──► 42                (Returns the number)
     quiz.MaxBy(q => q.Title.Length) ──► Question Object Q3 (Returns the object)

2. HOW IT WORKS INTERNALLY:
   - Immediate execution: Walks the sequence in a single forward pass (O(N) time).
   - Tracks a single champion variable as it iterates. When an element beats the current
     champion, the champion is updated.
   - Tied values: If multiple items share the exact same maximum/minimum value, `MaxBy` / `MinBy`
     returns the first one encountered in the stream.

3. COMMON PITFALLS:
   - Empty Collections: 
     Calling `Max()` or `Min()` on an empty sequence of value types (like `int`) throws an 
     `InvalidOperationException` ("Sequence contains no elements").
     `MaxBy()` and `MinBy()` return `null` (or `default`) if the source collection is empty 
     and `TSource` is a reference type.
   - Older Workarounds:
     Before .NET 6 introduced `MaxBy`, developers wrote `OrderByDescending(...).FirstOrDefault()`.
     That was wasteful because it sorted the whole list (O(N log N)). `MaxBy` does it in one pass (O(N)).
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Aggregate.Shared;

namespace _3__Max_Min_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> quiz = QuestionBank.All;

            // =========================================================================
            // 1. Max() vs. MaxBy()
            // =========================================================================
            
            // Max(): Returns only the scalar integer (highest title length)
            int longestTitleLength = quiz.Max((q) => q.Title.Length);

            // MaxBy(): Returns the actual Question instance that has the longest title
            Question questionWithLongestTitle = quiz.MaxBy((q) => q.Title.Length);

            Console.WriteLine("--- 1. Max vs MaxBy ---");
            Console.WriteLine($"Max Title Length (Scalar int): {longestTitleLength}");
            Console.WriteLine($"Question With Longest Title (Object): {questionWithLongestTitle.Title}");

            // =========================================================================
            // 2. Min() vs. MinBy() (The Direct Opposite)
            // =========================================================================

            // Min(): Returns only the scalar integer (lowest title length)
            int shortestTitleLength = quiz.Min((q) => q.Title.Length);

            // MinBy(): Returns the actual Question instance that has the shortest title
            Question questionWithShortestTitle = quiz.MinBy((q) => q.Title.Length);

            Console.WriteLine("\n--- 2. Min vs MinBy (Opposite) ---");
            Console.WriteLine($"Min Title Length (Scalar int): {shortestTitleLength}");
            Console.WriteLine($"Question With Shortest Title (Object): {questionWithShortestTitle.Title}");

            // =========================================================================
            // 3. Efficiency Tip: MaxBy() vs OrderByDescending()
            // =========================================================================
            // Avoid this legacy pattern:
            // quiz.OrderByDescending(q => q.Title.Length).FirstOrDefault(); // O(N log N) - Full sort
            
            // Prefer this:
            // quiz.MaxBy(q => q.Title.Length);                              // O(N) - Single pass
        }
    }
}