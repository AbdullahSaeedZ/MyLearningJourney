using System;
using System.Threading;
using System.Threading.Tasks;

namespace _79__Multithreading___Pooled_thread
{
    /*
    ====================================================================================================
    LESSON: THE THREAD POOL (THE CAPSTONE OF MULTITHREADING)
    ====================================================================================================
    
    1. THE PROBLEM IT SOLVES
    ------------------------
    Operating system threads are incredibly expensive. Creating a new thread via 'new Thread()' 
    involves allocating a massive chunk of memory for its stack (typically 1 MB) and burning 
    CPU cycles negotiating with the OS kernel. 
    
    If an application spawns a brand-new thread for every short-lived background job or incoming 
    web request, the CPU spends more time building and destroying threads than actually executing 
    your code. This overhead quickly degrades software performance.

    2. THE CORE IDEA
    ----------------
    To avoid this constant overhead, the .NET runtime automatically initializes a managed 
    "Thread Pool" the moment your process starts up, it is by default for every app.
    
    Instead of creating and destroying threads on the fly, the pool maintains a collection of 
    pre-allocated worker threads. When you have a background job, you simply queue it to the pool. 
    An idle thread grabs the job, runs it, and—instead of dying—returns safely to the pool, 
    waiting to be recycled for the next piece of work.

    3. HOW IT WORKS INTERNALLY
    --------------------------
    - MIN/MAX LIMITS: The pool initializes with a Minimum threshold of threads (usually matching 
      your machine's CPU core count) that are instantly ready. It has a high Maximum threshold 
      (thousands of threads) to prevent system crashes under extreme scenarios.

    - DYNAMIC SCALING: If work piles up past the minimum thread limit, a built-in "hill-climbing" 
      algorithm samples throughput and safely injects new threads or retires idle ones as needed.

    - BACKGROUND STATUS: Every single thread pool thread is explicitly a BACKGROUND thread. 
      This means if your application's Main thread terminates, these pool threads are forcefully 
      shut down immediately; they will not keep your process alive.

    - SYSTEM UTILITY: Even in purely synchronous applications, the .NET runtime itself uses this 
      pre-created pool behind the scenes to handle background tasks like parts of Garbage Collection, 
      timers, and system I/O signalling.

    - THE BRIDGE TO ASYNC: This topic is your direct exit point from Multithreading and your entry 
      point into Asynchronous programming. Modern async features ('async/await' and 'Task') use 
      this exact pool infrastructure under the hood to manage execution threads seamlessly.
    */

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== STEP 1: Inspecting the Pre-Created Pool Defaults ===");

            // Querying the runtime's built-in pool configurations
            ThreadPool.GetMinThreads(out int minWorker, out _);
            ThreadPool.GetMaxThreads(out int maxWorker, out _);

            Console.WriteLine($"Default Min Pool Threads (Instantly Available): {minWorker}");
            Console.WriteLine($"Default Max Pool Threads (Absolute Safety Cap): {maxWorker}\n");

            Console.WriteLine("=== STEP 2: Queueing Work via Legacy ThreadPool Class ===");

            // "Queueing" means dropping a job into a FIFO (First-In, First-Out) shared waiting line (thread pool).
            // You are NOT assigning this job to a specific thread. Instead, whichever thread pool thread 
            // becomes idle first will pull your job out of the line and execute it.\

            // THE PARAMETERS DETAILED:
            //
            // Parameter 1: The WaitCallback delegate (The Method/Work you want to execute)
            // which is just a delegate to let the queue method execute any work needed,
            // modern .NET uses Lambda insted of WaitCallback delegates
            //
            // Parameter 2: The State object (The data payload you want to pass inside that method).
            ThreadPool.QueueUserWorkItem(new WaitCallback(PrintWithState), "ThreadPool_Payload");


            // DEMONSTRATION: You can queue as many multiple, distinct pieces of work as needed back-to-back:
            // --------------------------------------------------------------------------------------------
            // If the pool has multiple idle worker threads, they will grab these jobs and run them at the exact same time (in parallel).
            // If only one thread is free, it runs Work1 first, while Work2 waits safely in line until a worker becomes available.
            // ThreadPool.QueueUserWorkItem(new WaitCallback(work1), "Payload_A");
            // ThreadPool.QueueUserWorkItem(new WaitCallback(work2), "Payload_B");

            Console.WriteLine("\n=== STEP 3: Queueing Work via Modern Task Class ===");

            // Task.Run internally calls the same queue mechanism. It wraps your method in a Task object 
            // and places it into the thread pool's queue, letting the pool manage which worker thread executes it.
            Task.Run(PrintAction);      // will intriduce Task clss in async programming lessons


            // CRITICAL CONFIGURATION: Because thread pool workers are background threads, 
            // if we do not explicitly block the Main thread here, the program will terminate 
            // before the background worker threads even get a chance to execute their queues.
            Console.WriteLine("\nPress [Enter] to exit the application and terminate background pool workers...");
            Console.ReadLine();
        }


        // Target method for modern Task.Run (Matches the Action delegate signature)
        private static void PrintAction()
        {
            ExecuteDiagnosticPrint("Task.Run Engine");
        }

        // Target method for traditional ThreadPool (Matches the WaitCallback delegate signature)
        private static void PrintWithState(object state)
        {
            ExecuteDiagnosticPrint($"ThreadPool Engine (State: {state})");
        }


        // Shared processing block just to show info of current executing thread
        private static void ExecuteDiagnosticPrint(string frameworkContext)
        {
            // Thread.CurrentThread lets us safely peek into properties of whichever pool thread picked up this job
            int threadId = Thread.CurrentThread.ManagedThreadId;
            string threadName = Thread.CurrentThread.Name ?? "Unnamed Pool Worker";
            bool isPoolThread = Thread.CurrentThread.IsThreadPoolThread;
            bool isBackground = Thread.CurrentThread.IsBackground;

            Console.WriteLine($"\n[{frameworkContext}] -> Managed Thread ID: {threadId} | Name: {threadName}");
            Console.WriteLine($"[{frameworkContext}] -> Is Managed Pool Thread? {isPoolThread} | Is Background Thread? {isBackground}");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"[{frameworkContext}] -> Executing simulated work cycle {i + 1}...");
                Thread.Sleep(200); // Simulate light processing blocks
            }

            Console.WriteLine($"[{frameworkContext}] -> Execution complete. Thread released back to the idle pool.");
        }
    }

}