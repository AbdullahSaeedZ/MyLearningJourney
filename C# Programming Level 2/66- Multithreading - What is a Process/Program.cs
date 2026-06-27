/*
 
 ============================================================================
                            WHAT IS A CPU CORE
 ============================================================================

 THE HISTORICAL CONTEXT (THE PROBLEM/LIMITATION):
 ----------------------------------------------------------------------------
 Many years ago, a Central Processing Unit (CPU) was a single square chip 
 that contained only one execution engine. This single engine was the Core.
 
 * WHAT IS A CORE?
 ----------------------------------------------------------------------------
 The core is the actual "brain" and the independent computational unit inside the CPU. 
 It is the specific component responsible for receiving software instructions 
 (e.g., add, subtract, move this variable in memory) and executing them.
 
 * THE GOLDEN RULE OF HARDWARE:
 ----------------------------------------------------------------------------
 A single core cannot physically or scientifically execute more than ONE 
 instruction at the exact same slice of time (Clock Cycle).
 
 * THE CONSEQUENCE:
 ----------------------------------------------------------------------------
 Therefore, old legacy processors had only a single core. This meant the CPU 
 had exactly "one brain" that could focus on only one single task at any given instant.
 


 ============================================================================
                            WHAT IS A PROCESS
 ============================================================================


 1. THE PROBLEM (WHY IT EXISTS)
 ----------------------------------------------------------------------------
 In early computing, if a computer was printing a file, the CPU remained fully 
 occupied waiting on the printer. You could not open a calculator or type text 
 until the print job finished. 

 This was a massive waste of clock cycles. Because the CPU operates at extreme 
 speeds while Input/Output (I/O) devices (like printers or hard drives) are 
 incredibly slow, the CPU spent most of its lifetime simply idling and waiting.


 2. THE CORE IDEA (THE PROCESS & MULTI-TASKING)
 ----------------------------------------------------------------------------
 To solve this idle waste, computer scientists invented the concept of a 
 "Process" and "Multi-tasking". A Process is an isolated container where the 
 Operating System (OS) runs a program. 

 Each Process receives:
 1. Isolated Memory (Virtual Memory): A dedicated memory space hidden from other processes.
 2. Security & Isolation: A boundary ensuring that if one process crashes, others survive.


 3. HOW IT WORKS INTERNALLY (ON A SINGLE-CORE CPU)
 ----------------------------------------------------------------------------
 Since a single core cannot physically execute more than one instruction per 
 clock cycle, OS designers implemented CPU Scheduling and Context Switching.

 The Mechanism:
 - The OS grants Process A a tiny time slice (e.g., 10 milliseconds) on the CPU.
 - Once time expires, the OS pauses Process A, saves its current state (registers, counter).
 - The OS then loads Process B's saved state and executes it for the next 10 milliseconds.

 Because this switching happens thousands of times per second, it creates a 
 seamless illusion of simultaneous execution (concurrency) to the human user.

 now we are able to run multiple programs (processes) within a single core.



 ============================================================================
                       THE PROCESS LIMITATION PROBLEM
 ============================================================================

 
 1. THE NEW PROBLEM (THE PROCESS LIMITATION)
 ----------------------------------------------------------------------------
 While the Process solved the issue of running multiple programs at once, 
 a major limitation emerged inside individual applications themselves.

 Imagine opening a Web Browser (which runs as a single Process). 
 Inside this browser, you want to perform three actions simultaneously:
 1. Wait for user mouse clicks and maintain a responsive UI.
 2. Download a high-resolution background image from the internet.
 3. Play an audio or video stream seamlessly.


 2. WHY USING MULTIPLE PROCESSES HERE IS A BAD IDEA
 ----------------------------------------------------------------------------
 If we relied strictly on the old process-per-task model to solve this, 
 the browser would have to spawn 3 independent, heavy Processes. 
 This approach is highly inefficient for two primary reasons:

 A. High Memory Overhead:
    Every new Process forces the Operating System to allocate a completely 
    new, fully isolated virtual memory environment, wasting RAM.

 B. Slow and Complex Communication:
    Because processes are strictly isolated, they cannot naturally see each 
    other's data. If the download process wants to pass an image to the UI 
    process to render it, it must use slow, complex OS mechanisms known as 
    IPC (Inter-Process Communication) which allow processes to communicate.

*/