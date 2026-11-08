/*
 * ============================================================================
 * LESSON: SORTING A LIST USING VARIOUS METHODS IN C#
 * ============================================================================
 * 
 * 1. IN-PLACE MODIFICATION (List<T> Built-in Methods)
 * ---------------------------------------------------
 * - Sort() [O(N log N)]:
 *   * Sorts elements directly inside the original list (in-place modification).
 *   * Ascending order by default using the elements' default comparer.
 * 
 * - Reverse() [O(N)]:
 *   * Reverses the order of elements directly inside the original list.
 * 
 * 
 * 2. NON-DESTRUCTIVE ORDERING (LINQ OrderBy / OrderByDescending)
 * -------------------------------------------------------------
 * - OrderBy() / OrderByDescending() [O(N log N)]:
 *   * Does NOT change the original list; returns a new sorted sequence (IOrderedEnumerable<T>).
 *   * We must provide a selector lambda so the method knows which key/property to sort by.
 *   * Supports custom projection keys (e.g., sorting strings by their .Length, or 
 *     shuffling randomly by ordering by a new Guid).
 */

namespace _8__Sorting_a_List_Using_Various_Methods;

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int> { 44, 22, 55, 666, 9, -6, 345, 11, 3, 3 , 100, 200};
        
        // Sort built-in method, ascending by default (modifies the list in-place)
        numbers.Sort();
        Console.WriteLine("Sort method:\n" + string.Join(", ", numbers));
        
        // Reverse built-in method, reverses item order in-place
        numbers.Reverse();
        Console.WriteLine("Reverse method:\n" + string.Join(", ", numbers));
        
        // Sorting with LINQ OrderBy method, ascending:
        // We must provide the selector on which ordering will be performed
        // (Does not modify 'numbers', produces a new sequence)
        Console.WriteLine("LINQ OrderBy method:\n" + string.Join(", ", numbers.OrderBy(item => item)));
        
        // Or descending:
        Console.WriteLine("LINQ OrderByDescending method:\n" + string.Join(", ", numbers.OrderByDescending(item => item)));
        
        
        // Using OrderBy with name length as the selector:
        List<string> names = new List<string> { "Abdullah", "Ahmed", "Ali", "Nasser", "Nora", "Rashid", "Khalid" };
        
        Console.WriteLine("\n\nInitial List:\n" + string.Join(", ", names));
        Console.WriteLine("LINQ OrderBy method on name length:\n" + string.Join(", ", names.OrderBy(name => name.Length)));
        
        // Using OrderBy with Guid as selector to randomly order the items:
        Console.WriteLine("LINQ OrderBy method with Guid:\n" + string.Join(", ", names.OrderBy(name => Guid.NewGuid())));
        
        // prove that list is not modified:
        Console.WriteLine("List items with no sorting, to prove OrderBy does not modify List:\n" + string.Join(", ", names));
        
    }
}