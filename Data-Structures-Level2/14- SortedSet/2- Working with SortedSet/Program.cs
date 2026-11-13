/*
================================================================================
Hands-On: Working with SortedSet<T>
================================================================================

Core Mechanics to Practice:
1. Instantiation, adding elements, and silent duplicate rejection (.Add).
2. Automatic ascending enumeration (foreach).
3. Boundary properties (.Min, .Max) and range views (.GetViewBetween).
4. Containment checks and removal (.Contains, .Remove).
================================================================================
*/

using System;
using System.Collections.Generic;

namespace SortedSetPractice;

class Program
{
    static void Main()
    {
        // =====================================================================
        // TASK 1: INSTANTIATION, ADDING & DUPLICATE REJECTION
        // =====================================================================
        // Declare and initialize a SortedSet<int> named 'numbers'
        SortedSet<int> numbers = new SortedSet<int>();

        // Insert elements out of order using Add: 40, 10, 50, 20, 30
        numbers.Add(40);
        numbers.Add(10);
        numbers.Add(50);
        numbers.Add(20);
        numbers.Add(30);

        // Attempt to insert a duplicate element (e.g., 20) using Add and print the boolean return value
        Console.WriteLine($"Adding a duplicate value success: {numbers.Add(30)}");

        // Iterate over 'numbers' using foreach and print each element to verify ascending order
        Console.WriteLine("Set Items Automatically Sorted:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }


        // =====================================================================
        // TASK 2: BOUNDARIES (.Min, .Max) & RANGE VIEWS (.GetViewBetween)
        // =====================================================================
        // Access and print the smallest element using .Min
        Console.WriteLine($"\n\nSmallest number: {numbers.Min}");

        // Access and print the largest element using .Max
        Console.WriteLine($"Largest number: {numbers.Max}");


        // Create a subset view of elements between 20 and 40 (inclusive) using .GetViewBetween(20, 40)
        SortedSet<int> subset = numbers.GetViewBetween(20, 40);

        // Iterate over the range view and print its elements
        Console.WriteLine("Subset Items Automatically Sorted:");
        foreach (int number in subset)
        {
            Console.WriteLine(number);
        }

        // Note: Mutating the range view mutates the original SortedSet!
        // Remove 30 from the range view, then print 'numbers' to observe the side effect
        Console.WriteLine($"\nremoved 30 from subset: {subset.Remove(30)}");
        
        Console.WriteLine("\nOriginal Set Items After removing from subset !!!:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }


        // =====================================================================
        // TASK 3: CONTAINMENT & REMOVAL
        // =====================================================================
        // Check if 50 exists in 'numbers' using .Contains() and print the result
        Console.WriteLine($"\n\nOriginal Set Contains 50: {numbers.Contains(50)}");

        // Remove 50 from 'numbers' using .Remove() and print the boolean return value
        Console.WriteLine($"Removed 50: {numbers.Remove(50)}");
        Console.WriteLine($"\nOriginal Set after removing 50:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        // Print the current Count of 'numbers'
        Console.WriteLine($"\nOriginal set count: {numbers.Count}");
    }
}