/*
====================================================================================================
                  LINQ ELEMENT OPERATIONS - Last & LastOrDefault
====================================================================================================

1. THE PROBLEM:
   Workflows frequently require reading the terminal element of a sequence or finding the last 
   item that satisfies a specific condition (e.g., retrieving the latest update, the final question 
   in an exam section, or the last error logged).

   Historically, extracting the last element from an arbitrary IEnumerable<T> imperatively required 
   either:
     - Buffering the entire sequence into a temporary list or array (`list[list.Count - 1]`), 
       which wastes memory.
     - Iterating through the sequence while constantly overwriting a tracking variable until the 
       loop finishes.

   Manual checks were also required to avoid exceptions when sequences were empty.

2. THE CORE IDEA:
   - Last(): Returns the last element of a sequence (or the last element matching a predicate).
     Throws `InvalidOperationException` if the sequence is empty or no match is found.
   - LastOrDefault(): Returns the last element, or a fallback value if no element matches.
     - Parameterless / Single Predicate: Returns `default(T)` (`null` for reference types).
     - Explicit Default Overload (.NET 6+): `LastOrDefault(defaultValue)` and 
       `LastOrDefault(predicate, defaultValue)`.

   Execution Flow:
   Sequence has matches:
   [ Q1, Q2, Q3 ] ──► Last()          ──► Returns Q3
   [ Q1, Q2, Q3 ] ──► LastOrDefault() ──► Returns Q3

   Sequence is empty / No match:
   [ ]            ──► Last()                           ──► Throws InvalidOperationException
   [ ]            ──► LastOrDefault()                  ──► Returns default(T) (null for Question)
   [ ]            ──► LastOrDefault(Question.Default)  ──► Returns Question.Default (.NET 6+)

3. HOW IT WORKS INTERNALLY (The Full-Scan Tradeoff):
   - Execution Model: Immediate execution.
   - IList<T> Optimization:
       - Parameterless `Last()` on an `IList<T>`: Directly evaluates `list[list.Count - 1]` in O(1) time.
   - Forward-Only Sequences / Predicates:
       - LINQ does not navigate backwards through an `IEnumerable<T>`. When filtering by a predicate 
         or enumerating a non-list source, `Last()` MUST scan the **entire** sequence from start to finish.
       - It tracks the most recent match in a temporary variable, continually overwriting it until 
         `MoveNext()` returns `false`.
   - Complexity:
       - Best case (Parameterless on `IList<T>`): O(1) time complexity.
       - Predicate or non-list traversal: O(N) linear time complexity (must inspect every item).

4. COMMON PITFALLS:
   - Assuming Early Exit: Unlike `First()`, which stops scanning at the first match, `Last(predicate)` 
     CANNOT short-circuit. It must evaluate every single item in the sequence to ensure there is no 
     later matching item.
   - Modifying In-Memory Collections During Traversal: Modifying the underlying source while `Last()` 
     iterates causes an `InvalidOperationException` (collection was modified).
   - Calling Last() on Infinite Streams: Because it must reach the end, calling `Last()` on an 
     unbounded generator hangs execution indefinitely.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Elements.Shared;

namespace _3__Last_LastOrDefault
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Question> questions = QuestionBank.All;

            // -------------------------------------------------------------------------
            // 1. Last (Strict Retrieval)
            // -------------------------------------------------------------------------
            // Parameterless: Grabs the final element in the collection (O(1) on List<T>):
            Question lastQuestion = questions.Last();
            Console.WriteLine("--- Last() ---");
            Console.WriteLine(lastQuestion.Title);

            // Predicate Overload: Scans through the entire sequence to find the FINAL match:
            Question lastMatching = questions.Last((Question q) => q.Choices.Count == 4);
            Console.WriteLine("\n--- Last(predicate) ---");
            Console.WriteLine(lastMatching.Title);

            // Throws InvalidOperationException if empty or if no match exists:
            try
            {
                Question nonExistent = questions.Last((Question q) => q.Title.StartsWith("NonExistent"));
                Console.WriteLine(nonExistent.Title);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"\nLast() Exception caught: {ex.GetType().Name} - {ex.Message}");
            }

            // -------------------------------------------------------------------------
            // 2. LastOrDefault (Safe Retrieval with default(T))
            // -------------------------------------------------------------------------
            // Returns null for reference types when no item matches:
            Question safeMissing = questions.LastOrDefault((Question q) => q.Title.StartsWith("NonExistent"));

            Console.WriteLine("\n--- LastOrDefault(predicate) ---");
            if (safeMissing == null)
            {
                Console.WriteLine("No match found. Safely returned default(Question) (null).");
            }

            // -------------------------------------------------------------------------
            // 3. LastOrDefault with Explicit Default Value (.NET 6+)
            // -------------------------------------------------------------------------
            // Overload signature: LastOrDefault(Func<T, bool> predicate, T defaultValue)
            Question safeWithFallback = questions.LastOrDefault(
                (Question q) => q.Title.StartsWith("NonExistent"),
                Question.Default
            );

            Console.WriteLine("\n--- LastOrDefault(predicate, defaultValue) ---");
            Console.WriteLine(safeWithFallback.Title);

            // -------------------------------------------------------------------------
            // 4. Value Types Example
            // -------------------------------------------------------------------------
            IEnumerable<int> scoreTimeline = new List<int> { 45, 80, 95 };

            // O(1) jump to index 2:
            int finalScore = scoreTimeline.Last();
            Console.WriteLine($"\nFinal Score: {finalScore}");

            // Explicit fallback for value types when condition produces 0 matches:
            int missingScore = scoreTimeline.LastOrDefault((int s) => s > 100, -1);
            Console.WriteLine($"Missing Score Fallback: {missingScore}"); // -1
        }
    }
}