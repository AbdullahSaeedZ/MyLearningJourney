/*
================================================================================
Lesson 5: ToDictionary (Key-Value Pair Materialization)
================================================================================

1. PROBLEM (WHY IT EXISTS):
   - Finding an item in a List<T> or array by ID takes O(n) linear search time.
   - When you need fast O(1) lookups by a unique identifier (like a tracking ID),
     you convert the sequence into a Dictionary<TKey, TValue>.
   - Like .ToList() and .ToArray(), .ToDictionary() is an EAGER operator:
     it iterates immediately and allocates a hash table in RAM.

2. CORE IDEA:
   - Maps each item in a sequence to a Key-Value pair.
   - CRITICAL RULE: Keys MUST be unique. If two items produce the same key,
     .ToDictionary() throws an ArgumentException (duplicate key crash).
   - Case 1 (1-to-1): Key is unique per item -> Direct .ToDictionary().
   - Case 2 (1-to-Many): Multiple items share a key -> Group them first, 
     then store the values as a List<TValue>.

+----------------------------------+------------------------+-----------------------------------------------+
| Scenario                         | Resulting Type         | How It Works                                  |
+----------------------------------+------------------------+-----------------------------------------------+
| 1-to-1 (Unique Key)              | Dictionary<K, V>       | Item -> Single Value                          |
+----------------------------------+------------------------+-----------------------------------------------+
| 1-to-Many (Grouping Duplicates)  | Dictionary<K, List<V>> | .GroupBy() bundles duplicates into lists      |
|                                  |                        | so the dictionary key stays unique.           |
+----------------------------------+------------------------+-----------------------------------------------+

3. HOW IT WORKS INTERNALLY:
   - Evaluates the key selector function for every element.
   - Inserts each element into an internal hashtable backing the Dictionary<TKey, TValue>.
   - Throws ArgumentException if an identical key is encountered twice.

4. WHEN NOT TO USE & COMMON PITFALLS:
   - Duplicate keys: Never run direct .ToDictionary() on non-unique data (like dates or status).
   - The .GroupBy().ToDictionary() pattern is often over-engineered; C# provides
     .ToLookup() specifically for 1-to-many lookup scenarios (covered next).
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;
using Conversion.Shared;

namespace LinqDeepDive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Shipping> shippings = ShippingRepository.AllAsList;

            // =============================================================
            // Part 1: 1-to-1 Mapping (Unique Key)
            // =============================================================
            // UniqueId is unique per shipment.
            // Fast O(1) lookup by tracking number.
            Console.WriteLine("=== 1. Unique Key: Dictionary<string, Shipping> ===");

            // Lambda (x => x.UniqueId): selects each shipment's UniqueId to serve as the dictionary key
            Dictionary<string, Shipping> dictionary1 = shippings.ToDictionary(x => x.UniqueId);

            dictionary1["ABC005"].Start();


            // =============================================================
            // Part 2: 1-to-Many Mapping (Handling Duplicate Keys)
            // =============================================================
            // ShippingDate is NOT unique (multiple shipments happen on the same day).
            // We must group them first so the dictionary key (DateTime) stays unique,
            // with the value being the List<Shipping> of all items on that date.
            Console.WriteLine("\n=== 2. Duplicate Keys: GroupBy -> Dictionary<DateTime, List<Shipping>> ===");

            Dictionary<DateTime, List<Shipping>> dictionary2 = shippings
                .GroupBy(x => x.ShippingDate) // (x => x.ShippingDate) groups shipments by date,
                .ToDictionary(s => s.Key, s => s.ToList());
            // (s => s.Key) uses that date as the dictionary key, and (s => s.ToList()) converts the grouped items into a list value
            
            
            DateTime date = DateTime.Today;
            if (dictionary2.ContainsKey(date))
            {
                dictionary2[date].Process($"Shippings on {date.ToString("dddd, MMMM dd yyyy")}");
            }
        }
    }
}