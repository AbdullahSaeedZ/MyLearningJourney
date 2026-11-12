/*
================================================================================
LINQ with SortedList<TKey, TValue> — Theory & Mechanics
================================================================================

1. HOW LINQ INTERACTS WITH SortedList:
- `SortedList<TKey, TValue>` implements `IEnumerable<KeyValuePair<TKey, TValue>>`.
- Therefore, every LINQ operator iterates over `KeyValuePair<TKey, TValue>` items 
  (accessing `.Key` and `.Value` on each element).
- Guaranteed Order: Because `SortedList` stores elements sorted by key, LINQ 
  queries automatically process items in ascending key order without needing 
  `.OrderBy(x => x.Key)`.

2. DEFERRED EXECUTION & IMMUTABILITY:
- Calling `.Where()`, `.Select()`, or `.GroupBy()` does NOT mutate the original 
  `SortedList`.
- Instead, it returns a new lazy `IEnumerable<T>` stream that executes when 
  iterated (`foreach`) or materialized (`.ToList()`, `.ToArray()`, etc.).

3. CORE OPERATORS IN THIS LESSON:
- `.Where(kvp => ...)`   : Filters pairs based on key, value, or both.
- `.Select(kvp => ...)`  : Projects/transforms pairs into a new shape or type.
- `.GroupBy(kvp => ...)` : Buckets pairs into `IGrouping<TGroupKey, KeyValuePair<TKey, TValue>>`.
- Method Chaining        : Passing the output stream of one operator directly 
                           into the next (e.g., `.Where(...).Select(...)`).
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace SortedListLinqPractice;

class Program
{
    static void Main()
    {
        // Dataset: Product SKU (Key) -> Category/Name string or Price
        // Using Product SKU (int) -> ProductInfo (Name, Category, Price)
        SortedList<int, (string Name, string Category, decimal Price)> inventory = new()
        {
            { 502, ("Mechanical Keyboard", "Peripherals", 120.00m) },
            { 101, ("USB-C Cable", "Accessories", 15.00m) },
            { 305, ("27-inch Monitor", "Displays", 350.00m) },
            { 108, ("Mouse Pad", "Accessories", 20.00m) },
            { 510, ("Wireless Mouse", "Peripherals", 65.00m) },
            { 301, ("Monitor Arm", "Displays", 95.00m) }
        };

        // =====================================================================
        // TASK 1: FILTERING WITH .Where()
        // GOALS:
        // - Query 'inventory' using .Where() to find all items where:
        //     - SKU (Key) is greater than 200, AND
        //     - Price (Value.Price) is less than 150.00m.
        // - Iterate through the filtered results and print SKU, Name, and Price.
        // - Notice that results remain ordered by SKU (301, then 502, then 510).
        // =====================================================================
        Console.WriteLine("Task 1:");
        foreach (KeyValuePair<int, (string, string ,decimal)> pair in inventory.Where(pair => pair.Key > 200 && pair.Value.Price < 150.00m))
        {
            Console.WriteLine($"SKU: {pair.Key}, Name: {pair.Value.Item1}, Price: {pair.Value.Item3}");
        }

        // =====================================================================
        // TASK 2: METHOD CHAINING (.Where() + .Select())
        // GOALS:
        // - Chain .Where() and .Select() on 'inventory':
        //     1. Filter for items in the "Peripherals" or "Displays" category.
        //     2. Project each matching pair into a formatted string or anonymous object
        //        containing the SKU and a 10% discounted price (Price * 0.90m).
        // - Print each projected item.
        // =====================================================================
        Console.WriteLine("\n\nTask 2:");
        foreach (var pair in inventory
                     .Where(pair => pair.Value.Category == "Peripherals" || pair.Value.Category == "Displays")
                     .Select(pair => new {SKU = pair.Key, DiscountedPrice = pair.Value.Price * 0.90m})
                 )
        {
            Console.WriteLine($"SKU: {pair.SKU}, Discounted Price: {pair.DiscountedPrice}");
        }

        // =====================================================================
        // TASK 3: GROUPING WITH .GroupBy()
        // GOALS:
        // - Group the 'inventory' entries by Category (kvp.Value.Category).
        // - Iterate through each group (IGrouping<string, ...>):
        //     - Print the Category name (group.Key) and item count (group.Count()).
        //     - Inside each group, print the SKU and Name of every product.
        // =====================================================================
        Console.WriteLine("\n\nTask 3:");
        IEnumerable<IGrouping<string, KeyValuePair<int, (string, string, decimal)>>> groups =
            inventory.GroupBy(pair => pair.Value.Category);
        
        foreach (IGrouping<string, KeyValuePair<int, (string, string, decimal)>> group in groups)
        {
            Console.WriteLine($"Category: {group.Key}, Items Count: {group.Count()}");
            foreach (KeyValuePair<int, (string, string, decimal)> pair in group)
            {
                Console.WriteLine($"    SKU: {pair.Key}, Name: {pair.Value.Item1}");
            }
        }

    }
}