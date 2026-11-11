/*
================================================================================
LESSON 14: HashSet<T> — Declaration, Concept & List Comparison
================================================================================

1. THE CORE IDEA:
`HashSet<T>` is a generic collection that stores unique elements using a hash table.
Think of it as a `Dictionary<TKey, TValue>` without the values—only keys exist.

Key Characteristics:
- Automatic Uniqueness: Duplicate items are ignored.
    Uniqueness is done by using Equals and GetHashCode, we must override them if needed.
- Unordered: Elements are placed into hash buckets, not kept in insertion order.
- No Indexing: Direct access like `set[0]` does not exist.

2. HOW TO ACCESS ELEMENTS:
Because `HashSet<T>` does not support indexers, you access items via:
1. Enumeration: Iterating over the sequence with `foreach`.
2. Membership Testing: Querying existence via `.Contains(item)` in O(1) time.
3. LINQ Operators: Using `.First()`, `.Where()`, etc. (which scan the bucket stream).

3. HASHSET<T> VS LIST<T>:

  Feature             List<T>                         HashSet<T>
  ─────────────────────────────────────────────────────────────────────────────
  Duplicates          Allowed                         Forbidden (Auto-discarded)
  Ordering            Preserved (Insertion order)     Unordered (Hash distribution)
  Indexing            Yes (list[i] in O(1))           No (Compilation error)
  Lookup (.Contains)  O(N) linear scan                O(1) average hash lookup
  Underlying Storage  Contiguous array                Hash buckets & entries
================================================================================
*/

using System;
using System.Collections.Generic;

namespace HashSetLessons;

class Program
{
    static void Main()
    {
        // =====================================================================
        // 1. DECLARATION & INITIALIZATION
        // =====================================================================
        
        // List: Keeps every element, preserves exact insertion order
        List<string> fruitList = new()
        {
            "Apple",
            "Banana",
            "Apple"
        };

        // HashSet: Keeps only distinct items, discards duplicates automatically
        HashSet<string> fruitSet = new()
        {
            "Apple",
            "Banana",
            "Apple"
        };

        Console.WriteLine($"List Count: {fruitList.Count}"); // Prints 3
        Console.WriteLine($"Set Count:  {fruitSet.Count}");  // Prints 2


        // =====================================================================
        // 2. ACCESS COMPARISON (Indexing vs Membership)
        // =====================================================================

        // List supports positional index access:
        string firstFruit = fruitList[0];
        Console.WriteLine($"\nFirst fruit in List: {firstFruit}");

        // HashSet does NOT support index access:
        // string setFruit = fruitSet[0]; // ERROR: Cannot apply indexing to HashSet<T>

        // HashSet access is done via O(1) membership check:
        bool hasApple = fruitSet.Contains("Apple");
        Console.WriteLine($"Does Set contain Apple? {hasApple}");


        // =====================================================================
        // 3. ENUMERATION (Accessing All Items)
        // =====================================================================
        Console.WriteLine("\nIterating over HashSet:");
        foreach (string fruit in fruitSet)
        {
            Console.WriteLine($" - {fruit}");
        }
    }
}