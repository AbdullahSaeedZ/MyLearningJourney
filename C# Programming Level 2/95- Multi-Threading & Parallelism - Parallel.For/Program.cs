// ============================================================================
// LESSON: PARALLEL.FOR (COUNTER-BASED DATA PARALLELISM)
// ============================================================================

// 1. THE PROBLEM
// When you have a massive dataset indexed by integers (like an array or a flat list) 
// and you need to perform an expensive calculation on every single element, a standard 
// sequential 'for' loop executes completely on a single thread.
//
// Even if your user's machine has 16 or 32 CPU cores, a sequential 'for' loop utilizes 
// only one core, leaving 95%+ of the processor's capacity sitting completely idle while 
// the processing time drags on linearly.

// 2. THE CORE IDEA
// 'Parallel.For' is designed to split an index-based iteration range (from index A to index B) 
// across multiple processor cores simultaneously. 
//
// Instead of running loop iterations sequentially (0, then 1, then 2...), it assumes that 
// each index iteration is entirely independent of the others. This allows the .NET runtime 
// to execute different index blocks at the exact same time across different threads.

// 3. HOW IT WORKS INTERNALLY
// When you execute Parallel.For(0, 1000000, i => { ... }), .NET executes these steps:
//
// A. Index Partitioning: It does not create a thread for every index (which would crash the OS). 
//    Instead, it uses a component called a "Partitioner" to break the 0-1,000,000 range into 
//    chunks (e.g., Core 1 gets 0-250k, Core 2 gets 250k-500k, etc.).
// B. Dynamic Load Balancing: It utilizes a "Work-Stealing" algorithm. If Core 1 finishes its 
//    assigned index range faster than Core 2, it will automatically "steal" remaining indexes 
//    from Core 2's chunk so no CPU core sits idle.
// C. Delegate Invocation: The body of the loop is passed as an Action<int> delegate. Each 
//    participating ThreadPool thread repeatedly invokes this delegate with the current index 
//    value it is responsible for.

// 4. MINIMAL C# EXAMPLE
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class ParallelForLesson
{
    static void Main()
    {
        // Define the number of iterations
        int numberOfIterations = 10;


        // Use Parallel.For to execute the loop in parallel
        // Parallel.For takes: (inclusive lower bound, exclusive upper bound, action delegate)
        Parallel.For(0, numberOfIterations, i =>
        {
            Console.WriteLine($"Executing iteration {i} on thread {Thread.CurrentThread.ManagedThreadId}");
            // Simulate some work
            Thread.Sleep(1000);
        });


        Console.WriteLine("All iterations completed.");
        Console.ReadKey();

        // -----------------------------------------------------------



        // comparing doing computations in both parallel and normal for statement

        // preparing the dataset:
        int totalItems = 100_000;
        double[] sourceData = new double[totalItems];
        double[] results = new double[totalItems];
        // Populate mock data sequentially
        for (int i = 0; i < totalItems; i++)
        {
            sourceData[i] = i * 1.5;
        }

        // using Parallel.For:
        Console.WriteLine("\n\n\nStarting heavy parallel computation...");
        Stopwatch sw = Stopwatch.StartNew();

        // Parallel.For takes: (inclusive lower bound, exclusive upper bound, action delegate)
        Parallel.For(0, totalItems, i =>
        {
            // This body executes concurrently on multiple ThreadPool threads.
            results[i] = HeavyMathematicalFormula(sourceData[i]);
        });

        sw.Stop();
        Console.WriteLine($"Parallel computation completed in: {sw.ElapsedMilliseconds}ms\n\n");


        // -----------------------------------------------------------

        // using normal for loop:
        // this will be ran on a single thread and core
        Console.WriteLine("Starting heavy computation using normal for loop...");
        Stopwatch sw1 = Stopwatch.StartNew();
        double[] results1 = new double[totalItems];
        for (int i = 0; i < totalItems; i++)
        {
            results1[i] = HeavyMathematicalFormula(sourceData[i]);
        }
        sw1.Stop();
        Console.WriteLine($"normal for loop computation completed in: {sw1.ElapsedMilliseconds}ms");

        // Takeaway: The cost of parallelism (thread management) is only worth it when the 
        // iterations are many and each iteration does significant work (like CPU-heavy computation).
    }

    static double HeavyMathematicalFormula(double input)
    {
        // Simulating an intensive CPU operation per item
        double result = input;
        for (int j = 0; j < 1000; j++)
        {
            result = Math.Sqrt(Math.Sin(result) + Math.Cos(result) + 1.1);
        }
        return result;
    }
}

// 5. WHEN NOT TO USE IT & COMMON OVER-ENGINEERING MISTAKES
//
// - OVER-ENGINEERING WITH LOCKS: If the code inside your Parallel.For modifies a shared 
//   variable outside the loop (like a shared counter or adding to a standard List<T>), 
//   and you use a 'lock' keyword to make it thread-safe, you serialize the execution. 
//   The threads will spend all their time waiting for the lock, making it *slower* than a regular loop.

// - ITERATION DEPENDENCY: Never use Parallel.For if iteration [i] depends on the result 
//   of iteration [i-1] (such as calculating a running total or a Fibonacci sequence). 
//   Because iterations run completely out of order, your calculations will be wrong.

// - BREAKING THE LOOP CARELESSLY: You cannot use the standard 'break' or 'continue' keywords 
//   inside a Parallel.For delegate. To stop execution, you must accept a 'ParallelLoopState' 
//   parameter and call state.Break() or state.Stop(), which introduces additional complexity.