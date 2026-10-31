/*
====================================================================================================
          EXPRESSION TREES - LESSON 5: MANUAL ASSEMBLY — BUILDING FROM SCRATCH
====================================================================================================

1. THE PURPOSE OF THIS LESSON:
   In Lesson 4, we deconstructed a ready-made Expression Tree into its individual pieces.
   
   Now, we reverse the entire process: we will manually manufacture each individual node from 
   scratch using static factory methods on the `Expression` class, wire them together into a tree, 
   wrap them inside a Lambda root, compile the tree, and execute the resulting delegate.


2. THE PROBLEM (Why Build Expressions Manually?):
   Normally, you write lambdas like `num => num % 2 == 0` directly in code.
   However, in enterprise applications, the logic is often UNKNOWN at compile time.
   
   Real-World Scenarios:
   - Dynamic Sorting: The user sends a sort column name as a string (e.g., "Salary" or "CreatedAt").
     You cannot hardcode `x => x.Salary` because the column is dynamic.
   - Dynamic Search Filters: A user fills out an optional search form (filtering by Name, Age, 
     or Department). You must assemble comparison nodes conditionally at runtime.
   - Dynamic Database Query Strings: ORMs dynamically construct Expression Trees to match 
     runtime criteria before translating them to SQL.


3. THE ASSEMBLY BLUEPRINT: Building (num) => num % 2 == 0

   Step 1: Build the Leaf Nodes (Constants & Parameters)
           - ParameterExpression : "num" of type int
           - ConstantExpression  : 2 of type int
           - ConstantExpression  : 0 of type int

   Step 2: Build the Sub-Branch (Modulo Operation)
           - BinaryExpression    : num % 2

   Step 3: Build the Root Branch (Equality Comparison)
           - BinaryExpression    : (num % 2) == 0

   Step 4: Wrap into the Root Node (Lambda Expression)
           - Expression<Func<int, bool>> : (num) => ((num % 2) == 0)

   Step 5: Compile & Execute
           - .Compile() -> invokes the JIT to return an executable Func<int, bool>.


4. TIME COMPLEXITY & RUNTIME COST:
   - Node Construction: O(1) per node. Fast heap allocations.
   - Tree Assembly: O(1) pointer connections.
   - `.Compile()`: Has measurable CPU overhead because it generates dynamic IL. 
     If a dynamic expression is reused, compile it once and cache the resulting delegate.

====================================================================================================
*/

using System;
using System.Linq.Expressions;

namespace _5__Manual_Expression_Assembly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Target Lambda to construct manually:
            // (num) => num % 2 == 0

            ConstantExpression zero = Expression.Constant(0, typeof(int));
            ConstantExpression two = Expression.Constant(2, typeof(int));
            ParameterExpression numPara = Expression.Parameter(typeof(string), "num");

            BinaryExpression moduloOperation = Expression.Equal(numPara, two);
            BinaryExpression equalityOperation = Expression.Equal(moduloOperation, zero);

            Expression<Func<int, bool>> isEvenExp =
                Expression.Lambda<Func<int, bool>>(equalityOperation, new ParameterExpression[] { numPara });
            
            // STEP 1: Create the Leaf Nodes (Parameters and Constants)
            // -------------------------------------------------------------------------
            // Parameter node: represents the variable argument 'int num'
            ParameterExpression numParam = Expression.Parameter(typeof(int), "num");

            // Constant nodes: represent the fixed numbers 0 and 2
            ConstantExpression zeroParam = Expression.Constant(0, typeof(int));
            ConstantExpression twoParam  = Expression.Constant(2, typeof(int));

            // STEP 2: Create the Sub-Branch Node (Modulo Operation '%')
            // we prepare the inner operation first to build for the main operation
            // -------------------------------------------------------------------------
            // Binary operation connecting Left (num) and Right (2) -> (num % 2) inner operation
            BinaryExpression moduloBinaryExpression = Expression.Modulo(numParam, twoParam);

            // STEP 3: Create the Root Branch Node (Equality Comparison '==')
            // -------------------------------------------------------------------------
            // Binary operation connecting Left (num % 2) and Right (0) -> ((num % 2) == 0) representing the BODY - main operation
            BinaryExpression isEvenBinaryExpression = Expression.Equal(moduloBinaryExpression, zeroParam);

            // STEP 4: Wrap the Body and Parameter into a Lambda (Root Node)
            // -------------------------------------------------------------------------
            // Expression.Lambda binds the executable body with its declared parameter list
            Expression<Func<int, bool>> isEvenExpression = Expression.Lambda<Func<int, bool>>(
                isEvenBinaryExpression, 
                new ParameterExpression[] { numParam }
            );

            // STEP 5: Compile the Manually Built Tree and Execute
            // -------------------------------------------------------------------------
            // .Compile() reads through our assembled object tree and outputs an executable Func
            Func<int, bool> isEven = isEvenExpression.Compile();

            // Test execution with inputs
            Console.WriteLine($"Is 10 even? {isEven(10)}"); // Output: True
            Console.WriteLine($"Is 7 even?  {isEven(7)}");  // Output: False
        }
    }
}