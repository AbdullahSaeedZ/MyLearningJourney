// 'using' can create an alias (alternative name) for a namespace or type (types are)
using System;
using koko = System.Console;


namespace _5__C__Using_Statement___To_create_an_alias
{

    internal class Program
    {
        static void Main(string[] args)
        {
            // this is the normal way of using Console Class from System namespace:
            Console.WriteLine("Hello, World!");

            // this is using the alias we created for the class:
            koko.WriteLine("Hello, World!");

        }
    }
}

/*
What is a Type ?

In C#
, a Type is anything that defines the kind of object or value
a variable can hold.

Examples of Types:

    int
    string
    bool
    double

    Person      // Class
    DateTime    // Struct
    ILogger     // Interface
    ConsoleColor // Enum

Many beginners think "Type" only means data types such as int
and string, but in C# the term is much broader.

Data types are only one category of types.

------------------------------------------------------------

Type Categories

    Type
    ├── Data Types
    │   ├── int
    │   ├── string
    │   ├── bool
    │   └── double
    │
    ├── Classes
    ├── Structs
    ├── Interfaces
    ├── Enums
    └── Delegates

Therefore, aliases are not limited to classes.

------------------------------------------------------------

Alias Examples

Class Alias:
    using MyConsole = System.Console;

Struct Alias:
    using MyDate = System.DateTime;

Interface Alias:
    using Logger = ILogger;

Enum Alias:
    using ColorType = System.ConsoleColor;

Built -in Type Alias:

    using Age = System.Int32;    >>> so the int we use is just a built-in alias of System.Int32
    using Price = System.Decimal;

Namespace Alias:
    using Collections = System.Collections.Generic;

------------------------------------------------------------

Important:
Creating an alias does NOT create a new type.

Example:

    using Age = System.Int32;

Here, Age and int are still exactly the same type.

    Age age = 25;

int x = age;   // Valid
Age y = x;     // Valid

The compiler treats both names as System.Int32.

------------------------------------------------------------

Why Use Aliases?

- Shorten long names.
- Improve readability.
- Resolve naming conflicts.
- Provide more meaningful names in specific contexts.

------------------------------------------------------------

Summary

- 'using' can create an alias for a namespace or type.
- A type is not limited to data types.
- Classes, structs, interfaces, enums, and delegates are all types.
- An alias is only an alternative name.
- An alias does not create a new type.

*/