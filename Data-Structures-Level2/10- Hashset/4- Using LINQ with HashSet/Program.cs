/*
================================================================================
LESSON 16: LINQ with HashSet<T>
================================================================================

CORE MENTAL MODEL:
`HashSet<T>` implements `IEnumerable<T>`. When you query it with LINQ:
- It yields an unordered stream of distinct items.
- Standard operators (`Where`, `Select`, `OrderBy`, `Any`, `Sum`) execute smoothly.
- Pitfall: LINQ operators return `IEnumerable<T>`. If you need fast O(1) set 
  membership or set operations afterward, you must re-materialize via `.ToHashSet()`.
================================================================================
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqWithHashSet;

class Program
{
    static void Main()
    {
        HashSet<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20, 25 };

        // TASK 1: FILTERING & PROJECTION
        // 1. Filter 'numbers' to find all items strictly greater than 5.
        // 2. Square each of those filtered numbers (num * num).
        // 3. Print each calculated square.
        // =====================================================================
        Console.WriteLine("Numbers After filtering and projecting:");
        foreach (int number in numbers.Where(num => num > 5).Select(num => num * num))
        {
            Console.WriteLine(number);
        }

        // =====================================================================
        // TASK 2: ORDERING 
        // Remember: HashSet<T> has no inherent order.
        // 1. Sort the entire 'numbers' set in descending order.
        // 2. Print the top 3 largest numbers.
        // =====================================================================
        Console.WriteLine("\n\nTop 3 Largest Numbers After ordering:");
        foreach (int number in numbers.OrderByDescending(num => num).Take(3))
        {
            Console.WriteLine(number);
        }


        // =====================================================================
        // TASK 3: AGGREGATION & QUANTIFIERS
        // 1. Compute and print the total sum of all odd numbers in the set.
        // 2. Check if the set contains ANY number divisible by 7 (print true/false).
        // 3. Check if ALL numbers in the set are positive (print true/false).
        // =====================================================================
        Console.WriteLine($"\n\nSum of All Odd numbers: {numbers.Where(num => num % 2 != 0).Sum()}");
        Console.WriteLine($"HashSet Contains Any number divisible by 7: {numbers.Any(num => num % 7 == 0)}");
        Console.WriteLine($"Any numbers in the set are not positive?, using Any: {numbers.Any(num => num < 0)}");
        Console.WriteLine($"ALL numbers in the set are positive?, using All: {numbers.All(num => num > 0)}");


        // =====================================================================
        // TASK 4: RE-MATERIALIZATION
        // 1. Filter 'numbers' to keep only multiples of 5 (num % 5 == 0).
        // 2. Re-materialize the result directly into a new HashSet<int>.
        // 3. Check if the new set contains 15 using in O(1) time.
        // =====================================================================
        Console.WriteLine($"\n\nHashSet Contains number 15? {numbers.Where(num => num % 5 == 0).ToHashSet().Contains(15)}");

    }
}