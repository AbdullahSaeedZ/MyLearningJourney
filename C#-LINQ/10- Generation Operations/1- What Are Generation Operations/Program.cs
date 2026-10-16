/*
====================================================================================================
                     LINQ GENERATION OPERATIONS - MODULE OVERVIEW
====================================================================================================

1. THE PROBLEM:
   Most LINQ methods are extension methods that transform, filter, or project an existing
   collection (IEnumerable<T>). However, real-world development regularly requires producing
   sequences from scratch:
     - Providing a valid, non-null empty sequence as a safe default return value.
     - Ensuring a sequence has at least one fallback element when data source queries return empty.
     - Generating a sequential series of integers without writing boilerplate for loops.
     - Instantiating a sequence of repeated values or objects without manually populating an array.

   Without dedicated generation mechanisms, developers resort to manual loop counters, repetitive
   allocations (such as new List<T>()), and defensive null checks throughout their codebase.

2. THE CORE IDEA:
   Generation operators function primarily as factories. Rather than receiving an existing
   sequence to transform, they manufacture an IEnumerable<T> based on caller arguments.

   Factory Pattern:
   Parameters / Type Tokens ──► [ Generator Factory ] ──► Synthesized IEnumerable<T>

   Shared Purpose & Methods Summary:
   ┌──────────────────────┬───────────────────────────────────────────────────────────────────────┐
   │ Method               │ Shared Purpose & Operational Summary                                  │
   ├──────────────────────┼───────────────────────────────────────────────────────────────────────┤
   │ Enumerable.Empty<T>()│ Returns an immutable, zero-element sequence. Provides an optimal,     │
   │                      │ allocation-free alternative to returning null or allocating new lists.│
   ├──────────────────────┼───────────────────────────────────────────────────────────────────────┤
   │ DefaultIfEmpty()     │ Supplies a fallback sequence containing a single default element if   │
   │                      │ the source sequence is empty; otherwise streams the source unmodified.│
   ├──────────────────────┼───────────────────────────────────────────────────────────────────────┤
   │ Enumerable.Range()   │ Generates a linear progression of integral numbers within a specified │
   │                      │ count starting from an initial value, eliminating index loops.        │
   ├──────────────────────┼───────────────────────────────────────────────────────────────────────┤
   │ Enumerable.Repeat()  │ Generates a sequence containing one repeated value duplicated a given │
   │                      │ number of times without instantiating explicit storage structures.    │
   └──────────────────────┴───────────────────────────────────────────────────────────────────────┘


*/