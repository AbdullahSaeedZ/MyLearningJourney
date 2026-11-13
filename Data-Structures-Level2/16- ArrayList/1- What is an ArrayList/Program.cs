/*
================================================================================
ArrayList — Foundations, Internal Architecture & Trade-offs
================================================================================

1. WHAT IT IS:
`ArrayList` is a legacy, non-generic dynamic array (from `System.Collections`) 
that automatically resizes as elements are added and can store elements of ANY 
data type inside the same collection.


2. THE PROBLEM IT SOLVED:
- Standard C# arrays (`T[]`) have a rigid, fixed length set at creation; 
  growing one requires manually allocating a new array and copying elements.
- `ArrayList` (introduced in .NET 1.0 before generics existed) solved this by 
  providing an automatically resizing array capable of holding any object type.


3. HOW IT WORKS INTERNALLY:
- Backing Store: Internally wraps a single `object[]` array (`_items`).
- Dynamic Growth: Starts at capacity 0 (jumps to 4 on first `Add`), and doubles 
  its capacity via `Array.Copy` whenever `Count == Capacity`.
  
- One-Way Shrinking & `.TrimToSize()`:
  Removing elements (`Remove`, `RemoveAt`, `Clear`) decrements `Count` and nulls 
  out the slots, but does NOT shrink `Capacity` automatically—wasting allocated 
  memory. Calling `list.TrimToSize()` reallocates a new internal `object[]` sized 
  exactly to `Count` (an O(n) copy operation) to reclaim unused memory.
  
- Boxing / Unboxing: Value types (`int`, `bool`, `struct`) are wrapped inside 
  heap-allocated `object` boxes on insert and cast back on read.


4. PERFORMANCE & COMPLEXITY:
- Index Access (`list[i]`):     O(1) — Direct index lookup on internal `object[]`.
- Append (`Add`):               O(1) amortized — O(n) only when resizing triggers.
- Insert / Remove (`Insert`):   O(n) — Shifts elements in memory via `Array.Copy`.
- Search (`Contains`):          O(n) — Linear scan calling `Object.Equals`.
- Shrink (`TrimToSize`):        O(n) — Allocates exact-size array & copies items.
- Memory Footprint:             High for value types due to heap boxing overhead.


5. ARCHITECTURAL COMPARISON (Array vs. ArrayList vs. List<T>):
┌─────────────────────┬────────────────────┬────────────────────┬────────────────────┐
│ Dimension           │ Array (T[])        │ ArrayList          │ List<T>            │
├─────────────────────┼────────────────────┼────────────────────┼────────────────────┤
│ Namespace           │ System             │ System.Collections │ System.Collections │
│                     │                    │                    │ .Generic           │
│ Size                │ Fixed at creation  │ Dynamic (2x growth)│ Dynamic (2x growth)│
│ Shrinking Method    │ Not Supported      │ .TrimToSize()      │ .TrimExcess()      │
│ Element Types       │ Strongly typed (T) │ Heterogeneous      │ Strongly typed (T) │
│                     │                    │ (`object[]`)       │ (`T[]`)            │
│ Value Type Boxing   │ None               │ Yes (Heap overhead)│ None               │
│ Type Safety         │ Compile-time       │ Runtime casts only │ Compile-time       │
│ Index Access [i]    │ O(1)               │ O(1)               │ O(1)               │
└─────────────────────┴────────────────────┴────────────────────┴────────────────────┘


6. WHEN TO USE VS. AVOID:
- AVOID IN MODERN C#:
  * `ArrayList` is obsolete in practice; `List<T>` replaced it in .NET 2.0.
  * Never use `ArrayList` in new code — it sacrifices compile-time type safety 
    and incurs heavy boxing/unboxing garbage collection overhead.
    
- MODERN ALTERNATIVE:
  * Use `List<T>` for homogeneous collections, or `List<object>` if you 
    genuinely need a list of mixed types.
================================================================================
*/
