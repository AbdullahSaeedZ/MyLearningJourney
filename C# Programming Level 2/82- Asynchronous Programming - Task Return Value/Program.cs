namespace _82__Asynchronous_Programming___Task_Return_Value
{

    // We have two types of Task classes:
    // 1. Task: Represents an operation that does not return a value (like void).
    // 2. Task<T>: A generic type that represents an operation that returns a value of type T.

    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Task.Run instantly queues 'GetCurrentDateTime' to start executing on a ThreadPool worker thread right away.
            // 2. AT THE SAME TIME, it immediately returns a 'Task' object to the Main thread.
            // 3. This returned Task acts as a handle (or receipt) that the Main thread can use to track the background job's progress, 
            //    register callbacks (continuations, explained in next lessons) to run when it finishes, or extract the final result.
            Task<DateTime> task = Task.Run(GetCurrentDateTime);

            // If we print the task handle itself, it only prints the type name, not the returned value
            Console.WriteLine(task);

            // Accessing the 'Result' property will BLOCK THE CALLING THREAD (Main thread) until the worker thread finishes.
            // If the worker thread is still running, the Main thread freezes here until the result is ready. This is synchronous/blocking behavior.
            Console.WriteLine(task.Result);



            // -----------------------------------------------------------------

            // can be done this way also, which is an advantage of Task class over Thread
            Console.WriteLine(task.GetAwaiter().GetResult());

        }


        static DateTime GetCurrentDateTime() => DateTime.Now;
    }
}
