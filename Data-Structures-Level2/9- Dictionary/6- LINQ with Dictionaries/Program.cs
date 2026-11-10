/*
================================================================================
LINQ WITH DICTIONARIES: Working with KeyValuePair Streams
================================================================================

1. THE CORE IDEA:
A `Dictionary<TKey, TValue>` implements `IEnumerable<KeyValuePair<TKey, TValue>>`.
When you run LINQ operators against a dictionary, you are not querying keys or 
values in isolation—you are operating on a sequential stream of `KeyValuePair` items:

  Dictionary<string, int>
  ┌───────────────────────┐
  │ "Apple"  ──► 15       │
  │ "Banana" ──► 4        │ ──► LINQ ──► Stream of KeyValuePair<string, int>
  │ "Orange" ──► 22       │
  └───────────────────────┘

Every lambda parameter inside `.Where()`, `.Select()`, or `.OrderBy()` represents 
a single `KeyValuePair<TKey, TValue>` (exposing `.Key` and `.Value`).

2. LINQ PIPELINE MECHANICS:
- Filtering (`Where`): Inspects `.Key` or `.Value` to filter the pair stream.
- Projection (`Select`): Extracts, reshapes, or projects pairs into new forms or types.
- Ordering (`OrderBy` / `OrderByDescending`): Reorders pairs based on key or value.
- Aggregation (`Sum`, `Average`, `Count`): Collapses the collection into a scalar.
- Re-materialization (`ToDictionary`): Converts the transformed stream back into a dictionary.

3. PITFALL:
LINQ operations DO NOT return a new `Dictionary` by default. They yield deferred 
`IEnumerable<KeyValuePair<TKey, TValue>>` or `IEnumerable<TResult>` sequences. 
If you need direct key lookups again after querying, you must call `.ToDictionary(...)`.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqWithDictionaries;

class Program
{
    static void Main(string[] args)
    {
        // Initial inventory: Fruit -> (Stock Quantity, Unit Price in USD)
        // A richer data set gives meaningful filtering, sorting, and aggregations.
        Dictionary<string, (int Quantity, decimal UnitPrice)> fruitInventory = new()
        {
            { "Honeycrisp Apple", (Quantity: 45, UnitPrice: 1.50m) },
            { "Cavendish Banana",  (Quantity: 12, UnitPrice: 0.60m) },
            { "Navel Orange",     (Quantity: 80, UnitPrice: 0.90m) },
            { "Red Grape",        (Quantity: 8,  UnitPrice: 2.75m) },
            { "Golden Pineapple", (Quantity: 15, UnitPrice: 3.20m) },
            { "Watermelon",       (Quantity: 5,  UnitPrice: 5.00m) }
        };

        Console.WriteLine("=== LINQ WITH DICTIONARIES PRACTICE ===\n");


        // =====================================================================
        // TASK 1: TRANSFORMATION (Select)
        // Transform the dictionary pairs into an anonymous type containing:
        // - FruitName: string (the Key)
        // - TotalValue: decimal (Quantity * UnitPrice)
        // Print: "[FruitName] - Inventory Value: $[TotalValue]"
        // =====================================================================
        foreach (var anonymusType in fruitInventory.Select(item => new {FruitName = item.Key, TotalValue = (item.Value.Quantity * item.Value.UnitPrice) }))
        {
            Console.WriteLine($"[{anonymusType.FruitName}] - Inventory Value: ${anonymusType.TotalValue}");
        }


        Console.WriteLine("\n");
        // =====================================================================
        // TASK 2: FILTERING (Where)
        // Filter out fruits that are low in stock (Quantity < 15).
        // Print: "Low Stock Alert: [FruitName] (Only [Quantity] left)"
        // =====================================================================
        foreach (var lowStockItems in fruitInventory.Where(item => item.Value.Quantity < 15))
        {
            Console.WriteLine($"Low Stock Alert: [{lowStockItems.Key}] - Only {lowStockItems.Value.Quantity} left");
        }

        Console.WriteLine("\n");
        // =====================================================================
        // TASK 3: ORDERING (OrderBy & OrderByDescending)
        // 1. Sort the pairs ascending by Quantity.
        // 2. Sort the pairs descending by UnitPrice.
        // Print both results showing the FruitName and the sorted metric.
        // =====================================================================
        Console.WriteLine("ascending by Quantity:");
        foreach (var item in fruitInventory.OrderBy(item => item.Value.Quantity))
        {
            Console.WriteLine($"Fruit name: [{item.Key}] - Quantity {item.Value.Quantity}");
        }

        Console.WriteLine("\ndescending by UnitPrice:");
        foreach (var item in fruitInventory.OrderByDescending(item => item.Value.UnitPrice))
        {
            Console.WriteLine($"Fruit name: [{item.Key}] - UnitPrice ${item.Value.UnitPrice}");
        }
        Console.WriteLine("\n");
        // =====================================================================
        // TASK 4: AGGREGATION (Sum)
        // Calculate:
        // 1. Total units of fruit currently in the warehouse.
        // 2. Total monetary value of the entire inventory (Sum of Quantity * UnitPrice).
        // Print both scalar totals.
        // =====================================================================
        int totalItemsInStock = fruitInventory.Sum(pair => pair.Value.Quantity);
        Console.WriteLine("Total fruits in stock: " + totalItemsInStock);
        
        decimal totalMonetaryValue = fruitInventory.Sum(pair => (pair.Value.Quantity * pair.Value.UnitPrice));
        Console.WriteLine("Total monetary value of the entire inventory: $" + totalMonetaryValue);

        Console.WriteLine("\n");
        // =====================================================================
        // TASK 5: RE-MATERIALIZATION (ToDictionary)
        // Filter the inventory for items where UnitPrice > 1.00m,
        // then materialize the result directly back into a new Dictionary<string, int>
        // mapping FruitName -> Quantity.
        // Print the contents of the newly created dictionary.
        // =====================================================================
        Dictionary<string, int> newDic = fruitInventory
            .Where(pair => pair.Value.UnitPrice > 1.00m)
            .ToDictionary(pair => pair.Key, pair => pair.Value.Quantity);

        Console.WriteLine("New Dictionary with FruitName -> Quantity:");
        foreach (KeyValuePair<string, int> pair in newDic)
        {
            Console.WriteLine($"Fruit Name: {pair.Key} -> Quantity: {pair.Value}");
        }
    }
}