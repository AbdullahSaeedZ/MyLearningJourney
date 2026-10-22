/*
====================================================================================================
                 LINQ ELEMENT OPERATIONS - Single & SingleOrDefault
====================================================================================================

1. THE PROBLEM:
   In database queries and domain repositories, entities frequently map to unique identifier 
   properties (such as primary keys or unique title prefixes like "Q #245:").
   
   If a developer uses `First()` or `FirstOrDefault()` to retrieve an entity by its key:
       
       Question q = QuestionBank.All.FirstOrDefault(x => x.Title.StartsWith("Q #245:"));

   The query will silently return the very first record found and ignore any remaining items. 
   If duplicate records exist in the repository (e.g., two entries for question #245), 
   `FirstOrDefault()` conceals the corruption, leading to silent bugs and inconsistent state.

   Developers need an operator that acts as an assertion guard: "Retrieve this entity, and fail 
   immediately if data integrity is violated by duplicate matches."

2. THE CORE IDEA:
   - Single(): Asserts that the sequence contains EXACTLY ONE element matching the condition.
     - 0 Matches: Throws `InvalidOperationException` ("Sequence contains no matching element").
     - 1 Match: Returns the single matching element.
     - >1 Matches: Throws `InvalidOperationException` ("Sequence contains more than one matching element").
   - SingleOrDefault(): Returns the matching element if exactly one exists.
     - 0 Matches: Safely returns `default(T)` (or explicit fallback).
     - 1 Match: Returns the single matching element.
     - >1 Matches: STILL THROWS `InvalidOperationException`!

   Decision Matrix:
   ┌──────────────────────┬───────────────────────────────┬─────────────────────────────────────┐
   │ Scenario             │ Single()                      │ SingleOrDefault()                   │
   ├──────────────────────┼───────────────────────────────┼─────────────────────────────────────┤
   │ Exactly 1 Match      │ Returns element               │ Returns element                     │
   │ 0 Matches            │ Throws InvalidOperationException│ Returns default(T) (null / fallback)│
   │ 2+ Matches (Duplicate)│ THROWS InvalidOperationException│ THROWS InvalidOperationException!    │
   └──────────────────────┴───────────────────────────────┴─────────────────────────────────────┘

3. HOW IT WORKS INTERNALLY (The Second-Element Verification):
   - Execution Model: Immediate execution.
   - Scan Mechanism:
       1. Advances the enumerator to locate the first matching element.
       2. Once found, it CANNOT terminate the loop early like `First()`. It MUST continue iterating 
          to verify that no second match exists.
       3. The moment a second match is encountered, it immediately aborts iteration and throws 
          `InvalidOperationException` to alert the caller of duplicate keys.
   - Complexity: Always O(N) when matches exist because the full collection (or up to the second 
     match) must be scanned to verify uniqueness.

4. COMMON PITFALLS:
   - The SingleOrDefault Fallacy: Assuming `SingleOrDefault` never throws exceptions. It only 
     suppresses exceptions for 0 matches; it ALWAYS throws when 2 or more matches are found.
   - Performance Cost vs First(): `First()` exits immediately at index 0 upon matching, whereas 
     `Single()` must continue scanning downstream to assert uniqueness.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Elements.Shared;

namespace _4__Single_SingleOrDefault
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Question> questions = QuestionBank.All;

            // -------------------------------------------------------------------------
            // 1. The Danger of FirstOrDefault() on Unique Keys
            // -------------------------------------------------------------------------
            // QuestionBank contains duplicate entries for "Q #245:".
            // FirstOrDefault() silently succeeds, hiding the fact that duplicates exist:
            Question maskedQuestion = questions.FirstOrDefault(
                (Question q) => q.Title.StartsWith("Q #245:")
            );

            Console.WriteLine("--- FirstOrDefault() on Duplicate Key ---");
            Console.WriteLine($"Result: {maskedQuestion?.Title}");
            Console.WriteLine("Warning: FirstOrDefault silently masked the duplicate entry in the bank!\n");

            // -------------------------------------------------------------------------
            // 2. Single() Catching the Duplicate Primary Key Violation
            // -------------------------------------------------------------------------
            // Single() asserts uniqueness. When it discovers the second "Q #245:", it throws:
            Console.WriteLine("--- Single() Asserting Uniqueness on Duplicate Key ---");
            try
            {
                Question duplicateCheck = questions.Single(
                    (Question q) => q.Title.StartsWith("Q #245:")
                );
                Console.WriteLine(duplicateCheck.Title);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Integrity Alert caught: {ex.GetType().Name} - {ex.Message}");
            }

            // -------------------------------------------------------------------------
            // 3. SingleOrDefault() Behavior Across All Three Scenarios
            // -------------------------------------------------------------------------

            // Scenario A: Exactly 1 Match (Valid query)
            Question uniqueQuestion = questions.SingleOrDefault(
                (Question q) => q.Title.StartsWith("Q #1:")
            );
            Console.WriteLine("\n--- Scenario A: Exactly 1 Match ---");
            Console.WriteLine($"Found unique: {uniqueQuestion?.Title}");

            // Scenario B: 0 Matches (Safely returns null or explicit fallback)
            Question safeNonExistent = questions.SingleOrDefault(
                (Question q) => q.Title.StartsWith("Q #9999:")
            );
            Console.WriteLine("\n--- Scenario B: 0 Matches (Standard Fallback) ---");
            Console.WriteLine($"Returned null safely? {safeNonExistent == null}");

            // Scenario B (Alternative): Explicit fallback parameter (.NET 6+)
            Question safeWithFallback = questions.SingleOrDefault(
                (Question q) => q.Title.StartsWith("Q #9999:"),
                Question.Default
            );
            Console.WriteLine($"Returned explicit fallback: {safeWithFallback.Title}");

            // Scenario C: 2+ Matches (Duplicate Key STILL THROWS!)
            Console.WriteLine("\n--- Scenario C: 2+ Matches (SingleOrDefault Still Throws!) ---");
            try
            {
                // SingleOrDefault does NOT suppress exceptions for duplicate matches:
                Question willThrow = questions.SingleOrDefault(
                    (Question q) => q.Title.StartsWith("Q #245:")
                );
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"SingleOrDefault integrity failure: {ex.GetType().Name} - {ex.Message}");
            }
        }
    }
}