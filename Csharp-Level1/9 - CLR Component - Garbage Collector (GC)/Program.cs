using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*******************************************************
 * 🧹 Garbage Collection (GC)
 *******************************************************/

/*
 * 1️⃣ Definition
 * -----------------------------------------------------
 * - The Garbage Collector (GC) is a component of the CLR.
 * - It works as an **automatic memory manager**.
 * - Its job: allocate memory to objects and reclaim it
 *   when those objects are no longer in use.
 */

/*
 * 2️⃣ How It Works
 * -----------------------------------------------------
 * - When you create an object (e.g., `new Customer()`),
 *   the GC allocates memory for it on the **heap**.
 *
 * - The GC constantly tracks object references.
 * - Once no active reference points to an object,
 *   the GC automatically frees that memory space.
 *
 * - This process prevents **memory leaks** and
 *   eliminates the need to manually delete memory.
 */

/*
 * 3️⃣ Comparison to C++
 * -----------------------------------------------------
 * 🧠 In C++:
 *   - You manually allocate with `new` and free with `delete`.
 *   - Forgetting `delete` → memory leak.
 *   - Deleting twice or accessing deleted memory → crash (dangling pointer).
 *
 * ⚙️ In .NET:
 *   - You allocate with `new`, but **never delete**.
 *   - The GC automatically detects unused objects
 *     and reclaims memory safely — no leaks, no dangling pointers.
 */

/*
 * 4️⃣ Key Features
 * -----------------------------------------------------
 * - Runs automatically (you can force it manually, but rarely needed).
 * - Works in **generations (0, 1, 2)** to optimize performance:
 *     • Gen 0 → short-lived objects (fast cleanup)
 *     • Gen 2 → long-lived objects (cleaned less often)
 * - Ensures memory safety: objects can’t access
 *   memory that’s already reclaimed.
 */

/*
 * ✅ In short:
 * -----------------------------------------------------
 *   C++ → “You create it, you delete it.”
 *   .NET → “You create it, GC deletes it for you.”
 *
 *   The Garbage Collector is one of .NET’s biggest advantages:
 *   it automates memory management and makes crashes
 *   from bad pointer handling virtually impossible.
 */



namespace _9___CLR_Component___Garbage_Collector__GC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
