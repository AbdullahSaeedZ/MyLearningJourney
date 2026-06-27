using System.Threading;

namespace _69__Multithreading___What_is_Thread_Class
{
    /*
    *- The Thread class in C# represents an execution path or a flow of control that 
       can run concurrently with other threads within a program.
       It's a fundamental building block for multithreaded applications, 
       allowing you to execute operations in parallel rather than sequentially.

    *- Basic Concept of Threading
       Think of your program as a single path that executes instructions one after another. 
       With threading, you can create multiple paths that run simultaneously, 
       potentially improving performance and responsiveness.


    *- Important Methods and Properties
       The Thread class provides several important members:

       Start(): Begins execution of the thread
       Join(): Blocks the calling thread until this thread terminates
       Sleep(): Suspends the thread for a specified duration
       Abort() (deprecated): Terminates the thread
       IsAlive: Property that indicates if the thread is running
       IsBackground: Property that determines if the thread is a background thread
       Name: Property to assign a name to the thread for debugging purposes
       Priority: Property to set the priority level of the thread

     */
    internal class Program
    {
        static void Main(string[] args) // <- main method is the entry point of the program, it represents the main thread 
        {
            
            // now the main thread is running, since it is one thread, it will execute the app sequentially
            Console.WriteLine("Main thread running all code sequentially:");
            Method1();
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"\tMain: {i}");
            }


            // applying multi-threading, the new thread will be running in parallel with main thread
            Console.WriteLine("\n\nThe main thread + Separate Thread to run the code in parallel:");

            Thread thread2 = new Thread(Method2);
            thread2.Start();
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"\tMain: {i}");
                Thread.Sleep(100);
            }


            // Thread.Join() is a basic form of "thread synchronization" —a concept we will dive into later—
            // used here to force the calling thread (Main thread in our case) to pause 
            // until the worker thread completely finishes.
            // Only the calling thread is affected; other threads continue running normally.
            Console.WriteLine("\n\nusing the join method to force the calling thread to stop till other threads execute:");

            Thread thread3 = new Thread(Method3);
            Thread thread4 = new Thread(Method4);
            thread3.Start();
            thread4.Start();

            thread3.Join();// Main thread pauses here until thread3 finishes.
            thread4.Join();// Main thread pauses here (if thread4 isn't already finished).
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"\tMain: {i}");
                Thread.Sleep(100);
            }
        }

        public static void Method1()
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"\tMethod1: {i}");
            }
        }
        public static void Method2()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"\tMethod2: {i}");
                Thread.Sleep(100); // <- i had to slow down the execution, cuz we cant control which thread will be executing
            }
        }
        public static void Method3()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"\tMethod3: {i}");
                Thread.Sleep(100); 
            }
        }
        public static void Method4()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"\tMethod4: {i}");
                Thread.Sleep(100); 
            }
        }

    }
}
