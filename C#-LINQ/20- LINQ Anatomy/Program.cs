using System;
using System.Collections.Generic;
using System.Linq;

namespace Anatomy
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // DemoFluentAPI();
            // DemoIEnumerableIQueryable();
            // DemoExecutionOrder();
            // DemoImmediateExecution();
            // DemoDeferredExecution();
            // DemoDeferredStreamedExecution();
            // DemoDeferredNonStreamedExecution();
            // DemoTake();
            // DemoFilterOrder();
            // RunQuery();

        } 
        private static void DemoFluentAPI()
        {
            // ### Fluent API ###
            //  Method Chaining and Extension method to make statement look like a sentence.
            //  is code that reads as a sentence.
            //  instead of deeply nested function calls (e.g., Take(Skip(OrderBy(...)))),
            //  each extension method chains off the previous one from left to right,
            //  forming a fluent, readable pipeline of operations.
                 
            var deck = new Deck();
            var cards = deck.Shuffle();

            var query = cards
                .OrderBy(x => x.Value).Skip(10).Take(10)
                .OrderBy(x => x.Suite).ToList();

            foreach (var item in query)
                Console.WriteLine(item.Name);
        }
        private static void DemoIEnumerableIQueryable()
        {
          var deck = new Deck();

            // LINQ to Objects, 
            // which mostly just does literally what it is told;
            // if you sort then page, then it sorts then pages;
            // if you page then sort, then it pages then sorts

            IEnumerable<Card> queryIEnumerable = deck.Shuffle()
                .Where(x => x.Value > 5).Skip(5).OrderBy(x => x.Value)
                .ThenByDescending(x => x.Suite).Take(5).AsEnumerable();

            // i.e LINQ to SQL
            // Query is being composed (Expression Tree)
            // When Execute Provider inspect your query tree
            // build the most suitable implementation possible

            IQueryable<Card> queryIQueryable = deck.Shuffle()
                .Where(x=> x.Value > 5).Skip(5).OrderBy(x => x.Value)
                .ThenByDescending(x=>x.Suite).Take(5).AsQueryable();

         
        }
        private static void DemoExecutionOrder()
        {
            // Left to right(All Expression in C# are executed Left to Right)
            // Understanding the semantics of query execution, can lead to some meaningful optimizations
            // Where is not required to find all matching items before fetching the first matching item. 
            // Where fetches matching items "on demand"
            // IEnumerable / foreach / yield Element are not returned at once / one at a time
            
            // HOW "ON DEMAND" WORKS HERE:
            // 1. Element-by-Element (Yielding vs. Dropping):
            //    - When condition is MET (e.g., 8 > 5): The first .Where() does not wait to find all matches;
            //      it immediately yields that single item to the next method (.Select) which passes it to the next one.
            //    - When condition FAILS (e.g., 2 > 5): The item is dropped immediately, and downstream methods
            //      are skipped for that number.
            //
            // 2. The Demand Cap (.Take):
            //    - .Take(2) defines how many items are demanded. 
            //    - As soon as 2 items survive the full pipeline (36 and 144), .Take(2) stops the process.
            //    - The rest of the array (number 9) is completely ignored and never evaluated by .Where().
            
            // run the method to see the visualization
            var numbers = new int[] { 8, 2, 3, 4, 1, 6, 5, 12, 9 };

            IEnumerable<int> query = numbers
                .Where(x =>
                {
                    Console.WriteLine($"Where({x} > 5) => {x > 5}");
                    return x > 5;
                })
                .Select(x =>
                {
                    Console.WriteLine($"\tSelect({x} X {x}) => {x * x}");
                    return x * x;
                })
                .Where(x =>
                {
                    var result = x % 6 == 0;
                    Console.WriteLine($"\t\tWhere({x} % 6) == 0 => {result}");
                    if (result)
                        Console.WriteLine($"\t\t\t\tTake: {x}");


                    return x % 6 == 0;
                })
                .Take(2);

            List<int> list = query.ToList();

            foreach (var item in list)
                Console.Write($" {item}");
        }
        
        // see the execution types pic
        private static void DemoImmediateExecution()
        {
            // IMMEDIATE EXECUTION:
            // The data source is read and the operation is performed immediately 
            // at the point in code where the query is declared (triggered by .ToList()).
            //
            // WHY THIS MATTERS:
            // 1. "Not up to date" (Snapshot in Time):
            //    - If you add or modify numbers in the source array later, 'materialized list' will NOT reflect those changes.
            //    - It stores a static, frozen copy of the results evaluated at line declaration.
            //
            // 2. "Not expensive to call" (Fast Re-reads):
            //    - Iterating 'list' multiple times (e.g., calling foreach or accessing indices) costs O(1) per step.
            //    - The LINQ pipeline does NOT run again if you call the materialized list, because the results are already cached in RAM.
            //
            // 3. "Lists are big" (Memory Footprint):
            //    - Allocates actual storage on the heap for the concrete List<T> object.
            //    - A deferred query blueprint takes almost zero memory; a materialized list holds real memory buffers.
            
            var numbers = new int[] { 8, 2, 3, 4, 1, 6, 5, 7, 9 };
            
            // Materializes immediately: .Where() and .Take(2) run right here, allocating the List<int>
            // 8 passes Where() and yields to Take() (count 1); Where() skips 2,3,4,1 until 6 passes,
            // Take() accepts it (count 2), and the pipeline stops immediately (5,7,9 are never checked).
            List<int> list = numbers
                .Where(x => x > 5)                      
                .Take(2) .ToList();

            foreach (var n in list)
                Console.WriteLine(n);
        }
        private static void DemoDeferredExecution()
        {
            // DEFERRED EXECUTION:
            // Not executed when constructed; only when enumerated (inside foreach).
            // The query variable only holds a tiny data structure (blueprint) describing the steps.
            //
            // WHY THIS MATTERS:
            // 1. "Queries are always up-to-date":
            //    - If the source array changes before the foreach runs, the query evaluates against the newest data.
            // 2. "Queries are more expensive than a list to retrieve results":
            //    - Re-enumerating 'query' in another foreach re-executes the entire pipeline from scratch.
            // 3. "Queries are tiny":
            //    - Consumes virtually zero memory; it stores execution logic, not data.

            int[] numbers = new int[] { 8, 2, 3, 4, 1, 6, 5, 7, 9 };

            // Declaration: Zero processing happens here; sets up the pipeline.
            IEnumerable<int> query = numbers
                .Where((int x) => x > 5)
                .Select((int x) => x * x)
                .Take(2); 

            // Execution starts only right here:
            // 8 passes Where() -> Select() squares it (64) -> Take() accepts (count 1);
            // 2,3,4,1 skipped; 6 passes Where() -> Select() squares it (36) -> Take() accepts (count 2) and halts (7, 9 ignored).
            foreach (int n in query)
                Console.WriteLine(n);
        }
        
        // Two Types of Deferred Execution:
        private static void DemoDeferredStreamedExecution()
        {
            // DEFERRED EXECUTION (STREAMING):
            // At the time of execution, operators (LINQ Methods) do NOT read all source data before producing results.
            // They process items via STREAMING: elements are fetched and YIELDED one-by-one on demand.
            // Where() is not required to find all matching items before fetching the first match.
            //
            // WHY THIS MATTERS:
            // 1. STREAMING Means Zero Buffering (O(1) Memory):
            //    - Elements are not buffered (accumulated like the other deferred type) in RAM; each item is YIELDED immediately downstream.
            // 2. YIELDING Enables Short-Circuiting:
            //    - Take(2) accepts individual YIELDED elements and halts the entire pipeline once satisfied,
            //      leaving unprocessed source elements untouched.

            int[] numbers = new int[] { 8, 2, 3, 4, 1, 6, 5, 7, 9 };

            // 8 passes Where() and STREAMS to Select() which squares it (64) -> fails second Where(); 2,3,4,1 fail first Where();
            // 6 passes Where() and STREAMS to Select() which squares it (36) -> passes second Where() -> Take(2) accepts (count 1);
            // 5 fails first Where(); 7 passes Where() and STREAMS to Select() which squares it (49) -> fails second Where();
            // 9 passes Where() and STREAMS to Select() which squares it (81) -> fails second Where().

            IEnumerable<int> query = numbers
                .Where((int x) =>
                {
                    Console.WriteLine($"Where({x} > 5) => {x > 5}");
                    return x > 5;
                })
                .Select((int x) =>
                {
                    Console.WriteLine($"\tSelect({x} X {x}) => {x * x}");
                    return x * x;
                })
                .Where((int x) =>
                {
                    bool result = x % 6 == 0;
                    Console.WriteLine($"\t\tWhere({x} % 6 == 0) => {result}");
                    if (result)
                        Console.WriteLine($"\t\t\t\tTake: {x}");

                    return result;
                })
                .Take(2); 
            List<int> list = query.ToList();
        }
        private static void DemoDeferredNonStreamedExecution()
        {
            // DEFERRED EXECUTION (NON-STREAMING / BUFFERING):
            // Operations like sorting and grouping must read and BUFFER all source data before they can YIELD even the first element.
            //
            // WHY THIS MATTERS:
            // 1. BUFFERING Interrupts STREAMING (O(N) Memory):
            //    - Unlike streamed operators, OrderBy() cannot YIELD items one-by-one immediately.
            //    - It must accumulate (buffer) all matching elements in RAM to determine which one is truly first.
            // 2. Short-Circuiting Is Delayed:
            //    - Even though Take(2) only demands 2 items, OrderBy() forces the pipeline to evaluate every single element in the source array first.

            int[] numbers = new int[] { 8, 2, 3, 4, 1, 6, 5, 12, 9 };

            // Where() evaluates the entire array (8 to 9); OrderBy() sorts the buffered matches into [6, 8, 9, 12];
            // THEN AFTER SORTING, 6 is yielded and STREAMS to Select() (36) -> Take(2) accepts (count 1);
            // 8 is yielded and STREAMS to Select() (64) -> Take(2) accepts (count 2) and halts (9 and 12 never reach Select).
            
            // so OrderBy() (sorting and grouping methods) is the non-streaming, it is like a keeper that accumulate all items passed to it then it does it job

            List<int> query = numbers
                .Where((int x) =>
                {
                    Console.WriteLine($"Where({x} > 5) => {x > 5}");
                    return x > 5;
                })
                .OrderBy((int x) => x) // Buffers ALL matching elements (8, 6, 12, 9) into memory before sorting and yielding
                .Select((int x) =>
                {
                    int result = x * x;
                    Console.WriteLine($"\tSelect({x} X {x}) => {result}");
                    Console.WriteLine($"\t\t\t\tTake: {result}");
                    return result;
                })
                .Take(2) 
                .ToList();

            List<int> list = query.ToList();
        }
        
        
        private static void DemoTake()
        {
            // The Take clause merely appends a Take operation to the query pipeline;
            // it does not execute the query immediately.
            //
            // Positioning is critical:
            // x.Take(y).Where(z) and x.Where(z).Take(y) produce completely different queries.
            // Changing where Take is placed fundamentally changes the meaning and outcome of the query.
            //
            // RULE OF THUMB:
            // Place Take as early as possible to minimize upstream processing,
            // but never so early that it alters the intended business logic.

            var deck = new Deck();

            IEnumerable<Card> cards = deck.GetSample();

            IEnumerable<Card> query = cards     //  Source: {  Jack Clubs, 9 Diamonds, 4 Hearts, 10 Spades, 3 Hearts, 6 Hearts }
                .Where((Card x) => x.IsRed)      // Step 1: {              9 Diamonds, 4 Hearts,            3 Hearts, 6 Hearts }  (Filtered red cards)
                .Skip(3)                         // Step 2: {                                                         6 Hearts }  (Remaining cards after skipping 3)
                .Take(3);                        // Step 3: {                                                         6 Hearts }  (Demands up to 3, takes what's available)

            List<Card> list = query.ToList(); // { 6 Hearts }

            list.PrintDeck("Take more than available");

        }
        private static void DemoFilterOrder()
        {
            // Filter / Order vs. Order / Filter:
            // Demonstrates how swapping the order of operations changes the business logic
            // and affects buffering performance.

            Deck deck = new Deck();

            IEnumerable<Card> cards = deck.Shuffle();

            // Query 1: Filter -> Order -> Take ("Top 10 among all red cards")
            // =========================================================================
            // 1. Where() filters the deck first, yielding only red cards.
            // 2. OrderBy() buffers and sorts only that smaller subset of red cards.
            // 3. Take(10) grabs the lowest 10 sorted red cards. (Guaranteed 10 red cards if available).
            IEnumerable<Card> query1 = cards      
                .Where((Card x) => x.IsRed)       // Step 1: Filters out all black cards first
                .OrderBy((Card x) => x.Value)     // Step 2: Buffers and sorts only the red cards
                .Take(10);                        // Step 3: Takes the first 10 sorted red cards
            
            query1.PrintDeck("top 10 red cards");

            // Query 2: Order -> Take -> Filter ("Red cards that happen to be in the deck's top 10")
            // =========================================================================
            // 1. OrderBy() buffers and sorts the entire 52-card deck (wasteful if we only care about red).
            // 2. Take(10) slices the top 10 lowest cards of the whole deck (mix of black and red).
            // 3. Where() filters that 10-card slice; you only get whichever cards in that slice happen to be red (could be 3, 5, or 0 cards).
            IEnumerable<Card> query2 = cards
                .OrderBy((Card x) => x.Value)     // Step 1: Buffers and sorts ALL 52 cards (red and black)
                .Take(10)                         // Step 2: Takes the top 10 lowest cards overall
                .Where((Card x) => x.IsRed);      // Step 3: Discards any black cards inside that top 10 slice

            query2.PrintDeck("Red Cards in the top 10");
        }
        
        // see the pic to visualize it
        private static void RunQuery()
        {
            // PIPELINE INTERACTION (WHERE -> SKIP -> ORDERBY -> TAKE -> TOLIST):
            // Combines streamed filtering/skipping with non-streamed buffering and truncation.
            //
            // WHY THIS MATTERS:
            // 1. Where() & Skip(1) Stream:
            //    - Only red cards pass through; the first red card found (9 Diamonds) is dropped on the fly.
            // 2. OrderBy() Interrupts Streaming (Buffers):
            //    - OrderBy() cannot know which card is smallest until it pulls and inspects all remaining red cards.
            //    - It buffers { 4 Hearts, 3 Hearts, 6 Hearts } in RAM and sorts them into { 3 Hearts, 4 Hearts, 6 Hearts }.
            // 3. Take(2) & ToList() Materialize:
            //    - Take(2) yields the top 2 from the sorted buffer directly into the concrete List<Card>.

            Deck deck = new Deck();

            IEnumerable<Card> cards = deck.GetSample();

            List<Card> query = cards                  // Source:          { Jack Clubs, 9 Diamonds, 4 Hearts, 10 Spades, 3 Hearts, 6 Hearts }
                .Where((Card x) => x.IsRed)           // Step 1 (Filter): {             9 Diamonds, 4 Hearts,            3 Hearts, 6 Hearts } (Streams red cards)
                .Skip(1)                              // Step 2 (Skip 1): {                         4 Hearts,            3 Hearts, 6 Hearts } (Drops 9 Diamonds)
                .OrderBy((Card x) => x.Value)         // Step 3 (Sort):   {                         3 Hearts,            4 Hearts, 6 Hearts } (Buffers & sorts in RAM)
                .Take(2)                              // Step 4 (Take 2): {                         3 Hearts, 4 Hearts                      } (Halts after 2 items)
                .ToList();                            // Result:          { 3 Hearts, 4 Hearts }

            query.PrintDeck("Order Buffer Sequence, when it's enumerated");
        }
    }
}