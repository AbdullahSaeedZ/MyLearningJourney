/*
====================================================================================================
                       TOPIC: RACE CONDITIONS & SYNCHRONIZATION BOUNDARIES
====================================================================================================

1. THE MULTITHREADING TERMINOLOGY MYTH
----------------------------------------------------------------------------------------------------
A common misconception is that Concurrency, Parallelism are identical terms. 
They are distinct engineering concepts that overlap in multithreaded systems:

* CONCURRENCY: Managing multiple tasks by interleaving their execution. The OS context-switches 
  rapidly between threads on a single or multiple CPU cores. It is about program STRUCTURE.
* PARALLELISM: Executing multiple tasks at the exact same physical millisecond across separate 
  physical CPU cores. It is about SIMULTANEOUS EXECUTION.

A race condition can occur in both concurrent (single-core time-slicing) and parallel (multi-core simultaneous execution) environments.

CRITICAL FACT: While they work differently, ALL those environments can cause a Race Condition 
if multiple execution paths attempt to modify the same shared resource at the same time.



2. WHAT IS A RACE CONDITION?
----------------------------------------------------------------------------------------------------
A Race Condition occurs when the correctness of a program depends entirely on the unpredictable 
timing or interleaving of operations from multiple threads. 

When multiple threads "race" to modify shared data simultaneously across multiple CPU cores, they 
overwrite each other's changes at the hardware level. This causes silent data corruption rather 
than a crash, making these bugs incredibly difficult to track down.

Step-by-Step Parallel Example (The $100 Bank Account Withdrawal):
Imagine two threads running on separate CPU cores try to withdraw $80 at the exact same physical millisecond:

  1. Core 1 (Thread A) and Core 2 (Thread B) simultaneously read the balance from RAM. Both see $100.
  2. Both cores independently evaluate the condition: "Is $100 >= $80?" Both approve it as valid.
  3. Core 1 finishes its subtraction first ($100 - $80) and writes $20 to the shared RAM address.
  4. Core 2 does NOT re-check the balance because its validation step already passed. Its internal 
     register is already holding its own calculated result ($100 - $80 = $20).
  5. A fraction of a nanosecond later, Core 2 forces its value ($20) into the exact same RAM address, 
     blindly overwriting Core 1's update.

The Disaster:
The application does NOT crash. Both withdrawals successfully complete and $160 total is dispensed, 
but the final remaining balance in RAM is saved as $20. Without synchronization (sequentioal ecexution), the application 
silently loses track of $80.



3. MUTABLE VS. IMMUTABLE TYPES: THE REAL CULPRIT
----------------------------------------------------------------------------------------------------
Race conditions cannot exist without a specific target. Data types are classified into two groups:

A. MUTABLE TYPES (The Danger Zone):
   - Objects whose internal state or property values CAN be altered after instantiation.
   - Examples: Primitive fields (int, bool), custom classes, Lists, and Arrays.
   - Mechanism: If Thread A reads a mutable variable while Thread B is halfway through overwriting 
     it, Thread A reads corrupted or partial state.

B. IMMUTABLE TYPES (The Safe Zone):
   - Objects whose internal state CANNOT be changed once created.
   - Examples: C# strings, records, or readonly structures.
   - Mechanism: When you "modify" an immutable type (like appending a string), C# allocates an 
     entirely new object at a different memory address instead of altering the original. 
   - Because the original data never changes, infinite threads can safely read it concurrently without 
     locks. 
   
     IMMUTABILITY ELIMINATES RACE CONDITIONS BY DESIGN.


4. THE REMEDY: SYNCHRONIZATION
----------------------------------------------------------------------------------------------------
The solution to this phenomenon is Synchronization mechanisms, which will be explained in next lessons.
*/