/*
================================================================================
DICTIONARY: TryGetValue & TryAdd (Safe & Efficient Access)
================================================================================

1. THE CORE IDEA (Why We Use Them):
Direct operations fail loudly or waste CPU cycles:
- Indexer (`dict[key]`) throws KeyNotFoundException if the key is missing.
- `.Add(key, value)` throws ArgumentException if the key already exists.
- Checking `.ContainsKey()` first is wasteful because it forces two full hash 
  lookups: one to check, and one to read/write.

`TryGetValue` and `TryAdd` exist to combine checking and acting into a single, 
safe, O(1) hash lookup with zero exceptions thrown.

2. TRYGETVALUE LOOKUP (Safe Read):
Key ──► [ Hash & Bucket Lookup ] ──┬──► Found     ──► Outputs value & returns true
                                   └──► Not Found ──► Outputs default & returns false

3. TRYADD LOOKUP (Safe Write):
Key ──► [ Hash & Bucket Lookup ] ──┬──► Found     ──► Leaves dict untouched & returns false
                                   └──► Not Found ──► Inserts pair & returns true

4. PITFALL:
Never read the `out` variable if `TryGetValue` returns `false`—it holds an 
uninitialized default value (e.g., 0, null, or false).
================================================================================
*/

using System;
using System.Collections.Generic;

namespace _5__TryGetValue_and_TryAdd;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> fruitBasket = new()
        {
            { "Apple", 5 },
            { "Banana", 2 }
        };

        // =====================================================================
        // 1. TryGetValue (Safe Reading in a Single Lookup)
        // =====================================================================

        // Non-existent key: returns false, orangeCount defaults to 0
        if (fruitBasket.TryGetValue("Orange", out int orangeCount))
        {
            Console.WriteLine($"Found Orange: {orangeCount}");
        }
        else
        {
            Console.WriteLine("Orange not found.");
        }

        // Existing key: returns true, extracts value
        if (fruitBasket.TryGetValue("Banana", out int bananaCount))
        {
            Console.WriteLine($"Found Banana: {bananaCount}");
        }

        // =====================================================================
        // 2. TryAdd (Safe Insertion in a Single Lookup)
        // =====================================================================

        // Key exists: returns false, dictionary remains untouched (Apple is still 5)
        bool appleAdded = fruitBasket.TryAdd("Apple", 10);
        Console.WriteLine($"Apple added: {appleAdded} (Current count: {fruitBasket["Apple"]})");

        // Key is new: returns true, pair inserted directly
        bool grapeAdded = fruitBasket.TryAdd("Grape", 8);
        Console.WriteLine($"Grape added: {grapeAdded} (Current count: {fruitBasket["Grape"]})");
    }
}