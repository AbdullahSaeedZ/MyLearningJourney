/*
====================================================================================================
               LINQ ELEMENT OPERATIONS - ElementAt & ElementAtOrDefault
====================================================================================================

1. THE PROBLEM:
   Code often needs to retrieve an element at a specific zero-based index from an arbitrary sequence 
   (`IEnumerable<T>`). When working with an `IList<T>` or array, developers use indexers (`list[i]`). 
   However, raw `IEnumerable<T>` pipelines (such as filtered or deferred LINQ queries) do not expose 
   indexer syntax. 

   Historically, reading a positional element from an `IEnumerable<T>` required manual iteration:

       Question target = null;
       int currentIndex = 0;
       foreach (Question q in questions)
       {
           if (currentIndex == targetIndex)
           {
               target = q;
               break;
           }
           currentIndex++;
       }

   Furthermore, if the requested index is out of bounds, standard indexers throw an exception, 
   requiring defensive count checks (`if (index >= 0 && index < list.Count)`).

2. THE CORE IDEA:
   - ElementAt(index): Returns the element at the specified zero-based index. Throws 
     `ArgumentOutOfRangeException` if the index is negative or greater than/equal to the sequence length.
   - ElementAtOrDefault(index): Returns the element at the specified index, or `default(T)` if the 
     index is out of range. In modern .NET (.NET 6+), it also accepts an explicit fallback value.

   Execution Flow:
   Valid Index (e.g., Index: 1 on 3 items):
   [ Q0, Q1, Q2 ] ──► ElementAt(1)          ──► Returns Q1
   [ Q0, Q1, Q2 ] ──► ElementAtOrDefault(1) ──► Returns Q1

   Out of Range (e.g., Index: 5 on 3 items):
   [ Q0, Q1, Q2 ] ──► ElementAt(5)          ──► Throws ArgumentOutOfRangeException
   [ Q0, Q1, Q2 ] ──► ElementAtOrDefault(5) ──► Returns default(T) (null for Question)

3. HOW IT WORKS INTERNALLY:
   - Immediate Execution: Consumes the sequence up to the index immediately.
   - Type-Check Optimization:
       1. Tests if the source implements `IList<TElement>`. If true, it bypasses enumeration entirely 
          and uses the O(1) indexer directly (`list[index]`).
       2. If the source does NOT implement `IList<TElement>`, it falls back to iterating via 
          `GetEnumerator()`, stepping through elements sequentially until reaching the target index.
   - Complexity: 
       - `IList<T>` sources: O(1) time complexity.
       - Non-list `IEnumerable<T>` sources: O(K) time complexity, where K is the target index.

4. COMMON PITFALLS:
   - Repeated Index Lookups on Non-List Sequences: Calling `ElementAt(i)` inside a loop over a 
     non-list `IEnumerable<T>` turns an O(N) traversal into an O(N^2) quadratic performance bottleneck.
   - Null Dereferencing on Reference Types: `ElementAtOrDefault` returns `null` for reference types 
     when out of bounds. Accessing properties on the result without checking for `null` triggers 
     a `NullReferenceException`.
   - Query Syntax Absence: Element operators are immediate execution terminal methods. They have 
     no C# query syntax keywords and must be invoked using method syntax.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Elements.Shared;

namespace _1__ElementAt_ElementAtOrDefault
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Question> questions = QuestionBank.All;

            // -------------------------------------------------------------------------
            // 1. ElementAt (Strict Retrieval)
            // -------------------------------------------------------------------------
            // Retrieves the element at index 0. O(1) internally because QuestionBank.All is a List<T>.
            Question firstQuestion = questions.ElementAt(0);
            Console.WriteLine("--- ElementAt(0) ---");
            Console.WriteLine(firstQuestion.Title);

            // Attempting to access an index outside the boundaries throws ArgumentOutOfRangeException:
            try
            {
                Question outOfBoundsQuestion = questions.ElementAt(999);
                Console.WriteLine(outOfBoundsQuestion.Title);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"\nElementAt(999) Exception caught: {ex.GetType().Name}");
            }

            // -------------------------------------------------------------------------
            // 2. ElementAtOrDefault (Safe Retrieval)
            // -------------------------------------------------------------------------
            // Parameterless overload: Returns default(T) (null for reference types) when out of bounds.
            Question safeOutOfBounds = questions.ElementAtOrDefault(999);

            Console.WriteLine("\n--- ElementAtOrDefault(999) ---");
            if (safeOutOfBounds == null)
            {
                Console.WriteLine("Index 999 not found. Safely returned default(Question) (null).");
            }

            // -------------------------------------------------------------------------
            // 3. Value Type Behavior with ElementAtOrDefault
            // -------------------------------------------------------------------------
            IEnumerable<int> marks = new List<int> { 85, 92, 78 };
            
            // default(int) evaluates to 0:
            int missingMark = marks.ElementAtOrDefault(10);
            Console.WriteLine($"\nMissing mark (int default): {missingMark}"); // 0

          
        }
    }
}