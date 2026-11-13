/*
================================================================================
Hands-On: Responding to Changes in ObservableCollection<T>
================================================================================

Core Mechanics to Practice:
1. Event Subscription (`CollectionChanged`):
   `ObservableCollection<T>` exposes the `CollectionChanged` event, which expects a 
   handler matching the `NotifyCollectionChangedEventHandler` delegate:
       void OnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
2. Inspecting `NotifyCollectionChangedEventArgs`:
   - `e.Action`   : Enum (`Add`, `Remove`, `Replace`, `Move`, `Reset`).
   - `e.NewItems` : Non-generic `IList` of added/new items (null on Remove/Reset).
   - `e.OldItems` : Non-generic `IList` of removed/old items (null on Add/Reset).
   - `e.NewStartingIndex` / `e.OldStartingIndex`: Index positions where the edit occurred.
================================================================================
*/

using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace ObservableCollectionEvents;

class Program
{
    static void Main()
    {
        // =====================================================================
        // TASK 1: INSTANTIATE & SUBSCRIBE USING A NAMED METHOD
        // =====================================================================
        // Instantiate an ObservableCollection<string> named 'orders'
        ObservableCollection<string> orders = new ObservableCollection<string>();

        // Subscribe to 'orders.CollectionChanged' using the 'Orders_CollectionChanged' method below
        orders.CollectionChanged += Orders_CollectionChanged;

        // =====================================================================
        // TASK 2: TRIGGER ALL 5 CHANGE ACTIONS
        // =====================================================================
        // 1. Add two items ("Order #101", "Order #102") -> triggers Action.Add
        orders.Add("order #101");
        orders.Add("order #102");

        // 2. Replace index 0 with "Order #101-RUSH" (orders[0] = ...) -> triggers Action.Replace
        orders[0] = "order #101-RUSH";

        // 3. Move index 1 to index 0 (orders.Move(1, 0)) -> triggers Action.Move
        orders.Move(1, 0);

        // 4. Remove "Order #102" -> triggers Action.Remove
        orders.Remove("order #102");

        // 5. Clear all items -> triggers Action.Reset
        orders.Clear();

    }

    // =========================================================================
    // TASK 3: IMPLEMENT THE EVENT HANDLER METHOD
    // =========================================================================
    // Complete this handler to inspect 'e.Action' and print what changed:
    // - Case Add:     Print e.NewItems[0] and e.NewStartingIndex
    // - Case Remove:  Print e.OldItems[0] and e.OldStartingIndex
    // - Case Replace: Print e.OldItems[0] -> e.NewItems[0] at e.NewStartingIndex
    // - Case Move:    Print e.OldItems[0] moved from e.OldStartingIndex to e.NewStartingIndex
    // - Case Reset:   Print that the collection was cleared/reset
    static void Orders_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        Console.WriteLine("\nEVENT TRIGGERED:");
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                Console.WriteLine($"[Add Action]: Item Added: {e.NewItems[0]} at index {e.NewStartingIndex}");
                break;
            
            case NotifyCollectionChangedAction.Remove:
                Console.WriteLine($"[Remove Action]: Item Removed: {e.OldItems[0]} at index {e.OldStartingIndex}");
                break;
            
            case NotifyCollectionChangedAction.Replace:
                Console.WriteLine($"[Replace Action]: Item Replaced (value updated): {e.OldItems[0]} to {e.NewItems[0]} at index {e.NewStartingIndex}");
                break;
            
            case NotifyCollectionChangedAction.Move:
                Console.WriteLine($"[Move Action]: Item Moved: {e.OldItems[0]} from index {e.OldStartingIndex} to index {e.NewStartingIndex}");
                break;
            
            case NotifyCollectionChangedAction.Reset:
                Console.WriteLine($"[Reset Action]: Items Reset.");
                break;
        }
    }
}