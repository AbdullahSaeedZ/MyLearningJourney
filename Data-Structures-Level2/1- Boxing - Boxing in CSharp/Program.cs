/*
 * ============================================================================
 * LESSON 1: INTRODUCTION TO BOXING IN C#
 * ============================================================================
 * 
 * 1. TWO WORLDS IN MEMORY
 * -----------------------
 * In C#, data types are split into two physical categories:
 * 
 * a) Value Types (int, double, bool, char, struct):
 *    - Store their raw data directly where declared (typically the Stack).
 *    - Fast, lightweight, and independent.
 * 
 * b) Reference Types (string, class, object):
 *    - Store an address (pointer).
 *    - The pointer references the actual data located on the managed Heap.
 * 
 * 
 *       STACK                                HEAP
 *  +------------------+             +--------------------+
 *  | int age = 25     |             |                    |
 *  | (Holds raw data) |             |                    |
 *  +------------------+             |                    |
 *  | string name      | ----------> | "Abdullah"         |
 *  | (Holds address)  |             | (Actual text data) |
 *  +------------------+             +--------------------+
 * 
 * 
 * 2. WHAT IS BOXING?
 * ------------------
 * Every type in C# inherits from System.Object.
 * 
 * Boxing is the process of converting a Value Type into a Reference Type.
 * 
 * When boxing happens:
 * 1. Memory is allocated on the managed Heap.
 * 2. The raw value from the Stack is copied into that new Heap space.
 * 3. The reference variable receives the address of that Heap object.
 * 
 * 
 *       STACK                                HEAP
 *  +------------------+             +--------------------+
 *  | int x = 10       |             |                    |
 *  +------------------+             |   [ "The Box" ]    |
 *  | object obj = x;  | ----------> |   COPIED Value: 10 |
 *  | (Holds address)  |             |                    |
 *  +------------------+             +--------------------+
 *           |                                 ^
 *           +------- copies raw bits ---------+
 * 
 * 
 3. WHY DO WE NEED IT? (THE REAL PROBLEM)
 * ----------------------------------------
 * In real-world software, we often need general-purpose methods that can 
 * accept and process ANY kind of data—text, numbers, or custom records.
 * 
 * Since 'System.Object' is the parent of everything in C#, a method can 
 * accept an 'object' so it can work with all data types:
 * 
 *     void Log(object data)
 *     {
 *         Console.WriteLine(data);
 *     }
 * 
 * The Problem:
 * - The parameter 'data' is a reference type pointing to the Heap.
 * - If you pass a reference type (like a string), it passes naturally.
 * - But if you pass a value type (like an int or bool), it lives as raw bits 
 *   on the Stack and cannot be referenced as a heap object directly.
 * 
 * The Solution:
 * C# automatically "boxes" the value type—copying it into a heap container—so 
 * that the general-purpose method can receive it just like any other object.
 *
 * 
 * 4. THE BIG PICTURE: TYPE CONVERSIONS IN C#
 * ------------------------------------------
 * Keep this map in mind to distinguish boxing from other conversions:
 * 
 * - Value Type     -> Reference Type : Boxing (allocates on heap, copies value)
 * - Reference Type -> Value Type     : Unboxing (extracts raw value back to stack)
 * - Value Type     -> Value Type     : Value Casting (e.g., int to double; watch for overflow/precision loss)
 * - Reference Type -> Reference Type : Polymorphism (Upcasting/Downcasting across an inheritance hierarchy)
 */

using System;

namespace BoxingLessons
{
    internal class Lesson01_Introduction
    {
        // This method accepts ANY type because every type inherits from 'object'
        static void Log(object data)
        {
            Console.WriteLine($"Logged: {data}");
        }

        static void Main(string[] args)
        {
            // Reference type: passed directly as a reference (no boxing)
            string message = "System running";
            Log(message);

            // Value type: C# boxes the number 42 into a heap object
            // so it can be passed into the 'object' parameter
            int statusCode = 42;
            Log(statusCode);

            // You can also box explicitly via assignment:
            object boxedCode = statusCode;
            Console.WriteLine($"Directly boxed: {boxedCode}");
        }
    }
}