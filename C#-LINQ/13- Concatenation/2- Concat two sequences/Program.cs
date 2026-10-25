/*
====================================================================================================
                        LINQ CONCATENATION OPERATION - Concat()
====================================================================================================

1. THE CORE IDEA:
   Enumerable.Concat appends one sequence to another, returning a single combined sequence 
   containing all elements from the first source followed directly by all elements from the second.

   - It does NOT deduplicate elements (unlike Union). Duplicate items are retained.
   - It preserves original ordering: all elements of sequence A, then all elements of sequence B.

   Data Flow:
   Sequence A: [ Q1, Q2 ]
   Sequence B: [ Q2, Q3 ]
   Concat():   [ Q1, Q2, Q2, Q3 ]  <-- Duplicate Q2 is retained in place!

   Concat vs. Union:
   ┌──────────────────────┬──────────────────────┬─────────────────────────────────────┐
   │ Operator             │ Duplicates Handled?  │ Output Order                        │
   ├──────────────────────┼──────────────────────┼─────────────────────────────────────┤
   │ Concat()             │ Kept (No filtering)  │ Strict: Sequence A, then Sequence B │
   │ Union()              │ Removed (Distinct)   │ Set-based (Unspecified / Distinct)  │
   └──────────────────────┴──────────────────────┴─────────────────────────────────────┘

2. HOW IT WORKS INTERNALLY:
   - Execution Model: Deferred streaming execution (yield return).
   - Mechanics:
       1. Enumerates all items from the first sequence using `yield return`.
       2. Once the first sequence finishes (`MoveNext()` is false), it enumerates all items 
          from the second sequence using `yield return`.
       3. Neither collection is buffered into an intermediate array or list in memory.
   - Complexity: O(N + M) time, O(1) auxiliary space (pure forward streaming).

3. COMMON PITFALLS:
   - Assuming Deduplication: Expecting Concat() to remove duplicate elements like a set operation.
   - Null Sequences: If either sequence argument is null, Concat() throws an ArgumentNullException 
     immediately upon invocation.
   - Query Syntax Absence: Concat() has no query expression keyword in C#; use method syntax.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Concat.Shared;

namespace _1__Concatenation_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Preparing Source Sequences
            // -------------------------------------------------------------------------
            // Partition QuestionBank into two separate subsets:
            // firstBatch  -> Q #1, Q #2
            // secondBatch -> Q #2, Q #3
            IEnumerable<Question> firstBatch = QuestionBank.All.Take(2);
            IEnumerable<Question> secondBatch = QuestionBank.All.Skip(1).Take(2);

            // 2. Concat() - Preserving Order and Duplicates
            // -------------------------------------------------------------------------
            // Appends secondBatch directly to the end of firstBatch:
            IEnumerable<Question> combinedQuiz = firstBatch.Concat(secondBatch);

            Console.WriteLine("\n--- Combined Quiz via Concat() (Duplicates Preserved) ---");
            foreach (Question q in combinedQuiz)
            {
                Console.WriteLine(q);
            }

            // 3. Deferred Execution Demonstration
            // -------------------------------------------------------------------------
            List<Question> dynamicFirstList = new List<Question> { QuestionBank.All.First() };
            List<Question> dynamicSecondList = new List<Question> { QuestionBank.All.Last() };

            // Query definition only (no enumeration has occurred yet):
            IEnumerable<Question> dynamicConcat = dynamicFirstList.Concat(dynamicSecondList);

            // Mutate the underlying source list after defining Concat():
            dynamicFirstList.Add(QuestionBank.All.ElementAt(1));

            // The deferred pipeline reads updated source collections upon enumeration:
            Console.WriteLine("\n--- Deferred Execution Demonstration ---");
            Console.WriteLine($"Dynamic Concat Count: {dynamicConcat.Count()}"); // Output: 3
        }
    }
}