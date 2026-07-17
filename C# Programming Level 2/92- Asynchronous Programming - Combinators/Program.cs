using System;
using System.Threading.Tasks;

namespace CA11TaskCombinators
{
    /* ==============================================================================================
 * TOPIC: ASYNCHRONOUS TASK COMBINATORS (.NET)
 * 
 * 1. THE PROBLEM:
 *    When launching multiple asynchronous operations simultaneously, managing them individually 
 *    creates clumsy code. Awaiting them one-by-one blocks sequentially, while managing their 
 *    concurrency manually requires messy state tracking and boilerplate error handling.
 * 
 * 2. THE CORE IDEA (WHAT IS A COMBINATOR?):
 *    A "Combinator" is a functional pattern that takes multiple inputs (Tasks) and combines 
 *    them into a single, unified output (a single Task) that represents the higher-level logic 
 *    of the entire group (e.g., "Wait for ALL to finish" or "Wait for ANY to finish").
 * 
 * 3. HOW THEY WORK INTERNALLY (.NET IMPLEMENTATION):
 * 
 *    A. Task.WhenAll (The Aggregator):
 *       - Expects all input tasks to complete.
 *       - Internally combines them into a single 'Task<T[]>'.
 *       - When you 'await' it, it extracts the raw underlying data array ('T[]') directly.
 *       - If multiple tasks fail, it aggregates all exceptions into an 'AggregateException' <- important.
 * 
 *    B. Task.WhenAny (The Race):
 *       - Expects only the fastest task to complete.
 *       - Internally monitors the group and returns the exact 'Task<T>' instance that crossed 
 *         the finish line first.
 *       - Why returns 'Task<T>' instead of raw 'T'? Because the caller needs the identity of the winning 
 *         Task object to know WHO won the race, and to inspect its specific status or errors.
 * 
 * 4. WHEN NOT TO USE IT:
 *    Avoid Task.WhenAll if the tasks are strictly dependent on each other's outputs (use sequential 
 *    awaits instead). Avoid running massive amounts of tasks inside WhenAll without throttling 
 *    (e.g., thousands of database writes), as it can overwhelm system resources or external APIs.
 *    
 * WHY USE COMBINATORS? (PERFORMANCE & EFFICIENCY)
 * 
 * 1. CONCURRENCY OVER SEQUENTIALITY: Awaiting tasks individually one after another can easily 
 *    lead to accidental sequential execution or cause multiple async state-machine hops. 
 *    Combinators fire all tasks concurrently in parallel.
 * 2. MINIMIZED AWAIT OVERHEAD: Instead of paying the cost of capturing and restoring synchronization 
 *    contexts multiple times for individual 'await' lines, combinators aggregate the wait into 
 *    a single, high-performance continuation point.
 * ============================================================================================== */
    class Program
    {
        static async Task Main(string[] args)
        {
            Task<string> has1000SubscriberTask = Task.Run(() => Has1000Subscriber());
            Task<string> has4000ViewHoursTask = Task.Run(() => Has4000ViewHours());
            Console.WriteLine("Using WhenAny()");
            Console.WriteLine("---------------");

            // this will return the task object, not the result,
            // cuz if result is returned, then we wouldnt know which task gave us this result
            Task<string> any = await Task.WhenAny(has1000SubscriberTask, has4000ViewHoursTask);
            Console.WriteLine(any.Result);

            Console.WriteLine("\n\n\nUsing WhenAll()");
            Console.WriteLine("---------------");

            string[] all = await Task.WhenAll(has1000SubscriberTask, has4000ViewHoursTask);
            foreach (string t in all)
            {
                Console.WriteLine(t);
            }
            Console.ReadKey();
        }

        static async Task<string> Has1000Subscriber()
        {
            await Task.Delay(4000);
            return "congratulation !! you have 1000 subscribers";
        }

        static async Task<string> Has4000ViewHours()
        {
            await Task.Delay(3000);
            return "congratulation !! you have 4000 view hours";
        }
    }
}