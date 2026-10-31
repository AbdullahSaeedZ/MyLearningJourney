/*
====================================================================================================
                        LINQ SET OPERATIONS: Union() vs UnionBy()
====================================================================================================

1. THE CORE IDEA:
   Both methods combine elements from two collections into one unified set (Set Union: A ∪ B).
   They merge all unique items from both sequences and remove duplicates.

   - Union():
     Compares WHOLE OBJECTS.
     Requires overriding `Equals()` and `GetHashCode()` on your class so LINQ knows when two 
     instances represent the same record.

   - UnionBy() (.NET 6+):
     Compares items by a specific KEY instead of whole objects.
     Eliminates the need to override `Equals()` or `GetHashCode()`.

   * Quick Contrast:
     - DistinctBy:  Dedupes a SINGLE collection using one property selector.
     - ExceptBy:    Filters Set 1 by excluding items matching Set 2 keys (Set Difference: A \ B).
     - IntersectBy: Filters Set 1 by keeping items matching Set 2 keys (Intersection: A ∩ B).
     - UnionBy:     Merges items from BOTH collections into one unified result.


2. WHY EXCEPTBY/INTERSECTBY NEED A SEPARATE KEY LIST, BUT UNIONBY DOES NOT:

   Think about what each method actually does with Set 2:

   A) ExceptBy & IntersectBy (FILTERING):
      - Goal: Filter Set 1 and return ONLY Set 1 items.
      - Set 2 is NEVER returned in the final result. It is just a filter list.
      - Because Set 2 is never returned, it doesn't even need to be the same class!
        You could filter `Employee` against a list of `Contractor` or raw `int` IDs.
      - Since Set 2 can be any type, LINQ cannot guess how to read it.
        You MUST extract and pass the keys of Set 2 separately:
        
        set1.ExceptBy(set2Keys, x => x.EmployeeNo)
                      ^^^^^^^^
                      Explicit list of keys to check against

   B) UnionBy (MERGING):
      - Goal: Merge Set 1 and Set 2 into ONE combined list.
      - Every item in the output comes from EITHER Set 1 OR Set 2.
      - To put them in the same list, both sets MUST be the exact same class (`Employee`).
      - Because they are the same class, they share the exact same properties.
        There is no need to extract a separate key list; LINQ simply takes ONE shared 
        selector and runs it on both:

        set1.UnionBy(set2, x => x.EmployeeNo)
                     ^^^^  ^^^^^^^^^^^^^^^^^
                     Whole  One shared rule that applies
                     set    to both sets


3. EXECUTION MODEL:
   - Deferred Streaming Execution (`yield return`):
     Neither method runs immediately. Elements are evaluated and yielded one at a time on demand.
   - Internal Tracking Set:
     LINQ maintains an internal `HashSet<TKey>`.
     First, it streams Set 1: if a key has not been seen, it yields the item and records the key.
     Next, it streams Set 2: if a key has not been seen in the tracker, it yields the item and 
     records the key. Any duplicate keys encountered in either collection are skipped.


4. VISUALIZATION (UnionBy Flow):

   Set 1 (Objects):   [ Emp(a10), Emp(a11) ]
   Set 2 (Objects):   [ Emp(a11), Emp(a13) ]

   --- UnionBy(set2, x => x.EmployeeNo) Flow ---
   
   Shared Key Selector: x => x.EmployeeNo
   Internal Seen Keys:  {}

   Stream Set 1:
     Emp(a10) -> Key "a10" seen? NO  -->  YIELD RETURN Emp(a10), Add "a10" to Seen
     Emp(a11) -> Key "a11" seen? NO  -->  YIELD RETURN Emp(a11), Add "a11" to Seen

   Stream Set 2:
     Emp(a11) -> Key "a11" seen? YES -->  DROP (duplicate)
     Emp(a13) -> Key "a13" seen? NO  -->  YIELD RETURN Emp(a13), Add "a13" to Seen

   Result: [ Emp(a10), Emp(a11), Emp(a13) ]


5. TIME COMPLEXITY:
   - Overall: O(N) linear time (specifically O(N + M)).
   - Each element lookup and insertion into the internal HashSet is O(1).
   - Fast, single-pass iteration with no nested loops (no O(N²)).


6. KEY RULES:
   - Type Compatibility:
     Both collections must be of the same type `TSource`.
   - Priority on Duplicates:
     If the same key exists in both collections, the object instance from Set 1 is returned 
     because Set 1 is evaluated first.

====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Sets.Shared;

namespace _6__Union_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------------
            // 1. Source Data
            // -------------------------------------------------------------------------
            List<Employee> set1 = Repository.Meeting1.Participants; // a10, a11, a12
            List<Employee> set2 = Repository.Meeting2.Participants; // a11, a13, a15

            set1.Print($"========= Meeting 1 Participants ({set1.Count()})");
            set2.Print($"========= Meeting 2 Participants ({set2.Count()})");

            // -------------------------------------------------------------------------
            // 2. Union() - Full Object Comparison
            // Relies on overridden Equals() & GetHashCode() on Employee to deduplicate "a11"
            // -------------------------------------------------------------------------
            // Union merges all items from set1 and set2, omitting any duplicates
            IEnumerable<Employee> set3 = set1.Union(set2);

            set3.Print($"========= set1.Union(set2) Participants ({set3.Count()})");
            // Output: a10, a11, a12, a13, a15 (5 items total)

            // -------------------------------------------------------------------------
            // 3. UnionBy() - Key-to-Key Comparison
            // Eliminates the need to override Equals() or GetHashCode() on Employee.
            // 
            // Notice: We pass 'set2' directly (NOT set2.Select(...)) because both sets 
            // are List<Employee>, allowing LINQ to run (x => x.EmployeeNo) on both collections!
            // -------------------------------------------------------------------------
            IEnumerable<Employee> set4 = set1.UnionBy(
                set2, 
                (Employee x) => x.EmployeeNo
            );

            set4.Print($"========= set1.UnionBy(set2, x => x.EmployeeNo) Participants ({set4.Count()})");
            // Output: a10, a11, a12, a13, a15 (5 items total)
        }
    }
}