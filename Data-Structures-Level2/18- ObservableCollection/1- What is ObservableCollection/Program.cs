/*
================================================================================
ObservableCollection<T> — Foundations, Event Architecture & Trade-offs
================================================================================

1. THE PROBLEM (WHY `List<T>` IS NOT ENOUGH):
- `List<T>` stores items silently. When you call `list.Add(item)` or 
  `list.Remove(item)`, the data changes in memory, but external code (like a UI 
  screen, logger, or cache) has zero way of knowing anything happened.
- To keep a UI synchronized with a `List<T>`, you would have to manually refresh 
  or re-bind the entire UI control after every single edit—which is error-prone 
  and inefficient.


2. CORE IDEA (A `List<T>` WITH A BUILT-IN BROADCAST SYSTEM):
`ObservableCollection<T>` (in `System.Collections.ObjectModel`) is a generic, 
dynamic list that automatically fires events whenever items are added, removed, 
replaced, moved, or cleared.

Visual Comparison:
┌──────────────────────────────────────────────────────────────────────────────┐
│ `List<T>` (Silent Storage)                                                   │
│   Code calls `list.Add("Task A")` ──► [ "Task A" ]  (No signal emitted)      │
│                                       UI stays stale unless manually reset   │
├──────────────────────────────────────────────────────────────────────────────┤
│ `ObservableCollection<T>` (Event-Driven Storage)                             │
│   Code calls `obs.Add("Task A")`  ──► [ "Task A" ]                           │
│                                            │                                 │
│                                            ▼ Fires `CollectionChanged`       │
│                                       UI / Listeners auto-update instantly!  │
└──────────────────────────────────────────────────────────────────────────────┘


3. HOW IT WORKS INTERNALLY (INHERITANCE & INTERFACES):
Under the hood, `ObservableCollection<T>` inherits from `Collection<T>` (which 
wraps an internal `List<T>`), and implements two key notification interfaces:

  Collection<T>  (Wraps internal `List<T>` for storage & O(1) index access)
        ▲
        │ inherits
  ObservableCollection<T>
        ├──► INotifyCollectionChanged  (Fires `CollectionChanged` on Add/Remove/Move/Replace/Reset)
        └──► INotifyPropertyChanged    (Fires `PropertyChanged` when `Count` or `Item[]` changes)

Exact Trace of Calling `obs.Add("Apple")`:
   1. Saves "Apple" into the underlying `List<T>`.
   2. Fires `INotifyPropertyChanged` (`PropertyChanged` for `"Count"` and `"Item[]"`).
   3. Fires `INotifyCollectionChanged` (`CollectionChanged`) passing `NotifyCollectionChangedEventArgs`:
        • `Action`   = Add / Remove / Replace / Move / Reset
        • `NewItems` = ["Apple"]     /    `OldItems` = null


4. IMPORTANT LIMITATION (COLLECTION CHANGES VS. ITEM PROPERTY CHANGES):
`ObservableCollection<T>` ONLY detects changes to the **list structure itself** 
(adding, removing, or replacing an object). It does **NOT** detect when a 
property *inside* an existing object changes:

  obs.Add(user);                 ──► FIRES `CollectionChanged` (List changed)
  obs.Remove(user);              ──► FIRES `CollectionChanged` (List changed)
  obs[0].Name = "New Name";      ──► SILENT! (The object reference at index 0 is 
                                     the same; `User` itself must implement 
                                     `INotifyPropertyChanged` for this)


5. ARCHITECTURAL COMPARISON (`List<T>` vs. `ObservableCollection<T>`):
┌──────────────────────┬──────────────────────────┬────────────────────────────┐
│ Dimension            │ List<T>                  │ ObservableCollection<T>    │
├──────────────────────┼──────────────────────────┼────────────────────────────┤
│ Namespace            │ System.Collections       │ System.Collections         │
│                      │ .Generic                 │ .ObjectModel               │
│ Underlying Storage   │ T[] array                │ Collection<T> -> List<T>   │
│ Change Notifications │ None                     │ CollectionChanged &        │
│                      │                          │ PropertyChanged events     │
│ Read/Write Speed     │ Faster (direct array)    │ Slightly slower (event     │
│                      │                          │ invocation overhead)       │
│ Primary Use Case     │ Backend logic, algorithms│ UI data binding (WPF,      │
│                      │ & general data storage   │ MAUI, WinUI) & observers   │
└──────────────────────┴──────────────────────────┴────────────────────────────┘


6. WHEN TO USE VS. AVOID:
- USE IT WHEN:
  * Building reactive UI applications (WPF, .NET MAUI, WinUI, Avalonia) where 
    lists/grids must stay automatically synchronized with a collection.
    
  * You need lightweight observer hooks whenever items enter or leave a list.
 * 
- AVOID IT WHEN:
  * Writing pure backend services, APIs, or tight algorithmic loops where no UI 
    or listener is subscribed—use `List<T>` to avoid unnecessary event allocation 
    and virtual method dispatch overhead.
    
  * Performing bulk updates (e.g., adding 10,000 items in a loop), because it 
    fires 10,000 separate `CollectionChanged` events (freezing the UI).
================================================================================
*/
