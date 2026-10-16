/*
====================================================================================================
                        LINQ GENERATION - DefaultIfEmpty()
====================================================================================================

1. THE PROBLEM:
   When streaming or aggregating sequences, receiving an empty collection can break downstream
   logic or UI expectations. For example:
     - Rendering an exam where an empty section causes an empty blank page instead of showing a
       placeholder "No questions assigned" template.
     - Simulating Left Outer Joins in LINQ query syntax, where unmatched outer keys must pair with
       a default or fallback row rather than being dropped entirely.

   Handling this imperatively requires defensive checks:

       if (!questions.Any())
       {
           questions = new List<Question> { Question.Default };
       }

   This approach breaks method chains and introduces branching boilerplate.

2. THE CORE IDEA:
   DefaultIfEmpty() is an extension method that acts as a safety cushion:
     - If the source sequence has elements, it streams the sequence completely untouched.
     - If the source sequence is empty, it returns a new sequence containing exactly ONE element:
       either `default(T)` (parameterless overload) or a supplied explicit fallback object.

   Pipeline Transformation:
   Non-Empty Input: [ Q1, Q2 ] ──► DefaultIfEmpty() ──► [ Q1, Q2 ]
   Empty Input:     [ ]        ──► DefaultIfEmpty() ──► [ default(T) ] (null for reference types)
   Empty Input:     [ ]        ──► DefaultIfEmpty(Question.Default) ──► [ Question.Default ] <- which is a question template, check its class 

3. HOW IT WORKS INTERNALLY:
   - Execution Model: Deferred streaming via an iterator state machine (`yield return`).
   - Mechanics: It calls `GetEnumerator()` on the source. If `MoveNext()` returns `true`, it yields
     that first element and continues yielding the rest of the source. If `MoveNext()` returns
     `false` immediately (empty source), it yields the default/fallback value once and terminates.
   - Complexity: O(1) auxiliary space, O(N) execution time matching source enumeration.

4. COMMON PITFALLS:
   - Parameterless Overload with Reference Types: Calling `DefaultIfEmpty()` without arguments on a
     class sequence (like `IEnumerable<Question>`) yields a sequence containing `null` (`default(Question)`).
     Iterating over it and accessing properties without null checks will cause a NullReferenceException.
     Always provide an explicit fallback instance when working with reference types.
   - Multiple Elements: DefaultIfEmpty never produces multiple default elements; it only emits
     exactly one fallback item if the source is empty.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Generation.Shared;

namespace _4__DefaultIfEmpty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------------
            // 1. Parameterless DefaultIfEmpty() on Value Types
            // -------------------------------------------------------------------------
            IEnumerable<int> emptyNumbers = Enumerable.Empty<int>();

            // For int, default(int) is 0:
            IEnumerable<int> numbersWithFallback = emptyNumbers.DefaultIfEmpty();

            Console.WriteLine("--- Parameterless DefaultIfEmpty on Value Types (int) ---");
            foreach (int num in numbersWithFallback)
            {
                Console.WriteLine($"Number: {num}"); // Prints 0
            }

            // -------------------------------------------------------------------------
            // 2. Parameterless DefaultIfEmpty() on Reference Types (The Null Pitfall)
            // -------------------------------------------------------------------------
            IEnumerable<Question> emptyQuestions = Enumerable.Empty<Question>();

            // WARNING: default(Question) evaluates to null because it is a reference type!
            IEnumerable<Question> questionsWithNullFallback = emptyQuestions.DefaultIfEmpty();

            Console.WriteLine("\n--- Parameterless DefaultIfEmpty on Reference Types ---");
            foreach (Question q in questionsWithNullFallback)
            {
                Console.WriteLine($"Is item null? {q == null}"); // True
                // Accessing q.Title here would throw NullReferenceException!
            }

            // -------------------------------------------------------------------------
            // 3. Method Syntax with Explicit Fallback (Best Practice for Objects)
            // -------------------------------------------------------------------------
            // Pass Question.Default from the shared library as the fallback item:
            IEnumerable<Question> safeQuestions = emptyQuestions.DefaultIfEmpty(Question.Default);

            Console.WriteLine("\n--- Explicit Fallback Object (Question.Default) ---");
            foreach (Question q in safeQuestions)
            {
                Console.WriteLine(q); // Prints the fallback question template safely
            }

            // If the source collection is NOT empty, DefaultIfEmpty() does nothing:
            IEnumerable<Question> actualQuestions = QuestionBank.Randomize(2).DefaultIfEmpty(Question.Default);

            Console.WriteLine($"\nNon-empty source count: {actualQuestions.Count()} (Unmodified)");

        }
    }
}