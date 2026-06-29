/*
====================================================================================================
THREAD SYNCHRONIZATION OVERVIEW
====================================================================================================

Synchronization is the act of establishing order and a strict sequence of execution 
among concurrent operations to prevent chaotic interference when accessing shared resources.


1. THE PROBLEM & THE SOLUTION
   When multiple threads try to update the exact same shared data at the same millisecond, they 
   overwrite each other's progress. This unpredictable chaos is called a "Race Condition." 
   Thread synchronization is explicitly the solution to race conditions. It brings order by 
   coordinating when threads are allowed to access shared resources.


2. THE LOCK MECHANISM (THE RESTROOM & THE QUEUE)
   
   Let's ground this concept using a clear architectural scenario. Imagine a high-traffic 
   application where hundreds of requests are being processed simultaneously. Each request 
   is handled by a separate Thread. 

   Most of these threads are completely independent—one is fetching data from the internet, another 
   is writing a file to the disk. But they all need to access one single, shared resource in memory, 
   such as a global counter. This shared resource is our "Single-Occupancy Restroom" (the Critical Section 
   where a Race Condition might happen).

   - THE LOCK (THE DOOR HANDLE):
     To protect the shared resource, we use a synchronization lock. This lock acts exactly like 
     the handle on the restroom door. It dictates whether the resource is currently occupied or vacant.

   - THE SCOPE: LOCK VS. MUTEX
     While a standard lock handles thread synchronization inside a single running application (like an 
     internal office restroom), a Mutex (Mutual Exclusion) is an operating-system-level mechanism. It 
     acts like a master key that works across completely separate programs running on your computer 
     (like a public restroom in a city square), ensuring that if Program A is currently updating a shared 
     system file or database, Program B is forced to wait in an OS queue until Program A is entirely finished.

   - ACQUIRING THE LOCK (ENTERING & BOLTING THE DOOR):
     Thread A arrives at the shared resource first. It sees the lock is free, claims it, and steps 
     inside the critical section. While inside, it reads and updates the shared memory. Thread A now 
     has exclusive ownership. No other thread can touch this data while it is inside.

   - THE MANAGED QUEUE (THE LINE IN THE HALLWAY):
     While Thread A is halfway through updating the data, Thread B arrives. It tries to access the 
     resource but finds it locked. Instead of wasting processing power by constantly checking the 
     door handle, the operating system puts Thread B into a temporary wait state and places it into 
     a managed queue (a disciplined line in the hallway). A millisecond later, Thread C arrives and 
     is queued right behind Thread B.

   - THE RELEASE AND WAKEUP:
     The moment Thread A finishes updating the resource and steps out of the critical section, it 
     automatically releases the lock. The operating system instantly steps in, wakes up Thread B 
     from the front of the queue, and hands it the lock. Thread C remains asleep, waiting its turn.


3. WHY IS IT STILL MULTITHREADING? (THE REST OF THE APPLICATION KEEPS RUNNING)

   A common beginner misconception is that putting Thread B and Thread C into a sequential queue 
   turns your entire application into a slow, single-threaded program. This is fundamentally false.

   - LOCALIZED BOTTLENECKS:
     The queue *only* exists for that exact critical section touching the shared resource. While Thread B 
     and Thread C are paused in that specific queue, what are the other threads doing? 
     - Thread D is actively pulling data from a remote web API over the internet.
     - Thread E is busy calculating complex business logic.
     - Thread F is reading an image file from the hard drive.
     All of this massive concurrency is still happening at 100% speed completely in parallel. 

   - IMMEDIATE CONCURRENCY RESUMPTION:
     Look at what happens the split-second Thread B gets its turn, finishes its quick update, and leaves 
     the lock. It doesn't stay trapped or slowed down. It instantly jumps right back into full 
     multithreaded execution—running at maximum speed alongside all the other active threads in the system.

   - THE PRAGMATIC TRADE-OFF:
     You are not destroying multithreading; you are managing it. You allow your threads to fly at maximum 
     speed through 99% of your application's architecture, and you only force them to form a disciplined, 
     one-at-a-time line at the exact 1% checkpoint where they cross paths and must modify the exact same 
     memory address. It is a highly localized speed bump that guarantees absolute data integrity without 
     sacrificing system-wide performance.


4. EXAMPLES OF OTHER SYNCHRONIZATION MECHANISMS
   Locks and Mutexes are strictly "one-at-a-time," but other scenarios require different blueprints:

   - SEMAPHORE MECHANISM: 
     Acts like a nightclub with a capacity limit. Instead of letting only 1 thread in, you can 
     set it to allow a specific maximum (e.g., limiting a browser to exactly 4 concurrent downloads). 
     The 5th thread is queued until one of the active 4 finishes.

   - READER-WRITER LOCKS MECHANISM: 
     Allows an unlimited number of threads to read data simultaneously (since reading doesn't corrupt 
     anything), but completely blocks everyone if a thread needs to write or update the data.

====================================================================================================
*/