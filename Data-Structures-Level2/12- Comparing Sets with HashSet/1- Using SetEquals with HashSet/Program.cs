/*
================================================================================
SetEquals vs. Equals() in HashSet<T>
================================================================================

1. SetEquals(IEnumerable<T>) — VALUE / SET EQUIVALENCE:
- Tests whether both collections share the exact same unique elements.
- Ignores element ordering, internal memory locations, and frequency of duplicates.
- Relies on the element's `GetHashCode()` and `Equals()`.

  ASCII: SetEquals Evaluation
  ┌───────────────────────┐         ┌───────────────────────────────┐
  │   HashSet<Role> A     │         │       Role[] Array B          │
  │  (Heap Instance #1)   │         │     (Heap Instance #2)        │
  │  ┌─────────────────┐  │         │  ┌─────────────────┐          │
  │  │ [1] Admin (x01) │  │         │  │ [2] Editor (y02)│          │
  │  │ [2] Editor(y01) │  │         │  │ [1] Admin  (x02)│          │
  │  └─────────────────┘  │         │  │ [1] Admin  (x02)│ ◄─(Dup)  │
  └───────────┬───────────┘         │  └─────────────────┘          │
              │                     └───────────────┬───────────────┘
              │                                     │
              └───────► Hash & Value Check ◄────────┘
                        Admin:  ID=1 == ID=1  (MATCH)
                        Editor: ID=2 == ID=2  (MATCH)
                        ────────────────────────────
                        Result: TRUE (Equivalent)


2. Equals(object) — REFERENCE IDENTITY:
- Inherited directly from `System.Object`.
- `HashSet<T>` DOES NOT override `Equals()`.
- Tests if two collection variables reference the same exact address on the heap.

  ASCII: Equals Evaluation
  setA ──► [Pointer: 0xAAAA] ──► Heap: HashSet { 1, 2, 3 }
                                           ▲
                                           │  ReferenceEquals: FALSE
                                           ▼
  setB ──► [Pointer: 0xBBBB] ──► Heap: HashSet { 3, 2, 1 }

  setA.Equals(setB)  ──► FALSE (Different memory addresses)
  setA.SetEquals(setB) ──► TRUE  (Identical distinct elements)
================================================================================
*/

using System;
using System.Collections.Generic;

namespace SetEqualsDeepDive;
class Program
{
    static void Main()
    {
        // =====================================================================
        // PART 1: SetEquals vs. Equals() ON THE HASHSET INSTANCES
        // =====================================================================
        HashSet<int> setA = new() { 1, 2, 3 };
        HashSet<int> setB = new() { 3, 2, 1 }; // Same values, different order, separate instance

        // 1. SetEquals: checks if unique contents match
        Console.WriteLine($"setA.SetEquals(setB): {setA.SetEquals(setB)}"); // True

        // 2. Equals: checks reference equality because HashSet<T> does not override Equals
        Console.WriteLine($"setA.Equals(setB):    {setA.Equals(setB)}");    // False (different heap instances)

        // 3. Equals on the exact same instance in memory
        HashSet<int> setC = setA;
        Console.WriteLine($"setA.Equals(setC):    {setA.Equals(setC)}");    // True (same reference)


        Console.WriteLine("\n--------------------------------------------------\n");


        // =====================================================================
        // PART 2: SetEquals WITH REFERENCE TYPES (Role Objects)
        // =====================================================================
        Role admin1 = new(1, "Admin");
        Role editor1 = new(2, "Editor");

        // Distinct instances in memory with identical property values
        Role admin2 = new(1, "Admin");
        Role editor2 = new(2, "Editor");

        HashSet<Role> assignedRoles = new() { admin1, editor1 };

        // Another collection (array) in different order, with duplicates and separate instances
        Role[] incomingPayload = new[] { editor2, admin2, editor2 };

        // SetEquals compares the elements using their overridden Equals & GetHashCode
        bool hasEquivalentRoles = assignedRoles.SetEquals(incomingPayload);
        Console.WriteLine($"assignedRoles.SetEquals(incomingPayload): {hasEquivalentRoles}"); // True


        Console.WriteLine("\n--------------------------------------------------\n");


        // =====================================================================
        // PART 3: SetEquals WITH MISMATCHED SETS
        // =====================================================================
        Role viewer = new(3, "Viewer");
        Role[] mismatchedPayload = new[] { admin2, viewer };

        bool isMatch = assignedRoles.SetEquals(mismatchedPayload);
        Console.WriteLine($"assignedRoles.SetEquals(mismatchedPayload): {isMatch}"); // False
    }
}


// Reference type with proper Value Equality overrides
public sealed class Role
{
    public int Id { get; }
    public string Name { get; }

    public Role(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public override bool Equals(object? obj) =>
        ReferenceEquals(this, obj) || (obj is Role other && Id == other.Id && Name == other.Name);

    public override int GetHashCode() =>
        HashCode.Combine(Id, Name);

    public override string ToString() => $"[{Id}] {Name}";
}