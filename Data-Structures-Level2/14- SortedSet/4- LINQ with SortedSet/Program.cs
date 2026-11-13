/*
================================================================================
Hands-On: LINQ with SortedSet<T>
================================================================================

1. CORE THEORY:
- `SortedSet<T>` implements `IEnumerable<T>`, meaning every standard LINQ operator 
  works directly on its elements.
  
- Preserved Order: Because `SortedSet<T>` stores elements in sorted order, LINQ 
  queries iterate through elements in ascending order automatically (no `.OrderBy()` 
  needed).
  
- Non-Mutating & Deferred:
  Unlike `ISet<T>` methods (`UnionWith`, `IntersectWith`, `ExceptWith`) which mutate 
  the set in-place, LINQ set operators (`.Union()`, `.Intersect()`, `.Except()`) 
  leave both source collections untouched and return a new lazy `IEnumerable<T>`.
  
- Note on LINQ Set Operators:
  `.Union()`, `.Intersect()`, and `.Except()` yield distinct elements, and when 
  applied to `SortedSet<T>`, preserve the sorted traversal order of the first sequence.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace SortedSetLinqPractice;

class Program
{
    static void Main()
    {
        SortedSet<int> scoresA = new() { 95, 60, 82, 45, 78, 90 };
        SortedSet<int> scoresB = new() { 78, 88, 95, 100 };

        // =====================================================================
        // TASK 1: SIMPLE LINQ QUERY (.Where)
        // =====================================================================
        // Query 'scoresA' using .Where() to filter for passing scores (>= 75)
        IEnumerable<int> passing = scoresA.Where(score => score >= 75);

        // Iterate and print the passing scores (observe they remain sorted: 78, 82, 90, 95)
        Console.WriteLine("scores over 74:");
        foreach (int i in passing)
        {
            Console.WriteLine(i);
        }

        // =====================================================================
        // TASK 2: METHOD CHAINING (.Where + .Select)
        // =====================================================================
        // Chain .Where() and .Select() on 'scoresA':
        // 1. Filter for scores strictly greater than 80
        // 2. Project each score into a formatted string (e.g., $"Grade: {score}%")
        IEnumerable<string> over80 = scoresA.Where(score => score > 80).Select(score => $"score: {score.ToString()}");

        // Iterate and print each projected string
        Console.WriteLine("\n\nscores over 80 as strings:");
        foreach (string s in over80)
        {
            Console.WriteLine(s);
        }

        // =====================================================================
        // TASK 3: NON-MUTATING LINQ SET OPERATIONS (.Union, .Intersect, .Except)
        // =====================================================================
        // scoresA =  { 95, 60, 82, 45, 78, 90 };
        // scoresB =  { 78, 88, 95, 100 };
        
        // Compute the union of 'scoresA' and 'scoresB' using .Union() and print the results
        Console.WriteLine("\n\nunion of both sets:");
        foreach (int score in scoresA.Union(scoresB))
        {
            Console.WriteLine(score);
        }

        // Compute the intersection of 'scoresA' and 'scoresB' using .Intersect() and print the results
        Console.WriteLine("\n\nintersection of both sets:");
        foreach (int score in scoresA.Intersect(scoresB))
        {
            Console.WriteLine(score);
        }

        // Compute the difference (elements in 'scoresA' but not in 'scoresB') using .Except() and print the results
        Console.WriteLine("\n\nset A scores EXCEPT set B scores:");
        foreach (int score in scoresA.Except(scoresB))
        {
            Console.WriteLine(score);
        }

        // Verify 'scoresA' was NOT mutated by printing its current Count (must still be 6)
        Console.WriteLine($"\n\nscoresA count: {scoresA.Count}");
        
    }
}