
/*
====================================================================================================
                        LINQ GENERATION - Enumerable.Repeat()
====================================================================================================

1. THE PROBLEM:
   Workflows often need a sequence populated with default or placeholder data. However, there are 
   two fundamentally different requirements developers run into:
     - Requirement A: Creating distinct, independent objects that can be modified individually.
     - Requirement B: Reusing an identical instance or value multiple times across a stream.

2. THE CORE IDEA:
   Enumerable.Repeat(element, count) manufactures an IEnumerable<T> that yields the exact same 
   supplied element 'count' times using deferred execution.

   Use Case Comparison (Distinct Objects vs. Reused Reference):
   ┌──────────────────────────────────┬─────────────────────────────────────────────────────────────┐
   │ Approach                         │ Memory & Reference Behavior                                 │
   ├──────────────────────────────────┼─────────────────────────────────────────────────────────────┤
   │ for loop + new Question()        │ Allocates N distinct objects on the heap.                   │
   │                                  │ ReferenceEquals(item[0], item[1]) == False                  │
   ├──────────────────────────────────┼─────────────────────────────────────────────────────────────┤
   │ Enumerable.Repeat(instance, N)   │ Allocates 0 extra objects. Yields the SAME reference N times.│
   │                                  │ ReferenceEquals(item[0], item[1]) == True                   │
   └──────────────────────────────────┴─────────────────────────────────────────────────────────────┘

3. HOW IT WORKS INTERNALLY:
   - Execution Model: Deferred execution via an iterator block (`yield return`).
   - Complexity: O(1) auxiliary space, O(N) iteration time.
   - For reference types, it yields the original memory address repeatedly without cloning.

4. COMMON PITFALLS:
   - Shared Mutation: Because reference types share one pointer in Repeat(), modifying a property 
     on one element changes it for all elements in that repeated sequence.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Generation.Shared;

namespace _6__Enumerable.Repeat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------------
            // Use Case 1: Distinct Instances (When objects must mutate independently)
            // -------------------------------------------------------------------------
            List<Question> independentQuestions = new List<Question>();
            for (int i = 0; i < 5; i++)
            {
                independentQuestions.Add(new Question());
            }

            // Each element is an entirely separate instance on the heap:
            bool isSameLoopInstance = ReferenceEquals(independentQuestions[0], independentQuestions[1]);
            Console.WriteLine($"Loop with new Question() ReferenceEquals: {isSameLoopInstance}"); // False

            // -------------------------------------------------------------------------
            // Use Case 2: Reusing the Same Reference (Enumerable.Repeat)
            // -------------------------------------------------------------------------
            // Yields the single Question.Default instance 5 times without allocating new objects:
            IEnumerable<Question> repeatedQuestions = Enumerable.Repeat(Question.Default, 5);

            Question firstItem = repeatedQuestions.ElementAt(0);
            Question secondItem = repeatedQuestions.ElementAt(1);

            bool isSameRepeatInstance = ReferenceEquals(firstItem, secondItem);
            Console.WriteLine($"Enumerable.Repeat ReferenceEquals: {isSameRepeatInstance}"); // True

            // -------------------------------------------------------------------------
            // Use Case 3: Value Types (Primitives)
            // -------------------------------------------------------------------------
            // Value types are simply copied by value:
            IEnumerable<int> repeatedScores = Enumerable.Repeat(100, 3);

            Console.WriteLine("--- Repeated Primitive Values ---");
            foreach (int score in repeatedScores)
            {
                Console.WriteLine($"Score: {score}");
            }
        }
    }
}