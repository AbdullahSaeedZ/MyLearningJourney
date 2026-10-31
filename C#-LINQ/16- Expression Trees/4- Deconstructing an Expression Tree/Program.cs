/*
====================================================================================================
          EXPRESSION TREES - LESSON 4: DECONSTRUCTION
====================================================================================================

1. THE PURPOSE OF THIS LESSON:
   In Lesson 3, we saw how `.Compile()` converts an Expression Tree into a callable delegate.
   
   Now, we do the reverse: we will take an existing Expression Tree, open it up, and traverse 
   its nodes programmatically. This is the exact mechanism ORMs (like EF Core) use to inspect 
   your code and translate it into database query strings.


2. THE TWO EXAMPLES COVERED:
   - Example 1: Flat Single-Tier Expression -> `(num) => num < 0`
     Only one binary comparison, connecting two direct leaf nodes.
     
   - Example 2: Nested Multi-Tier Expression -> `(num) => num % 2 == 0`
     An equality comparison whose left side is itself a modulo operation.


3. VISUALIZING THE TREE STRUCTURES:

   --- Example 1: num < 0 ---
   [ Lambda (Root) ]
           |
      [ < (Branch) ]
       /         \
    [ num (Leaf) ] [ 0 (Leaf) ]


   --- Example 2: num % 2 == 0 ---
          [ Lambda (Root) ]
                 |
          [ == (Branch 1) ]
           /             \
    [ % (Branch 2) ]    [ 0 (Leaf) ]
       /         \
   [ num (Leaf) ] [ 2 (Leaf) ]


4. TRAVERSAL PROPERTIES REVIEW:
   - `Parameters[0]` : Retrieves declared parameters (ParameterExpression).
   - `Body`          : Retrieves the core statement inside the lambda.
   - `operation.Left`: Retrieves the left child node of a BinaryExpression.
   - `operation.Right`: Retrieves the right child node of a BinaryExpression.
   - `NodeType`      : An enum exposing the operation (LessThan, Equal, Modulo, etc.).

Official Reference:
- Microsoft Learn: How to modify expression trees (C#)
  https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/expression-trees/how-to-modify-expression-trees
====================================================================================================
*/

using System;
using System.Linq.Expressions;

namespace _4__Deconstructing_Expressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // =========================================================================
            // EXAMPLE 1: Flat Tree -> (num) => num < 0
            // =========================================================================
            Console.WriteLine("===== Example 1: Deconstructing (num < 0) =====");

            // 1. Declare the Expression Tree
            Expression<Func<int, bool>> isNegativeExpr = (num) => num < 0;

            // 2. Extract the Parameter (Leaf Node)
            // Parameters collection holds: [ num ]
            ParameterExpression numParam1 = isNegativeExpr.Parameters[0];

            // 3. Extract the Body (Branch Node: Binary Comparison)
            // Cast to BinaryExpression because '<' compares Left and Right
            BinaryExpression operation1 = (BinaryExpression)isNegativeExpr.Body;

            // 4. Extract Left & Right Children of the Branch
            // Left child is the variable parameter: 'num'
            ParameterExpression left1 = (ParameterExpression)operation1.Left;

            // Right child is the fixed constant value: 0
            ConstantExpression right1 = (ConstantExpression)operation1.Right;

            // 5. Inspect the extracted metadata
            Console.WriteLine($"Parameter Name : {numParam1.Name}");
            Console.WriteLine($"Left Operand   : {left1.Name}");
            Console.WriteLine($"Operator (Node): {operation1.NodeType}");
            Console.WriteLine($"Right Operand  : {right1.Value}");
            Console.WriteLine($"Reconstructed  : {numParam1.Name} => {left1.Name} {operation1.NodeType} {right1.Value}\n");


            // =========================================================================
            // EXAMPLE 2: Nested Tree -> (num) => num % 2 == 0
            // =========================================================================
            Console.WriteLine("===== Example 2: Deconstructing (num % 2 == 0) =====");

            // 1. Declare the Expression Tree
            Expression<Func<int, bool>> isEvenExpr = (num) => num % 2 == 0;

            // 2. Extract Parameter (Leaf Node)
            ParameterExpression numParam2 = isEvenExpr.Parameters[0];

            // 3. Extract Top-Level Body (Branch Node 1: Equality '==')
            BinaryExpression rootEquality = (BinaryExpression)isEvenExpr.Body;

            // 4. Inspect Right Child of '==' (Leaf Node: Constant 0)
            ConstantExpression zeroConst = (ConstantExpression)rootEquality.Right;

            // 5. Inspect Left Child of '==' (Branch Node 2: Modulo '%')
            // The left side is not a simple value; it is another BinaryExpression!
            BinaryExpression moduloOp = (BinaryExpression)rootEquality.Left;

            // 6. Extract Children of the Modulo Branch
            ParameterExpression moduloLeft = (ParameterExpression)moduloOp.Left;  // 'num'
            ConstantExpression moduloRight = (ConstantExpression)moduloOp.Right; // 2

            // 7. Print the decomposed nested metadata
            Console.WriteLine($"Root Operator  : {rootEquality.NodeType} (==)");
            Console.WriteLine($"Right of Root  : {zeroConst.Value}");
            Console.WriteLine($"Sub-Operator   : {moduloOp.NodeType} (%)");
            Console.WriteLine($"Sub Left Leaf  : {moduloLeft.Name}");
            Console.WriteLine($"Sub Right Leaf : {moduloRight.Value}");
            Console.WriteLine($"Reconstructed  : ({moduloLeft.Name} {moduloOp.NodeType} {moduloRight.Value}) {rootEquality.NodeType} {zeroConst.Value}");
        }
    }
}