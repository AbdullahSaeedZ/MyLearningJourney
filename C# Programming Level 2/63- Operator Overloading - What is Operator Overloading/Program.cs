using System;

/*
================================================================================
C# OPERATOR OVERLOADING: CONCEPT INTRODUCTION
================================================================================

1. The Problem
In early programming languages, operators like + or - were strictly hardcoded 
for primitive types (integers, floats). If you created a custom data structure—like 
a Vector, a Matrix, or a ComplexNumber—you couldn't use intuitive mathematical syntax. 
Instead, you had to call verbose methods like Vector.Add(v1, v2). This made 
mathematical or domain-specific code difficult to read and maintain.

2. Core Idea
Operator overloading allows you to treat user-defined types (classes and structs) 
as first-class citizens. It lets you define exactly how built-in operators behave 
when applied to your custom objects, making your code cleaner and more intuitive.

3. How It Works Internally
At compile time, the C# compiler treats overloaded operators as static methods 
with a special name (e.g., op_Addition). When the compiler encounters a + b where 
a and b are your custom types, it translates that syntax into a direct method call 
behind the scenes: YourType.op_Addition(a, b). 
*/

public class Program
{
    public static void Main(string[] args)
    {
        // the nature of the built-in '+' operator based on context:

        // first context, numeric types invoke standard arithmetic addition
        int x = 10, y = 20;
        int z = x + y;
        
        // second context, string types invoke string concatenation (String.Concat)
        string s1 = "Abdullah", s2 = "Alzahrani";
        string s3 = s1 + ' ' + s2;

        // results
        Console.WriteLine($"Numeric addition result: z = {z}");
        Console.WriteLine($"String concatenation result: s3 = {s3}");

        Console.ReadKey();
    }
}