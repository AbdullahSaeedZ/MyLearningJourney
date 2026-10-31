/*
====================================================================================================
                        LINQ SET OPERATIONS - Overview
====================================================================================================

1. THE CORE IDEA:
   Set operations produce a result based on the presence or absence of equivalent elements 
   within the same collection or across two collections, derived from mathematical set theory.

   Unlike concatenation or simple filtering, set operations automatically deduplicate elements.

   Primary LINQ Set Operators:
   ┌──────────────────────┬────────────────────────────────────────────────────────────────────────┐
   │ Method               │ Mathematical Meaning & Behavior                                        │
   ├──────────────────────┼────────────────────────────────────────────────────────────────────────┤
   │ Distinct()           │ Removes duplicate elements from a single sequence.                     │
   │ DistinctBy()         │ (.NET 6+) Removes duplicates based on a specific key selector.         │
   │ Union()              │ Combines two sequences, removing any duplicate elements.               │
   │ UnionBy()            │ (.NET 6+) Combines two sequences, deduplicating by a key selector.     │
   │ Intersect()          │ Returns only elements that appear in BOTH sequences.                   │
   │ IntersectBy()        │ (.NET 6+) Returns elements from the first sequence whose keys exist    │
   │                      │ in the second key sequence.                                            │
   │ Except()             │ Returns elements in the first sequence that DO NOT exist in the second.│
   │ ExceptBy()           │ (.NET 6+) Returns elements from the first sequence whose keys DO NOT   │
   │                      │ exist in the second key sequence.                                      │
   └──────────────────────┴────────────────────────────────────────────────────────────────────────┘

   Visual Set Comparisons:
   Sequence A: [ 1, 2, 3 ]
   Sequence B: [ 2, 3, 4 ]

   Distinct(A):   [ 1, 2, 3 ]
   Union(A, B):     [ 1, 2, 3, 4 ]       (Set combination without duplicates)
   Intersect(A, B): [ 2, 3 ]             (Overlap / common elements only)
   Except(A, B):    [ 1 ]                (Elements in A that are missing from B)

2. HOW IT WORKS INTERNALLY:
   - Execution Model: Deferred streaming execution (`yield return`).
   - Internal Hash Set:
     Under the hood, LINQ utilizes a `Set<TElement>` (an internal lightweight `HashSet<T>`).
     As elements stream through, it computes hash codes and inserts them into this lookup.
   - Streaming vs. Buffering:
     - `Distinct()` streams immediately: yields an item, remembers it in the hash set, and skips it next time.
     - `Intersect()` and `Except()` buffer the ENTIRE second sequence into a hash set first,
       then stream-filter the first sequence against that lookup.
   - Equality Comparison:
     Equality is evaluated via `EqualityComparer<T>.Default`. For custom classes (like `Employee` or `Meeting`),
     it relies on overridden `Equals()` and `GetHashCode()`, or an explicit `IEqualityComparer<T>`.

3. COMMON PITFALLS:
   - Forgetting to Override `GetHashCode()`:
     Overriding `Equals()` alone is not enough. Set operations insert items into hash buckets first;
     if `GetHashCode()` returns different values for identical items, duplicates will NOT be filtered.
   - Expecting Concat-like Order:
     While LINQ preserves the relative first-seen order for `Distinct()`, set operations logically 
     treat data as unordered sets.
   - Large Second Collections:
     `Except()` and `Intersect()` buffer the second sequence into memory. A massive second collection
     causes an upfront memory allocation spike before the first item can be yielded.
====================================================================================================
*/

