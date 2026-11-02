/*
================================================================================
Lesson 6: ToLookup (One-to-Many Grouped Materialization)
================================================================================

1. PROBLEM (WHY IT EXISTS):
   - In Lesson 5, we saw that mapping multiple items under the same key using
     .ToDictionary() requires an awkward chaining workaround:
     .GroupBy(...).ToDictionary(s => s.Key, s => s.ToList()).
   - Furthermore, accessing a missing key in a Dictionary throws a KeyNotFoundException.
   - We need a native, eager data structure built specifically for one-to-many lookups
     that groups items under a key automatically and handles missing keys safely.

2. CORE IDEA:
   - .ToLookup() is an EAGER conversion operator that organizes items into an ILookup<TKey, TElement>.
   - A Lookup is essentially a 1-to-many dictionary: 1 Key maps to an IEnumerable of values.
   - Key differences from Dictionary:
       * Handles duplicate keys automatically without crashing or needing .GroupBy().
       * Accessing a missing key returns an empty sequence instead of throwing KeyNotFoundException.
       * Immutable: Once created, you cannot add or remove keys/values.

+-----------------------+-----------------------------+-------------------------------+
| Feature               | Dictionary<TKey, TValue>    | ILookup<TKey, TElement>       |
+-----------------------+-----------------------------+-------------------------------+
| Key Uniqueness        | Strictly unique (1-to-1)    | Allows grouping (1-to-Many)   |
+-----------------------+-----------------------------+-------------------------------+
| Duplicate Key Action  | Throws ArgumentException    | Groups items under same key   |
+-----------------------+-----------------------------+-------------------------------+
| Missing Key Access    | Throws KeyNotFoundException | Returns empty sequence        |
+-----------------------+-----------------------------+-------------------------------+
| Mutability            | Mutable (Add / Remove)      | Immutable (Read-only)         |
+-----------------------+-----------------------------+-------------------------------+

3. HOW IT WORKS INTERNALLY:
   - Immediately enumerates the source sequence.
   - Computes the key for each item and hashes it into internal groupings.
   - Allocates an internal Lookup<TKey, TElement> table containing grouped collections.

4. WHEN NOT TO USE & COMMON PITFALLS:
   - Forgetting that lookup[key] returns a collection: Even if a key only has
     one matching item, lookup[key] returns an IEnumerable<T>, so you must call
     .First() or iterate over it to access the object.
   - Needing mutation: If you need to dynamically add or delete key-value pairs
     after creation, use Dictionary<TKey, List<TValue>> instead of ILookup.
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
            // Part 1: Lookup by Unique Key (1-to-Many structure, 1 item per key)
            // =============================================================
            Console.WriteLine("=== 1. Unique Key: ILookup<string, Shipping> ===");

            // Lambda (x => x.UniqueId): selects UniqueId as the grouping key.
            ILookup<string, Shipping> lookup1 = shippings.ToLookup(x => x.UniqueId);

            // lookup1["ABC005"] returns an IEnumerable<Shipping>, so we call .First() to get the item.
            lookup1["ABC005"].First().Start();


            // =============================================================
            // Part 2: Lookup by Non-Unique Key (Native 1-to-Many grouping)
            // =============================================================
            Console.WriteLine("\n=== 2. Duplicate Keys: ILookup<DateTime, Shipping> ===");

            // Lambda (x => x.ShippingDate): automatically groups all shipments sharing the same date under that date.
            ILookup<DateTime, Shipping> lookup2 = shippings.ToLookup(x => x.ShippingDate);

            DateTime date = DateTime.Today;

            // lookup2[date] directly returns the grouped IEnumerable<Shipping> for that date.
            lookup2[date].Process($"Shippings on {date.ToString("dddd, MMMM dd yyyy")}");
        }
    }
}