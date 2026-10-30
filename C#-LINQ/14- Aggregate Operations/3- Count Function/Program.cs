/*
====================================================================================================
                        LINQ AGGREGATION - Count() and Count(predicate)
====================================================================================================

1. THE CORE IDEA:
   `Count()` returns the total number of items in a collection.

   Instead of pulling a whole list into memory just to figure out how many items exist,
   or writing a manual counter with `foreach`, `Count()` gives you a direct tally.

   The 2 Overloads:
   ┌──────────┬────────────────────────┬─────────────────────────────────────────────────────────┐
   │ Overload │ Syntax                 │ What It Does                                            │
   ├──────────┼────────────────────────┼─────────────────────────────────────────────────────────┤
   │ 1        │ source.Count()         │ Counts all items in the sequence.                       │
   │ 2        │ source.Count(x => ...) │ Counts only the items that satisfy the boolean filter.  │
   └──────────┴────────────────────────┴─────────────────────────────────────────────────────────┘

   Data Flow (Counting questions with more than 2 choices):
   
     [ Q1: 2 choices ] ──► (Filter: Choices.Count > 2) ──► False (Skip)
     [ Q2: 4 choices ] ──► (Filter: Choices.Count > 2) ──► True  ──► Counter + 1
     [ Q3: 3 choices ] ──► (Filter: Choices.Count > 2) ──► True  ──► Counter + 1
     
     Final Count = 2

2. HOW IT WORKS INTERNALLY:
   - Immediate execution: Inspects the collection to calculate the count right away.
   - Smart Optimization (Overload 1):
     Before running an O(N) loop, .NET checks if the source implements `ICollection<T>` or `IReadOnlyCollection<T>`.
     If it does (like `List<T>` or an array), it directly reads the `.Count` or `.Length` property in O(1) time.
     If the source is a streaming generator or raw `IEnumerable<T>`, it walks the elements with a loop.
   - Overload 2 (`Count(predicate)`):
     Always iterates element-by-element (O(N) time) to evaluate your condition on each item.
   - Overflow Check:
     If the count exceeds `int.MaxValue` (2,147,483,647), use `LongCount()` instead.

3. COMMON PITFALLS:
   - Writing `Where(...).Count()` instead of `Count(...)`:
     `quiz.Where(q => q.CorrectAnswer == 1).Count()` works, but `quiz.Count(q => q.CorrectAnswer == 1)`
     is cleaner and avoids allocating the intermediate `Where` iterator.
   - Calling `Count() > 0` just to check if items exist:
     Using `.Count() > 0` on an unbuffered database stream or generator forces it to count every single row.
     Always use `.Any()` if you only care whether the collection is empty.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Aggregate.Shared;

namespace _2__Count_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Question> quiz = QuestionBank.All;

            // =========================================================================
            // Overload 1: Count() - Total Number of Items
            // =========================================================================
            int totalQuestions = quiz.Count();

            Console.WriteLine("--- Overload 1: Count() ---");
            Console.WriteLine($"Total Questions: {totalQuestions}");

            // =========================================================================
            // Overload 2: Count(predicate) - Count Matching Items
            // =========================================================================
            // Count how many questions have their correct answer set to option 1:
            int questionsWithFirstAnswerCorrect = quiz.Count((q) => q.CorrectAnswer == 1);

            // Count how many questions have a title longer than 15 characters:
            int questionsWithLongTitles = quiz.Count((q) => q.Title.Length > 15);

            Console.WriteLine("\n--- Overload 2: Count(predicate) ---");
            Console.WriteLine($"Questions with CorrectAnswer == 1: {questionsWithFirstAnswerCorrect}");
            Console.WriteLine($"Questions with Title.Length > 15: {questionsWithLongTitles}");

            // =========================================================================
            // Senior Tip: Count(predicate) vs Where().Count()
            // =========================================================================
            // Both give the exact same answer, but Count(predicate) skips the extra iterator:
            int whereCount = quiz.Where((q) => q.CorrectAnswer == 1).Count();
            int directCount = quiz.Count((q) => q.CorrectAnswer == 1);

            Console.WriteLine("\n--- Optimization Comparison ---");
            Console.WriteLine($"Where().Count(): {whereCount}");
            Console.WriteLine($"Count(predicate): {directCount}");
        }
    }
}