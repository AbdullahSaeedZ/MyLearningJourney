/*
================================================================================
Difference (Set Subtraction) in HashSet<T> (ExceptWith vs. LINQ Except)
================================================================================

1. THE CORE IDEA:
Set difference (subtraction) removes all elements found in a second set from the first:
  Set A:        { 1, 2, 3, 4 }
  Set B:        { 3, 4, 5, 6 }
  A minus B:    { 1, 2 }

2. CRITICAL DISTINCTION: HashSet<T>.ExceptWith() vs. LINQ .Except()

  Feature               HashSet<T>.ExceptWith()           LINQ .Except()
  ─────────────────────────────────────────────────────────────────────────────
  Execution             In-Place Mutation (Eager)         Deferred Execution
  Return Value          void                              IEnumerable<T>
  Memory Allocation     Reuses existing set (No new set)  Allocates a new iterator/set
  Best Used When        Pruning an existing collection    Preserving source sets

- `setA.ExceptWith(setB)`: Mutates `setA` directly by stripping out every item that appears in `setB`.
- `setA.Except(setB)`: Leaves both `setA` and `setB` unchanged, returning a deferred sequence of items unique to `setA`.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace HashSetDifference;

class Program
{
    static void Main()
    {
        // =====================================================================
        // TASK 1: IN-PLACE MUTATION USING HashSet<T>.ExceptWith()
        // 1. Declare 'allPermissions': { "Read", "Write", "Execute", "Delete", "Admin" }.
        // 2. Declare 'restrictedPermissions': { "Delete", "Admin" }.
        // 3. Use .ExceptWith() to strip 'restrictedPermissions' from 'allPermissions'.
        // 4. Print 'allPermissions' (verify it only contains "Read", "Write", "Execute").
        // =====================================================================
        HashSet<string> allPermissions = new HashSet<string>() {"Read", "Write", "Execute", "Delete", "Admin"};
        HashSet<string> restrictedPermissions = new HashSet<string>() { "Delete", "Admin" };

        allPermissions.ExceptWith(restrictedPermissions); // mutated

        Console.WriteLine("All permissions except the restricted:");
        foreach (string permission in allPermissions)
        {
            Console.WriteLine(permission);
        }
        
        // =====================================================================
        // TASK 2: IMMUTABLE SET DIFFERENCE USING LINQ .Except()
        // 1. Declare 'enrolledStudentIds': { 1, 2, 3, 4, 5, 6 }.
        // 2. Declare 'submittedAssignmentIds': { 2, 4, 6 }.
        // 3. Find missing students (Enrolled - Submitted) using LINQ .Except().
        // 4. Materialize the missing IDs into a new HashSet<int> named 'missingStudentIds'.
        // 5. Verify and print that 'enrolledStudentIds' was NOT mutated (Count is still 6).
        // 6. Print all IDs in 'missingStudentIds'.
        // =====================================================================
        HashSet<int> enrolledStudentIds = new HashSet<int>() {1, 2, 3, 4, 5, 6};
        HashSet<int> submittedAssignmentIds = new HashSet<int>() {2, 4, 6 };

        IEnumerable<int> missingIDs = enrolledStudentIds.Except(submittedAssignmentIds); // deferred
        HashSet<int> materialized = missingIDs.ToHashSet();

        Console.WriteLine("\n\nMissing IDs that didnt submit:");
        foreach (int ID in materialized)
        {
            Console.WriteLine(ID);
        }

        Console.WriteLine("\n Proof that both sets were not mutated:");
        Console.WriteLine($"all IDs count: {enrolledStudentIds.Count}, Submitted IDs: {submittedAssignmentIds.Count}");

    }
}