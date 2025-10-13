using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



// check pdf file

// C# Data Types are divided into two main categories:
// 1. Value Types (stored directly on the stack)
// 2. Reference Types (stored on the heap, referenced by pointers)

// ------------------- VALUE TYPES -------------------

// Simple Types
// Integral types: store whole numbers
sbyte, byte, short, ushort, int, uint, long, ulong;

// Character type: single Unicode character
char;

// Floating types: store real numbers (with decimals)
float, double;

// Decimal type: high-precision decimal numbers (for financial calculations)
decimal;

// Boolean type: true or false
bool;

// Enum Types
// Used to define a set of named constants
enum ExampleEnum { Low, Medium, High };

// Struct Types
// Custom value types that can contain multiple fields and methods
struct Point { public int X; public int Y; }

// Nullable Types
// Allow value types to represent null
int? age = null;

// ------------------- REFERENCE TYPES -------------------

// Class Types
// Base of all reference types
object;  // base class of all types
string;  // sequence of characters (immutable)
class MyClass { }  // user-defined class

// Interface Types
// Define contracts that classes or structs must implement
interface IShape { void Draw(); }

// Array Types
// Collection of elements of the same type
int[] numbers = { 1, 2, 3 };

// Delegate Types
// Hold references to methods
delegate void MyDelegate(string message);


namespace _22___Datatypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
