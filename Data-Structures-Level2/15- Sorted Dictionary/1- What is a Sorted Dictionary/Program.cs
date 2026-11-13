/*
================================================================================
SortedDictionary<TKey, TValue> — Foundations, Architecture & Comparisons
================================================================================

1. WHAT IT IS:
`SortedDictionary<TKey, TValue>` is a generic key-value collection that keeps 
its pairs strictly sorted by key (ascending by default, or via a custom 
`IComparer<TKey>`) at all times.


2. THE PROBLEM IT SOLVES:
- `Dictionary<TKey, TValue>`:
  Provides ultra-fast O(1) hash lookups and insertions, but keys are completely 
  unordered. Retrieving elements in sorted order requires extracting and sorting 
  the entire collection: O(n log n).

- `SortedList<TKey, TValue>`:
  Keeps keys sorted using two flat parallel arrays, giving fast O(log n) key lookups 
  and O(1) index access. However, inserting or deleting elements forces 
  `Array.Copy` to shift subsequent elements in memory, creating an O(n) write 
  bottleneck on large datasets.

- `SortedDictionary<TKey, TValue>`:
  Solves the write bottleneck by replacing flat arrays with a self-balancing 
  tree. Keys stay sorted while insertions, deletions, and lookups all run in 
  O(log n) without shifting memory.


3. HOW IT WORKS INTERNALLY (BALANCED TREE):
Under the hood, `SortedDictionary<TKey, TValue>` is implemented as a 
**Self-Balancing Binary Search Tree (Red-Black Tree)**—specifically wrapping a 
tree of `KeyValuePair<TKey, TValue>` nodes:
- Each entry is stored in its own heap-allocated `Node` object with pointers to 
  Left (smaller key) and Right (larger key) children.
- Searching traverses down one branch at a time, cutting the remaining nodes in 
  half on each step -> O(log n).
- Inserting or deleting updates node pointers in O(log n) without copying or 
  shifting blocks of memory.


4. PERFORMANCE & MEMORY TRADE-OFFS:
- Key Search (`[key]`, `TryGetValue`): O(log n) — Tree traversal by key comparison.
- Insert / Delete (`Add`, `Remove`):   O(log n) — Tree traversal + pointer updates.
- Positional Index Access (`[i]`):     NOT SUPPORTED — Tree nodes have no numeric index.
- Memory Overhead:                     HIGH — Every key-value pair allocates a 
                                       separate `Node` object on the managed heap 
                                       with child pointers and color metadata.


5. ARCHITECTURAL COMPARISON (Dictionary vs. SortedList vs. SortedDictionary):
┌─────────────────────┬────────────────────────┬───────────────────────┬──────────────────────────┐
│ Dimension           │ Dictionary<K, V>       │ SortedList<K, V>      │ SortedDictionary<K, V>   │
├─────────────────────┼────────────────────────┼───────────────────────┼──────────────────────────┤
│ Internal Structure  │ Hash Buckets + Entries │ Two Parallel Arrays   │ Red-Black Tree (Nodes)   │
│ Key Ordering        │ Unordered              │ Strictly Sorted       │ Strictly Sorted          │
│ Key Lookup (Search) │ O(1) average (Hash)    │ O(log n) (BinarySrch) │ O(log n) (Tree Traversal)│
│ Insert (`Add`)      │ O(1) average           │ O(n) (Array.Copy)     │ O(log n) (Pointer update)│
│ Delete (`Remove`)   │ O(1) average           │ O(n) (Array.Copy)     │ O(log n) (Pointer update)│
│ Index Access [i]    │ Not Supported          │ O(1) (.Keys[i])       │ Not Supported            │
│ Memory Footprint    │ Medium (Hash tables)   │ Minimal (Flat arrays) │ High (Heap node objects) │
└─────────────────────┴────────────────────────┴───────────────────────┴──────────────────────────┘


6. WHEN TO USE WHICH:
- Use `Dictionary<TKey, TValue>`:
  When key order does not matter and you want maximum O(1) speed for reads and writes.

- Use `SortedList<TKey, TValue>`:
  When you need sorted keys, minimal memory usage, and O(1) positional index 
  access (`[i]`), and the dataset is small or rarely modified after initial load.

- Use `SortedDictionary<TKey, TValue>`:
  When you need sorted keys on a large, dynamic dataset with frequent random 
  insertions and deletions (avoiding the O(n) array-shifting penalty).
================================================================================
*/
