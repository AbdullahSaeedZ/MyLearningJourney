/*
================================================================================
LESSON 08: Hashtable (Key-Value Storage & O(1) Lookups)
================================================================================

1. THE PROBLEM:
When you need to store and retrieve data instantly using a unique identifier (like 
looking up a phone number by a person's name), searching through a standard list 
one item at a time is too slow (O(N)). We need a data structure that provides 
direct access in constant time (O(1)).

2. THE CORE IDEA:
A Hashtable (or Hash Map) is an associative collection that maps unique keys to 
values using a hash function and an array of storage buckets.

   KEYS               HASH FUNCTION            STORAGE (BUCKETS)
   +-------+          +-------------+          +---------------------+
   | James | -------> |             | -------> | 01: 555-123-4251    |
   +-------+          |   Lambda    |          +---------------------+
   | Ellen | -------> | (Hash Code) | -------> | 03: 621-236-7423    |
   +-------+          +-------------+          +---------------------+

3. HOW IT WORKS INTERNALLY:
- Namespace & Typing: Resides in `System.Collections` and is **non-generic**, 
  meaning it stores keys and values as `object`.
- Performance: Offers O(1) average time complexity for insertions, deletions, 
  and lookups.
- Rules: Keys must be unique, but values can repeat. Elements have no 
  predictable order.
- The Cost (Boxing/Unboxing): Because it accepts any `object`, value types (like `int`) 
  are boxed into objects on insertion and unboxed on retrieval, hurting performance.

4. PITFALL:
- Using `Hashtable` in modern greenfield applications. Because it is non-generic 
  and lacks type safety, you must manually cast types when retrieving items. 
  Modern C# code should use `Dictionary<TKey, TValue>` instead, keeping `Hashtable` 
  relevant mainly for legacy codebases.
================================================================================
*/