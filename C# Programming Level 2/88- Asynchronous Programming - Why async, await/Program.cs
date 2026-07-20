using System;
using System.Threading.Tasks;

namespace AsyncLesson1
{
    internal class Program
    {
        /*
        ============================================================================
        LESSON 1 - WHY WAS async/await CREATED?
        ============================================================================

        Before learning async/await, we first need to understand the problem it
        was designed to solve.

        ---------------------------------------------------------------------------
        THE PROBLEM
        ---------------------------------------------------------------------------

        Many operations are I/O-bound rather than CPU-bound.

        Examples:
            • Downloading data from the internet
            • Reading a file
            • Querying a database
            • Calling a Web API

        During these operations, the CPU does almost nothing.

        The operating system sends the request to an external resource
        (server, disk, database...) and simply waits for a response.

        While waiting...

            The thread is blocked.

        Example:

            Main Thread
                |
                |---- Send HTTP Request
                |
                |---- Waiting...
                |---- Waiting...
                |---- Waiting...
                |
                |---- Response Arrives
                |
                |---- Continue Execution

        A blocked thread performs no useful work.

        Since threads are expensive resources, wasting one while waiting for I/O
        is inefficient.

        ---------------------------------------------------------------------------
        THE FIRST PRACTICAL SOLUTION
        ---------------------------------------------------------------------------

        Developers started writing asynchronous code using Tasks and callbacks
        (continuations).

        The idea was simple:

            1. Start the operation.
            2. Register a callback.
            3. Return immediately.
            4. Execute the callback when the operation finishes.

        This freed the thread immediately.

        However...

        Every new asynchronous operation had to be placed inside another callback.

        As applications grew, the code became deeply nested and difficult to read.

        This problem became known as "Callback Hell".

        The next lesson will show how async/await solves this while still using
        the same callback mechanism behind the scenes.
        */


        // reminder: 
        // The essence of the problem of why we use asyncronous is not the number of threads.
        // The problem is that any individual thread can become idle while waiting for an I/O operation to complete.
        // Multithreading doesn't eliminate this problem; every thread can still waste time waiting for I/O.


        static void Main()
        {
            Console.WriteLine("========== CALLBACK HELL ==========\n");

            // STEP 1:
            // Start the asynchronous operation.
            // Returns immediately with a Task representing the unfinished work.
            DownloadUser()
                .GetAwaiter()
                .OnCompleted(() =>
                {
                    Console.WriteLine("User downloaded.");

                    DownloadOrders()
                        .GetAwaiter()
                        .OnCompleted(() =>
                        {
                            Console.WriteLine("Orders downloaded.");

                            DownloadProducts()
                                .GetAwaiter()
                                .OnCompleted(() =>
                                {
                                    Console.WriteLine("Products downloaded.");

                                    SaveDatabase()
                                        .GetAwaiter()
                                        .OnCompleted(() =>
                                        {
                                            Console.WriteLine("Database saved.");

                                            SendEmail()
                                                .GetAwaiter()
                                                .OnCompleted(() =>
                                                {
                                                    Console.WriteLine("Email sent.");
                                                    Console.WriteLine("\nWorkflow completed.");
                                                });
                                        });
                                });
                        });
                });
            // STEP 3:
            // The callback has been registered.



            // STEP 4:
            // Main continues executing immediately.
            // It does NOT wait for DownloadUser().

            // main thread reaches here cuz it was not blocked waiting for above callbacks
            // once callbacks are ready, any free thread will go execute them, which will happen if we run and see the results
            Console.WriteLine("Main thread is already free.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // NOTE:
        // Only the first operation is started by Main().
        // Every operation after that is started by the previous callback.
        //
        // Main() never directly calls DownloadOrders(),
        // DownloadProducts(), SaveDatabase(), or SendEmail().




        static Task DownloadUser()
        {
            // 2. main thread runs this method, then returns a delayed task
            Console.WriteLine("Downloading User...");
            return Task.Delay(1000);
        }

        static Task DownloadOrders()
        {
            Console.WriteLine("Downloading Orders...");
            return Task.Delay(1000);
        }

        static Task DownloadProducts()
        {
            Console.WriteLine("Downloading Products...");
            return Task.Delay(1000);
        }

        static Task SaveDatabase()
        {
            Console.WriteLine("Saving Database...");
            return Task.Delay(1000);
        }

        static Task SendEmail()
        {
            Console.WriteLine("Sending Email...");
            return Task.Delay(1000);
        }
    }
}