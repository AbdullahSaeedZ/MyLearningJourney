/*
====================================================================================================
                        LINQ SET OPERATIONS: Except() vs ExceptBy()
====================================================================================================

1. THE CORE IDEA:
   Both methods return items from Set 1 that do NOT exist in Set 2 (Set Difference: A \ B).
   They also remove duplicates from the final result.

   - Except():
     Compares WHOLE OBJECTS.
     Requires overriding `Equals()` and `GetHashCode()` on your class so LINQ knows when two 
     instances represent the same record.

   - ExceptBy() (.NET 6+):
     Compares KEYS instead of whole objects.
     Eliminates the need to override `Equals()` or `GetHashCode()`.

   * Quick Contrast:
     - DistinctBy: Filters a SINGLE collection using one property selector.
     - ExceptBy:   Filters ACROSS TWO collections using a blacklist of keys.


2. EXECUTION MODEL:
   - Deferred Streaming Execution (`yield return`):
     Neither method runs immediately upon definition. Elements from Set 1 are evaluated and 
     yielded one at a time on demand as you iterate (e.g., using `foreach` or `.ToList()`).
   - The Blacklist Pre-buffering:
     Before streaming begins, LINQ must fully evaluate and load Set 2's keys into an internal 
     `HashSet<TKey>` to enable instant lookups.


3. VISUALIZATION (Blacklist Logic):

   Set 1 (Objects):   [ Emp(a10), Emp(a11), Emp(a12) ]
   Set 2 (Objects):   [ Emp(a11), Emp(a13), Emp(a15) ]

   --- ExceptBy() Flow ---
   
   Step 1: Extract blacklist keys from Set 2:
           set2.Select(x => x.EmployeeNo)  -->  Blacklist HashSet: { "a11", "a13", "a15" }

   Step 2: Stream Set 1 lazily (`yield return`) and test each key against the Blacklist:
           Emp(a10) -> Key "a10" in Blacklist? NO   -->  YIELD RETURN Emp(a10)
           Emp(a11) -> Key "a11" in Blacklist? YES  -->  DROP
           Emp(a12) -> Key "a12" in Blacklist? NO   -->  YIELD RETURN Emp(a12)

   Result: [ Emp(a10), Emp(a12) ]


4. TIME COMPLEXITY:
   - Overall: O(N) linear time (specifically O(N + M)).
   - Building the blacklist is O(M), and checking each item is O(1) via the internal HashSet.
   - It is fast and never executes nested loops (no O(N²)).


5. KEY RULES:
   - Order matters: `set1.Except(set2)` is NOT the same as `set2.Except(set1)`.
   - `ExceptBy` expects keys for parameter 1, not objects:
       Correct:   set1.ExceptBy(set2.Select(x => x.Id), x => x.Id)
       Wrong:     set1.ExceptBy(set2, x => x.Id)  // Compile Error!

====================================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Sets.Shared;

namespace _4__Except_Operations
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
            // 2. Except() - Full Object Comparison
            // Relies on overridden Equals() & GetHashCode() on Employee to eliminate "a11"
            // -------------------------------------------------------------------------
            // Except will take all OBJECTS of set2, label them as a blacklist
            // and checks all items in set1, if one item matches any of the blacklist then it's not included in the return result
            IEnumerable<Employee> set3 = set1.Except(set2);

            set3.Print($"========= set1.Except(set2) Participants ({set3.Count()})");
            // Output: Ruba Ali (a10), Abeer Omar (a12)

            // -------------------------------------------------------------------------
            // 3. ExceptBy() - Key-to-Key Comparison
            // Eliminates the need to override Equals() or GetHashCode() on Employee.
            // so we rely on the keys of set2 not the objects to produce the blacklist, 
            // then it checks all keys of set1 against that blacklist to exclude from the final result
            //
            // - set2.Select(x => x.EmployeeNo): produces the blacklist of keys (IEnumerable<string>)
            // - (Employee x) => x.EmployeeNo: extracts the key from each Employee in set1
            // -------------------------------------------------------------------------
            IEnumerable<string> excludedKeys = set2.Select((Employee x) => x.EmployeeNo);

            IEnumerable<Employee> set4 = set1.ExceptBy(
                excludedKeys, 
                (Employee x) => x.EmployeeNo
            );

            // Corrected count target: evaluating set4
            set4.Print($"========= set1.ExceptBy(set2.Select(x => x.EmployeeNo)) Participants ({set4.Count()})");
            // Output: Ruba Ali (a10), Abeer Omar (a12)
        }
    }
}