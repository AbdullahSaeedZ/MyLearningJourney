using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*******************************************************
 * ⚙️ Common Language Runtime (CLR)
 *******************************************************/

/*
 * 1️⃣ Definition
 * -----------------------------------------------------
 * - CLR stands for **Common Language Runtime**.
 * - It’s the core execution engine of the .NET platform.
 * - The CLR is responsible for **executing .NET applications**.
 */

/*
 * 2️⃣ Role in .NET
 * -----------------------------------------------------
 * common intermediate language (CIL) = Microsoft Intermediate Language (MSIL) = Intermediate Language (IL)
 * after languages code are compiled into CIL , the CLR takes over.
 * - The CLR provides the **runtime environment** where
 *   all .NET code runs.
 * - It offers key services including:
 *     • Memory management (Garbage Collection)
 *     • Type safety and security enforcement
 *     • Exception handling
 *     • Thread and process management
 */

/*
 * 3️⃣ Execution Responsibilities
 * -----------------------------------------------------
 * - Manages the entire lifecycle of a .NET program.
 * - Handles:
 *     • Just-In-Time (JIT) compilation (IL → Machine Code)
 *     • Thread scheduling and execution
 *     • Automatic memory cleanup
 * - Ensures the application runs efficiently and safely.
 */

/*
 * 4️⃣ Bridge Between Code and OS
 * -----------------------------------------------------
 * - The CLR acts as a **bridge** between:
 *     • The .NET code (your assemblies)
 *       and
 *     • The underlying Operating System.
 * - This abstraction allows .NET applications to run
 *   on any supported OS (Windows, Linux, macOS)
 *   without worrying about hardware or system details.
 */

/*
 * 5️⃣ Key Advantage
 * -----------------------------------------------------
 * - Developers can write code in **any .NET-supported language**
 *   (C#, F#, VB, etc.) and have it run anywhere .NET is supported.
 * - The CLR takes care of all the low-level details
 *   like compilation, memory, threads, and exceptions.
 */

/*
 * ✅ In short:
 * -----------------------------------------------------
 *   The CLR = the “brain” of .NET.
 *   It runs your code, manages resources,
 *   and makes .NET apps portable and safe across platforms.
 */


namespace _5___What_is_CLR
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
