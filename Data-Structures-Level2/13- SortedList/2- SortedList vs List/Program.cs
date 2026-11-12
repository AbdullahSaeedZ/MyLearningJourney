/*
================================================================================
Architecture & Trade-Offs: List<T> vs. SortedList<TKey, TValue>
================================================================================

1. OVERVIEW & PURPOSE:
While both collections rely on contiguous arrays under the hood, they solve 
fundamentally different data organization problems:
- List<T> is an indexed sequence optimized for fast data ingestion and preserving 
  arrival order.
- SortedList<TKey, TValue> is a sorted associative map designed for key-based 
  lookups and ordered retrieval.


2. THE FUNDAMENTAL DIFFERENCE:
- List<T>: 
  A linear, dynamic array of individual elements (T). Order is strictly 
  chronological / insertion-based (index represents arrival position).
- SortedList<TKey, TValue>: 
  An associative dictionary-like structure backed by TWO parallel dynamic arrays 
  (TKey[] and TValue[]). Order is strictly determined by Key comparisons.


3. ARCHITECTURAL COMPARISON:

┌─────────────────────┬──────────────────────────┬─────────────────────────────┐
│ Dimension           │ List<T>                  │ SortedList<TKey, TValue>    │
├─────────────────────┼──────────────────────────┼─────────────────────────────┤
│ Data Model          │ Single values (T)        │ Key-Value pairs (TKey, TVal)│
│                     │                          │                             │
│ Internal Memory     │ One flat array: T[]      │ Two flat arrays:            │
│                     │                          │ TKey[] _keys, TValue[] _vals│
│                     │                          │                             │
│ Ordering Principle  │ Insertion / Append order │ Sorted by Key (Ascending)   │
│                     │                          │                             │
│ Positional Access   │ list[i] -> O(1)          │ list.Keys[i], list.Values[i]│
│                     │                          │ -> O(1)                     │
│                     │                          │                             │
│ Key Lookup (Search) │ Linear scan: O(n)        │ Binary search: O(log n)     │
│                     │ (unless sorted manually) │ (always enabled)            │
│                     │                          │                             │
│ Append (At End)     │ Amortized O(1)           │ O(n) (unless new key happens│
│                     │                          │ to be > max existing key)   │
│                     │                          │                             │
│ Insert (Middle)     │ O(n) (Array.Copy shift)  │ O(n) (Array.Copy shift)     │
│                     │                          │                             │
│ Unique Keys         │ Not enforced (allows     │ Enforced strictly           │
│                     │ duplicate values)        │ (duplicate key throws)      │
└─────────────────────┴──────────────────────────┴─────────────────────────────┘


4. MECHANICS & COMPLEXITY BREAKDOWN:

A. Element Lookup:
- List<T>:
  Calling `list.Contains(item)` or `list.IndexOf(item)` performs an O(n) linear 
  scan across the array because the data is not guaranteed to be ordered.
  
- SortedList<TKey, TValue>:
  Calling `list.ContainsKey(key)` or `list[key]` performs `Array.BinarySearch` 
  on the sorted `_keys` array, completing in O(log n) time.

B. Insertion Cost:
- List<T>.Add(item):
  Places the item at `_items[_size++]`. It does not shift memory, yielding 
  amortized O(1) cost.
  
- SortedList<TKey, TValue>.Add(key, value):
  Must maintain sorted order. It runs binary search to find the correct index 
  in O(log n), then executes `Array.Copy` to shift all subsequent keys and 
  values to the right to open a slot, yielding O(n) cost.


5. WHEN TO CHOOSE WHICH:

CHOOSE List<T> WHEN:
- You need a sequence of independent elements (not key-value pairs).
- Order of insertion matters (e.g., event logs, queues, raw data streams).
- Fast append operations (O(1)) are required.
- You do not perform high-frequency key-based lookups.

CHOOSE SortedList<TKey, TValue> WHEN:
- You need an associative lookup table (key-value) that stays sorted by key.
- You need both O(log n) key lookups AND O(1) positional access by numeric index.
- The collection is populated upfront and heavily queried, minimizing write penalties.
- You want lower memory overhead and better cache locality than a tree-based 
  SortedDictionary<TKey, TValue>.
================================================================================
*/