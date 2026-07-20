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
            Log($"Returned a web task.");
            return client.GetStringAsync("https://postman-echo.com/get?foo=Hello");
        }

        static void Log(string message, [CallerLineNumber] int line = 0)
        {
            Console.WriteLine(
                $"[Thread {Thread.CurrentThread.ManagedThreadId}] {message}");
        }
    }

    /* 
    =======================================================================
                   THE DEFINITIVE C# AWAIT TRACKING GUIDE
    =======================================================================

    STEP 1: THE APPROACH (The Pre-Await Drive)
    ------------------------------------------
    • The calling thread drives STRAIGHT into the invoked method synchronously.
    • It executes line-by-line until it hits a 'return' or an internal await.
    • The method hands a Task object back to the await keyword.

    STEP 2: THE SPLIT (Evaluating the Task Status)
    -----------------------------------------------
    When the thread hits the 'await' keyword, it checks: IsCompleted?

      ► PATH A: FAST PATH (Task is ALREADY Complete)
        • Occurs if data is cached, uses Task.FromResult, or completed instantly.
        • The thread DOES NOT yield and DOES NOT return to its caller.
        • It keeps driving straight down to the next line in the same method.

      ► PATH B: SLOW PATH (Task is INCOMPLETE)
        • Occurs during active network I/O, Task.Run, or Task.Delay.
        • The remaining lines of this method are packaged as a callback.
        • FREEING MOMENT: The thread exits this method and returns to its caller.

    STEP 3: THE CALLER RESPONSE (Where the Thread Lands)
    ----------------------------------------------------
    When the thread returns to the calling method, its next move depends on:

      • Case A: Caller used 'await' -> The thread sees this parent task is 
        also incomplete. It yields again, returning to the caller's caller.
        (Exception: In a Console Main(), it blocks to keep the app alive).

      • Case B: Caller omitted 'await' (Fire-and-Forget = a task with no await keyword before it) -> The thread 
        ignores the task and instantly runs the very next line in the caller.

    STEP 4: THE RESURRECTION (Running the Continuation)
    ---------------------------------------------------
    When the background operation finally finishes, the callback must run:

      • Console / ASP.NET Core: ANY available ThreadPool thread wakes up 
        and executes the lines following the original await.
      • UI Apps (WPF/WinForms): The execution is routed back to the Main 
        UI thread via the SynchronizationContext to allow safe UI updates.
    */

}