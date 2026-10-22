/*
====================================================================================================
                        LINQ EQUALITY OPERATIONS - SequenceEqual()
====================================================================================================

1. THE CORE IDEA:
   The primary purpose of Enumerable.SequenceEqual is to compare two collections to determine if 
   they contain the exact same items in the exact same sequence.

   Why not just write manual loops?
   To achieve deep structural comparison between two question lists, you would have to:
     1. Override Equals() and GetHashCode() on the child entity (Choice).
     2. Override Equals() and GetHashCode() on the parent entity (Question).
     3. Write an imperative for/while loop inside Question.Equals() to check the child Choices.
     4. Write yet another for/while loop in your calling code to check the outer Question lists.

   SequenceEqual cuts through that boilerplate. It provides a standardized, pre-built algorithm 
   that takes direct advantage of your overridden Equals() methods:
     - Outer level: sequenceA.SequenceEqual(sequenceB) eliminates the outer loop.
     - Inner level: Choices.SequenceEqual(other.Choices) eliminates the inner loop inside Question.Equals.

   Architecture Diagram:
   
     sequenceA (List<Question>) ──────────────┐
                                              ├──► SequenceEqual() [Outer Pre-built Engine]
     sequenceB (List<Question>) ──────────────┘          │
                                                         ▼
                                            Calls Question.Equals() on each pair
                                                         │
                                                         ▼
                                            Choices.SequenceEqual() [Inner Pre-built Engine]
                                                         │
                                                         ▼
                                            Calls Choice.Equals() on each pair

   Comparison Matrix:
   ┌────────────────────────────────────────────────────────┬──────────────────────┬──────────────────────┐
   │ Scenario                                               │ Reference Comparison │ SequenceEqual Result │
   │                                                        │ (ReferenceEquals)    │                      │
   ├────────────────────────────────────────────────────────┼──────────────────────┼──────────────────────┤
   │ Same list compared to itself                           │ True                 │ True                 │
   │ Two lists containing identical shared references       │ True (per element)   │ True                 │
   │ Distinct instances, same properties (NO Equals override)│ False (per element)  │ False                │
   │ Distinct instances, same properties (WITH Equals ovrd) │ False (per element)  │ True                 │
   │ Order mismatch (e.g., [Q1, Q2] vs [Q2, Q1])            │ True / False         │ False                │
   │ Missing element or count mismatch                      │ Irrelevant           │ False                │
   └────────────────────────────────────────────────────────┴──────────────────────┴──────────────────────┘

2. HOW IT WORKS INTERNALLY:
   - Execution Model: Immediate execution.
   - Stepping Logic:
       1. Opens IEnumerator<T> on both sequences simultaneously in lockstep.
       2. Advances both using MoveNext(). If one ends earlier (count mismatch), it immediately exits false.
       3. Invokes EqualityComparer<T>.Default.Equals(first.Current, second.Current) on the current pair.
          If Equals() is overridden, it executes your custom domain logic; otherwise, it falls back to 
          reference pointer comparisons.
       4. Short-circuits and returns false on the very first mismatch; returns true only after both 
          enumerators complete traversal together.
   - Complexity: Best case O(1) on early mismatch, Worst case O(N) full traversal.

3. COMMON PITFALLS:
   - Strict Order Sensitivity: SequenceEqual treats [A, B] and [B, A] as unequal.
   - Omitting Equals on Child Collections: Overriding Equals on Question while leaving Choice to 
     default reference comparison causes SequenceEqual to fail whenever choices are separate heap objects.
   - Forgetting GetHashCode(): Whenever overriding Equals(), GetHashCode() must be overridden using 
     the exact same fields so hash-based collections (Dictionary, HashSet) operate correctly.
   - Query Syntax Absence: SequenceEqual has no C# query syntax keyword; it is exclusively method syntax.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Equality.Shared;

namespace _1__SequenceEqual_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------------
            // Setup Base Data Entities
            // -------------------------------------------------------------------------
            Question q1 = new Question
            {
                Title = "What is LINQ?",
                CorrectAnswer = 1,
                Choices = new List<Choice>
                {
                    new Choice { Order = 1, Description = "Language Integrated Query" },
                    new Choice { Order = 2, Description = "Linear Query" }
                }
            };

            Question q2 = new Question
            {
                Title = "What is C#?",
                CorrectAnswer = 1,
                Choices = new List<Choice>
                {
                    new Choice { Order = 1, Description = "Object-Oriented Language" },
                    new Choice { Order = 2, Description = "Database Engine" }
                }
            };

            // -------------------------------------------------------------------------
            // A - SequenceEqual() with Same Sequence Items (Shared References)
            // -------------------------------------------------------------------------
            // Two different list instances on the heap, but pointing to the exact same item references:
            List<Question> sequenceA = new List<Question> { q1, q2 };
            List<Question> sequenceB = new List<Question> { q1, q2 };

            // Reference check on the list containers themselves:
            bool areListPointersEqual = ReferenceEquals(sequenceA, sequenceB);
            Console.WriteLine("--- A - SequenceEqual() with Same Sequence Items ---");
            Console.WriteLine($"ReferenceEquals(sequenceA, sequenceB): {areListPointersEqual}"); // False

            // SequenceEqual compares item by item. Since references match, it short-circuits to true:
            bool areSameItemsEqual = sequenceA.SequenceEqual(sequenceB);
            Console.WriteLine($"sequenceA.SequenceEqual(sequenceB): {areSameItemsEqual}"); // True

            // -------------------------------------------------------------------------
            // B - SequenceEqual() on the Same Sequence (Self-Comparison)
            // -------------------------------------------------------------------------
            // Comparing a sequence directly against its own instance in memory:
            bool isSameSequenceEqual = sequenceA.SequenceEqual(sequenceA);
            Console.WriteLine("\n--- B - SequenceEqual() on Same Sequence ---");
            Console.WriteLine($"sequenceA.SequenceEqual(sequenceA): {isSameSequenceEqual}"); // True

            // -------------------------------------------------------------------------
            // C - SequenceEqual() with Different Sequences (Order / Count Mismatch)
            // -------------------------------------------------------------------------
            // Case A: Order Mismatch ([q1, q2] vs [q2, q1])
            List<Question> reversedSequence = new List<Question> { q2, q1 };
            bool isOrderEqual = sequenceA.SequenceEqual(reversedSequence);
            Console.WriteLine("\n--- C - SequenceEqual() with Different Sequences ---");
            Console.WriteLine($"Order Mismatch [q1, q2] vs [q2, q1]: {isOrderEqual}"); // False

            // Case B: Count Mismatch ([q1, q2] vs [q1])
            List<Question> partialSequence = new List<Question> { q1 };
            bool isCountEqual = sequenceA.SequenceEqual(partialSequence);
            Console.WriteLine($"Count Mismatch [q1, q2] vs [q1]: {isCountEqual}"); // False

           // -------------------------------------------------------------------------
            // D - SequenceEqual() with Distinct Instances (Overridden Equals)
            // -------------------------------------------------------------------------
            // The thing is: in production, collections often carry identical data fetched
            // from different sources (like an API payload vs. a database query), meaning
            // they reside at completely different memory addresses.
            
            // Create a new instance with identical values (different memory address):
            Question q1Duplicate = new Question
            {
                Title = "What is LINQ?",
                CorrectAnswer = 1,
                Choices = new List<Choice>
                {
                    new Choice { Order = 1, Description = "Language Integrated Query" },
                    new Choice { Order = 2, Description = "Linear Query" }
                }
            };

            // This list holds identical content, but with different object addresses.
            // By default, reference comparison would return false here.
            // We could rely solely on our overridden Equals(), but we would still have to
            // write manual loops to step through both collections and check counts.
            // SequenceEqual saves us boilerplate and handles lockstep iteration for us:
            List<Question> sequenceCloned = new List<Question> { q1Duplicate, q2 };

            // Even with new instances and different addresses, SequenceEqual leverages 
            // our overridden Equals() to compare by content rather than references.
            // Without it, we would have to write manual loops both here and inside Question.Equals.
            bool isDeepEqual = sequenceA.SequenceEqual(sequenceCloned);

            Console.WriteLine("\n--- D - Deep Content Comparison via SequenceEqual() ---");
            Console.WriteLine($"sequenceA.SequenceEqual(sequenceCloned): {isDeepEqual}"); // True
        }
    }
}