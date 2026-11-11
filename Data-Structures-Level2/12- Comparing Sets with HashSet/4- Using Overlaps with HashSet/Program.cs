/*
================================================================================
Overlaps in HashSet<T> (Overlaps)
================================================================================

1. THE CORE IDEA:
`setA.Overlaps(collectionB)` checks whether `setA` and `collectionB` share 
AT LEAST ONE common element. It answers: "Is the intersection non-empty?"

Mathematical Definition:
  A ∩ B ≠ ∅  (Intersection is not empty)

  Set A:         { 1, 2, 3 }
  Set B:         { 3, 4, 5 }
  Overlaps:      TRUE (3 is shared)

  Set A:         { 1, 2, 3 }
  Set C:         { 6, 7, 8 }
  Overlaps:      FALSE (Disjoint sets; zero common elements)

2. KEY BEHAVIORS & OPTIMIZATION:
- Short-Circuiting: It stops iterating the moment the FIRST matching item is found.
- Empty Sets: An empty set overlaps with NOTHING:
  `new HashSet<int>().Overlaps(anySet) == false`.
- Parameter: Accepts any `IEnumerable<T>`, not just `HashSet<T>`.
- Time Complexity: Best-case O(1), Worst-case O(N) where N is elements checked 
  before finding a match.
================================================================================
*/

using System;
using System.Collections.Generic;

namespace HashSetOverlaps;

class Program
{
    static void Main()
    {
        HashSet<int> set1 = new() { 1, 2, 3 };
        HashSet<int> set2 = new() { 3, 4, 5 };
        HashSet<int> set3 = new() { 6, 7, 8 };
        HashSet<int> emptySet = new();

        // 1. True: set1 and set2 share element 3
        Console.WriteLine($"Does set1 overlap with set2: {set1.Overlaps(set2)}");

        // 2. False: set1 and set3 share zero elements (disjoint)
        Console.WriteLine($"Does set1 overlap with set3: {set1.Overlaps(set3)}");

        // 3. False: an empty collection has no elements to share
        Console.WriteLine($"Does set1 overlap with empty: {set1.Overlaps(emptySet)}");

        // 4. True: any non-empty set overlaps with itself
        Console.WriteLine($"Does set1 overlap with itself: {set1.Overlaps(set1)}");
    }
}