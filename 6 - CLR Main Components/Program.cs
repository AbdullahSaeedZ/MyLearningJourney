using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// details of those components will be explained separately in next lessons

/*******************************************************
 * ⚙️ CLR Main Components (Overview)
 *******************************************************/

/*
 * 1️⃣ Common Type System (CTS)
 * -----------------------------------------------------
 * - Defines how data types are declared and used in .NET.
 * - Ensures all .NET languages (C#, VB, F#) use the same base types
 *   — so “int” in C# = “Integer” in VB = System.Int32.
 */

/*
 * 2️⃣ Common Language Specification (CLS)
 * -----------------------------------------------------
 * - A set of rules that all .NET languages must follow
 *   to be compatible with each other.
 * - Enables **cross-language interoperability**.
 */

/*
 * 3️⃣ Garbage Collector (GC)
 * -----------------------------------------------------
 * - Automatically manages memory.
 * - Frees up unused objects and prevents memory leaks.
 */

/*
 * 4️⃣ Just-In-Time (JIT) Compiler
 * -----------------------------------------------------
 * - Converts Intermediate Language (IL) code into
 *   native machine code at runtime (on-demand).
 */

/*
 * 5️⃣ Metadata and Assemblies
 * -----------------------------------------------------
 * - Assemblies (.exe / .dll) store compiled code + metadata.
 * - Metadata contains info about classes, methods, types, etc.
 * - Used by the CLR for reflection, linking, and security.
 */

/*
 * ✅ Summary:
 * -----------------------------------------------------
 *   The CLR provides a consistent type system (CTS),
 *   enforces language compatibility (CLS),
 *   manages memory (GC),
 *   compiles on demand (JIT),
 *   and uses assemblies to organize and execute code.
 */



namespace _6___CLR_Main_Components
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
