// ============================================================================
// LESSON: PARALLEL.FOREACH (COLLECTION-BASED DATA PARALLELISM)
// ============================================================================

// 1. THE PROBLEM
// In real-world software engineering, data rarely arrives as a clean sequence of 
// integer indexes (0 to N). Instead, it lives inside object collections—such as a 
// List<User>, a HashSet<Transaction>, or custom domain models.
//
// If you use a standard 'foreach' loop to process these objects, .NET handles them 
// sequentially, one by one, on a single thread. If processing a single object requires 
// heavy CPU computation (e.g., parsing a complex string, validating a model, processing 
// an image structure), processing thousands of objects in sequence leaves the remaining 
// CPU cores completely underutilized, resulting in slow execution pipelines.

// 2. THE CORE IDEA
// 'Parallel.ForEach' is built to process collections that implement 'IEnumerable<T>' 
// across multiple execution threads concurrently.
//
// Instead of manually mapping collection elements to integer indexes to use Parallel.For, 
// Parallel.ForEach accepts the collection directly. It assumes that processing each element 
// inside the collection is completely independent of the others, allowing the runtime to 
// distribute the actual objects across separate background workers simultaneously.

// 3. HOW IT WORKS INTERNALLY
// When you execute Parallel.ForEach(userList, user => { ... }), .NET implements these steps:
//
// A. Element Partitioning: Unlike an index range where lengths are known instantly, an 
//    IEnumerable could be an open stream. Parallel.ForEach uses sophisticated strategies 
//    like "Range Partitioning" (for arrays/lists) or "Chunk Partitioning" (for generic streams) 
//    to safely slice the collection into dynamic, manageable batches.

// B. Worker Task Generation: It provisions structural internal Tasks via the .NET ThreadPool 
//    to consume these chunks.

// C. Enumerator Management: It safely tracks the collection's underlying enumerator. 
//    Multiple threads pull object references out of the shared collection buffers without 
//    colliding, invoking your Action<T> delegate concurrently for each individual object.

// 4. MINIMAL C# EXAMPLE
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class ParallelForEachLesson
{
    // A sample domain model representing a data entity requiring heavy parsing
    class DataPayload
    {
        public string RawData { get; set; }
        public bool IsProcessed { get; set; }
        public double ComputedResult { get; set; }
    }

    static void Main()
    {
        // 1. SETUP: Prepare a generic list of object payloads
        int datasetSize = 50_000;
        List<DataPayload> payloadsForParallel = new List<DataPayload>();
        List<DataPayload> payloadsForSequential = new List<DataPayload>();

        // filling both lists with payloads 
        for (int i = 0; i < datasetSize; i++)
        {
            var payload = new DataPayload { RawData = $"Payload_Data_Value_{i}" };
            payloadsForParallel.Add(payload);

            // Duplicate the exact dataset for an accurate performance comparison
            payloadsForSequential.Add(new DataPayload { RawData = payload.RawData });
        }

        // -----------------------------------------------------------





        // 2. PARALLEL EXECUTION DEMONSTRATION
        Console.WriteLine("Starting collection processing via Parallel.ForEach...");
        Stopwatch parallelSw = Stopwatch.StartNew();

        // Parallel.ForEach takes: (IEnumerable source, Action<TSource> body)
        Parallel.ForEach(payloadsForParallel, payload =>
        {
            // Executing concurrently across the ThreadPool. 
            // We pass the object directly into the processing engine.
            payload.ComputedResult = PerformHeavyObjectParsing(payload.RawData);
            payload.IsProcessed = true;
        });

        parallelSw.Stop();
        Console.WriteLine($"Parallel.ForEach completed in: {parallelSw.ElapsedMilliseconds}ms\n");

        // -----------------------------------------------------------

        // 3. SEQUENTIAL EXECUTION COMPARISON
        Console.WriteLine("Starting collection processing via standard sequential foreach...");
        Stopwatch sequentialSw = Stopwatch.StartNew();

        foreach (var payload in payloadsForSequential)
        {
            // Executing entirely on a single main thread
            payload.ComputedResult = PerformHeavyObjectParsing(payload.RawData);
            payload.IsProcessed = true;
        }

        sequentialSw.Stop();
        Console.WriteLine($"Standard foreach completed in: {sequentialSw.ElapsedMilliseconds}ms\n");

        Console.ReadKey();
    }

    static double PerformHeavyObjectParsing(string input)
    {
        // Simulating intensive string hashing or mathematical parsing logic
        double hashValue = input.GetHashCode();
        for (int i = 0; i < 500; i++)
        {
            hashValue = Math.Sqrt(Math.Abs(Math.Tan(hashValue) * 1.05));
        }
        return hashValue;
    }
}

// 5. WHEN NOT TO USE IT & COMMON OVER-ENGINEERING MISTAKES
//
// - THREAD-UNSAFE COLLECTIONS: Never modify the source collection (e.g., adding or 
//   removing items from the list you are looping through) inside the Parallel.ForEach body. 
//   Standard .NET collections are not thread-safe for modifications and will throw 
//   an InvalidOperationException or corrupt your data.

// - POOR PARTITIONING OVERHEAD: If your collection contains very fast, lightweight operations 
//   (e.g., reading an integer property), a standard 'foreach' loop is superior. The overhead 
//   of chunk partitioning an IEnumerable and passing references to the ThreadPool will 
//   make Parallel.ForEach noticeably slower.

// - DYNAMIC OR COMPLEX COLLECTIONS: Avoid using Parallel.ForEach on collections 
//   that take a long time to yield their elements, or data streams where the total 
//   size keeps changing dynamically. If fetching the next item from the collection 
//   is slow or requires heavy processing, your parallel worker threads will sit completely 
//   idle waiting for the collection to give them data, ruining any performance gains.