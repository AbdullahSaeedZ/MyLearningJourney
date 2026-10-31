/*
====================================================================================================
                        LINQ SET OPERATIONS: Intersect() vs IntersectBy()
====================================================================================================

1. THE CORE IDEA:
   Both methods return items that exist in BOTH Set 1 AND Set 2 (Set Intersection: A ∩ B).
   They also remove duplicates from the final result.

   - Intersect():
     Compares WHOLE OBJECTS.
     Requires overriding `Equals()` and `GetHashCode()` on your class so LINQ knows when two 
     instances represent the same record.

   - IntersectBy() (.NET 6+):
     Compares KEYS instead of whole objects.
     Eliminates the need to override `Equals()` or `GetHashCode()`.

   * Quick Contrast:
     - DistinctBy:  Filters a SINGLE collection using one property selector.
     - ExceptBy:    Filters ACROSS TWO collections using a BLACKLIST of keys (Set Difference: A \ B).
     - IntersectBy: Filters ACROSS TWO collections using a WHITELIST of keys (Intersection: A ∩ B).


2. EXECUTION MODEL:
   - Deferred Streaming Execution (`yield return`):
     Neither method runs immediately upon definition. Elements from Set 1 are evaluated and 
     yielded one at a time on demand as you iterate (e.g., using `foreach` or `.ToList()`).
   - The Whitelist Pre-buffering:
     Before streaming begins, LINQ must fully evaluate and load Set 2's keys into an internal 
     `HashSet<TKey>` to enable instant lookups.


3. VISUALIZATION (Whitelist Logic):

   Set 1 (Objects):   [ Emp(a10), Emp(a11), Emp(a12) ]
   Set 2 (Objects):   [ Emp(a11), Emp(a13), Emp(a15) ]

   --- IntersectBy() Flow ---
   
   Step 1: Extract whitelist keys from Set 2:
           set2.Select(x => x.EmployeeNo)  -->  Whitelist HashSet: { "a11", "a13", "a15" }

   Step 2: Stream Set 1 lazily (`yield return`) and test each key against the Whitelist:
           Emp(a10) -> Key "a10" in Whitelist? NO   -->  DROP
           Emp(a11) -> Key "a11" in Whitelist? YES  -->  YIELD RETURN Emp(a11) (and remove key from HashSet)
           Emp(a12) -> Key "a12" in Whitelist? NO   -->  DROP

   Result: [ Emp(a11) ]


4. TIME COMPLEXITY:
   - Overall: O(N) linear time (specifically O(N + M)).
   - Building the whitelist is O(M), and checking each item is O(1) via the internal HashSet.
   - It is fast and never executes nested loops (no O(N²)).


5. KEY RULES:
   - Order preserved from Set 1:
     `set1.Intersect(set2)` returns common elements in the order they appear in `set1`, 
     using `set1`'s object references.
   - `IntersectBy` expects keys for parameter 1, not objects:
       Correct:   set1.IntersectBy(set2.Select(x => x.Id), x => x.Id)
       Wrong:     set1.IntersectBy(set2, x => x.Id)  // Compile Error!

====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Sets.Shared;

namespace _5__Intersect_Operations
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
            // 2. Intersect() - Full Object Comparison
            // Relies on overridden Equals() & GetHashCode() on Employee to match "a11"
            // -------------------------------------------------------------------------
            // Intersect will take all OBJECTS of set2, label them as a whitelist
            // and check all items in set1; only items that match the whitelist are included in the return result
            IEnumerable<Employee> set3 = set1.Intersect(set2);

            set3.Print($"========= set1.Intersect(set2) Participants ({set3.Count()})");
            // Output: Sana Ahmad (a11)

            // -------------------------------------------------------------------------
            // 3. IntersectBy() - Key-to-Key Comparison
            // Eliminates the need to override Equals() or GetHashCode() on Employee.
            // We rely on the keys of set2 (not the objects) to produce the whitelist, 
            // then check all keys of set1 against that whitelist to include in the final result.
            //
            // - set2.Select(x => x.EmployeeNo): produces the whitelist of keys (IEnumerable<string>)
            // - (Employee x) => x.EmployeeNo: extracts the key from each Employee in set1
            // -------------------------------------------------------------------------
            IEnumerable<string> includedKeys = set2.Select((Employee x) => x.EmployeeNo);

            IEnumerable<Employee> set4 = set1.IntersectBy(
                includedKeys, 
                (Employee x) => x.EmployeeNo
            );

            set4.Print($"========= set1.IntersectBy(set2.Select(x => x.EmployeeNo)) Participants ({set4.Count()})");
            // Output: Sana Ahmad (a11)
        }
    }
}