using System;
using System.Threading;
using System.Threading.Tasks;

namespace _86__Asynchronous_Programming___Task.Delay___Vs_Thread.Sleep__
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // THE BLOCKING (SYNCHRONOUS) WAY
            Console.WriteLine("Main thread will start sleeping:");
            SleepUsingThread(5000);
            Console.WriteLine("Main thread job executed!");


            Console.WriteLine("\n\nPress any key to delay using Task...");
            Console.ReadKey();


            // THE NON-BLOCKING (ASYNCHRONOUS) WAY
            Console.WriteLine("\nDelaying task will start:");

            // CORRECTED CONCEPT:
            // Task.Delay does NOT run or simulate a task on a worker thread. 
            // It registers a timer with the Operating System and immediately returns control.
            // During the 5-second wait, ZERO threads are blocked or waiting.
            DelayUsingTask(5000);

            Console.WriteLine("Task.Delay() registered! Main thread is free and executes this immediately!");
            Console.ReadKey();
        }

        static void DelayUsingTask(int ms)
        {
            // GOOD: This is the non-blocking, asynchronous approach.
            // Task.Delay(ms) returns a Task that completes when the OS hardware timer fires.
            // .OnCompleted() registers a callback (delegate). 
            // Once the timer finishes, the .NET Runtime grabs an available ThreadPool thread to run the callback.
            Task.Delay(ms).GetAwaiter().OnCompleted(() =>
            {
                Console.WriteLine($"Thread ID {Thread.CurrentThread.ManagedThreadId} completed the callback after Task.Delay({ms})");
            });
        }

        static void SleepUsingThread(int ms)
        {
            // BAD: This is the blocking, synchronous approach.
            // Thread.Sleep freezes the calling thread (the Main Thread here) completely.
            // No other code can run on this thread until the time expires.
            Thread.Sleep(ms);
            Console.WriteLine($"Thread Slept using Thread.Sleep({ms})");
        }
    }
}