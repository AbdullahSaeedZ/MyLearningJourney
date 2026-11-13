/*
================================================================================
SortedSet<T> — Foundations, Internal Architecture & Trade-offs
================================================================================

1. WHAT IT IS:
`SortedSet<T>` is a generic collection of UNIQUE elements maintained in strictly 
sorted order at all times.

- Like `HashSet<T>`: It enforces uniqueness (duplicate elements are silently 
  ignored) and provides set operations (UnionWith, IntersectWith, ExceptWith).
- Unlike `HashSet<T>`: Elements are kept sorted automatically (using 
  `IComparable<T>` or a custom `IComparer<T>`), NOT stored by hash buckets.


2. THE PROBLEM IT SOLVES:
- `HashSet<T>` gives O(1) lookups and uniqueness, but elements are stored in 
  pseudo-random bucket order. Getting elements in sorted order or finding the 
  Min/Max requires sorting or scanning the entire set: O(n log n) or O(n).
- `List<T>` can be sorted manually, but does not enforce uniqueness and costs 
  O(n) to insert in sorted position due to array element shifting.
- `SortedSet<T>` maintains uniqueness AND sorted order dynamically on every 
  insert and delete without shifting arrays.


3. HOW IT WORKS INTERNALLY (BALANCED TREE):
Unlike `SortedList<TKey, TValue>` (which uses flat arrays), `SortedSet<T>` stores 
elements in a **Self-Balancing Binary Search Tree (Red-Black Tree)**:
- Each element lives in its own heap-allocated `Node` object linking to smaller 
  (left) and larger (right) child nodes.
- Because it uses linked nodes instead of contiguous arrays, inserting or 
  deleting updates pointers in O(log n) without copying or shifting blocks of 
  memory.


4. PERFORMANCE & COMPLEXITY:
- Search (`Contains`):       O(log n) — Tree traversal from root to leaf.
- Insert (`Add`):            O(log n) — Tree traversal + pointer updates.
- Delete (`Remove`):         O(log n) — Tree traversal + pointer updates.
- Min / Max (`.Min`, `.Max`): O(log n) — Walks down the leftmost or rightmost spine.
- Positional Indexing:       NOT SUPPORTED (`set[0]` is impossible; tree nodes 
                             have no contiguous index).
- Memory Footprint:          High — Every element allocates a separate `Node` 
                             object on the heap.


5. ARCHITECTURAL COMPARISON (HashSet vs. SortedSet vs. SortedList):
┌─────────────────────┬────────────────────┬────────────────────┬────────────────────┐
│ Dimension           │ HashSet<T>         │ SortedSet<T>       │ SortedList<K, V>   │
├─────────────────────┼────────────────────┼────────────────────┼────────────────────┤
│ Data Model          │ Single values (T)  │ Single values (T)  │ Key-Value pairs    │
│ Internal Structure  │ Hash Buckets Array │ Red-Black Tree     │ Parallel Arrays    │
│ Element Order       │ Unordered          │ Strictly Sorted    │ Strictly Sorted    │
│ Search (`Contains`) │ O(1) average       │ O(log n)           │ O(log n)           │
│ Insert (`Add`)      │ O(1) average       │ O(log n)           │ O(n) (Array.Copy)  │
│ Delete (`Remove`)   │ O(1) average       │ O(log n)           │ O(n) (Array.Copy)  │
│ Index Access [i]    │ Not Supported      │ Not Supported      │ O(1) (.Keys[i])    │
│ Memory Overhead     │ Low-Medium         │ High (Heap Nodes)  │ Minimal (Packed)   │
└─────────────────────┴────────────────────┴────────────────────┴────────────────────┘


6. WHEN TO USE VS. AVOID:
- USE WHEN:
  * You need unique elements kept continuously sorted while performing frequent 
    insertions and deletions.
  * You need fast range queries (`GetViewBetween(min, max)`) or frequent 
    `.Min` / `.Max` lookups.
- AVOID WHEN:
  * Order does not matter -> Use `HashSet<T>` for faster O(1) operations and 
    lower memory usage.
  * You need positional index access (`[i]`) -> Use `SortedList` or a sorted `List<T>`.
================================================================================
*/