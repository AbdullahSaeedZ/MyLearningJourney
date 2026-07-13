/*
====================================================================================================
                                           TASK INTRO
====================================================================================================

1. THE PROBLEM:
   In traditional synchronous programming, operations that take time (like downloading a file or 
   waiting for a database response) completely block the executing thread. A blocked thread cannot 
   do any other work. In desktop apps, the UI freezes; on web servers, scalable performance drops 
   because threads are held hostage doing absolutely nothing but waiting.

2. WHAT IS THE 'TASK' CLASS?
   A Task is NOT a thread. It is a lightweight object that represents an asynchronous operation 
   that will complete in the future. Think of it as a "receipt" or a "restaurant pager." When you 
   call an async method, it immediately gives you this receipt (Task). The receipt doesn't contain 
   the final data yet; it simply tracks the status of the background operation.
   - Task: Represents an operation that returns no value (similar to void). It just signals completion.
   - Task<T>: Represents an operation that will eventually return a value of type T (e.g., Task<string>).


====================================================================================================
 =======================================================================================
                                 WHY TASK OVER THREAD?
 =======================================================================================
 | CRITERIA               | THREAD                | TASK        | ADVANTAGE            |
 |------------------------|-----------------------|-------------|----------------------|
 | CONCEPT                | LOW LEVEL             | ABSTRACTION | LESS DETAILS         |
 |                        |                       |             |                      |
 | LEVERAGING THREAD POOL | NO                    | YES         | PERFORMANCE          |
 |                        |                       |             |                      |
 | RETURN VALUE           | NO                    | YES         | LESS CODE            |
 |                        |                       |             |                      |
 | CHAINING               | NO                    | YES         | ORDER / READABILITY  |
 |                        |                       |             |                      |
 | EXCEPTION PROPAGATION  | NO                    | YES         | PARENT CATCH IT      |
 |                        |                       |             |                      |
 | TASK TYPE              | FOREGROUND /          | BACKGROUND  | PROCESS TERMINATION  |
 |                        | BACKGROUND            |             |                      |
 |                        |                       |             |                      |
 | SUPPORT CANCELLATION   | NO                    | YES         | SAVE RESOURCES       |
 =======================================================================================

 1. CONCEPT -> LESS DETAILS
    - Threads force you to manually set up, manage, and tear down raw operating system resources.
    - Tasks handle all that complex setup behind the scenes, letting you just focus on your code.

 2. LEVERAGING THREAD POOL -> PERFORMANCE
    - Creating a new thread from scratch is slow and eats up a lot of memory (~1MB each).
    - Tasks automatically reuse a pool of existing threads, making them incredibly fast.

 3. RETURN VALUE -> LESS CODE
    - Threads cannot easily return data, forcing you to use messy global variables to share results.
    - Tasks have a built-in '.Result' property that safely passes data back like a normal function.

 4. CHAINING -> ORDER / READABILITY
    - Running threads in a specific sequence requires writing messy, nested callback functions.
    - Tasks let you easily link jobs together in a clean, readable chain using '.ContinueWith()'.

 5. EXCEPTION PROPAGATION -> PARENT CATCH IT
    - An error inside a raw thread is isolated; it cannot be caught easily and will crash the app.
    - Tasks catch errors internally and pass them back up so your main code can safely handle them.

 6. TASK TYPE -> PROCESS TERMINATION
    - Raw threads stay alive by default and can block your app process from fully closing down.
    - Tasks run quietly in the background and automatically stop the moment your app exits.

 7. SUPPORT CANCELLATION -> SAVE RESOURCES
    - Force-stopping a running thread is dangerous and can corrupt your application's memory.
    - Tasks use a safe, built-in "token" signaling system to gracefully stop work early.


 =======================================================================================


*/

using System;
using System.Threading;
using System.Threading.Tasks;

namespace TaskClass
{
    class Program
    {
        static void Main(string[] args)
        {
            var th = new Thread(() => Display("Abdullah using thread!"));
            th.Start();
            th.Join();

            // the same thing using less code
            // .Wait() is same as .Join()
            // Run() uses pooled threads by default, while new Thread() creates new threads
            Task.Run(() => Display("Abdullah using task!")).Wait();
            Console.ReadKey();
        }

        static void Display(string message)
        {
            ShowThreadInfo(Thread.CurrentThread);
            Console.WriteLine(message);
        }

        private static void ShowThreadInfo(Thread th)
        {
            // Task class thread are background by default
            Console.WriteLine($"TID: {th.ManagedThreadId}, Pooled: {th.IsThreadPoolThread}, Background: {th.IsBackground}");
        }
    }
}