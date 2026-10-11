/*
================================================================================
LESSON: ANONYMOUS TYPES IN C#
================================================================================

1. THE PROBLEM (WHY THEY EXIST)
--------------------------------------------------------------------------------
Before C# 3.0, grouping a few properties together meant declaring an entire class:

    public class TempSummary
    {
        public string Name { get; set; }
        public decimal Tax { get; set; }
    }

Writing a dedicated class for throwaway data needed only within 3 lines of a 
single method pollutes the project with boilerplate.


2. THE CORE IDEA
--------------------------------------------------------------------------------
An Anonymous Type is an immutable, temporary object defined on the fly without 
writing an explicit class declaration.

    var item = new { Name = "Sara", Tax = 500m };

You get strong typing and IntelliSense inside the local method without creating 
a permanent `.cs` file or class.


3. HOW IT WORKS INTERNALLY
--------------------------------------------------------------------------------
SEE THIS, VERY HELPFUL: https://www.youtube.com/watch?v=2G4qCfgqy4Q&list=PLqPejUavRNTXdgLMPnCwqriZX1yZ_Kgib&index=5

The compiler handles the heavy lifting:
- Generates an internal generic class behind the scenes with a hidden name 
  (e.g., `<>f__AnonymousType0<T1, T2>`).
- Properties are read-only (getter-only). Values cannot change after creation.
- Overrides `Equals()` and `GetHashCode()` automatically: two separate instances 
  with the exact same property values are evaluated as EQUAL (value equality).

Compiler Lowering Diagram:
  Your Code:        var p = new { Name = "Sara", Age = 25 };
                           |
                           v  (Compiler translates to IL)
  Internal Class:   class <>f__AnonymousType0<string, int>
                    {
                        public string Name { get; }
                        public int Age { get; }
                        // Generated Equals(), GetHashCode(), ToString()
                    }


4. MINIMAL C# DEMONSTRATION
--------------------------------------------------------------------------------
*/

using System;

public class Program
{
    public static void Main()
    {
        string dept = "Engineering";

        // 1. Definition with explicit and inferred property names
        var person = new 
        { 
            Name = "Sami", 
            Salary = 6000m,
            Department = dept // Inferred property name: 'Department'
        };

        // 2. Read properties with full compile-time type safety
        Console.WriteLine($"{person.Name} works in {person.Department}");

        // 3. Immutability check (Compile-time error if uncommented)
        // person.Salary = 7000m; // ERROR: Property is read-only!

        // 4. Value-based Equality
        var personA = new { Id = 1, Role = "Admin" };
        var personB = new { Id = 1, Role = "Admin" };

        Console.WriteLine($"Are equal: {personA.Equals(personB)}"); // True
    }
}

/*
--------------------------------------------------------------------------------
5. WHEN NOT TO USE & COMMON PITFALLS
--------------------------------------------------------------------------------
- Returning Outside Method Boundaries:
  Anonymous types have no visible type name. Returning one from a method forces 
  you to return `object` or `dynamic`, losing compile-time type safety. 
  Rule: Use a `record` or DTO whenever data leaves the method.

- Mutation:
  If properties need to change over time, use a standard `class`.
*/