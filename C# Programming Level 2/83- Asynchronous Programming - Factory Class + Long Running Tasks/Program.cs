using System;
using System.Threading;
using System.Threading.Tasks;

// =======================================================================================
// HISTORY & THE "WHY":
// - .NET 4.0 introduced 'Task.Factory.StartNew' as the original, low-level engine to create tasks.
//   It was highly configurable but required a lot of verbose boilerplate code.
// - .NET 4.5 introduced 'Task.Run' as a clean, simple shortcut for 90% of daily work,
//   automatically configuring tasks to use optimal default settings on the Thread Pool.
//
// THE CORE PROBLEM:
// - 'Task.Run' is built strictly for short-lived tasks that yield quickly.
// - If you put a long-running task (like an infinite loop or a socket listener) on a 
//   pooled thread, you block that thread permanently. Doing this repeatedly starves 
//   the Thread Pool, leaving no threads available to handle your app's short tasks.
//
// THE SOLUTION:
// - We drop back down to 'Task.Factory' exclusively when we need advanced configuration.
// - By passing 'TaskCreationOptions.LongRunning', we tell the engine to bypass the 
//   Thread Pool entirely and spin up a brand new, dedicated raw OS thread.
// =======================================================================================

namespace _83__Asynchronous_Programming___Long_Running_Tasks
{
    // The standard 'Task.Run' uses the Thread Pool, which is optimized for short-running tasks.
    // If you clog the Thread Pool with tasks that run forever, you cause "thread starvation" (no pool threads left for short tasks).

    // To solve this, the 'Task.Factory' class provides advanced configuration flags. 
    // It STILL uses the Thread Pool by default, but passing 'TaskCreationOptions.LongRunning' 
    // tells the engine to bypass the pool and spin up a dedicated, raw OS thread.

    // How to choose:
    // 1. Use Thread Pool (Task.Run) -> When execution time is short or medium.
    // 2. Use Raw Thread (Task.Factory + LongRunning) -> When execution time is massive (e.g., an infinite loop listening to a socket).

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- Starting Pooled Task ---");
            // Running the task using a standard pooled thread
            Task.Run(RunLongTask).Wait();

            Console.WriteLine("\n--- Starting Raw Thread Task ---");
            // Running the task using a dedicated raw thread via the Factory class
            Task.Factory.StartNew(RunLongTask, TaskCreationOptions.LongRunning).Wait();

        }

        static void RunLongTask()
        {
            // Simulating a heavy workload
            Thread.Sleep(1000);
            ShowThreadInfo();
        }

        private static void ShowThreadInfo()
        {
            Console.WriteLine($"Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine($"Is Pooled Thread: {Thread.CurrentThread.IsThreadPoolThread}");
            Console.WriteLine($"Is Background Thread: {Thread.CurrentThread.IsBackground}");
        }
    }
}