/*
================================================================================
 Dictionary<TKey, TValue> (The Modern, Type-Safe Hashtable)
================================================================================

1. THE PROBLEM:
While `Hashtable` gives us fast O(1) key-value lookups, it is non-generic and 
stores everything as `object`. This forces slow casting and performance-killing 
boxing/unboxing when using value types, and introduces runtime type-casting crashes.

2. THE CORE IDEA:
Dictionary is an advanced form of hashtable; both are built on similar concepts 
like using hash functions and buckets to map keys to values. `Dictionary<TKey, TValue>` 
is its generic evolution in C# (similar to `std::map` in C++). It enforces 
strict types at compile time for both keys and values, eliminating casting and 
boxing overhead entirely.

   NON-GENERIC (Hashtable)               GENERIC (Dictionary<TKey, TValue>)
   +------------------------+            +---------------------------------+
   | Key: object            |            | Key: int (Strongly Typed)       |
   | Value: object          |            | Value: string (Strongly Typed)  |
   +------------------------+            +---------------------------------+
   Requires casting & boxing             Zero casting, zero boxing!

3. HOW IT WORKS INTERNALLY:
- Namespace: Resides in the `System.Collections.Generic` namespace.
- Type Safety: The compiler guarantees you can only put the specified data types 
  into the dictionary, catching bugs before the program runs.
- Performance: Retains the fast O(1) average time complexity for insertions, 
  deletions, and searches while running significantly faster than `Hashtable` due 
  to the absence of boxing.
- Rules: Keys must be unique, values can repeat, and elements have no predictable order.

4. PITFALL:
- Modifying the keys or structure of a Dictionary inside a `foreach` loop. Just 
  like other generic collections, mutating a dictionary while enumerating over it 
  will throw an immediate runtime exception.
================================================================================
*/