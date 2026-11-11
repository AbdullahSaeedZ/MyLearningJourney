/*
================================================================================
Subset Evaluation in HashSet<T> (IsSubsetOf)
================================================================================

1. THE CORE IDEA:
`setA.IsSubsetOf(collectionB)` checks whether EVERY element in `setA` exists in 
`collectionB`.

Mathematical Definition:
  A ⊆ B  (Set A is a subset of B)

  Set A:         { 1, 2 }
  Collection B:  { 1, 2, 3, 4 }
  IsSubsetOf:    TRUE (All items of A exist in B)

  Set A:         { 1, 2, 5 }
  Collection B:  { 1, 2, 3, 4 }
  IsSubsetOf:    FALSE (5 is missing from B)

2. ASCII DIAGRAM:
  Collection B (Superset)
  ┌─────────────────────────────────┐
  │  3            4                 │
  │      Set A (Subset)             │
  │     ┌──────────────┐            │
  │     │   1      2   │            │
  │     └──────────────┘            │
  └─────────────────────────────────┘
  setA.IsSubsetOf(collectionB) ──► TRUE

3. KEY BEHAVIORS & EDGE CASES:
- Identity: Every set is a subset of itself (`setA.IsSubsetOf(setA) == true`).
- Equal Sets: If Set A and Set B have the exact same elements, both are subsets of each other.
- The Empty Set: An empty set is mathematically a subset of ANY collection.
- Parameter: Accepts any `IEnumerable<T>`, not just another `HashSet<T>`.
- Time Complexity: O(N) where N is the number of elements in `setA`.
================================================================================
*/

using System;
using System.Collections.Generic;

namespace HashSetSubset;

class Program
{
    static void Main()
    {
        HashSet<string> requiredSkills = new() { "C#", "SQL" };
        HashSet<string> applicantSkills = new() { "C#", "SQL", "Git", "Docker" };
        HashSet<string> seniorSkills = new() { "C#", "SQL", "Kubernetes" };
        HashSet<string> emptySet = new();

        // 1. True: All required skills are present in applicantSkills
        Console.WriteLine($"Is required a subset of applicant: {requiredSkills.IsSubsetOf(applicantSkills)}");

        // 2. False: "Kubernetes" is missing from applicantSkills
        Console.WriteLine($"Is senior a subset of applicant:   {seniorSkills.IsSubsetOf(applicantSkills)}");

        // 3. True: An empty set is mathematically a subset of any collection
        Console.WriteLine($"Is empty set a subset:             {emptySet.IsSubsetOf(applicantSkills)}");

        // 4. True: Every set is a subset of itself
        Console.WriteLine($"Is applicant a subset of itself:   {applicantSkills.IsSubsetOf(applicantSkills)}");
    }
}