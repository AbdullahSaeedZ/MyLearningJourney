/*
================================================================================
Superset Evaluation in HashSet<T> (IsSupersetOf)
================================================================================

1. THE CORE IDEA:
`setA.IsSupersetOf(collectionB)` checks whether `setA` contains EVERY element 
found in `collectionB`. It is the inverse perspective of `IsSubsetOf`.

Mathematical Definition:
  A ⊇ B  (Set A is a superset of B)

  Set A:         { 1, 2, 3, 4 }
  Collection B:  { 1, 2 }
  IsSupersetOf:  TRUE (A fully encloses all items of B)

  Set A:         { 1, 2, 3, 4 }
  Collection B:  { 1, 2, 5 }
  IsSupersetOf:  FALSE (A is missing element 5)

2. ASCII DIAGRAM:
  Set A (Superset)
  ┌─────────────────────────────────┐
  │  3            4                 │
  │      Collection B (Subset)      │
  │     ┌──────────────┐            │
  │     │   1      2   │            │
  │     └──────────────┘            │
  └─────────────────────────────────┘
  setA.IsSupersetOf(collectionB) ──► TRUE

3. KEY BEHAVIORS & EDGE CASES:
- Identity: Every set is a superset of itself (`setA.IsSupersetOf(setA) == true`).
- The Empty Set: Every set is a superset of an empty collection:
  `anySet.IsSupersetOf(new List<int>()) == true`.
- An empty set is ONLY a superset of another empty set; otherwise, it returns `false`.
- Parameter: Accepts any `IEnumerable<T>`, not just another `HashSet<T>`.
- Time Complexity: O(M) where M is the number of elements in `collectionB` (looking up each in setA).
================================================================================
*/

using System;
using System.Collections.Generic;

namespace HashSetSuperset;

class Program
{
    static void Main()
    {
        HashSet<string> systemPermissions = new() { "Read", "Write", "Execute", "Delete" };
        HashSet<string> standardRole = new() { "Read", "Write" };
        HashSet<string> superAdminRole = new() { "Read", "Write", "Execute", "Delete", "RootAccess" };
        List<string> emptyRole = new();

        // 1. True: systemPermissions contains all elements of standardRole
        Console.WriteLine($"Is system a superset of standard:   {systemPermissions.IsSupersetOf(standardRole)}");

        // 2. False: systemPermissions lacks "RootAccess"
        Console.WriteLine($"Is system a superset of superAdmin: {systemPermissions.IsSupersetOf(superAdminRole)}");

        // 3. True: any set is a superset of an empty collection
        Console.WriteLine($"Is system a superset of empty:      {systemPermissions.IsSupersetOf(emptyRole)}");

        // 4. True: every set is a superset of itself
        Console.WriteLine($"Is system a superset of itself:     {systemPermissions.IsSupersetOf(systemPermissions)}");
    }
}