/*
================================================================================
Symmetric Difference in HashSet<T> (SymmetricExceptWith)
================================================================================

1. THE CORE IDEA:
Symmetric Difference keeps elements that exist in EITHER set, but NEVER in both.
It acts like a logical XOR (discards the intersection):

  Set A:                 { 1, 2, 3, 4 }
  Set B:                 { 3, 4, 5, 6 }
  Symmetric Difference:  { 1, 2, 5, 6 }   (Elements 3 and 4 are removed)

2. COMPARISON WITH PREVIOUS IN-PLACE METHODS:

  Method                     Mathematical Operation    Behavior on 'Set A'
  ─────────────────────────────────────────────────────────────────────────────
  setA.UnionWith(setB)        Union (OR)               Adds missing elements from B.
  setA.IntersectWith(setB)    Intersection (AND)       Removes elements NOT in B.
  setA.ExceptWith(setB)       Difference (A minus B)   Removes elements found in B.
  setA.SymmetricExceptWith(B) Symmetric Difference     Keeps unique to A + unique to B;
                              (XOR)                    removes common items.

- All 4 methods modify 'setA' in-place.
- None of them allocate a new collection.
- All execute eagerly with void return type.
================================================================================
*/

using System;
using System.Collections.Generic;

namespace HashSetSymmetricDifference;

class Program
{
    static void Main()
    {
        // =====================================================================
        // TASK 1: SYMMETRIC DIFFERENCE (SymmetricExceptWith)
        // 1. Declare 'localFiles': { "main.cs", "config.json", "readme.md" }.
        // 2. Declare 'remoteFiles': { "main.cs", "config.json", "license.txt" }.
        // 3. Apply .SymmetricExceptWith() on 'localFiles' using 'remoteFiles'.
        // 4. Print 'localFiles' (verify it only contains "readme.md" and "license.txt").
        // =====================================================================
        HashSet<string> localFiles = new HashSet<string>() { "main.cs", "config.json", "readme.md" };
        HashSet<string> remoteFiles = new HashSet<string>() { "main.cs", "config.json", "license.txt" };

        localFiles.SymmetricExceptWith(remoteFiles);
        
        Console.WriteLine("Merging AND removing all intersected items entirely:");
        foreach (string localFile in localFiles)
        {
            Console.WriteLine(localFile);
        }
        
        // =====================================================================
        // TASK 2: SIDE-BY-SIDE IN-PLACE BEHAVIOR
        // Given:
        // Set A: { 1, 2, 3 }
        // Set B: { 2, 3, 4 }
        //
        // GOALS:
        // - Observe how each of the 4 in-place methods modifies Set A.
        // - Verify that your output reflects:
        //     * Union: combines all unique items.
        //     * Intersection: isolates only mutual items.
        //     * Difference: subtracts Set B from Set A.
        //     * Symmetric Difference: excludes shared items, keeping only unique elements.
        // =====================================================================
        HashSet<int> A = new HashSet<int>() { 1, 2, 3 };
        HashSet<int> B = new HashSet<int>() { 2, 3, 4 };
        
        // combines all unique items
        A.UnionWith(B);
        
        Console.WriteLine("\n\nCombine all unique items:");
        foreach (int number in A)
        {
            Console.WriteLine(number);
        }
        
        // isolates only mutual items
        A = new HashSet<int>() { 1, 2, 3 };
        A.IntersectWith(B); 
        
        Console.WriteLine("\nIsolate only mutual items:");
        foreach (int number in A)
        {
            Console.WriteLine(number);
        }
        
        // subtracts Set B from Set A
        A = new HashSet<int>() { 1, 2, 3 };
        A.ExceptWith(B); 
        
        Console.WriteLine("\nSubtract Set B from Set A:");
        foreach (int number in A)
        {
            Console.WriteLine(number);
        }
        
        
        // excludes shared items, keeping only unique elements
        A = new HashSet<int>() { 1, 2, 3 };
        A.SymmetricExceptWith(B); 
        
        Console.WriteLine("\nExclude shared items, keeping only unique elements:");
        foreach (int number in A)
        {
            Console.WriteLine(number);
        }

    }
}