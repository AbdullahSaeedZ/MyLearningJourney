using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
 * ⚙️ Just-In-Time (JIT) Compiler
 *******************************************************/

/*
 * 1️⃣ Definition
 * -----------------------------------------------------
 * - JIT stands for **Just-In-Time** compiler.
 * - It’s part of the CLR and is responsible for converting
 *   Intermediate Language (CIL / IL) into **native machine code**
 *   right before execution.
 *
 * - In other words, .NET code isn’t compiled fully ahead of time.
 *   Instead, each part is compiled only when it’s needed at runtime.
 */

/*
 * 2️⃣ Why It Exists
 * -----------------------------------------------------
 * - It makes execution faster and smarter:
 *     • Only the code that runs gets compiled.
 *     • Unused methods aren’t processed at all.
 * - Compiled machine code is **cached** in memory for reuse
 *   — so subsequent calls to the same method don’t need recompilation.
 */

/*
 * 3️⃣ Analogy
 * -----------------------------------------------------
 * - Think of JIT like **lazy loading** in web development:
 *   only load what’s needed, when it’s needed.
 * - This keeps startup time fast and saves resources.
 */

/*
 * 4️⃣ Types of JIT
 * -----------------------------------------------------
 *  1. **Pre-JIT (AOT - Ahead of Time)**
 *     - Compiles the entire application *before* execution, and all compiled code is saved in cache memory.
 *     - Example: using Ngen.exe.
 *     - No runtime compilation, but slower startup and larger size.
 *
 *  2. **Econo-JIT**
 *     - Compiles methods on demand but does **not** cache them.
 *     - Saves memory (economic), but methods are recompiled every call cuz they are not cached in memory.
 *
 *  3. **Normal JIT (Default)**
 *     - Compiles only the code that’s used.
 *     - The compiled native code is **cached** for later reuse.
 *     
 *     - which is faster ? it depends on your case and needs, no one right answer.
 */

/*
 * 5️⃣ Relationship to the CLR
 * -----------------------------------------------------
 * - The CLR invokes the JIT when a method is first called.
 * - The JIT converts IL → Machine Code → CPU executes.
 * - This process happens transparently during runtime.
 */

/*
 * ✅ In short:
 * -----------------------------------------------------
 *   The JIT compiler makes .NET apps efficient:
 *   - Converts IL to native machine code *on demand*.
 *   - Caches results to boost performance.
 *   - Acts as the bridge between portability (CIL)
 *     and performance (native execution).
 */



namespace _10___CLR_Component___Just_In_Time_Compilation__JIT_
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
