/*
================================================================================
Basic Operations on ObservableCollection<T> — Complete Reference Example
================================================================================

Core Mechanics Demonstrated:
- Built on `List<T>` (via `Collection<T>`):
  Shares the exact same standard API and complexity (`Add`, `Insert`, `Remove`, 
  `RemoveAt`, `Clear`, `Contains`, `IndexOf`, `Count`, `O(1)` indexing `obs[i]`), 
  plus `.Move(oldIndex, newIndex)` for shifting elements cleanly.
================================================================================
*/

using System;
using System.Collections.ObjectModel;

namespace ObservableCollectionBasics;

class Program
{
    static void Main()
    {
        // 1. Instantiation & Adding / Inserting Items
        ObservableCollection<string> tasks = new ObservableCollection<string>();
        tasks.Add("Build API");
        tasks.Add("Write Tests");
        tasks.Add("Deploy");

        tasks.Insert(0, "Design Schema"); // Shifts elements right: O(n)

        Console.WriteLine($"Count: {tasks.Count}");
        foreach (string task in tasks)
        {
            Console.WriteLine($"- {task}");
        }
        // Order: Design Schema, Build API, Write Tests, Deploy


        // 2. Indexing, Searching & Moving Items
        Console.WriteLine($"\nIndex 2: {tasks[2]}"); // O(1) lookup -> "Write Tests"

        tasks[2] = "Write Unit Tests";             // Indexer replacement
        bool hasDeploy = tasks.Contains("Deploy"); // O(n) linear scan -> true
        int deployIdx = tasks.IndexOf("Deploy");   // O(n) linear scan -> 3
        Console.WriteLine($"Contains 'Deploy': {hasDeploy} (Index {deployIdx})");

        // Built-in ObservableCollection method: repositions item and fires 'Move' event
        tasks.Move(3, 1); // Moves "Deploy" from index 3 to index 1


        // 3. Removing & Clearing Items
        tasks.Remove("Design Schema"); // Removes by value: O(n)
        tasks.RemoveAt(0);             // Removes at index 0: O(n)

        Console.WriteLine("\nRemaining tasks:");
        foreach (string task in tasks)
        {
            Console.WriteLine($"- {task}");
        }

        tasks.Clear(); // Empties internal List<T> and fires 'Reset' event
        Console.WriteLine($"\nCount after Clear: {tasks.Count}");
    }
}