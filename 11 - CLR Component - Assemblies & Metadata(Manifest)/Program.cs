using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*******************************************************
 * 📦 Assemblies & Metadata (Manifest)
 *******************************************************/

/*
 * 1️⃣ What is an Assembly?
 * -----------------------------------------------------
 * - The **final compiled output** of a .NET project.
 * - A container for:
 *     • CIL (Intermediate Language)
 *     • Metadata (info about classes, methods, types)
 *     • Manifest (name, version, dependencies)
 *     • Optional resources (.config, images, etc.)
 * - Comes as:
 *     • .exe → executable program
 *     • .dll (dynamic link library)→ class library to be used inside different programs
 */

/*
 * 2️⃣ When It’s Created ?
 * -----------------------------------------------------
 * 🧩 Stage 1 – Language Compiler (Build Time)
 *   - Source code (C#, VB, F#) → compiled into CIL + Metadata + Manifest.
 *   - All packed into one file → **Assembly (.exe / .dll)**.
 *   - So the assembly is created **by the compiler**, not CLR.
 *
 * 🧩 Stage 2 – CLR / JIT (Runtime)
 *   - CLR loads the assembly and reads the IL.
 *   - JIT compiler converts IL → native machine code in memory.
 *   - JIT only *uses* the assembly, it doesn’t recreate it.
 */

/*
 * 3️⃣ Role of Metadata & Manifest
 * -----------------------------------------------------
 * - **Metadata:** describes everything in the assembly
 *   (classes, methods, parameters, references).
 * - **Manifest:** defines the assembly’s identity and dependencies.
 * - The CLR reads both to verify, load, and run the program safely.
 * - they are basically information like author , methods and libraries used and so on
 */

/*
 * ✅ Summary
 * -----------------------------------------------------
 *   Compiler → builds assembly (.exe/.dll)
 *   CLR/JIT  → loads, convert to machine code & executes it at runtime
 *
 *   Assembly = IL + Metadata + Manifest
 *   → the bridge between source code and execution.
 */



namespace _11___CLR_Component___Assemblies___Metadata_Manifest_
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
