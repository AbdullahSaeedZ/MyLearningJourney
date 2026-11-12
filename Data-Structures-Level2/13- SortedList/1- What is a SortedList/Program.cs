/*
   ================================================================================
   SortedList<TKey, TValue> — Foundations, Architecture & Mechanics
   ================================================================================
   
   1. WHAT IT IS:
   An associative key-value collection stored internally across two contiguous, 
   parallel arrays:
     Keys[]:   [ 10,     25,       40    ]   <-- Kept strictly sorted at all times
     Values[]: [ "Low",  "Medium", "High"]   <-- Aligned at matching indices
   
   # Similar to a Dictionary, it also does not allow duplicate keys.
   
   
   2. THE DUAL ACCESS ADVANTAGE (VS. DICTIONARY):
   Unlike a standard Dictionary<TKey, TValue> that only permits key lookups, 
   SortedList provides two distinct ways to access data:
   
     A. Positional Numeric Indexing:
        Because keys and values live in flat arrays, you get direct O(1) integer 
        indexing by position:
          list.Keys[i]   -> O(1) direct array access (e.g., list.Keys[0] is the smallest)
          list.Values[i] -> O(1) direct array access (e.g., list.Values[0] is its value)
        A standard Dictionary cannot do this without copying and buffering elements.
   
     B. Key-Based Access (Searching):
        Accessing by key like a dictionary:
          string val = list[key];
          bool found = list.TryGetValue(key, out string? val);
   
   
   3. HOW KEY SEARCH WORKS (AND WHY IT IS O(log n)):
   - The Problem in Unsorted Arrays:
     Searching an unsorted array requires scanning element by element: O(n).
   
   - The Solution in SortedList:
     Because the internal Keys[] array is strictly sorted on every insertion, 
     the runtime executes Array.BinarySearch instead of a linear scan:
       1. Reads the middle element of Keys[].
       2. Compares it against the target key.
       3. Eliminates the left or right half entirely based on the comparison.
       4. Halves the remaining search range on every step until found.
   
     -> Cause & Effect: 
        Sorted Keys[] array -> Enables Binary Search -> Produces O(log n) lookup.
        (e.g., finding a key in 1,000 items takes at most ~10 checks: log2(1000) ≈ 10).
   
   - Contrast with Dictionary:
     Dictionary does not sort or binary search. It feeds the key to GetHashCode(), 
     computes an array bucket index via math, and jumps directly to the entry in 
     ~O(1) time.
   
   
   # Hence, slower in addition and removal, fast in retrieval.
   
   4. THE WRITE BOTTLENECK (INSERTION & DELETION):
   While searching is fast at O(log n), modifying the collection costs O(n):
   - Binary search locates the correct slot in O(log n).
   - Array.Copy must then shift every subsequent element in memory to the right to 
     open space for the new key and value.
   - Removing an item forces an Array.Copy shift to the left to close the gap.
   
   
   5. ARCHITECTURAL COMPARISON:
   ┌─────────────────────┬──────────────────────────┬─────────────────────────────┐
   │ Dimension           │ Dictionary<TKey, TValue> │ SortedList<TKey, TValue>    │
   ├─────────────────────┼──────────────────────────┼─────────────────────────────┤
   │ Internal Storage    │ Buckets + Entries arrays │ Two compact, packed arrays  │
   │ Key Order           │ Unordered                │ Strictly sorted (ascending) │
   │ Positional Access   │ Impossible (no indexers) │ O(1) via .Keys[i],.Values[i]│
   │ Key Lookup (Search) │ O(1) via Hash Calculation│ O(log n) via Binary Search  │
   │ Insert / Delete     │ O(1) average             │ O(n) via Array.Copy shifting│
   │ Memory Footprint    │ Medium (hashing tables)  │ Minimal (pure array layout) │
   └─────────────────────┴──────────────────────────┴─────────────────────────────┘
   ================================================================================
   */