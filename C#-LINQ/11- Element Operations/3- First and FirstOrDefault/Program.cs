/*
====================================================================================================
                 LINQ ELEMENT OPERATIONS - First & FirstOrDefault
====================================================================================================

1. THE PROBLEM:
   Applications frequently need to retrieve the initial item in a sequence or find the first element
   satisfying a specific business condition (e.g., finding the first question with a specific ID).
   
   Historically, writing this imperatively required manual loop iteration with early exit flags:

       Question found = null;
       foreach (Question q in questions)
       {
           if (q.Title.Length > 20)
           {
               found = q;
               break;
           }
       }
       if (found == null)
       {
           throw new InvalidOperationException("No matching element found.");
       }

   Handling empty sequences or missing matches manually creates redundant branching logic.

2. THE CORE IDEA:
   - First(): Returns the first element of a sequence (or the first element matching a predicate).
     Throws `InvalidOperationException` if the sequence is empty or no element matches the condition.
   - FirstOrDefault(): Returns the first matching element, or a fallback value if no element is found.
     - In .NET Framework / Standard: Falls back strictly to `default(T)` (i.e., `null` for reference types).
     - In .NET 6+: Supports an explicit fallback overload: `FirstOrDefault(defaultValue)` and 
       `FirstOrDefault(predicate, defaultValue)`.

   Execution Flow:
   Sequence has matches:
   [ Q1, Q2, Q3 ] ──► First()          ──► Yields Q1 (Stops scanning immediately)
   [ Q1, Q2, Q3 ] ──► FirstOrDefault() ──► Yields Q1 (Stops scanning immediately)

   Sequence is empty / No match:
   [ ]            ──► First()                           ──► Throws InvalidOperationException
   [ ]            ──► FirstOrDefault()                  ──► Returns default(T) (null for Question)
   [ ]            ──► FirstOrDefault(Question.Default)  ──► Returns Question.Default (.NET 6+)

3. HOW IT WORKS INTERNALLY:
   - Immediate Execution: Consumes elements only until the first match is encountered.
   - Short-Circuit Evaluation: 
       - Parameterless `First()` on an `IList<T>`: Directly accesses index `[0]` in O(1) time.
       - Non-list or predicate overload: Obtains an `IEnumerator<T>` and advances with `MoveNext()`.
         The moment the predicate evaluates to `true`, it captures the current element and exits 
         immediately without evaluating remaining items.
   - Complexity: Best case O(1), Worst case O(N) when scanning to the end or finding no matches.

4. COMMON PITFALLS:
   - Combining .Where() with .First(): Writing `questions.Where(predicate).First()` allocates an 
     intermediate filtering iterator. Instead, use the integrated predicate overload directly: 
     `questions.First(predicate)`.
   - The Parameterless FirstOrDefault Null Pitfall: On reference types, `FirstOrDefault()` returns 
     `null` when no match is found. Directly accessing members (`questions.FirstOrDefault().Title`) 
     causes a `NullReferenceException`.
   - Value Type Ambiguity: On primitive types like `int`, `FirstOrDefault()` returns `0` when no match 
     is found, making it impossible to distinguish between a matching `0` and a missing result without 
     supplying an explicit fallback or checking beforehand.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Elements.Shared;

namespace _2__First_FirstOrDefault
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Question> questions = QuestionBank.All;

            // -------------------------------------------------------------------------
            // 1. First (Strict Retrieval)
            // -------------------------------------------------------------------------
            // Parameterless: Grabs the very first element:
            Question firstQuestion = questions.First();
            Console.WriteLine("--- First() ---");
            Console.WriteLine(firstQuestion.Title);

            // Predicate Overload: Grabs the first element matching a condition:
            Question firstMatching = questions.First((q) => q.Choices.Count == 4);
            Console.WriteLine("\n--- First(predicate) ---");
            Console.WriteLine(firstMatching.Title);

            // Throws InvalidOperationException if the sequence is empty or no match exists:
            try
            {
                Question missing = questions.First((q) => q.Title.StartsWith("NonExistent"));
                Console.WriteLine(missing.Title);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"\nFirst() Exception caught: {ex.GetType().Name} - {ex.Message}");
            }

            // -------------------------------------------------------------------------
            // 2. FirstOrDefault (Safe Retrieval with default(T))
            // -------------------------------------------------------------------------
            // Parameterless / Single Predicate: Returns null for Question when no match exists:
            Question safeMissing = questions.FirstOrDefault(( q) => q.Title.StartsWith("NonExistent"));

            Console.WriteLine("\n--- FirstOrDefault(predicate) ---");
            if (safeMissing == null)
            {
                Console.WriteLine("No match found. Safely returned default(Question) (null).");
            }

            // -------------------------------------------------------------------------
            // 3. FirstOrDefault with Explicit Default Value (.NET 6+)
            // -------------------------------------------------------------------------
            // Signature: FirstOrDefault(Func<T, bool> predicate, T defaultValue)
            // Eliminates the need for manual '?? Question.Default' null coalescing:
            Question safeWithFallback = questions.FirstOrDefault(
                (q) => q.Title.StartsWith("NonExistent"),
                Question.Default
            );

            Console.WriteLine("\n--- FirstOrDefault(predicate, defaultValue) ---");
            Console.WriteLine(safeWithFallback.Title);

            // -------------------------------------------------------------------------
            // 4. Value Type Ambiguity Solution
            // -------------------------------------------------------------------------
            IEnumerable<int> examScores = new List<int> { 0, 75, 88 };

            // Ambiguous: default of int is 0 which is returned in this case
            // so was 0 found, or did it fail to find an element?
            int scoreResult = examScores.FirstOrDefault((s) => s < 0);
            Console.WriteLine($"\nDefault value type result (ambiguous 0): {scoreResult}");

            // Resolved with explicit default parameter:
            int distinctFallback = examScores.FirstOrDefault((int s) => s < 0, -1);
            Console.WriteLine($"Explicit fallback result: {distinctFallback}"); // -1 indicates missing
        }
    }
}