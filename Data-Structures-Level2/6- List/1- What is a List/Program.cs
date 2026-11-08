/*
 * ============================================================================
 * LESSON: INTRODUCTION TO List<T> IN C#
 * ============================================================================
 * 
 * 1. WHAT IS List<T>?
 * -------------------
 * List<T> is a generic collection class located in the System.Collections.Generic 
 * namespace. It represents a strongly-typed, dynamically resizable list of objects 
 * accessible by index.
 * 
 * Unlike standard C# arrays, which have a fixed length determined at creation time, 
 * List<T> manages its own memory automatically, growing in size as new elements 
 * are added.
 * 
 * 
 * 2. KEY ARCHITECTURAL CONCEPTS
 * -----------------------------
 * a) Generic Type Parameter (<T>):
 *    The 'T' stands for the type of elements stored in the list. It can represent 
 *    primitives, built-in reference types, or custom domain models:
 *    - List<int>
 *    - List<string>
 *    - List<Customer>
 * 
 * b) Dynamic Sizing:
 *    Under the hood, List<T> wraps a standard contiguous array (T[]). When the 
 *    underlying array fills up, List<T> automatically allocates a larger array 
 *    (typically double the size) and copies the existing items over.
 * 
 * c) Zero-Based Indexing:
 *    Elements are ordered sequentially and accessed via zero-based indexes, 
 *    providing O(1) constant-time direct access (e.g., list[0], list[4]).
 * 
 * d) Strong Typing (Compile-Time Safety):
 *    Because the type parameter is fixed at declaration, the compiler prevents 
 *    accidental type mismatches. A List<string> cannot accept an int.
 * 
 * 
 * 3. CAPACITY VS. COUNT
 * ---------------------
 * Understanding this distinction is essential for memory efficiency:
 * 
 * - Count:
 *   The actual number of elements currently stored in the List<T>.
 *   (What you have used so far).
 * 
 * - Capacity:
 *   The total number of elements the internal array can hold before a resize 
 *   and memory reallocation is forced.
 *   (The size of the underlying memory buffer).
 * 
 * Example Lifecycle:
 * If a List has Capacity = 4 and you add a 5th item:
 * 1. Count becomes 5.
 * 2. The runtime allocates a new array (usually Capacity = 8).
 * 3. Elements are copied over to the new array.
 * 
 * 
 * 4. THREAD SAFETY CONSIDERATION
 * ------------------------------
 * List<T> is NOT thread-safe for concurrent writes.
 * If multiple threads read and write to a List<T> concurrently without synchronization, 
 * data corruption or index exceptions will occur.
 * 
 * For multi-threaded scenarios, consider thread-safe alternatives from the 
 * System.Collections.Concurrent namespace, such as ConcurrentBag<T>.
 */

