/*
====================================================================================================
               LINQ CONCATENATION - Concat() with Projected Properties (Select)
====================================================================================================

1. THE CORE IDEA:
   When concatenating collections where you only need specific fields (e.g., just question titles 
   or a lightweight DTO), you can combine Concat() with Select().

   Pipeline Ordering Options:
   Option A (Project then Concat):
     quiz1.Select(q => q.Title).Concat(quiz2.Select(q => q.Title))
     - Projects each sequence into strings first, then appends them.
     - Type signature: IEnumerable<string>.Concat(IEnumerable<string>)

   Option B (Concat then Project):
     quiz1.Concat(quiz2).Select(q => q.Title)
     - Appends the entire object sequences first, then runs a single Select projection across all items.
     - Cleaner, requires only one Select lambda, and yields the exact same result.

   Data Flow:
   quiz1 (Question) ──► Select(Title) ──► ["Q #1", "Q #2", "Q #3"] ──┐
                                                                      ├──► Concat() ──► Combined Titles
   quiz2 (Question) ──► Select(Title) ──► ["Q #2", "Q #4"]        ──┘

2. HOW IT WORKS INTERNALLY:
   - Type Matching Requirement: Concat() operates on two sequences of the exact same generic type `T`.
     Both sides must yield the same projected type (e.g., both must yield `string`, or both must 
     yield the exact same anonymous type / DTO structure).
   - Execution Model: Fully deferred streaming. No string buffers or intermediate arrays are created.

3. COMMON PITFALLS:
   - Type Mismatches: Attempting to Concat two different projected shapes will result in a compiler error.
   - Code Duplication: Writing `.Select(...)` twice (once on each sequence) instead of concatenating 
     first and projecting once: `quiz1.Concat(quiz2).Select(...)`.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Concat.Shared;

namespace _2__Concat_Projected_Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------------
            // 1. Source Sequences
            // -------------------------------------------------------------------------
            IEnumerable<Question> quiz1 = QuestionBank.Randomize(3);
            IEnumerable<Question> quiz2 = QuestionBank.Randomize(2);

            // -------------------------------------------------------------------------
            // 2. Option A: Project Each Sequence First, Then Concat
            // -------------------------------------------------------------------------
            // Each sequence projects into IEnumerable<string> before concatenating:
            IEnumerable<string> questionTitlesA = quiz1.Select((Question q) => q.Title)
                .Concat(quiz2.Select((Question q) => q.Title));

            Console.WriteLine("--- Option A: Project Then Concat ---");
            foreach (string title in questionTitlesA)
            {
                Console.WriteLine(title);
            }

            // -------------------------------------------------------------------------
            // 3. Option B: Concat First, Then Project Once (Cleaner Alternative)
            // -------------------------------------------------------------------------
            // Appends the two sequences first, requiring only one Select lambda:
            IEnumerable<string> questionTitlesB = quiz1.Concat(quiz2)
                .Select((Question q) => q.Title);

            Console.WriteLine("\n--- Option B: Concat Then Project Once ---");
            foreach (string title in questionTitlesB)
            {
                Console.WriteLine(title);
            }
        }
    }
}