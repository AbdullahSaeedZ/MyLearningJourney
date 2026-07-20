using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CA12ConcurrencyAndParallelism
{
    /*
    ===================================================================================================
    THE CORE DIFFERENCE: CONCURRENCY VS. PARALLELISM
    ===================================================================================================
    * Concurrency (Dealing with many things at once): 
      This is a structural design pattern. It is about splitting a program into distinct tasks 
      that can run in overlapping time frames. On a single-core CPU, this happens via context 
      switching (interleaving tasks so quickly that it feels simultaneous).

    * Parallelism (Doing many things at once): 
      This is a hardware-dependent execution strategy. It requires multiple CPU cores to physically 
      execute separate tasks at the exact same millisecond.

    * The Kitchen Analogy:
      - Concurrency: One chef slicing onions, stopping to check the oven, then returning to onions.
                     Only one action happens at any instant, but multiple jobs progress.
      - Parallelism: Hiring four chefs to work simultaneously on their own cutting boards.
    ===================================================================================================
    
    ===================================================================================================
    TECHNICAL NOTE: WHY DOES THE SAME THREAD CHANGE CPU CORES (PROCESSOR IDs)?
    ===================================================================================================
    When you execute ProcessThingsInConcurrent, you notice that the Thread ID (TID) stays exactly 
    the same, but the ProcessorId continuously changes. 

    Why this happens:
    1. Single-Threaded Execution: The loop is synchronous. A single thread handles the work sequentially.
    2. OS Thread Scheduling: Windows (or your OS) does not lock a single thread to one physical CPU core 
       forever unless you configure strict "thread affinity." 
    3. Context Switching & Delays: When Task.Delay(100).Wait() is called, the thread pauses execution. 
       When the OS schedules that thread to wake back up and resume work, it assigns it to whichever 
       CPU core happens to be free at that exact millisecond to balance the system's thermal and 
       processing load.

    Conclusion: A changing ProcessorId does NOT mean code is running in parallel. True parallelism 
    requires MULTIPLE Thread IDs (TIDs) processing workloads at the exact same time.
    ===================================================================================================
    */

    class Program
    {
        static void Main(string[] args)
        {
            var things = new List<DailyDuty>
            {
                new DailyDuty("Cleaning House"),
                new DailyDuty("Washing Dishes"),
                new DailyDuty("Doing Laundry"),
                new DailyDuty("Preparing Meals"),
                new DailyDuty("Checking Emails"),
                new DailyDuty("Cleaning House")
            };

            Console.WriteLine("Using Parallel Processing");
            ProcessThingsInParallel(things);

            Console.WriteLine("\n\nUsing Concurrent Processing");
            ProcessThingsInConcurrent(things);

            Console.ReadKey();
        }

        // Achieves true Parallelism by partitioning work across multiple ThreadPool threads.
        static Task ProcessThingsInParallel(IEnumerable<DailyDuty> things)
        {
            // The Parallel class partitions the collection and executes the work using multiple threads.
            // Note: This is part of the Task Parallel Library (TPL) and will be explained deeply in next lessons.
            Parallel.ForEach(things, thing => thing.Process());
            return Task.CompletedTask;
        }

        // Runs synchronously (Sequentially) on the calling thread.
        static Task ProcessThingsInConcurrent(IEnumerable<DailyDuty> things)
        {
            foreach (var thing in things)
            {
                thing.Process();
            }
            return Task.CompletedTask;
        }
    }

    class DailyDuty
    {
        public string title { get; private set; }
        public bool Processed { get; private set; }

        public DailyDuty(string title)
        {
            this.title = title;
        }

        public void Process()
        {
            Console.WriteLine($"TID: {Thread.CurrentThread.ManagedThreadId}, " +
                $"ProcessorId: {Thread.GetCurrentProcessorId()}");

            Task.Delay(100).Wait();
            this.Processed = true;
        }
    }
}