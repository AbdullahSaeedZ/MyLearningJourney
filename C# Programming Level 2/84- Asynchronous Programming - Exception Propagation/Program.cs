using System;
using System.Threading;
using System.Threading.Tasks;

namespace _84__Asynchronous_Programming___Exception_Propagation
{
    // An exception propagates from method to method up the call stack until it is caught.

    internal class Program
    {
        static void Main(string[] args)
        {
            // ------------------------------- The issue without propagation -------------------------------

            // When a child thread throws an exception, the parent thread won't catch the exception.
            // We must handle it manually inside that same child thread.
            Console.WriteLine("---- Main Thread Exception ----");
            try
            {
                // This exception is thrown by the MAIN THREAD
                ThrowException();
            }
            catch (Exception ex)
            {
                // So it is CAUGHT by the try-catch body which is in the main method, MAIN THREAD
                Console.WriteLine($"Caught: {ex.GetType().Name} in main method!");
            }


            // Uncomment to see how this main thread try-catch fails to handle the child thread exception (Crashes the app)
            //Console.WriteLine("\n\n---- Not handled Worker Thread Exception ----");
            //try
            //{
            //    // This exception is thrown by a new worker Thread
            //    // But this try-catch block is executed by the main thread, not by the worker thread.
            //    // So there will be no handling for the worker thread exception -> application crashes!
            //    // Which means, raw threads have no Exception Propagation!
            //    Thread th = new Thread(ThrowException);
            //    th.Start();
            //    th.Join();
            //}
            //catch
            //{
            //    Console.WriteLine("This block will never execute.");
            //}


            // This way, the child thread has its own handling block to handle its own internal exception safely.
            Console.WriteLine("\n\n---- Handled Worker Thread Exception ----");
            Thread th1 = new Thread(ThrowExceptionWithTryCatch);
            th1.Start();
            th1.Join();









            // ------------------------------- Exception propagation -------------------------------
            // Exception propagation is difficult in the Thread class and needs complex workarounds,
            // but it is the default behavior in the Task class:


            //                           WHAT IS AN AGGREGATEEXCEPTION?

            // 1. THE CORE CONCEPT:
            //    - It applies to ANY and ALL background threads running code inside a Task.
            //    - When code inside a Task crashes on a background thread, the .NET runtime catches 
            //      it, wraps it in an 'AggregateException' container, and hands it to the Main thread.
            //
            // 2. MULTIPLE EXCEPTIONS SCENARIO:
            //    - Even if you are only running one background thread right now, a single Task has the 
            //      ability to spawn multiple sub-tasks or use advanced tools like the 'Parallel' class.
            //    - (Note: You will learn about the 'Parallel' class later, but its job is to split 
            //       work across multiple worker threads at the exact same time).
            //
            // 3. WHY THE CONTAINER IS NECESSARY:
            //    - If multiple background threads crash simultaneously, a traditional 'catch' block 
            //      can only throw one single error at a time.
            //    - 'AggregateException' solves this by acting as a collection basket that holds 
            //      EVERY background error inside its '.InnerExceptions' list so nothing gets lost.
            //

            Console.WriteLine("\n\n---- Exception propagation to Parent Thread ----");
            try
            {
                // This exception is thrown inside the WORKER THREAD task
                Task.Run(ThrowException).Wait();
            }
            catch (AggregateException ex)
            {
                // Propagated from child to parent safely!
                Console.WriteLine($"Propagated Wrapper: {ex.GetType().Name} caught in Main Thread!");

                // This is how you access the actual error that happened inside the Task:
                foreach (var innerEx in ex.InnerExceptions)
                {
                    Console.WriteLine($"--> Inner Background Exception: {innerEx.GetType().Name}");
                }
            }
        }

        static void ThrowException()
        {
            throw new NullReferenceException();
        }

        static void ThrowExceptionWithTryCatch()
        {
            try
            {
                throw new NullReferenceException();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Exception was safely caught inside the worker thread log block.");
            }
        }
    }
}