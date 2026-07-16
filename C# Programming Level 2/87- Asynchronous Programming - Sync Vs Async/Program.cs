using System;
using System.Threading;
using System.Threading.Tasks;

/*
================================================================================
TECHNICAL BRIEF: SYNCHRONOUS VS. ASYNCHRONOUS WAITING
================================================================================

1. THE PROBLEM (Why Asynchrony Exists)
   OS threads are expensive (each costs ~1MB of memory). When a thread synchronously 
   waits for I/O, network, or a timer (like Thread.Sleep), it is frozen and wasted. 
   Creating more threads to handle blocking leads to heavy memory overhead and CPU thrashing.

2. THE CORE IDEA (Non-Blocking Progress)
   Asynchrony lets a thread register a callback ("when finished, run this") and 
   immediately return to do other work. The OS handles the wait via hardware and 
   kernel interrupts. During the waiting period, exactly zero threads are blocked.

3. THE ENVIRONMENT DIFFERENCE (Why the executing thread changes)
   What executes the callback once the wait is over depends entirely on the execution context:
   
   - Console Applications (No SynchronizationContext):
     The Main thread has no "event loop" or mailbox queue to receive new instructions. Additionally, 
     in this demo, it is blocked at `Console.ReadKey()`. Because the Main thread is unreachable, 
     the .NET ThreadPool must assign a worker thread to execute the completion callback.
     
   - UI/JavaScript Applications (Single-Threaded Event Loop):
     These environments run a message loop. The main thread remains free to handle window events. 
     When the OS timer fires, a message is posted to the main thread's queue, and the *exact same* 
     main thread processes the callback. No secondary thread is ever utilized.
================================================================================
*/

namespace CA07SyncVsAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            LogThread(41);

            // 1. Synchronous Execution (Blocking)
            CallSynchronous();

            LogThread(46);

            // 2. Asynchronous Execution (Non-Blocking)
            CallAsynchronous();

            LogThread(51);

            // Freeze Main thread here to keep process alive so the async callback can execute by a worker thread.
            // if it was a Single-Threaded Event Loop, then the main thread could recieve the instruction to execute the callback
            Console.ReadKey();
        }

        static void CallSynchronous()
        {

            LogThread(61); // Starts on Main Thread

            // Simulates heavy synchronous CPU/IO work. 
            // THE ISSUE: The Main Thread is now frozen here and cannot handle any other tasks.
            Thread.Sleep(4000);

            LogThread(67); // Resumes and finishes on the exact same Main Thread
            Console.WriteLine("++++++++++ Synchronous Completed +++++++++++\n");
        }

        static void CallAsynchronous()
        {
            LogThread(38); // Starts on Main Thread

            // Task.Delay registers a hardware timer with the OS. 
            // The Main thread does not wait; it immediately returns out of this method 
            // and continues executing Main (reaching Console.ReadKey).
            Task.Delay(4000).GetAwaiter().OnCompleted(() => {

                // Once the 4-second OS timer interrupts, this callback triggers.
                // Because the Console App lacks a message pump and the Main thread is 
                // blocked at Console.ReadKey(), .NET dispatches a ThreadPool worker thread here.
                // otherwise the main thread would pick it up and execute the callback
                LogThread(84);
                Console.WriteLine("++++++++++ Asynchronous Completed +++++++++++\n");
            });
        }

        private static void LogThread(int lineNumber)
        {
            var t = Thread.CurrentThread;
            Console.WriteLine($"[Line {lineNumber:D2}] Thread ID: {t.ManagedThreadId} | Pool: {t.IsThreadPoolThread} | Background: {t.IsBackground}");
        }
    }
}