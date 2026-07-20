// ============================================================================
// LESSON: INTRODUCTION TO THE PARALLEL CLASS (ARCHITECTURE & CORE CONCEPTS)
// ============================================================================

// 1. THE PROBLEM
// Before the Parallel class was introduced in .NET 4 (Task Parallel Library), 
// if you wanted to execute code across multiple CPU cores to improve performance, 
// you had to manually create, manage, and destroy raw threads (System.Threading.Thread).
//
// Manual thread management introduced huge accidental complexity:
// - Over-allocating threads caused "thread thrashing" (the CPU spending more time 
//   switching contexts between threads than actually doing real work).
// - Under-allocating threads meant you wasted available physical CPU cores.
// - Developers had to manually calculate how to slice data ranges to distribute 
//   them evenly among threads.
// - Handling exceptions safely across background threads was incredibly painful.


// 2. THE CORE IDEA
// The 'Parallel' class is a static utility class that completely abstracts away raw threads.
// Instead of telling the operating system *how* to allocate and manage threads, you 
// simply tell the Parallel class *what* work needs to be executed concurrently.
//
// It acts as a high-level manager that automatically partitions your workload 
// and schedules tasks across the available CPU cores using the internal .NET ThreadPool.


// 3. HOW IT WORKS INTERNALLY
// When you invoke a Parallel method, the .NET runtime performs these operations:
//
// A. Work Partitioning: It analyzes your collection or range and dynamically breaks 
//    it down into smaller, optimized chunks.
// B. Task Injection: It wraps these chunks inside underlying .NET 'Task' objects.
// C. ThreadPool Scheduling: It dispatches these tasks to the .NET ThreadPool. The 
//    ThreadPool dynamically expands or contracts worker threads based on your machine's 
//    current hardware capabilities and CPU load.
// D. Synchronous Blocking: Even though the work inside executes concurrently on 
//    background threads, the calling thread *blocks* and halts execution until all 
//    parallel workers finish their assigned chunks. It behaves like synchronous code to the caller.
// E. Exception Aggregation: If multiple concurrent chunks throw errors, the Parallel class 
//    catches them all, packages them into a single 'AggregateException', and throws it 
//    once the entire operation concludes.


// 4. WHEN NOT TO USE IT & COMMON OVER-ENGINEERING MISTAKES
//
// - DO NOT use it for I/O-bound operations (e.g., fetching URLs, querying databases, 
//   reading large files). Parallel keeps threads blocked waiting for responses. 
//   For I/O, always prefer true asynchronous code using async/await.
// - DO NOT use it on small datasets or trivial calculations (e.g., looping 100 times to add numbers). 
//   The processing overhead of partitioning data and coordinating ThreadPool threads 
//   will make the code run significantly *slower* than a simple sequential loop.
// - DO NOT use it if the loops depend on a shared state (e.g., multiple threads modifying 
//   a shared List or primitive counter variable) without synchronization locks. 
//   This causes severe race conditions and data corruption.