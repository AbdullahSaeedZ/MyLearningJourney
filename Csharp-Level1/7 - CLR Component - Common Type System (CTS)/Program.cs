using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CTS(Common Type System) rules applied to CIL so that code be ready to use by CLR
/*******************************************************
 * 🧠 How CTS Fits into the .NET Compilation Process
 *******************************************************/

/*
 * 1️⃣ SOURCE CODE (Developer Level)
 * -----------------------------------------------------
 *  - You write code in a .NET language (C#, VB.NET, F#, etc.)
 *  - Each language has its own syntax and data types.
 *
 *    Example:
 *      C#     → int Age = 25;
 *      VB.NET → Dim Age As Integer = 25
 */

/*
 * 2️⃣ COMPILATION STAGE (Compiler Level)
 * -----------------------------------------------------
 *  - Each language compiler translates source code into
 *    Common Intermediate Language (CIL).
 *
 *  - During this stage:
 *      🔸 CTS (Common Type System) rules are applied.
 *      🔸 Language-specific types are converted to
 *        their common CTS equivalents.
 *
 *    Example:
 *      C# int     → System.Int32
 *      VB Integer → System.Int32
 *
 *  - Result: All compiled code now follows the same
 *    type structure — **language-independent**.
 *
 *  - Output: CIL stored in an assembly (.exe or .dll)
 */

/*
 * 3️⃣ RUNTIME STAGE (CLR Level)
 * -----------------------------------------------------
 *  - The CLR (Common Language Runtime) takes over execution.
 *  - It reads the assembly and performs:
 *      🔹 Just-In-Time (JIT) compilation → native machine code
 *      🔹 Garbage Collection
 *      🔹 Memory & Thread Management
 *      🔹 Security and Type Safety Enforcement
 *
 *  - Here, CTS acts as a **rulebook** owned by CLR —
 *    ensuring that all data types behave consistently
 *    across all .NET languages.
 *
 *  - Note: The CLR doesn’t convert types anymore;
 *    it simply executes them according to CTS rules.
 */

/*
 * 🧩 Summary:
 * -----------------------------------------------------
 *  ✔ CTS defines the universal type system (rules)
 *  ✔ Compiler applies those rules → creates CIL
 *  ✔ CLR enforces and runs them → executes safely
 *
 *  So, CTS is a **design contract defined by CLR**
 *  but **applied at compile time** by the compiler.
 */

/*
 * 🔁 Flow Recap:
 *
 *  ┌────────────────────────────────────────────┐
 *  │  Source Code (C#, VB, F#...)               │
 *  └────────────────────────────────────────────┘
 *                       │
 *                       ▼
 *       ┌────────────────────────────────────┐
 *       │  Language Compiler                 │
 *       │  → Applies CTS rules               │
 *       │  → Converts to CIL (IL Code)       │
 *       └────────────────────────────────────┘
 *                       │
 *                       ▼
 *       ┌────────────────────────────────────┐
 *       │  CLR Runtime (Execution Engine)    │
 *       │  → Enforces CTS behavior           │
 *       │  → Uses JIT to make Machine Code   │
 *       │  → Manages Memory & Threads        │
 *       └────────────────────────────────────┘
 *                       │
 *                       ▼
 *       ⚙️ Machine Code (runs on OS & CPU)
 *
 *******************************************************/


namespace _7___CLR_Component___Common_Type_System__CTS_
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
