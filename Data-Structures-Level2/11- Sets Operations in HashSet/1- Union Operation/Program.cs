/*
================================================================================
 Union in HashSet<T> (UnionWith vs. LINQ Union)
================================================================================

1. THE CORE IDEA:
A mathematical union combines two collections into one, keeping only distinct items:
  Set A: { 1, 2, 3 }
  Set B: { 3, 4, 5 }
  Union: { 1, 2, 3, 4, 5 }

2. CRITICAL DISTINCTION: HashSet<T>.UnionWith() vs. LINQ .Union()

  Feature               HashSet<T>.UnionWith()            LINQ .Union()
  ─────────────────────────────────────────────────────────────────────────────
  Execution             In-Place Mutation (Eager)         Deferred Execution
  Return Value          void                              IEnumerable<T>
  Memory Allocation     Reuses existing set (No new set)  Allocates a new iterator/set
  Best Used When        Modifying the current set         Preserving original data

- `setA.UnionWith(setB)`: Mutates `setA` directly by adding all missing elements from `setB`.
- `setA.Union(setB)`: Leaves both `setA` and `setB` untouched, returning a brand-new sequence.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace HashSetUnion;

class Program
{
    static void Main()
    {
        // =====================================================================
        // TASK 1: IN-PLACE MUTATION USING HashSet<T>.UnionWith()
        // 1. Declare 'primarySkills': { "C#", "SQL", "Git" }.
        // 2. Declare 'backendSkills': { "SQL", "ASP.NET Core", "Docker" }.
        // 3. Use .UnionWith() to merge 'backendSkills' directly into 'primarySkills'.
        // 4. Print the mutated 'primarySkills' set (verify "SQL" is not duplicated).
        // =====================================================================
        HashSet<string> primarySkills = new HashSet<string>() { "C#", "SQL", "Git" };
        HashSet<string> backendSkills = new HashSet<string>() { "SQL", "ASP.NET Core", "Docker" };
        
        primarySkills.UnionWith(backendSkills);

        Console.WriteLine("Merged Skills with no duplicates, primary set has been mutated:");
        foreach (string skill in primarySkills)
        {
            Console.WriteLine(skill);
        }

        // =====================================================================
        // TASK 2: IMMUTABLE UNION USING LINQ .Union()
        // 1. Declare 'teamAIds': { 101, 102, 103 }.
        // 2. Declare 'teamBIds': { 103, 104, 105 }.
        // 3. Combine them using LINQ .Union() to create a new sequence 'allTeamIds'.
        // 4. Materialize the result into a new HashSet<int> using .ToHashSet().
        // 5. Verify and print that 'teamAIds' was NOT modified (its count is still 3).
        // 6. Print all items in 'allTeamIds'.
        // =====================================================================
        HashSet<int> teamAIds = new HashSet<int>() { 101, 102, 103 };
        HashSet<int> teamBIds = new HashSet<int>() { 103, 104, 105 };

        IEnumerable<int> mergedDistinct = teamAIds.Union(teamBIds); // deferred
        HashSet<int> materialized = mergedDistinct.ToHashSet();
        
        Console.WriteLine("\n\nMerged Skills with no duplicates, both sets has NOT been mutated:");
        foreach (int ID in materialized)
        {
            Console.WriteLine(ID);
        }

        Console.WriteLine("\nProof that both sets were not mutated:");
        Console.WriteLine($"teamAIds count: {teamAIds.Count},  teamBIds count: {teamBIds.Count}");
    }
}