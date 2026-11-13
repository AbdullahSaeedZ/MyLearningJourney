/*
================================================================================
Hands-On: Set Operations in SortedSet<T> (ISet<T>)
================================================================================

1. CORE THEORY:
- `SortedSet<T>` implements `ISet<T>`, providing standard mathematical set 
  operations while maintaining strictly sorted order at all times.

- Mutating Operations (Modify the calling set in-place; return void):
    * `UnionWith(other)`           : A = A ∪ B (Adds all missing elements from B)
    * `IntersectWith(other)`       : A = A ∩ B (Keeps only elements present in both A and B)
    * `ExceptWith(other)`          : A = A \ B (Removes all elements present in B from A)
    * `SymmetricExceptWith(other)` : A = A Δ B (Keeps elements present in A OR B, but NOT both)
 
- Non-Mutating Inspection Methods (Return bool without modifying either set):
    * `IsSubsetOf(other)`          : True if every element in A is also in B (A ⊆ B)
    * `IsSupersetOf(other)`        : True if A contains every element in B (A ⊇ B)
    * `Overlaps(other)`            : True if A and B share at least one common element
    * `SetEquals(other)`           : True if A and B contain the exact same elements
 
- Note on Input Parameter:
  All methods accept `IEnumerable<T>` (e.g., `List<T>`, `int[]`, `HashSet<T>`, 
  or another `SortedSet<T>`), not just `SortedSet<T>`.
================================================================================
*/

using System;
using System.Collections.Generic;

namespace SortedSetOperationsPractice;

class Program
{
    static void Main()
    {
        // =====================================================================
        // TASK 1: UNION (A ∪ B) — .UnionWith()
        // =====================================================================
        // Declare a SortedSet<int> named 'setA' initialized with { 1, 2, 3, 4 }
        SortedSet<int> setA = new SortedSet<int>() { 1, 2, 3, 4 };

        // Declare a SortedSet<int> named 'setB' initialized with { 3, 4, 5, 6 }
        SortedSet<int> setB = new SortedSet<int>() { 3, 4, 5, 6 };

        // Combine 'setB' into 'setA' using .UnionWith()
        setA.UnionWith(setB);

        // Iterate and print 'setA' (Expected: 1, 2, 3, 4, 5, 6 — unique & sorted)
        Console.WriteLine("set A after combining setA and setB:");
        foreach (int i in setA)
        {
            Console.WriteLine(i);
        }

        // =====================================================================
        // TASK 2: INTERSECTION (A ∩ B) — .IntersectWith()
        // =====================================================================
        // Re-initialize 'setA' to { 1, 2, 3, 4 }
        setA = new SortedSet<int>() { 1, 2, 3, 4 };

        // Keep only elements in 'setA' that also exist in 'setB' { 3, 4, 5, 6 } using .IntersectWith()
        setA.IntersectWith(setB);

        // Iterate and print 'setA' (Expected: 3, 4)
        Console.WriteLine("\n\nset A after intersecting setA and setB:");
        foreach (int i in setA)
        {
            Console.WriteLine(i);
        }


        // =====================================================================
        // TASK 3: DIFFERENCE (A \ B) — .ExceptWith()
        // =====================================================================
        // Re-initialize 'setA' to { 1, 2, 3, 4 }
        setA = new SortedSet<int>() { 1, 2, 3, 4 };

        // Remove all elements present in 'setB' { 3, 4, 5, 6 } from 'setA' using .ExceptWith()
        setA.ExceptWith(setB);

        // Iterate and print 'setA' (Expected: 1, 2)
        Console.WriteLine("\n\nset A items EXCEPT setB items:");
        foreach (int i in setA)
        {
            Console.WriteLine(i);
        }


        // =====================================================================
        // TASK 4: SYMMETRIC DIFFERENCE (A Δ B) — .SymmetricExceptWith()
        // =====================================================================
        // Re-initialize 'setA' to { 1, 2, 3, 4 }
        setA = new SortedSet<int>() { 1, 2, 3, 4 };

        // Keep only elements in 'setA' OR 'setB' { 3, 4, 5, 6 }, excluding shared ones, using .SymmetricExceptWith()
        setA.SymmetricExceptWith(setB);

        // Iterate and print 'setA' (Expected: 1, 2, 5, 6)
        Console.WriteLine("\n\nset A items and setB items, without shared ones:");
        foreach (int i in setA)
        {
            Console.WriteLine(i);
        }


        // =====================================================================
        // TASK 5: NON-MUTATING SET RELATIONS (Subset, Superset, Overlaps, Equals)
        // =====================================================================
        // Declare 'sub' = { 2, 3 } and 'main' = { 1, 2, 3, 4 }
        SortedSet<int> main = new SortedSet<int>() { 1, 2, 3, 4 };
        SortedSet<int> sub = new SortedSet<int>() { 2, 3 };

        // Check and print if 'sub' is a subset of 'main' using .IsSubsetOf()
        Console.WriteLine($"\n\nsub is subset of main: {sub.IsSubsetOf(main)}");

        // Check and print if 'main' is a superset of 'sub' using .IsSupersetOf()
        Console.WriteLine($"main is superset of sub: {main.IsSupersetOf(sub)}");

        // Check and print if 'sub' and 'main' share any common elements using .Overlaps()
        Console.WriteLine($"main and sub overlapping (sharing items): {sub.Overlaps(main)}");

        // Check and print if 'sub' equals a new array int[] { 3, 2 } using .SetEquals()
        Console.WriteLine($"sub {{2, 3}} is equal to array {{3, 2}}: {sub.SetEquals(new int[] { 3, 2 })}");
    }
}