using System;

// In C#, data types are categorized into 3 groups:
// 1. Value Types
// 2. Reference Types
// 3. Pointer Types (unsafe context only)


// Value Types (e.g., struct, int, bool)
// - Store the *value itself* directly.
// - If declared as a local variable → stored on the stack.
// - If stored as part of an object → stored inside the object on the heap.
// - Copying a value type copies the value itself.


// Reference Types (e.g., class, string, arrays)
// - The variable stores a *reference* (pointer-like address).
// - The reference is stored on the stack.
// - The actual data/object is stored on the heap.
// - Copying a reference type copies the reference, not the object.


// Important Note:
// "Value type = direct value storage" and "Reference type = stores a reference"
// The location (stack or heap) depends on how/where the variable is allocated.


namespace ClassVsStructDemo
{
    // Class → Reference Type
    class EmployeeClass
    {
        public string Name;
    }

    // Struct → Value Type
    struct EmployeeStruct
    {
        public string Name;
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ---------- Reference Type Example ----------

            EmployeeClass c1 = new EmployeeClass();
            c1.Name = "John";

            // c2 points to the same object as c1, basically since it is a reference type means pointer, we point now to the same address
            EmployeeClass c2 = c1;
            c2.Name = "Mohammed";

            Console.WriteLine("Class Example:");
            Console.WriteLine("c1.Name = " + c1.Name); // changed → Mohammed
            Console.WriteLine("c2.Name = " + c2.Name);
            Console.WriteLine();





            // ---------- Value Type Example ----------
            EmployeeStruct s1 = new EmployeeStruct();
            s1.Name = "Mohammed";

            // s2 receives a COPY of s1, this is not a reference type(not a pointer)
            EmployeeStruct s2 = s1;
            s2.Name = "Ali";

            Console.WriteLine("Struct Example:");
            Console.WriteLine("s1.Name = " + s1.Name); // unchanged → Mohammed
            Console.WriteLine("s2.Name = " + s2.Name);
        }
    }
}

/*
Summary (Key Differences):

1. Class → Reference Type
   - Stored on the heap.
   - Variables hold references to the same object.
   - Changes through one variable reflect on the other.
   - Supports inheritance.

2. Struct → Value Type
   - Stored on the stack.
   - Variables hold independent copies of the data.
   - Changing one variable does not affect the other.
   - Does NOT support inheritance (except from System.ValueType).

3. Constructors:
   - Classes have automatic default constructors.
   -The CLR automatically provides a default parameterless constructor that zero-initializes all fields.
   -You can define constructors with parameters, but not a custom parameterless one.

4. Performance:
   - Structs are lighter and faster for small data.
   - Classes better for larger, complex objects.

5. Usage Rule of Thumb:
   - Use struct for small, short-lived, simple data.
   - Use class for anything with behavior, relationships, or inheritance.
*/
