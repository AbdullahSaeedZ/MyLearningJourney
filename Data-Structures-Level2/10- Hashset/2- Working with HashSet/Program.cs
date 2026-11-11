/*
================================================================================
LESSON 15: Working with HashSet<T> (Core Operations)
================================================================================

1. CORE METHODS (All O(1) Average):
- `.Add(item)`: Inserts item. Returns `true` if added, `false` if already exists.
- `.Contains(item)`: Checks existence via hash lookup. Returns `true` or `false`.
- `.Remove(item)`: Deletes item. Returns `true` if found and removed, `false` otherwise.
- `.Clear()`: Empties the entire set.
- `.Count`: Property returning total number of elements.

2. CRITICAL CONSTRAINT: ZERO INDEXING
A `HashSet<T>` distributes elements across internal hash buckets. There is NO 
concept of index 0, 1, or N:
- `set[0]` will NOT compile.
- If you need ordered access, positional retrieval, or sorting, use `List<T>`.
- To access all elements, you must enumerate via `foreach`.
================================================================================
*/

using System;
using System.Collections.Generic;

namespace HashSetOperations;

class Program
{
    static void Main(string[] args)
    {
        // TASK 1: INITIALIZATION & SAFE INSERTION (.Add)
        // =====================================================================
        HashSet<string> activeUsers = new HashSet<string>();

        activeUsers.Add("Admin");
        // Add method is boolean, so we can use it to check success
        bool adding = activeUsers.Add("user1");
        Console.WriteLine($"Adding user1 success: {adding}");
        
        // if adding an existing item, it will return false and ignore it:
        bool addingDuplicate = activeUsers.Add("user1");
        Console.WriteLine($"Adding duplicate user1 success: {addingDuplicate}");
        

        // TASK 2: MEMBERSHIP TESTING (.Contains)
        // =====================================================================
        Console.WriteLine($"Does Admin exist in the HashSet: {activeUsers.Contains("Admin")}"); // using default comparing (references)


        // TASK 3: REMOVAL & COUNT (.Remove & .Count)
        // =====================================================================
        Console.WriteLine($"Removing Admin success: {activeUsers.Remove("Admin")}");
        Console.WriteLine($"Count of items in HashSet: {activeUsers.Count}");


        // TASK 4: DEMONSTRATE NO INDEXING & ENUMERATE
        // =====================================================================
        
        //Console.WriteLine($"Accessing with index: {activeUsers[0]}"); // will throw
        
        // accessing is done by iterating:
        foreach (string user in activeUsers)
        {
            Console.WriteLine($"HashSet item: {user}");
        }
        
        // clearing the set
        activeUsers.Clear();
        Console.WriteLine($"Count of items in HashSet after clearing: {activeUsers.Count}");
    }
}