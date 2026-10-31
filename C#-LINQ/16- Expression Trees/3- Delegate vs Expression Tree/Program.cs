/*
====================================================================================================
          EXPRESSION TREES - LESSON 3: DELEGATE VS. EXPRESSION TREE & COMPILATION
====================================================================================================

1. THE PURPOSE OF THIS LESSON:
   We previously established that:
   - A `Func` is compiled executable logic (a black box you can only run).
   - An `Expression<Func>` is an inspectable tree structure (a blueprint of the code).

   This lesson shows both side-by-side in code, demonstrates how they are declared with the 
   exact same lambda syntax, and shows how `.Compile()` converts an Expression Tree back into 
   an executable delegate.


2. THE KEY PLAYERS:
   - Standard Delegate:
       Func<int, bool> isEven = (num) => num % 2 == 0;
     The compiler immediately turns this lambda into IL byte instructions.
     Execution: You call it directly (`isEven(10)` or `isEven.Invoke(10)`).

   - Expression Tree:
       Expression<Func<int, bool>> isEvenExpr = (num) => num % 2 == 0;
     The compiler sees `Expression<T>` and instead generates an in-memory object tree.
     Execution: It cannot run directly! It is just a data structure.

   - The Bridge (`.Compile()`):
     Calls the .NET runtime compiler at runtime to convert the data tree into real IL instructions, 
     returning an executable `Func<int, bool>`.


3. VISUALIZING THE BRIDGE:

   Lambda Syntax: (num) => num % 2 == 0
         |
         |---> Assigned to Func<int, bool>
         |     Result: Direct Executable Code (IL)
         |
         |---> Assigned to Expression<Func<int, bool>>
               Result: In-Memory Object Tree (Blueprint)
                         |
                         |---> .Compile()
                         |     Result: Executable Delegate (Func<int, bool>)


4. TIME COMPLEXITY & RUNTIME COST:
   - Calling a `Func`: O(1) direct invocation.
   - Creating an Expression Tree: O(1) object allocations.
   - Calling `.Compile()`: Has a measurable CPU overhead because it invokes the JIT/IL generator 
     at runtime. You should compile once and cache the resulting delegate if reused frequently.

====================================================================================================
*/

using System;
using System.Linq.Expressions;

namespace _3__Delegate_Vs_ExpressionTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // -------------------------------------------------------------------------
            // 1. Standard Delegate (Compiled Executable Logic)
            // -------------------------------------------------------------------------
            // The compiler directly generates IL instructions.
            // This is a black box: it can only be executed, not inspected.
            Func<int, bool> isEven = (num) => num % 2 == 0;
            
            // Direct invocation
            Console.WriteLine(isEven?.Invoke(2));


            // -------------------------------------------------------------------------
            // 2. Expression Tree (Data Blueprint of the Code)
            // -------------------------------------------------------------------------
            // The compiler builds a tree of Expression objects instead of IL instructions.
            // You cannot call `isEvenExpression(10)` directly because it is NOT a method.
            Expression<Func<int, bool>> isEvenExpression = (num) => num % 2 == 0;

            
            // -------------------------------------------------------------------------
            // 3. The Bridge: Compiling the Blueprint Back to Executable Code
            // -------------------------------------------------------------------------
            // .Compile() reads the tree nodes and emits executable IL at runtime,
            // returning a standard Func<int, bool>.
            Func<int, bool> isEvenCompiled = isEvenExpression.Compile();

            // Now it can be invoked just like any delegate
            Console.WriteLine(isEvenCompiled?.Invoke(2));    // Output: True
        }
    }
}