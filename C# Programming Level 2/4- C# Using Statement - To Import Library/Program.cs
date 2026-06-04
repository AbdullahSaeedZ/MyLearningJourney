/*
============================
C# Using Directive
============================

```
The 'using' directive allows us to access types (classes, interfaces,
structs, enums, etc.) from a namespace without writing the full
namespace name every time.

Example:

    using System;

    Console.WriteLine("Hello");

is equivalent to:

    System.Console.WriteLine("Hello");

------------------------------------------------------------

Important:

The 'using' directive DOES NOT import, install, or add a library
to the project.

It only provides a shorter way to reference types that are already
available to the project.

Think of it as a shortcut for names.

------------------------------------------------------------

To use a namespace, the library containing that namespace must
already be available to the project.

This can happen in several ways:

1. The namespace is part of the .NET runtime.
2. The namespace exists in another project reference.
3. The namespace comes from a DLL reference.
4. The namespace comes from a NuGet package.

 --- can see them in the project dependencies

Example:

    using MyLibrary;

This will only work if MyLibrary is already referenced
by the project.

------------------------------------------------------------

Without using:
    System.Console.WriteLine("Hello World");

With using:
    using System;

    Console.WriteLine("Hello World");

Both statements produce exactly the same result.

------------------------------------------------------------

- Fully Qualified Name:
When we write the complete path to a type, we are using its
Fully Qualified Name.

Example:
    System.Console.WriteLine("Hello");

Here:
    System  -> Namespace
    Console -> Class
    WriteLine() -> Method

------------------------------------------------------------

- Relationship Between References and Using:

    Reference / DLL / NuGet Package
                    ↓
       Makes the library available
             to the project

                    ↓

                using
                    ↓
     Makes type names easier to access

Therefore:

- Reference adds the library.
- using shortens the namespace path.
- using does not add new libraries.
- using does not copy code into the project.
- using only helps the compiler resolve names more easily.

------------------------------------------------------------
