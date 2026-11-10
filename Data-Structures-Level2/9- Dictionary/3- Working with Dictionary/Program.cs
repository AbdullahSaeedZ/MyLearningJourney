/*
================================================================================
LESSON 10.1: Working with Dictionary<TKey, TValue> — Core Operations
================================================================================

1. THE PROBLEM:
When working with key-value data, you frequently need to insert, read, update, 
and remove items safely without triggering runtime crashes when keys already 
exist or are missing.

2. THE CORE IDEA (Common Operations & Methods):
- Adding:
  * `.Add(key, value)`: Inserts a pair. Throws an exception if the key exists.
  * `[key] = value`: Inserts if missing, or overwrites/updates if it already exists.
 * 
- Querying:
  * `.ContainsKey(key)`: Fast O(1) check to see if a key exists before reading it.
  * `.TryGetValue(key, out var val)`: Safely retrieves the value in one step without crashing.
 * 
- Deleting:
  * `.Remove(key)`: Deletes the key-value pair and returns true if found.
  * `.Clear()`: Removes all items from the collection.
 * 
- Enumerating:
  * Iterates as `KeyValuePair<TKey, TValue>` structs (no heap allocation).

3. PITFALL:
- Using `dict[key]` to read a value without checking `.ContainsKey(key)` or using 
  `.TryGetValue()`. If the key does not exist, reading via the indexer throws a 
  `KeyNotFoundException`.
================================================================================
*/

using System;
using System.Collections.Generic;

namespace _3__Working_with_Dictionary;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> fruitBasket = new Dictionary<string, int>();
        
        // Adding elements
        fruitBasket.Add("Apple", 4);
        fruitBasket.Add("Orange", 4);
        fruitBasket.Add("Banana", 2);
        
        // Duplicate keys via .Add() throw an ArgumentException:
        // fruitBasket.Add("Banana", 5);
        
        // Assigning and updating (Indexer safely inserts or overwrites)
        fruitBasket["Apple"] = 10;

        Console.WriteLine("Dictionary Content:");
        foreach (KeyValuePair<string, int> pair in fruitBasket)
        {
            Console.WriteLine($"key: {pair.Key}, Value: {pair.Value}");
        }
        
        // Removing elements
        fruitBasket.Remove("Apple");

        Console.WriteLine("\n\nDictionary Content after removal:");
        foreach (KeyValuePair<string, int> pair in fruitBasket)
        {
            Console.WriteLine($"key: {pair.Key}, Value: {pair.Value}");
        }
    }
}