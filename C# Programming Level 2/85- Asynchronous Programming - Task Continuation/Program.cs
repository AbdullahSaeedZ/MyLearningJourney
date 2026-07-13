using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace _85__Asynchronous_Programming___Task_Continuation
{
    /*
    =============================================================================
    THE ANATOMY OF THE TASK AND TASKAWAITER RELATIONSHIP
    =============================================================================
    When you call 'Task.Run', .NET allocates a tracking object in heap memory:

     ┌──────────────────────────────────────────────────────────┐
     │                      Task<T> Object                      │
     │                      (Think: "The TV")                   │
     ├──────────────────────────────────────────────────────────┤
     │ 1. State / Status                                        │
     │    [ Created ➔ Running ➔ RanToCompletion / Faulted ]     │
     ├──────────────────────────────────────────────────────────┤
     │ 2. Result Slot (T)                                       │
     │    [ Holds the final value once Status is completed ]    │
     ├──────────────────────────────────────────────────────────┤
     │ 3. The Callback List (Continuations)                     │
     │    [ List of actions/delegates to run when finished ]    │
     │    • Callback 1: Console.WriteLine(Result)               │
     │    • Callback 2: (Another action...)                     │
     └──────────────────────────────────────────────────────────┘
                                 ▲
                                 │
     (Controls & reads via reference)
                                 │
     ┌──────────────────────────────────────────────────────────┐
     │                    TaskAwaiter Struct                    │
     │                 (Think: "The Remote Control")            │
     ├──────────────────────────────────────────────────────────┤
     │ - Holds a direct reference to its parent Task            │
     │ - IsCompleted : Checks underlying Task status            │
     │ - OnCompleted() : Wires a callback into Callback List    │
     │ - GetResult() : Safely extracts value from Result Slot   │
     └──────────────────────────────────────────────────────────┘

    Key Concepts:
    - Result Slot: If you access '.Result' directly while this is empty, your calling 
                   thread blocks (freezes) until it is filled.

    - Callback: A callback is just a method/delegate that you hand over, which is 
                guaranteed to be executed only when the task completes its work.

    - Callback List: A queue of delegates. When you use 'OnCompleted' or 'ContinueWith', 
                     you register a callback here. The main thread is freed immediately.
                     Once the background thread finishes, it writes to the Result Slot
                     and triggers these callbacks. Because the task is already finished
                     by then, retrieving the result inside the callback is instant and 
                     never blocks.

    - TaskAwaiter: A lightweight struct helper that acts as the communication interface 
                   to the Task. Rather than working with the heavy Task object directly,
                   the .NET execution engine (and the compiler during async/await) uses 
                   the TaskAwaiter as a standard gateway to register callbacks and 
                   extract results safely.



    - Async/Await Integration: Modern C# 'async' and 'await' keywords are purely 
                                syntactic sugar that the compiler translates into 
                                this exact TaskAwaiter and OnCompleted state machine under the hood.
    =============================================================================
    */

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------- Task blocking main thread -------");

            // 1. Instantly queues the work to a ThreadPool worker thread to execute right away.
            // 2. Returns a Task object handle to the Main thread immediately.
            Task<int> task = Task.Run(() => CountPrimeNumberInARange(2, 3_000_000));

            // Calling '.Result' will FREEZE the calling thread (Main thread) until the result is available.
            // This is a waste of time, better used only when we are sure the task is extremely fast.
            Console.WriteLine(task.Result);

            // Even though the Main thread and worker thread were executing simultaneously,
            // the Main thread was blocked at '.Result' above until it was ready.
            Console.WriteLine("blocked main thread job");





            Console.WriteLine("\n\n------- Task not blocking main thread using TaskAwaiter, OnCompleted -------");

            // LOW-LEVEL CALLBACK MECHANISM (The foundation used by the compiler under the hood)
            Task<int> task1 = Task.Run(() => CountPrimeNumberInARange(2, 3_000_000));

            // Extract the low-level communication device (awaiter/remote control) from the task.
            TaskAwaiter<int> awaiter = task1.GetAwaiter();

            // Register a callback into the Task's internal Callback List using the awaiter.
            // Think of this like a button click event handler. The code inside this block is set
            // to run ONLY when the background task transitions to the "Completed" state.
            awaiter.OnCompleted(() =>
            {
                // This code runs on a worker thread only AFTER the task is finished.
                // Because the task is complete, calling 'GetResult()' is instant and does NOT block.
                Console.WriteLine(awaiter.GetResult());
            });

            // The Main thread does not wait! It registers the callback and immediately continues here.
            Console.WriteLine("non-blocked main thread job");





            Console.WriteLine("\n\n------- Task not blocking main thread using Continuation -------");

            // HIGH-LEVEL DEVELOPER-FRIENDLY ABSTRACTION
            Task<int> task2 = Task.Run(() => CountPrimeNumberInARange(2, 3_000_000));

            // 'ContinueWith' is a cleaner abstraction built on top of the awaiter mechanism. 
            // It automatically registers the callback into the Task's Callback List.
            // It automatically passes the finished task (antecedent) as an input parameter ('completedTask').
            task2.ContinueWith((completedTask) =>
            {
                // Because this callback only runs when the task is finished, 
                // accessing 'completedTask.Result' is completely safe and non-blocking.
                Console.WriteLine(completedTask.Result);
            });

            // The Main thread registers the continuation and immediately moves on.
            Console.WriteLine("non-blocked main thread job");

            Console.ReadKey();
        }



        
        static int CountPrimeNumberInARange(int lowerBound, int upperBound)
        {
            int counter = 0;

            for (int i = lowerBound; i < upperBound; i++)
            {
                int j = lowerBound;
                bool isPrime = true;
                while (j < (int)Math.Sqrt(i))
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                    ++j;
                }

                if (isPrime)
                    ++counter;
            }
            return counter;
        }
    }
}