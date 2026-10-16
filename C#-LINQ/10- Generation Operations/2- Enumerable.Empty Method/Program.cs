/*
====================================================================================================
                        LINQ GENERATION - Enumerable.Empty<T>()
====================================================================================================

1. THE PROBLEM:
   When queries or methods find zero records, returning 'null' forces callers to add defensive 
   checks ('if (result != null)') or risk NullReferenceException. Conversely, returning 
   'new List<T>()' wastes memory by allocating unused objects on the heap.

2. THE CORE IDEA:
   Enumerable.Empty<T>() returns a cached, zero-allocation, empty sequence. It allows safe, linear 
   iteration ('foreach' executes 0 times cleanly) and adheres to the Null Object pattern.

   Null vs. Empty List vs. Enumerable.Empty:
   return null;                   ──► Requires 'if (res != null)' check; crashes on foreach.
   return new List<Question>();   ──► Safe, but wastes heap memory and triggers GC overhead.
   return Enumerable.Empty<T>();  ──► Safe, 0 heap allocations (reuses cached internal array).

   Query Syntax Note:
   Enumerable.Empty<T>() is a static factory method on the Enumerable class. C# query syntax has 
   no keyword equivalent (such as 'empty' or 'from empty'); it must be invoked via method syntax.

3. HOW IT WORKS INTERNALLY:
   - Execution Model: Immediate return of a static cached instance (Array.Empty<T>()).
   - Complexity: O(1) time complexity and O(0) memory allocation.

4. COMMON PITFALLS:
   - Attempting Mutation: The returned sequence is immutable. You cannot add items to it.
   - Using For Non-Empty Defaults: If you need a fallback element when empty, use DefaultIfEmpty().
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Generation.Shared;

namespace _1__Empty_Operation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------------
            // Quick Comparison: new List<T>() vs. Enumerable.Empty<T>()
            // -------------------------------------------------------------------------
            // Unnecessary heap allocation (new object + backing array allocated in memory):
            IEnumerable<Question> listAllocation = new List<Question>();

            // Optimized approach (0 allocations, reuses cached internal singleton):
            IEnumerable<Question> zeroAllocation = Enumerable.Empty<Question>();

            // -------------------------------------------------------------------------
            // Practical Usage Example:
            // -------------------------------------------------------------------------
            // Querying a topic that does not exist returns Enumerable.Empty<Question>():
            IEnumerable<Question> questions = GetQuestionsByTopic("History");

            // Check if results exist cleanly using .Any() rather than null checks:
            if (!questions.Any())
            {
                Console.WriteLine("No questions found for this topic.");
            }

            // Safe iteration: Executes 0 times without null-checks or crashing:
            foreach (Question q in questions)
            {
                Console.WriteLine(q);
            }
        }

        private static IEnumerable<Question> GetQuestionsByTopic(string topic)
        {
            if (topic != "Streaming")
            {
                // Returns a cached empty singleton with 0 heap allocation:
                return Enumerable.Empty<Question>();
            }

            return QuestionBank.All;
        }
    }
}