/*
 * ============================================================================
 * LESSON 2: BOXING AND UNBOXING IN PRACTICE
 * ============================================================================
 * 
 * 1. RECAP: THE BIG PICTURE OF TYPE CONVERSIONS
 * ---------------------------------------------
 * - Value Type     -> Reference Type : Boxing (allocates on heap, copies value)
 * - Reference Type -> Value Type     : Unboxing (extracts raw value back to stack)
 * - Value Type     -> Value Type     : Value Casting (e.g., int to double; watch for overflow)
 * - Reference Type -> Reference Type : Polymorphism (Upcasting/Downcasting across inheritance)
 * 
 * 
 * 2. SYNTAX: IMPLICIT VS. EXPLICIT
 * --------------------------------
 * a) Boxing is IMPLICIT:
 *    The C# compiler safely handles wrapping the value type into an object
 *    without requiring a cast.
 * 
 *        int number = 10;
 *        object boxed = number; // Implicit boxing
 * 
 * b) Unboxing is EXPLICIT:
 *    You MUST tell the compiler the exact type you are pulling out of the box.
 * 
 *        int unboxed = (int)boxed; // Explicit cast required
 * 
 * 
 * 3. WHAT HAPPENS UNDER THE HOOD?
 * -------------------------------
 * Unboxing involves two physical operations:
 * 1. Type Check: The CLR inspects the heap object's actual type. If it does not
 *    match the target value type exactly, it throws an 'InvalidCastException'.
 * 
 * 2. Bit Copy: The raw bits inside the heap box are copied back into the 
 *    stack variable.
 * 
 * 
 *       STACK                                HEAP
 *  +------------------+             +--------------------+
 *  | int number = 10  |             |                    |
 *  +------------------+             |   [ "The Box" ]    |
 *  | object boxed     | ----------> |   Type: System.Int32
 *  +------------------+             |   Value: 10        |
 *  | int unboxed = 10 |             |                    |
 *  +------------------+             +--------------------+
 *           ^                                 |
 *           +------- copies raw bits back ----+
 * 
 * 
 * 4. CRITICAL CONCEPT: VALUE COPIES, NOT SHARED REFERENCES
 * ---------------------------------------------------------
 * Boxing does NOT link the stack variable to the heap object.
 * They are two completely independent copies of the data:
 * - Changing the stack variable after boxing does NOT change the heap object.
 * - Unboxing creates another independent stack copy.
 */

using System;

namespace BoxingLessons
{
    internal class Lesson02_BoxingAndUnboxing
    {
        static void Main(string[] args)
        {
            // ----------------------------------------------------
            // 1. Basic Boxing and Unboxing Syntax
            // ----------------------------------------------------
            int originalValue = 25;

            // Implicit Boxing: Stack value copied to a new Heap object
            object boxedValue = originalValue;

            // Explicit Unboxing: Type checked, then bits copied back to Stack
            int unboxedValue = (int)boxedValue;

            Console.WriteLine($"Original : {originalValue}");
            Console.WriteLine($"Boxed    : {boxedValue}");
            Console.WriteLine($"Unboxed  : {unboxedValue}");
            Console.WriteLine();

            // ----------------------------------------------------
            // 2. Demonstration: Value Independence (Deep Copy)
            // ----------------------------------------------------
            int count = 100;
            object boxedCount = count; // 'boxedCount' gets a copy of 100

            // Mutate the original stack variable
            count = 500;

            // Mutate by unboxing into a new stack variable
            int unboxedCount = (int)boxedCount;
            unboxedCount = 999;

            // The heap box still holds the untouched original copy (100)
            Console.WriteLine($"Stack variable 'count'       : {count}");        // 500
            Console.WriteLine($"Heap object 'boxedCount'     : {boxedCount}");   // 100
            Console.WriteLine($"Stack variable 'unboxedCount': {unboxedCount}"); // 999
        }
    }
}