/*
 * ============================================================================
 * LESSON 3: STRICT UNBOXING RULES, THE CONVERT CLASS, AND THE BIG PICTURE
 * ============================================================================
 * 
 * 1. THE BIG PICTURE: TYPE CONVERSIONS IN C#
 * ------------------------------------------
 * Keep these four distinct conversion boundaries clear:
 * 
 * a) Value Type     -> Reference Type : Boxing (allocates on heap, copies value)
 * b) Reference Type -> Value Type     : Unboxing (extracts raw value back to stack)
 * c) Value Type     -> Value Type     : Value Casting (widening/narrowing, e.g., int to double)
 * d) Reference Type -> Reference Type : Polymorphism (Upcasting/Downcasting across inheritance)
 * 
 * 
 * 2. THE STRICT UNBOXING LAW
 * --------------------------
 * When you unbox, the CLR enforces an exact type match.
 * 
 * If a value was boxed as an 'int', it MUST be unboxed as an 'int'.
 * 
 * Attempting to unbox directly to a different numeric type fails at runtime:
 * 
 *     int x = 10;
 *     object boxed = x;       // Boxed as System.Int32
 *     double d = (double)boxed; // RUNTIME CRASH: System.InvalidCastException
 * 
 * Why?
 * The CLR checks the heap box's TypeHandle (MethodTable). It sees System.Int32,
 * not System.Double. Unboxing only extracts the exact packaged bits; it does 
 * not perform numerical re-interpretation simultaneously.
 * 
 * 
 * 3. THE TWO WAYS TO HANDLE DIFFERENT TARGET TYPES
 * ------------------------------------------------
 * a) Two-Step Cast (Manual unbox, then cast):
 *    Unbox to the original type first, then perform standard value casting.
 * 
 *        double d = (double)(int)boxed;
 * 
 * b) Using the System.Convert Class:
 *    The 'Convert' class inspects the underlying boxed object, handles type 
 *    checks dynamically, and converts it to the target type in one step.
 * 
 *        double d = Convert.ToDouble(boxed);
 */

using System;

namespace BoxingLessons
{
   

    internal class Lesson03_StrictUnboxingAndTheBigPicture
    {
        static void Main(string[] args)
        {
            // PART 1: The Strict Unboxing Rule & Solutions
            // ================================================================
            int originalInt = 42;
            object boxed = originalInt; // Boxed as System.Int32

            // direct cast fails at runtime:
            // double bad = (double)boxed; // Throws InvalidCastException

            // Solution A: Two-step explicit cast
            double convertedViaCast = (double)(int)boxed;
            Console.WriteLine($"Two-step cast result: {convertedViaCast}");

            // Solution B: Using the Convert class
            double convertedViaClass = Convert.ToDouble(boxed);
            Console.WriteLine($"Convert class result: {convertedViaClass}");
            Console.WriteLine();

            // PART 2: One Example of Each Type in the Big Picture
            // ================================================================

            // 1. Value Type -> Reference Type (Boxing)
            int score = 95;
            object boxedScore = score; // Implicit boxing to Heap

            // 2. Reference Type -> Value Type (Unboxing)
            int unboxedScore = (int)boxedScore; // Explicit unbox to Stack

            // 3. Value Type -> Value Type (Value Casting)
            // Widening (safe) or Narrowing (potential truncation/overflow)
            long bigNumber = 1000;
            int castedInt = (int)bigNumber; // Explicit narrowing cast

            // 4. Reference Type -> Reference Type (Polymorphism / Up & Downcasting)
            Dog myDog = new Dog();

            // Upcasting (Dog -> Animal): Implicit, safe pointer re-interpretation
            Animal animalRef = myDog; 

            // Downcasting (Animal -> Dog): Explicit, verified at runtime
            Dog restoredDog = (Dog)animalRef;
            restoredDog.Bark();
        }
        
        
        
        
        // Class hierarchy to demonstrate Reference-to-Reference conversions
        class Animal
        {
            public void Eat() => Console.WriteLine("Animal eating.");
        }

        class Dog : Animal
        {
            public void Bark() => Console.WriteLine("Dog barking.");
        }
    }
}