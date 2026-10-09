using System;

/*
===============================================================================
TOPIC: EXPRESSIONS VS. STATEMENTS IN C#
===============================================================================

1. THE PROBLEM:
-------------------------------------------------------------------------------
When beginners write code, they often treat every line as "just instructions."
This creates confusion when learning why you cannot do this:
    int x = if (true) { 5 }; // COMPILE ERROR: 'if' is a statement, not an expression.
Or why you cannot do this:
    var result = Console.WriteLine("Hello"); // COMPILE ERROR: expression evaluates to void (nothing).

Understanding the difference between an Expression and a Statement is fundamental 
to understanding language syntax and compiler evaluation.

2. CORE IDEA:
-------------------------------------------------------------------------------
  - EXPRESSION: Evaluates to something (a value, a variable, a type, or void/nothing).
                It is a "phrase" of computation.
  - STATEMENT:  A complete instruction or action ending in a semicolon or code block.
                It controls flow, declares variables, or performs an operation.
                It is a complete "sentence".

    Analogy:
    "3.14 * (r * r)"  --> Phrase (Expression: evaluates to a number)
    "double area = 3.14 * (r * r);" --> Sentence (Statement: performs the declaration and storage)

                +------------------------------------------------+
                |                   STATEMENTS                   |
                | (The entire sentence that performs an action)  |
                |                                                |
                |   int area = [ 3.14 * (radius * radius) ];     |
                |              |________________________|        |
                |                           |                    |
                |                       EXPRESSION               |
                |              (The phrase that evaluates)       |
                +------------------------------------------------+

3. HOW VOID FITS IN:
-------------------------------------------------------------------------------
According to the C# Language Specification (§12.2):
  - An expression can evaluate to:
      1. A value (e.g., 5 + 2 evaluates to 7)
      2. A variable / reference (e.g., person.Name)
      3. NOTHING (a "void" expression, e.g., Console.WriteLine())
  - A void invocation like `DoSomething()` is technically an EXPRESSION.
  - But because it yields NO value (nothingness), it cannot be assigned or passed:
        int x = DoSomething(); // ILLEGAL: no value exists to assign.
  - It can only be used as an EXPRESSION STATEMENT (executed for its side effect).

4. THE GOLDEN RULE:
-------------------------------------------------------------------------------
Statements can contain expressions.
Expressions generally cannot contain statements.
===============================================================================
*/

namespace ExpressionVsStatement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // STATEMENTS DEFINITION:
            // A statement is a complete instruction in C#. It can consist of a 
            // single line ending in a semicolon (;), or a series of statements 
            // grouped together in a block enclosed in curly brackets ({}).
            // Statement blocks can also contain nested blocks inside them.
            // =================================================================

            // 1. Single-Line Statements (end with ';')
            int counter;               // Declaration
            counter = 1;               // Assignment
            const double pi = 3.14159; // Declaration & initialization

            // 2. Statement Block (enclosed in '{ }')
            // Groups statements together and can contain nested blocks.
            if (counter > 0)
            {
                Console.WriteLine("Outer block");

                // Nested block
                {
                    int temp = counter * 10;
                    Console.WriteLine($"Nested block: {temp}");
                }
            }

            // PART 2: EXPRESSIONS (EVALUATE TO A VALUE OR OBJECT)
            // =================================================================

            // Expression 1: Literal (evaluates to int 10)
            // Embedded inside a declaration statement.
            var radius = 10;

            // Expression 2: Arithmetic calculation
            // "3.14 * (radius * radius)" evaluates to a double value.
            var area = 3.14 * (radius * radius);

            // Expression 3: Object / Array creation expression
            // "new string[] { ... }" evaluates to an instance of string array on the heap.
            var names = new string[] { "ali", "ahmad", "reem" };


            // PART 3: THE SPECIAL CASE — "VOID" EXPRESSIONS
            // =================================================================

            // Console.WriteLine(area) is an INVOCATION EXPRESSION.
            // However, its return type is 'void', meaning it evaluates to NOTHING.
            // When an expression is allowed to stand on its own as a full line,
            // it is called an EXPRESSION STATEMENT.
            Console.WriteLine(area);

            // Calling a custom void method is also an invocation expression:
            DoSomething();

            // PROOF THAT VOID HAS NO VALUE:
            // The compiler will reject this because you cannot assign 'nothing':
            // var nothing = DoSomething(); // CS1061: Cannot assign void to an untyped variable
        }

        // A method with a 'void' return type returns nothing.
        // Invoking it produces a void expression (no value).
        static void DoSomething()
        {
            return;
        }
    }
}