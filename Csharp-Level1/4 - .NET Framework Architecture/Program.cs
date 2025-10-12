using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************
 * 🏗️ Architecture of the .NET Framework
 *******************************************************/

/*
 * The .NET Framework is built on two major components:
 * -----------------------------------------------------
 *   1. Common Language Runtime (CLR)
 *   2. .NET Framework Class Library (FCL or BCL)
 *
 * There’s also a third layer — the programming languages
 * (like C#, F#, VB) — which sit above the CLR and use it.
 */

/*
 * 1️⃣ Common Language Runtime (CLR)
 * -----------------------------------------------------
 * - The CLR is the core execution engine of .NET.
 * - It runs your compiled code (CIL) and provides:
 *     • Memory management (Garbage Collection)
 *     • Thread and process management
 *     • Exception handling
 *     • Type-safety and security checks
 * - In short: it’s the brain that executes and manages
 *   everything at runtime.
 */

/*
 * 2️⃣ .NET Framework Class Library (FCL / BCL)
 * -----------------------------------------------------
 * - A large collection of pre-built classes, types, and APIs
 *   for everyday functionality.
 * - Includes support for:
 *     • Strings, Dates, Numbers
 *     • File I/O (read/write files)
 *     • Networking and Databases
 *     • Graphics, Drawing, Collections, and more
 * - Basically, it’s the toolbox developers use
 *   to build applications on top of the CLR.
 */

/*
 * 3️⃣ Languages Layer
 * -----------------------------------------------------
 * - Languages like C#, VB.NET, and F# compile your code
 *   into Common Intermediate Language (CIL).
 * - All of them share the same runtime (CLR)
 *   and can use the same class libraries.
 *
 * ✅ This makes .NET a multi-language, unified platform.
 */




/*******************************************************
 * 🏗️ structure of the .NET Framework
 *******************************************************/

/*
 * The .NET Framework consists of three main layers:
 * -----------------------------------------------------
 *   I.   Application Layer
 *   II.  Base Class Library (BCL)
 *   III. Common Language Runtime (CLR)
 */

/*
 * 🧩 I. Application Layer
 * -----------------------------------------------------
 * - This is the top layer — where developers build actual apps.
 * - It includes all types of .NET applications:
 *     • Windows Forms  → Desktop GUI apps
 *     • Web Forms (ASP.NET) → Web applications (Server/Client)
 *     • Console Applications → Command-line apps
 * - Uses controls, drawing, and services provided by lower layers.
 */

/*
 * ⚙️ II. .NET Framework Base Class Library (BCL)
 * -----------------------------------------------------
 * - Middle layer — the foundation of reusable code.
 * - Contains predefined classes, interfaces, and APIs used by all .NET apps.
 * - Major components include:
 *     • ADO.NET     → Database and data access
 *     • Remoting    → Communication between processes
 *     • Reflection  → Inspecting and manipulating types
 *     • Diagnostics → Debugging and logging tools
 *     • Threading   → Multitasking and concurrency
 *     • I/O         → File handling and input/output operations
 * - The BCL acts as the “toolbox” for .NET development.
 */

/*
 * ⚡ III. Common Language Runtime (CLR)
 * -----------------------------------------------------
 * - The lowest layer — the heart of .NET execution.
 * - It manages and runs the compiled IL code.
 * - Core responsibilities:
 *     • Garbage Collection (automatic memory cleanup)
 *     • Code Management (loading, verification, JIT)
 *     • Exception Handling, Type Safety, and Security
 * - Provides the execution environment for all .NET languages.
 */

/*
 * ✅ Summary:
 * -----------------------------------------------------
 *   Application Layer → Built using frameworks (WinForms, ASP.NET, Console)
 *   ↓
 *   Base Class Library → Provides APIs and classes for all app types
 *   ↓
 *   CLR → Executes code, manages memory, and handles runtime behavior
 */


namespace _4__.NET_Framework_Architecture
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
