using System;
using System.Threading;


class Program
{
    // Every single object created in C# (.NET) has a hidden, internal property 
    // built into it by the runtime called a 'SyncBlock'. 
    
    // When we instantiate this empty object, we are creating a lightweight token 
    // that exists purely so the .NET runtime can use its SyncBlock to flag whether 
    // the critical section (in the lock statement) is currently "Locked" or "Unlocked". 
    
    // It acts exactly like a traffic light that threads inspect before passing through.
    static readonly object lockObject = new object();
    // shared resource to be protected from Race Condition
    static int sharedCounter = 0;


    static void Main()
    {
        // Create two threads that increment a shared counter
        Thread t1 = new Thread(() => IncrementCounter("T1"));
        Thread t2 = new Thread(() => IncrementCounter("T2"));

        Console.WriteLine($"initial value of shared counter: {sharedCounter}");
        t1.Start();
        t2.Start();

        // Wait for both threads to complete
        t1.Join();
        t2.Join();

        Console.WriteLine("Final Counter Value: " + sharedCounter);
    }


    static void IncrementCounter(string ThreadName)
    {
        // both threads start at same time, but since they are both using the same method with a locked resource
        // then they will be in a queue to execute the counter update (the lock code block)
        // it is not that one thread will finish all iterations then the second thread will do his,
        // since the lock statement is applied only on the shared counter update statement, \
        // then both will do iterations simultaneosly, but will queue whenever lock statement is executing

        for (int i = 0; i < 10; i++) 
        {
            // Use lock to synchronize access to the shared counter
            lock (lockObject)
            {
                // critical section code block here
                sharedCounter++;

                Console.WriteLine($"{ThreadName} increases 1 value, shared counter value: {sharedCounter}");
                Thread.Sleep(500);
            }


            // comment out the lock then uncomment below code to see how chaotic things get
            // imagine this writeline function were a new balance assignment function, what would the result be ???

            //sharedCounter++;
            //Console.WriteLine($"{ThreadName} increase 1 value, shared counter value: {sharedCounter}");
            //Thread.Sleep(500);
        }
    }
}