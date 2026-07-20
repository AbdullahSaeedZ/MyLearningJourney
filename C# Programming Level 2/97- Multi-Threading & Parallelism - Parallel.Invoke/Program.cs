// ============================================================================
// LESSON: PARALLEL.INVOKE (TASK-BASED TASK PARALLELISM)
// ============================================================================

// 1. THE PROBLEM
// Sometimes, you do not need to loop over a collection of data. Instead, you have 
// a set of completely separate, heavy operations that need to run at the same time. 
// For example: step A creates a backup, step B generates a report, and step C processes an image.
//
// If you write these out sequentially, step B cannot start until step A is fully finished. 
// If each step takes 3 seconds, your application wastes time processing them linearly, 
// running on a single CPU core while the other cores sit completely idle.

// 2. THE CORE IDEA
// 'Parallel.Invoke' is designed to execute an array of completely different, independent 
// actions concurrently. 
//
// You pass multiple delegates (functions) into it, and the Parallel class attempts to 
// distribute these distinct actions across available CPU cores so they execute at the exact 
// same time. It does not care about data indexing or loops, it cares about independent actions.

// 3. HOW IT WORKS INTERNALLY
// When you execute Parallel.Invoke(Action1, Action2, Action3), .NET performs these steps:
//
// A. Action Wrapping: It takes your array of Action delegates and wraps each one inside 
//    an underlying .NET 'Task' object.

// B. ThreadPool Distribution: It injects these tasks into the .NET ThreadPool. Available 
//    worker threads grab the actions and run them simultaneously.

// C. Fork-Join Synchronization: The calling main thread halts (blocks) at the Parallel.Invoke 
//    statement. It acts as a barrier, waiting until *every single action* finishes its 
//    work before letting the code execution continue past the Invoke block.

// D. Exception Packaging: If Action1 and Action3 both crash, the Parallel class lets 
//    Action2 finish, catches all exceptions, bundles them into an 'AggregateException', 
//    and throws it back to the caller.

// 4. MINIMAL C# EXAMPLE
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class ParallelInvokeLesson
{
    static void Main()
    {
        Console.WriteLine("Starting independent system operations...");

        // Parallel.Invoke takes a params array of Action delegates: 
        // Parallel.Invoke(params Action[] actions)
        Parallel.Invoke(
            () => LoadSystemConfiguration(),
            () => GenerateFinancialReport(),
            () => VerifyCloudStorageBackup()
        );

        Console.WriteLine($"\nAll parallel operations completed successfully.");
        Console.ReadKey();
    }

    static void LoadSystemConfiguration()
    {
        Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Loading configuration...");
        Thread.Sleep(2000); // Simulating CPU work
        Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Configuration loaded.");
    }

    static void GenerateFinancialReport()
    {
        Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Generating report...");
        Thread.Sleep(2500); // Simulating heavy data aggregation
        Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Report compiled.");
    }

    static void VerifyCloudStorageBackup()
    {
        Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Verifying backup hashes...");
        Thread.Sleep(1500); // Simulating processing
        Console.WriteLine($"[Thread {Thread.CurrentThread.ManagedThreadId}] Backup verified.");
    }
}

// 5. WHEN NOT TO USE IT & COMMON OVER-ENGINEERING MISTAKES
//
// - SEQUENTIAL DEPENDENCIES: Do not use Parallel.Invoke if Step B requires the calculated 
//   output of Step A. Because they execute concurrently and out of order, Step B will run 
//   with empty or corrupted data.

// - ASYMMETRIC WORKLOAD BLOCKING: Parallel.Invoke is synchronous to the caller. If you run 
//   one massive operation that takes 10 seconds alongside two fast operations that take 
//   10 milliseconds, your main thread will remain completely blocked for the full 10 seconds.

// - UNCONTROLLED CONCURRENCY LIMITS: If you pass 50 completely different heavy methods into 
//   Parallel.Invoke at once, you can temporarily exhaust the ThreadPool, leading to 
//   thread-allocation latency as .NET scrambles to spin up enough worker threads.