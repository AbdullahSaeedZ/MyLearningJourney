using System;
//     ^
//     |

// this is a class library called by "using" keyword and the namespace name, it includes code like Console.WriteLine("hi");
// so now we will make one class library to be called anywhere in any type of project 

// Solution is a container for multiple project, so we add one more project in the solution as class library type (in .dll = dynamic link library)

// we prepare our class in saperate project, then we link that project to this project by choosing reference from the options to be able to use it here

// then we call it by "using" keyword:
// we call the namespace that includes the class, not the class itself
using MyLibrary;


internal class Program
{
   static void Main(string[] args)
   {
       
       
        clsMyMath myMath = new clsMyMath(); // -> clsMyMath class in namespace called MyLibrary in another project referenced(linked) to this project
        Console.WriteLine(myMath.Sum(15, 10));
   }
}



// another way to link class library to the project, is by taking the dll file which contains the code of our class, and do referencing to any project (WinForms on console or whatever)
// dll file will be created from the class library build and find it in the class project folder inside the debug folder
// follow the next project to see how i linked the dll to another project in another solution




/*
 
When you build a class library project in C#, the following events occur:

Source Code Compilation: The C# compiler (e.g., csc.exe) compiles the source code files in the project. This involves checking the syntax and semantics of your code.

Output as a DLL: The result of the compilation is a Dynamic Link Library (DLL) file. A class library project in C# does not produce an executable (.exe) file; instead, it produces a DLL. This DLL contains the compiled types (classes, interfaces, etc.) that you define in your project.

Metadata Generation: Along with the compiled code, metadata is generated. This metadata contains information about the types, methods, properties, etc., present in the class library. Other projects will use this metadata when referencing the library.

No Entry Point: A class library does not have a Main() method (an entry point). Instead, it is designed to be used as a dependency for other projects, which will call the library's methods and functionality.

Output Location: The compiled DLL is placed in the project's output directory (usually /bin/Debug or /bin/Release based on your build configuration).

Once built, this DLL can be referenced by other projects, such as a console application, web application, or another class library, to use the functionality provided by the library.
 
 */