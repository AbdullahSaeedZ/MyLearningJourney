/*
============================================================================
INTRODUCING async/await
============================================================================

In previous lessons, we learned how asynchronous code was traditionally
written using:

    • Task
    • TaskAwaiter
    • OnCompleted()

This worked correctly and efficiently, but became difficult to read as
applications grew.

The goal of async/await was NOT to create a new asynchronous programming
model.

Instead, its goal was to make the existing callback model easier to write,
read, and maintain.

In other words:

    async/await is built ON TOP OF the low-level Task/Awaiter model.

============================================================================
LOW-LEVEL APPROACH
============================================================================

Task<string> task = ReadURL(url);

TaskAwaiter<string> awaiter = task.GetAwaiter();

awaiter.OnCompleted(() =>
{
    string result = awaiter.GetResult();

    Console.WriteLine(result);
});

Notice what we're doing:

1. Start the asynchronous operation.
2. Obtain its awaiter.
3. Register a continuation (callback).
4. Return immediately.
5. Continue execution later when the Task completes.

============================================================================
HIGH-LEVEL APPROACH
============================================================================

string result = await ReadURL(url);

Console.WriteLine(result);

Much shorter...

But is it doing something different?

No.

The compiler simply performs Steps 2 to 5 automatically for us.

The generated code is conceptually similar to:

    Task<string> task = ReadURL(url);

    TaskAwaiter<string> awaiter = task.GetAwaiter();

    awaiter.OnCompleted(...);

The difference is:

    YOU write:
        await ReadURL();

    The compiler secretly writes:
        GetAwaiter()
        OnCompleted(...)
        GetResult()

============================================================================
IMPORTANT
============================================================================

async/await does NOT replace Tasks.

Tasks still exist.

Awaiters still exist.

Callbacks (continuations) still exist.

The compiler simply generates the boilerplate code for you.
*/
using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncLesson2
{
    internal class Program
    {
        /*
        HIGH-LEVEL (This Lesson)

        string html = await ReadWebPage();

        CONCEPTUALLY
        await ReadWebPage();
                    ↓
        GetAwaiter()
        OnCompleted(...)
        GetResult()

        (The compiler generates these calls for us.)
        */

        static async Task Main()
        {
            Log("Application Started.");

            await DownloadWebPage();

            Log("Application Finished.");

            Console.ReadKey();
        }

        static async Task DownloadWebPage()
        {
            Log("Preparing to download a web page...");

            // STEP 1:
            // Start the asynchronous operation.
             
            // ReadWebPage() immediately returns a Task<string>
            // representing an unfinished HTTP request.
             
            // Low-Level Equivalent:
            // Task<string> task = ReadWebPage();
            string html = await ReadWebPage();

            // The 'await' keyword now takes over.
            // It obtains the TaskAwaiter.
            // If the Task has not completed yet, it registers a continuation (callback).
            // That continuation already contains all the code that comes after the
            // 'await' statement. then the method returns.


            // Later, when the Task completes, the continuation executes.
            // It first calls GetResult() to retrieve the result, assigns it to 'html variable',
            // then continues executing the remaining code in this method.
            Log($"Downloaded {html.Length} characters.");

            // Conceptually, the compiler generates something similar to:
            //
            // Task<string> task = ReadWebPage();
            // TaskAwaiter<string> awaiter = task.GetAwaiter();
            // awaiter.OnCompleted(/* continuation */);

            // It appears as though the method simply "paused" at await keyword line
            // and later resumed from the same line.
        }

        static Task<string> ReadWebPage()
        {
            HttpClient client = new HttpClient();

            return client.GetStringAsync("https://postman-echo.com/get?foo=Hello");
        }

        static void Log(string message, [CallerLineNumber] int line = 0)
        {
            Console.WriteLine(
                $"[Thread {Thread.CurrentThread.ManagedThreadId}] {message}");
        }
    }
}