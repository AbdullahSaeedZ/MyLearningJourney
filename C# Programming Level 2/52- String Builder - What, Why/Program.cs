using System;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main()
    {
        // =================================================================================
        // 1. WHAT IS A BUFFER? (CONVENTIONAL ILLUSTRATION)
        // =================================================================================
        // A buffer is a reserved, pre-allocated block of memory used to hold data temporarily.
        // .NET implements this using a mutable character array (char[]).

        Console.WriteLine("--- Understanding the Buffer Concept ---");

        char[] manualBuffer = new char[10];
        manualBuffer[0] = 'A';
        manualBuffer[1] = 'l';
        manualBuffer[2] = 'i';

        // NOTE ON '\0': It represents a 'Null Terminator' (binary 0 in RAM as a placeholder). It acts as a protected 
        // placeholder slot telling the OS that this space is reserved and ready for future writes.
        for (int i = 0; i < manualBuffer.Length; i++)
        {
            char c = manualBuffer[i];
            string visual = ( c == '\0' ) ? "\\0" : c.ToString();
            Console.WriteLine($"Index [{i}]: '{visual}'");
        }

        // =================================================================================
        // 2. THE PROBLEM: IMMUTABLE STRINGS & ABANDONED OBJECTS
        // =================================================================================
        // Standard C# strings are Immutable. In a loop, traditional concatenation creates 
        // a massive trail of "Abandoned Objects" in the Heap.
        // If you have a string of 10,000 chars and append 1 char, .NET allocates a brand-new 
        // 10,001 char string, copies all old data, and leaves the old 10,000 char string 
        // dead in memory as garbage for the Garbage Collector (GC) to clean up.

        // =================================================================================
        // 3. THE SOLUTION: STRINGBUILDER
        // =================================================================================
        // To solve this architectural bottleneck, .NET provides the StringBuilder class.
        // Instead of abandoning immutable instances, it shifts the strategy from "Copy-on-Modify"
        // to an "In-Place Modification" approach. It serves as a dynamic, reusable workspace 
        // that manages memory on-demand, ensuring that performance remains constant regardless 
        // of how many modifications or appends you perform.



        // =================================================================================
        // 4. THE BEHIND-THE-SCENES MECHANISM: LINKED LIST OF BLOCKS
        // =================================================================================
        // How does StringBuilder expand on-demand without copying old data?
        // Let's break down the exact lifecycle of how memory is allocated and managed:
        //
        // STEP 1: INITIALIZATION (THE FIRST BLOCK)
        // ----------------------------------------
        // When you write 'new StringBuilder()', .NET creates a single object in the Heap.
        // Inside this object, .NET automatically prepares TWO main fields:
        // 1. A buffer: A mutable character array 'char[] m_ChunkChars' to hold your text.
        //    - Size is based on your choice (e.g., 100) or defaults to 16 if left empty.
        // 2. A pointer: A field called 'm_ChunkPrevious' designed to hold a reference to 
        //    ANOTHER StringBuilder object (acting like a pointer to a node in a Linked List).
        //
        // Crucial Point: Right now, this is the very first and only block. There is NO previous 
        // block in existence. Therefore, .NET sets 'm_ChunkPrevious = null'. 
        // It is just a placeholder variable waiting inside the object, ready to be used ONLY 
        // if we fill up the current buffer and need to link a new block later.
        //
        // STEP 2: IN-PLACE MODIFICATION (O(1) EFFICIENCY)
        // -----------------------------------------------
        // As long as your total appended characters fit within this initial capacity, 
        // StringBuilder behaves as a plain mutable array. It overwrites the pre-allocated 
        // slots directly in-place. No extra memory is requested from the OS.
        //
        // STEP 3: THE THRESHOLD BREACH (EXCEEDING THE BUFFER CAPACITY)
        // ------------------------------------------------------------
        // What happens if your initial capacity is 16, and you attempt to append the 17th character?
        // Instead of creating a brand-new giant array and copying everything over (which is slow O(N)), 
        // modern .NET switches to a smart "Linked List of Blocks" pattern:
        //
        // A) The Current Block points to the "New Block": .NET allocates a brand new 
        //    StringBuilder block object in the Heap on-demand.
        // B) Backward Linking: This new block sets its internal pointer 'm_ChunkPrevious' 
        //    to point backwards to the old filled block.
        // C) Clean Slate Buffer: The new block instantiates a fresh, empty internal 'char[]' buffer 
        //    (typically matching the size of the previous block or dynamically scaled).
        // D) Writing the Overflow: The 17th character is written directly into index [0] 
        //    of this brand new block's buffer.
        //
        // CRITICAL ARCHITECTURAL BENEFIT: 
        // The historical data sitting in the older blocks is completely untouched, never moved, 
        // and never copied during expansion. Appending remains a blazing fast O(1) operation 
        // because it only ever interacts with the newest active block's buffer. 
        // No memory fragmentation occurs, and zero objects are abandoned as garbage!




        // =================================================================================
        // 5. HOW TO USE: EFFICIENT STRINGBUILDER USAGE
        // =================================================================================
        Console.WriteLine("\n--- HOW TO USE: EFFICIENT STRINGBUILDER USAGE ---");

        // Advanced Practice: Pre-allocating an expected capacity creates one single large block,
        // preventing the overhead of creating multiple linked blocks later.
        StringBuilder sb = new StringBuilder(100);

        // Appending directly into the reserved buffer space
        sb.Append("Hello")
          .Append(" ")
          .Append("Abu Fahad");

        sb.Replace("Hello", "Welcome");

        // The only single allocation of the actual string object occurs here at the very end
        // by walking backwards through the linked blocks to calculate total size and copy characters once.
        string finalMessage = sb.ToString();
        Console.WriteLine($"Result: {finalMessage}");





        // =================================================================================
        // 5. PERFORMANCE COMPARISON (STOPWATCH BENCHMARK)
        // =================================================================================
        Console.WriteLine("\n--- Performance Benchmark (String vs StringBuilder) ---");

        int iterations = 50000;
        Stopwatch sw = new Stopwatch();


        // --- Scenario A: The Bad Way (Traditional String Concatenation & Abandoned Objects) ---
        sw.Start();
        string regularString = "";
        for (int i = 0; i < iterations; i++)
        {
            regularString += "x"; // Generates 50,000 temporary abandoned objects in memory!
        }
        sw.Stop();
        long stringTime = sw.ElapsedMilliseconds;
        Console.WriteLine($"Traditional String (+) took: {stringTime} ms");

        // Resetting the stopwatch for a clean run
        sw.Reset();



        // --- Scenario B: The Smart Way (Optimized StringBuilder Linked Blocks) ---b 
        sw.Start();
        StringBuilder optimizedBuilder = new StringBuilder();
        for (int i = 0; i < iterations; i++)
        {
            optimizedBuilder.Append("x"); // Extends via linked blocks on demand with ZERO copying overhead
        }
        string builderResult = optimizedBuilder.ToString(); // Single final string allocation
        sw.Stop();
        long builderTime = sw.ElapsedMilliseconds;
        Console.WriteLine($"StringBuilder Append took: {builderTime} ms");

        // --- Architectural Conclusion ---
        Console.WriteLine("\n--- Conclusion ---");
        Console.WriteLine($"StringBuilder was {( (double)stringTime / ( builderTime == 0 ? 1 : builderTime ) )}x times faster.");
    }
}