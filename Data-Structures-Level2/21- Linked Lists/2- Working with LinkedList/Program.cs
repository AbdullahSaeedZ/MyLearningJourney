/*
================================================================================
Working with LinkedList<T> — Complete Reference Example
================================================================================

Core Mechanics Demonstrated:
1. Adding at Ends: `.AddFirst()` and `.AddLast()` in O(1).
2. Holding Node References (`LinkedListNode<T>`):
   Unlike `List<T>`, `LinkedList<T>` exposes node wrapper objects (`node.Value`, 
   `node.Next`, `node.Previous`). Holding a `LinkedListNode<T>` lets you insert 
   or delete adjacent items in O(1) without searching.
3. Positional Edits & Removal: `.Find()`, `.AddBefore()`, `.AddAfter()`, 
   `.Remove(node)`, `.RemoveFirst()`, `.RemoveLast()`.
================================================================================
*/

using System;
using System.Collections.Generic;

namespace LinkedListReference;

class Program
{
    static void Main()
    {
        // 1. Instantiation & Adding at Both Ends — O(1)
        LinkedList<string> playlist = new LinkedList<string>();
        playlist.AddLast("Track 2: Midnight");     // [Track 2]
        playlist.AddFirst("Track 1: Intro");       // [Track 1] <-> [Track 2]
        playlist.AddLast("Track 4: Outro");        // [Track 1] <-> [Track 2] <-> [Track 4]

        Console.WriteLine($"Count: {playlist.Count}"); // Output: 3


        // 2. Finding a Node & Inserting Before / After — O(n) Find, O(1) Insert
        // .Find() scans from First to Last and returns the LinkedListNode<T> wrapper
        LinkedListNode<string>? track2Node = playlist.Find("Track 2: Midnight");

        if (track2Node != null)
        {
            // Since we hold the node reference, inserting next to it is O(1) pointer rewiring
            playlist.AddAfter(track2Node, "Track 3: Interlude");
            playlist.AddBefore(track2Node, "Track 1.5: Skit");
        }


        // 3. Traversing Forward (First -> Last) & Backward (Last -> First)
        Console.WriteLine("\nForward traversal (foreach):");
        foreach (string track in playlist)
        {
            Console.WriteLine($"- {track}");
        }

        Console.WriteLine("\nBackward traversal using .Last and .Previous:");
        LinkedListNode<string>? current = playlist.Last;
        while (current != null)
        {
            Console.WriteLine($"- {current.Value}");
            current = current.Previous;
        }


        // 4. Removing Nodes — O(1) by Node/Ends, O(n) by Value
        playlist.RemoveFirst();                // O(1) — removes "Track 1: Intro"
        playlist.RemoveLast();                 // O(1) — removes "Track 4: Outro"

        if (track2Node != null)
        {
            playlist.Remove(track2Node);       // O(1) — removes "Track 2" directly via node ref
        }

        playlist.Remove("Track 1.5: Skit");    // O(n) — must search by value first, then unlink

        Console.WriteLine($"\nRemaining Count: {playlist.Count}"); // Output: 1 ("Track 3: Interlude")
    }
}