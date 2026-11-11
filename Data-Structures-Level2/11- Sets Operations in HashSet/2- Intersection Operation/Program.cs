/*
================================================================================
Intersection in HashSet<T> (IntersectWith vs. LINQ Intersect)
================================================================================

1. THE CORE IDEA:
Mathematical intersection extracts only elements that exist in BOTH sets:
  Set A:        { 1, 2, 3, 4 }
  Set B:        { 3, 4, 5, 6 }
  Intersection: { 3, 4 }

2. CRITICAL DISTINCTION: HashSet<T>.IntersectWith() vs. LINQ .Intersect()

  Feature               HashSet<T>.IntersectWith()        LINQ .Intersect()
  ─────────────────────────────────────────────────────────────────────────────
  Execution             In-Place Mutation (Eager)         Deferred Execution
  Return Value          void                              IEnumerable<T>
  Memory Allocation     Reuses existing set (No new set)  Allocates a new iterator/set
  Best Used When        Filtering an existing set down    Preserving original data

- `setA.IntersectWith(setB)`: Mutates `setA` directly by removing any element that is not also in `setB`.
- `setA.Intersect(setB)`: Leaves both `setA` and `setB` untouched, returning a brand-new sequence containing only common elements.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace HashSetIntersection;

class Program
{
    static void Main()
    {
        // =====================================================================
        // TASK 1: IN-PLACE MUTATION USING HashSet<T>.IntersectWith()
        // 1. Declare 'backendDevCandidates': { "Alice", "Bob", "Charlie", "David" }.
        // 2. Declare 'passedTechnicalInterview': { "Bob", "David", "Eve" }.
        // 3. Use .IntersectWith() to filter 'backendDevCandidates' down to only candidates
        //    who passed the technical interview.
        // 4. Print 'backendDevCandidates' (verify it only contains "Bob" and "David").
        // =====================================================================
        HashSet<string> backendDevCandidates = new HashSet<string>() { "Alice", "Bob", "Charlie", "David" };
        HashSet<string> passedTechnicalInterview = new HashSet<string>() { "Bob", "David", "Eve" };
        
        Console.WriteLine("All candidate names:");
        foreach (string candidate in backendDevCandidates)
        {
            Console.WriteLine(candidate);
        }
        
        backendDevCandidates.IntersectWith(passedTechnicalInterview); // mutated

        Console.WriteLine("\nAfter keeping ONLY intersecting names:");
        foreach (string candidate in backendDevCandidates)
        {
            Console.WriteLine(candidate);
        }

        // =====================================================================
        // TASK 2: IMMUTABLE INTERSECTION USING LINQ .Intersect()
        // 1. Declare 'serverAOpenPorts': { 80, 443, 22, 8080 }.
        // 2. Declare 'serverBOpenPorts': { 443, 8080, 5432, 3306 }.
        // 3. Find common open ports using LINQ .Intersect().
        // 4. Materialize the result into a new HashSet<int> named 'commonPorts'.
        // 5. Verify and print that both 'serverAOpenPorts' and 'serverBOpenPorts' 
        //    counts remain unchanged (both still 4).
        // 6. Print all common ports.
        // =====================================================================

        HashSet<int> serverAOpenPorts = new HashSet<int>() { 80, 443, 22, 8080 };
        HashSet<int> serverBOpenPorts = new HashSet<int>() { 443, 8080, 5432, 3306 };

        IEnumerable<int> commonOpenPorts = serverAOpenPorts.Intersect(serverBOpenPorts); // deferred
        HashSet<int> materialized = commonOpenPorts.ToHashSet();
        
        Console.WriteLine("\n\nCommon open ports using LINQ .Intersect():");
        foreach (int port in materialized)
        {
            Console.WriteLine(port);
        }

        Console.WriteLine("\nProof that both sets were not mutated with LINQ:");
        Console.WriteLine($"A Open Ports count: {serverAOpenPorts.Count}, B Open Ports count: {serverBOpenPorts.Count}");

    }
}