// ====================================================================================================================
// THE EVOLUTION OF EXECUTION: FROM BLOCKING LINES TO CONCURRENT JUGGLING
// ====================================================================================================================

// --------------------------------------------------------------------------------------------------------------------
// 1. THE PROBLEM (Why we couldn't stay where we started)
// --------------------------------------------------------------------------------------------------------------------
// Computers naturally execute code sequentially, line by line, from top to bottom.
// The fundamental problem: A single slow operation completely halts the entire application.
// If your code needs to fetch an image or run a heavy calculation, the CPU thread freezes.
// It cannot move to the next line of code until the previous one finishes, wasting millions of clock cycles.
//
//   [CPU Thread] ───(Run Line 1)───► [Wait for Network Response (Frozen/Idle)] ───(Run Line 2)───►
//                                    └───► Total Waste of Computing Resources!


// --------------------------------------------------------------------------------------------------------------------
// 2. THE PROGRESS OF INVENTIONS (From Default Behavior to Advanced Scheduling)
// --------------------------------------------------------------------------------------------------------------------
//
// FIRST STAGE: SYNCHRONOUS BY DEFAULT
// All execution starts here. It is simple, deterministic, and entirely sequential.
// tasks stack back-to-back. If Task1 takes 8s, Task2 takes 4s, 
// and Task3 takes 2s, the application takes a total of 14 seconds. No execution overlaps.
//
//   Timeline: 0s                4s          8s                    12s       14s
//   [Single-Thread]  ├───Task 1 (8s)───┴───────────┼───Task 2 (4s)───────┼─Task 3 (2s)─┤ (Total: 14s)
//
//
// SECOND STAGE: MULTI-THREADING (The Illusion vs. The Reality)
// To prevent the application from freezing, operating systems introduced multiple threads of execution.

// However, how this multi-threading behaves internally depends entirely on your underlying hardware architecture:
//
//   A. Single-Core Multi-Threading (Pure Concurrency / Time-Slicing)
//      A single CPU core cannot physically do two things at once. Instead, it plays a trick called "Concurrency."
//      The OS rapidly switches back and forth between threads (Context Switching). It gives a slice of time 
//      to Thread 1, pauses it, gives a slice to Thread 2, and repeats. It creates the *illusion* of simultaneous 
//      progress, but it is just rapid juggling on a single core.
//
//      Single Core: [ Slice 1: Thread1 ] -> [ Slice 2: Thread2 ] -> [ Slice 3: Thread3 ] -> [ Slice 4: Thread1 ]
//                   └───────────────────── CONCURRENT (Juggling) ───────────────────────────┘
//


//   B. Multi-Core Multi-Threading (True Parallelism)
//      When you have multiple physical CPU cores, you achieve "Parallelism." Real, simultaneous execution.
//      Core 1 handles Thread1, Core 2 handles Thread2,and Core 3 handles Thread3 at the exact same physical moment,
//      crushing the total time down to 8 seconds, which is the time taken to only execute the longest task.
//
//      Core 1: ├───Task 1 (8s)─────────────────────────────────────┤
//      Core 2: ├───Task 2 (4s)───────────┤                           │ -> PARALLEL (Simultaneous)
//      Core 3: ├───Task 3 (2s)───┤                                   │
//              0s                                                   8s
//
//
// BRIEF RECAP: WHAT IS I/O AND WHY DOES IT CAUSE A BOTTLENECK?
// As a quick reminder, I/O (Input/Output) involves the CPU communicating with external hardware (network, disk, 
// database). Because CPUs run in nanoseconds and networks run in milliseconds, waiting for an I/O response 
// is like waiting for a letter in the mail. In traditional programming, the thread is forced to sit completely 
// still and freeze while waiting, which brings us to the next massive shift:
//
//
// THIRD STAGE: ASYNCHRONOUS (Single-Threaded Efficiency)
// Multi-threading fixed CPU bottlenecks, but it introduced a new issue: threads are heavy and expensive.
// Spinning up an entire OS thread just to let it sit idle waiting for an I/O network response is wasteful.
// Asynchrony is not about adding more physical threads; it is about smarter management of a single thread.
//
// Instead of blocking while waiting for an external system (like a database or API), the single thread 
// kicks off the request, hands the waiting off to the OS kernel, and immediately leaves to work on something else.
// When the data arrives, the thread circles back to finish the job.
//
// Think of it like a single waiter in a restaurant:
// * Synchronous: Waiter takes your order, walks to the kitchen, and stands there staring at the chef for 20 minutes 
//   until your food is cooked. Other tables starve.
// * Asynchronous: Waiter takes your order, hands it to the kitchen (the OS kernel), and immediately walks away to 
//   serve other tables. When the kitchen bell rings (the I/O finishing signal), the waiter returns to pick up your food.

// --------------------------------------------------------------------------------------------------------------------
// 3. THE KEY DIFFERENCES AT A GLANCE
// --------------------------------------------------------------------------------------------------------------------
// * Synchronous                         : One task blocks progress until completion.
//                                         (1 worker, 1 queue, strict line)
//
// * Concurrent                          : Multiple tasks make progress during overlapping time periods.
//                                         (Can be achieved via async, multi-threading, or both)
//                                         (1 worker juggling multiple jobs)
//
// * Parallel                            : Multiple tasks execute at the exact same physical moment.
//                                         (Requires multiple CPU cores)
//                                         (3 workers doing 3 jobs simultaneously)
//
// * Asynchronous (usually concurrent)   : Non-blocking execution that releases the thread during waits
//                                         and resumes later when work can continue.
//                                         (1 worker delegates waiting and serves others)



// --------------------------------------------------------------------------------------------------------------------
//   ASYNCHRONOUS EXECUTION (Single Thread + Non-Blocking I/O)
// --------------------------------------------------------------------------------------------------------------------
//   Time ─────────────────────────────────────────────────────────────────────────►
//
//   CPU Thread:
//
//   Task 1 : ├── Start Request ──► [Waiting handled by OS] ───────────────────────────┤► Resume ── Finish ─┤
//                                  (thread released)
//
//   Task 2 :                       ├──── Execute ──── Finish ────┤
//
//   Task 3 :                                                     ├─ Execute ─ Finish ─┤
//
//
//   Actual Thread Timeline:
//
//   [ Task1(Start I/O) ]
//              │
//              ▼
//      [ Instead of waiting for I/O to finish, Thread Becomes Free ]
//              │
//              ├────────► [ Run Task2 ]
//              │
//              ├────────► [ Run Task3 ]
//              │
//              ▼
//      [ I/O Completion Signal Arrives ]
//              │
//              ▼
//      [ Resume Task1 → Continue After await ]
//
//   Total Time ≈ 11s (instead of 14s in Synchronous)
//   Waiting still exists — but the thread no longer wastes time doing nothing.




// Synchronous programming is well-suited for simpler applications
// or workflows where operations naturally depend on previous results.


// Multi-threading is well-suited for CPU-bound workloads where actual computation
// must continue while other work is also progressing (calculations, image processing,
// simulations, background processing). Multiple threads may provide concurrency
// and, on multi-core CPUs, true parallelism.


// Asynchronous programming is well-suited for I/O-bound workloads where waiting
// dominates execution time (network requests, file access, database queries).
// Instead of blocking a thread during waiting periods, execution is suspended
// and resumed later when the external operation completes.


// Threading introduces additional complexity such as synchronization,
// shared-state management, deadlocks, race conditions, and context switching.


// Asynchronous programming improves resource utilization by avoiding blocked
// threads during waits. It often achieves concurrency without requiring
// parallel execution, although async operations may still resume on different threads.