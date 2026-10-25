/*
====================================================================================================
               LINQ CONCATENATION - Combining More Than Two Sequences
====================================================================================================

1. THE CORE IDEA:
   When concatenating three or more sequences, you have two primary approaches:

   Approach A: Fluent Chained Concat()
     quiz1.Concat(quiz2).Concat(quiz3)
     - Clean when chaining a small, fixed number of known collections.
     - Works entirely via method syntax chaining.

   Approach B: SelectMany() Flattening
     new[] { quiz1, quiz2, quiz3 }.SelectMany(q => q)
     - The senior-level approach when combining a dynamic list of collections (e.g., List<List<T>>),
       or an arbitrary number of collections gathered at runtime.

   Comparison:
   ┌────────────────────────┬─────────────────────────┬────────────────────────────────────────┐
   │ Technique              │ Best Used When...       │ Syntax Pattern                         │
   ├────────────────────────┼─────────────────────────┼────────────────────────────────────────┤
   │ Chained Concat()       │ Fixed, few sequences    │ seq1.Concat(seq2).Concat(seq3)         │
   │ SelectMany()           │ Dynamic / many sequences│ collectionOfSequences.SelectMany(s=>s) │
   └────────────────────────┴─────────────────────────┴────────────────────────────────────────┘

2. HOW IT WORKS INTERNALLY:
   - Chained Concat creates nested iterator wrappers: enumerates seq1, then seq2, then seq3.
   - Both techniques stream items sequentially using deferred execution (`yield return`).
   - Neither approach buffers intermediate items in memory.

3. COMMON PITFALLS:
   - Excessive Chaining: Chaining 10+ `.Concat()` calls creates deep nested iterator layers.
     Use `SelectMany()` instead for large or dynamic sets of collections.
   - Null Collections: If any sequence in the chain or array is null, enumeration throws
     an ArgumentNullException.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Concat.Shared;

namespace _3__Concat_Multiple_Sequences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------------
            // 1. Source Sequences (Three Separate Batches)
            // -------------------------------------------------------------------------
            IEnumerable<Question> quiz1 = QuestionBank.Randomize(2);
            IEnumerable<Question> quiz2 = QuestionBank.Randomize(2);
            IEnumerable<Question> quiz3 = QuestionBank.Randomize(1);

            // -------------------------------------------------------------------------
            // 2. Approach A: Chained Concat() (Best for Known, Fixed Sequences)
            // -------------------------------------------------------------------------
            IEnumerable<Question> chainedQuiz = quiz1.Concat(quiz2).Concat(quiz3);

            Console.WriteLine("--- Approach A: Chained Concat() ---");
            foreach (Question q in chainedQuiz)
            {
                Console.WriteLine(q.Title);
            }

            // -------------------------------------------------------------------------
            // 3. Approach B: SelectMany() (Best for Dynamic Lists of Collections)
            // -------------------------------------------------------------------------
            List<IEnumerable<Question>> allQuizzes = new List<IEnumerable<Question>>
            {
                quiz1,
                quiz2,
                quiz3
            };

            // Flattens the collection of sequences into a single continuous stream:
            IEnumerable<Question> flattenedQuiz = allQuizzes.SelectMany((IEnumerable<Question> batch) => batch);

            Console.WriteLine("\n--- Approach B: Dynamic SelectMany() Flattening ---");
            foreach (Question q in flattenedQuiz)
            {
                Console.WriteLine(q.Title);
            }
        }
    }
}