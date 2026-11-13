/*
================================================================================
Hands-On: LINQ Chaining & Set Operations on SortedDictionary<TKey, TValue>
================================================================================

1. CORE MECHANICS:
- Chaining (`.Where().Select()`): Filters `KeyValuePair<TKey, TValue>` items 
  and transforms them into a new shape in a single deferred pipeline.
  
- LINQ Set Operations (`.Intersect()`, `.Except()`, `.Union()`):
  Because `SortedDictionary<TKey, TValue>` implements 
  `IEnumerable<KeyValuePair<TKey, TValue>>`, LINQ compares BOTH `.Key` AND 
  `.Value` using `EqualityComparer<KeyValuePair<TKey, TValue>>.Default`.
  
- Non-Mutating: Neither source dictionary is altered.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SortedDictionaryLinqTasks;

class Program
{
    static void Main()
    {
        SortedDictionary<int, int> primaryStock = new()
        {
            { 300, 15 },
            { 100, 80 },
            { 400, 5 },
            { 200, 50 }
        };

        SortedDictionary<int, int> backupStock = new()
        {
            { 100, 80 }, // Exact match (Key 100, Value 80)
            { 200, 99 }, // Same Key (200), DIFFERENT Value (99 vs 50)
            { 500, 40 }
        };

        // =====================================================================
        // TASK 1: METHOD CHAINING (.Where + .Select)
        // =====================================================================
        // Chain .Where() and .Select() on 'primaryStock':
        // 1. Filter for warehouses with stock >= 20
        // 2. Project each matching pair into a formatted string:
        //    $"Warehouse {kvp.Key}: {kvp.Value} units"
        IEnumerable<string> over20 = primaryStock
            .Where(pair => pair.Value >= 20)
            .Select(pair => $"warehouse {pair.Key}: {pair.Value} units");

        // Print each projected string (Expected: Warehouse 100, then Warehouse 200)
        Console.WriteLine("warehouses with stock >= 20: ");
        foreach (string s in over20)
        {
            Console.WriteLine(s);
        }


        // =====================================================================
        // TASK 2: LINQ SET OPERATION (.Intersect / .Except)
        // =====================================================================
        // Find exact matching pairs between 'primaryStock' and 'backupStock' using .Intersect()
        
        // (Observe that Key 200 is excluded because its Value differs between both dictionaries: 50 vs 99) IMPORTANT
        IEnumerable<KeyValuePair<int, int>> intersecting = primaryStock.Intersect(backupStock);

        // Print the matching Key and Value pairs
        Console.WriteLine("\n\nintersecting both stocks:");
        foreach (KeyValuePair<int, int> pair in intersecting)
        {
            Console.WriteLine($"warehouse {pair.Key}: {pair.Value} units");
        }

        // Find pairs in 'primaryStock' that do NOT match 'backupStock' using .Except()
        IEnumerable<KeyValuePair<int, int>> except = primaryStock.Except(backupStock);
    
        // Print the differing Key and Value pairs
        Console.WriteLine("\n\nprimary stock except backup stock:");
        foreach (KeyValuePair<int, int> pair in except)
        {
            Console.WriteLine($"warehouse {pair.Key}: {pair.Value} units");
        }

    }
}