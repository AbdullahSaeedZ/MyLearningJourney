/*
====================================================================================================
                        LINQ SET OPERATIONS - Distinct() and DistinctBy()
====================================================================================================

1. THE CORE IDEA:
   `Distinct()` removes duplicate elements from a sequence, yielding only unique items.

   - Distinct():
     Evaluates the whole element for equality using `EqualityComparer<T>.Default`.
     For primitive types (like int or string), it compares values directly.
     For custom classes, it requires overriding both `Equals()` AND `GetHashCode()` (or supplying
     an explicit `IEqualityComparer<T>`), otherwise it falls back to reference address checks.

   - DistinctBy() (.NET 6+):
     Removes duplicates based on a specific key selector without requiring the source class 
     to override `Equals()` or `GetHashCode()`.
     Example: `.DistinctBy((Employee e) => e.EmployeeNo)` deduplicates based solely on the ID.

   Distinct() vs. DistinctBy():
   ┌───────────────┬─────────────────────────────┬─────────────────────────────────────────────────┐
   │ Operator      │ Equality Basis              │ Class Requirement                               │
   ├───────────────┼─────────────────────────────┼─────────────────────────────────────────────────┤
   │ Distinct()    │ Whole object equality       │ Must override Equals() AND GetHashCode()        │
   │ DistinctBy()  │ Selected key property       │ None (compares the projected key type directly) │
   └───────────────┴─────────────────────────────┴─────────────────────────────────────────────────┘

   Data Flow:
   Source:     [ 1, 2, 2, 3, 1 ]
   Seen Set:   { 1 } ──► { 1, 2 } ──► (2 duplicate, skip) ──► { 1, 2, 3 } ──► (1 duplicate, skip)
   Distinct(): [ 1, 2, 3 ]

2. HOW IT WORKS INTERNALLY:
   - Execution Model: Deferred streaming execution (`yield return`).
   - Hash Bucket Tracking:
     Internally instantiates a lightweight hash set (`Set<TElement>`).
     As each element arrives:
       1. Computes the hash code via `GetHashCode()`.
       2. If not already present in the set, it adds the key and immediately yields the item.
       3. If already present, it discards the duplicate and pulls the next item.
   - Order Preservation:
     Preserves the relative order of the first time each unique element is encountered.

3. COMMON PITFALLS:
   - Forgetting GetHashCode():
     Overriding `Equals()` without `GetHashCode()` breaks `Distinct()`. Hash-based sets inspect 
     hash codes first; if hashes do not match, `Equals()` is never even called.
   - DistinctBy First-Win Semantic:
     If two objects share the same key but differ in other properties, `DistinctBy()` keeps the 
     FIRST instance encountered and drops the subsequent one.
====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Sets.Shared;

namespace _2__Distinct_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Distinct() on Primitive Numbers Array
            // =========================================================================
            int[] numbers = new int[] { 1, 2, 2, 3, 4, 4, 4, 5, 1 };

            IEnumerable<int> uniqueNumbers = numbers.Distinct();

            Console.WriteLine("--- 1. Distinct on Numbers Array ---");
            foreach (int n in uniqueNumbers)
            {
                Console.Write($"{n} "); // 1 2 3 4 5
            }
            Console.WriteLine();

            // 2. Combining Sequences with Duplicates
            // Meeting 1 and Meeting 2 both contain participant Sana Sayed (a11)
            // =========================================================================
            IEnumerable<Employee> participantsM1M2 =
                Repository.Meeting1.Participants.Concat(Repository.Meeting2.Participants);

            participantsM1M2.Print("Duplicate Meeting 1 & 2 Participants");

            // 3. Distinct() with Overridden Equals() & GetHashCode()
            // Even though Meeting1 and Meeting2 instantiated separate Employee objects
            // with different heap memory addresses, Distinct() identifies duplicates 
            // via the overridden Equals() and GetHashCode() logic in the Employee class.
            // =========================================================================
            IEnumerable<Employee> distinctParticipants = participantsM1M2.Distinct();

            distinctParticipants.Print("Distinct Meeting 1 & 2 Participants (via Overridden Equals)");

            // 4. DistinctBy() (.NET 6+) - Deduplicating via Key Selector
            // COMMENT OUT THE OVERRIDDEN METHODS IN EMPLOYEE CLASS TO TEST THIS METHOD THE RIGHT WAY
            // Deduplicates based strictly on the selected property (EmployeeNo).
            // This works even if the Employee class has NO overridden Equals() or GetHashCode().
            // =========================================================================
            IEnumerable<Employee> distinctByParticipants = participantsM1M2
                .DistinctBy((Employee participant) => participant.EmployeeNo);

            distinctByParticipants.Print("DistinctBy Meeting 1 & 2 Participants (via EmployeeNo Key)");
        }
    }
}