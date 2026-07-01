/*
 
 ============================================================================
                             SUMMARY OF LAST LESSON
 ============================================================================

 PHASE 1: THE SINGLE-TASK ERA
 ----------------------------------------------------------------------------
 In the beginning, a single running program took complete monopoly over the CPU.
 While this program executed, all other system tasks were completely disabled 
 and forced to wait, leading to massive hardware idling and inefficiency.
 
 PHASE 2: THE MULTI-TASKING ERA (THE PROCESS)
 ----------------------------------------------------------------------------
 To eliminate this waste, the concept of the "Process" was introduced. 
 This allowed multiple programs to APPEAR to run at the exact same time.

 ISSUE: 
 A single Process cannot easily run multiple internal tasks at the same time.
 Forcing a program like a browser to use separate processes for UI, downloading, 
 and media playback creates MASSIVE MEMORY OVERHEAD and slow communication.
 
 
 ============================================================================
                           THE SOLUTION: THREADS
 ============================================================================


 1. THE BIRTH OF THE THREAD
 ----------------------------------------------------------------------------
 To solve the inner-limitation of the process, computer scientists introduced 
 the "Thread" (Lightweight Process). 
 
 Instead of spawning an entirely isolated process for every sub-task, a single 
 Process is subdivided internally into smaller execution pathways called Threads.
 
 Core Concept:
 A Thread is the smallest unit of execution that the OS can schedule on a CPU. 
 The Process is now simply the blueprint and heavy container where these threads live.
 

 2. HOW THREADS SOLVED THE PROBLEMS
 ----------------------------------------------------------------------------
 A. Shared Memory & Resources:
    All threads living inside the same parent Process share its exact memory space.
    Example: A download thread can drop an image directly into RAM, and the UI 
    thread can display it instantly without needing slow OS IPC mechanisms.
 
 B. Lightweight Performance:
    Creating a thread does not require allocating a new virtual memory block 
    from the OS. It recycles existing process memory, making thread creation 
    and destruction exponentially faster than process creation.
 

 3. THE MAIN THREAD VS. WORKER THREADS
 ----------------------------------------------------------------------------
 - The Main Thread:
   The moment you launch any program, the OS automatically spawns exactly one 
   primary thread to execute the entry point of your code (the Main() method).
 
 - Worker Threads:
   From within that Main Thread, you can programmatically spawn additional 
   background threads (Worker Threads) to handle offloaded, concurrent tasks.
 
 - Threads within the same process are not fully isolated. 
   The failure of one thread can potentially affect the entire process.


 *** till this point, there is no real PARALLELISM in a single-core CPU
  it is only a simulation, a CONCURRENCY, using context switching,
  only multi-tasking using processes and threads inside a process, (each thread represents a task)

  This tricks the human brain into thinking multiple tasks run at once.
  Purpose on Single-Core: To prevent blocking (e.g., keeping the UI responsive 
  while another thread waits for a slow Hard Drive or Network I/O).

  - it is multi-threading, although they work in CONCURRENCY, not PARALLELISM.
 */



// this example is showing how a program is executed in a Sequential Synchronous Approach
// one thread executing the code Sequentially
using System.Diagnostics;

internal class Test
{
    public static void PrintInfo()
    {
        // these info can be seen in the task manager as well
        Console.WriteLine($"Process ID: {Process.GetCurrentProcess().Id}");
        Console.WriteLine($"Default Thread of process ID: {Thread.CurrentThread.ManagedThreadId}");

        // this is the processor (the core) in which the thread is executed
        Console.WriteLine($"processor ID: {Thread.GetCurrentProcessorId()}");
    }

    public static void Main()
    {
        // just to show info
        PrintInfo();

        // ------------------------------------

        var wallet = new Wallet("Issam", 80);

        
        Console.WriteLine("\n\n\n----------------");
        wallet.RunRandomTransactions();
        Console.WriteLine($"\n{wallet}\n"); // initialy has 80 bitcoins, then random added 80

        Console.WriteLine("\n\n\n----------------");
        wallet.RunRandomTransactions();
        Console.WriteLine($"\n{wallet}\n"); // had 160 bitcoins, then random added 80


        // see how the same thread is handled by different processors
        // this is because of the CPU Thread Scheduler:
        // Scheduler is responsible for scheduling threads on processors based on certain algorithms or calculations
    }
}


class Wallet
{
    public Wallet(string name, int bitcoins)
    {
        Name = name;
        Bitcoins = bitcoins;
    }

    public string Name { get; private set; }
    public int Bitcoins { get; private set; }


    public void Debit(int amount)
    {
        Bitcoins -= amount;
    }

    public void Credit(int amount)
    {
        Bitcoins += amount;
    }

    // will perform random trasactions on the account just to see how they are handled by thread and processor
    public void RunRandomTransactions()
    {
        // random numbers to simulate a randoom transaction, negatives will be Debit transaction
        int[] amounts = { 10, 20, 30, -20, 10, -10, 30, -10, 40, -20 }; // total = 80

        foreach (var amount in amounts)
        {
            var absValue = Math.Abs(amount);
            if (amount < 0)
                Debit(absValue);
            else
                Credit(absValue);

            Console.WriteLine($"[Thread: {Thread.CurrentThread.ManagedThreadId}" + $", Processor Id: {Thread.GetCurrentProcessorId()}] {amount}");
        }
    }

    public override string ToString()
    {
        return $"[{Name} -> {Bitcoins} Bitcoins]";
    }
}