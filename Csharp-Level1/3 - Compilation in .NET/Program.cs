using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// each language compiles from source code to machine code, but in .net lang the flow is different as follows:

/*******************************************************
 * 🔄 .NET Compilation & Execution Flow
 *******************************************************/

/*
 * 1️⃣ Source Code
 * -----------------------------------------------------
 * - You write the program in a .NET language (C#, F#, VB).
 * - It's human-readable, high-level code (.cs, .fs, .vb files).
 */

/*
 * 2️⃣ Language Compiler
 * -----------------------------------------------------
 * - Each language has its own compiler (csc, fsc, vbc).
 * - The compiler checks syntax, logic, and types.
 * - Then it translates the source code into
 *   Common Intermediate Language (CIL or IL).
 * - Output is stored in an **assembly file** (.exe or .dll).
 *   → This assembly contains both the IL code and metadata.
 *
 * ⚙️ Note:
 *   The assembly is *not yet machine code*.
 *   It’s platform-independent and will later be processed
 *   by the CLR and JIT compiler at runtime.
 */

/*
 * 3️⃣ Intermediate Language(IL) or Common Intermediate Language (CIL)
 * -----------------------------------------------------
 * - The CIL is CPU- and OS-independent.
 * - It represents low-level .NET instructions.
 * - Assemblies also contain metadata (types, methods, references).
 */

/*
 * 4️⃣ CLR – Common Language Runtime
 * -----------------------------------------------------
 * - The CLR loads the assembly when you run the program.
 * - It handles memory, exceptions, threading, and security.
 * - It passes IL code from the assembly to the JIT compiler.
 */

/*
 * 5️⃣ JIT Compiler (Just-In-Time)
 * -----------------------------------------------------
 * - Takes IL from the assembly and converts it to native machine code.
 * - Only the parts of code being executed are compiled in the run-time (on demand).
 * - Compiled code is cached in memory for reuse.
 * - Similar to *lazy loading* in web apps — only what’s needed gets processed.
 * this is the default in .Net - we can change this mode later and turn off JIT to make all code compiled at once in the beginning of app for different purposes or when start up time is critical, it is called Ahead-Of-Time compilation (AOT).
 */

/*
 * 6️⃣ Machine Code
 * -----------------------------------------------------
 * - The final 0s and 1s executed directly by the CPU.
 * - Fully managed by the CLR during program execution.
 */

/*
 * ✅ In short:
 * -----------------------------------------------------
 *   Source Code  →  Language Compiler  →  CIL →  CLR ( which performs JIT Compilation)  →  Machine Code
 */




namespace _3___Compilation_in.NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
