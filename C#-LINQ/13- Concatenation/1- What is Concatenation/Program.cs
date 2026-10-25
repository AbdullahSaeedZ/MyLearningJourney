/*
====================================================================================================
                        LINQ CONCATENATION OPERATION - Concat()
====================================================================================================

1. THE CORE IDEA:
   Enumerable.Concat appends one sequence to another, returning a single combined sequence 
   containing all elements from the first source followed directly by all elements from the second.

   - It does NOT deduplicate elements (unlike Union). Duplicate items are retained.
   - It preserves original ordering: all elements of sequence A, then all elements of sequence B.

   Data Flow:
   Sequence A: [ 1, 2, 3 ]
   Sequence B: [ 3, 4, 5 ]
   Concat():   [ 1, 2, 3, 3, 4, 5 ]  <-- Duplicate '3' is preserved!

   Concat vs. Union vs. SelectMany:
   ┌──────────────────────┬──────────────────────┬─────────────────────────────────────────────────┐
   │ Operator             │ Duplicates Handled?  │ Primary Purpose / Intent                        │
   ├──────────────────────┼──────────────────────┼─────────────────────────────────────────────────┤
   │ Concat()             │ Kept (No filtering)  │ Append exactly two known sequences              │
   │ Union()              │ Removed (Distinct)   │ Set-based unique combination                    │
   │ SelectMany()         │ Kept (No filtering)  │ Flattening dynamic or nested collections (1:N)  │
   └──────────────────────┴──────────────────────┴─────────────────────────────────────────────────┘

2. CAN'T WE JUST USE SelectMany()?
   Technically yes: `new[] { listA, listB }.SelectMany(list => list)` yields the exact same items.
   However, Concat() is preferred for two sequences because:
   - Readability: Concat explicitly expresses binary concatenation without wrapping items.
   - Zero Wrapper Allocation: SelectMany requires allocating an intermediate wrapper array 
     (`new[] { listA, listB }`) just to immediately flatten it. Concat chains the two references directly.
   - Role Distinction: Use Concat() to join two distinct streams; use SelectMany() when unpacking 
     nested collections (e.g., extracting all Choices across a collection of Questions).

3. HOW IT WORKS INTERNALLY:
   - Execution Model: Deferred streaming execution (yield return).
   - Mechanics:
       1. Enumerates all items from the first sequence using `yield return`.
       2. Once the first sequence finishes (`MoveNext()` is false), it enumerates all items 
          from the second sequence using `yield return`.
       3. Neither collection is buffered into an intermediate array or list in memory.
   - Complexity: O(N + M) time, O(1) auxiliary space (pure forward streaming).

4. COMMON PITFALLS:
   - Assuming Deduplication: Expecting Concat() to remove duplicate elements like a set operation.
   - Null Sequences: If either sequence argument is null, Concat() throws an ArgumentNullException 
     immediately upon invocation.
   - Query Syntax Absence: Concat() has no query expression keyword in C#; use method syntax.
====================================================================================================
*/