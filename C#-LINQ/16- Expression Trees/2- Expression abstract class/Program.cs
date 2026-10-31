/*
====================================================================================================
               EXPRESSION TREES - LESSON 2: THE TYPE HIERARCHY & NODE TYPES
====================================================================================================

1. THE PURPOSE OF THIS LESSON:
   In Lesson 1, we learned that an Expression Tree segments code into nodes (Root, Branch, Leaf).
   In C#, each of those nodes is an actual class object in RAM.
   
   This lesson maps our tree concepts directly to the official .NET classes that represent them, 
   showing how they all inherit from a single abstract base class.


2. THE ABSTRACT BASE CLASS: System.Linq.Expressions.Expression
   `Expression` is an abstract class. You cannot instantiate it directly with `new Expression()`.
   
   It serves two main purposes:
   - The Common Contract: Every single node type in the tree inherits from `Expression`.
   - The Static Factory: It contains static factory methods (like `Expression.Parameter`, 
     `Expression.Constant`, `Expression.Equal`) used to construct nodes programmatically.

   Every node inheriting from `Expression` carries two essential properties:
   - `NodeType`: An enum (ExpressionType) describing the operation (e.g., Equal, Add, Modulo).
   - `Type`    : The standard .NET System.Type of the evaluated result (e.g., int, bool, string).


3. THE NODE CLASSIFICATIONS (Matching our Tree Roles):

   A) ROOT NODE (The Function Definition):
      - Class: `LambdaExpression` (specifically `Expression<TDelegate>`)
      - Role : Represents the entire function signature. It holds the parameters and the body.
      - Example: `(parameter) => body`

   B) BRANCH NODES (Operations with Children):
      - Class: `BinaryExpression`
        * Represents an operation between TWO children: `Left` and `Right`.
        * Examples: Arithmetic (`+`, `-`, `%`), Comparison (`==`, `>`, `<`), Logical (`&&`, `||`).
 * 
      - Class: `UnaryExpression`
        * Represents an operation on ONE child: `Operand`.
        * Examples: Negation (`-x`), Logical Not (`!x`), Type Casting `(int)x`.
 * 
      - Class: `MethodCallExpression`
        * Represents invoking a method (e.g., `string.Contains("abc")`).
 * 
      - Class: `MemberExpression`
        * Represents accessing a field or property on an object (e.g., `emp.Salary`).

   C) LEAF NODES (Endpoints - No Children):
      - Class: `ParameterExpression`
        * Represents a declared variable or function parameter.
        * Properties: `Name` ("num"), `Type` (typeof(int)).
 * 
      - Class: `ConstantExpression`
        * Represents a fixed, hardcoded value.
        * Properties: `Value` (0, 10, "Active"), `Type` (typeof(int)).


4. MAPPING THE HIERARCHY TO AN ACTUAL TREE:

   Statement: (num) => num % 2 == 0

   Visual Node Role                 C# Class Type               Properties / Data
   -------------------------------------------------------------------------------------------------
   [ Root Node ]                 -> Expression<Func<int,bool>>  Parameters: [num], Body: (==)
         |
   [ Branch Node (Equality) ]    -> BinaryExpression            NodeType: Equal, Left: (%), Right: 0
        / \
       /   \
      /     \--> [ Leaf Node ]   -> ConstantExpression          Value: 0, Type: int
     /
   [ Branch Node (Modulo) ]      -> BinaryExpression            NodeType: Modulo, Left: num, Right: 2
        / \
       /   \-->  [ Leaf Node ]   -> ConstantExpression          Value: 2, Type: int
      /
   [ Leaf Node ]                 -> ParameterExpression         Name: "num", Type: int


5. THE BIG-PICTURE CONNECTION (How ORMs use these types):
   When EF Core receives an `Expression<Func<T, bool>>`:
   - It checks: Is the body a `BinaryExpression` with `NodeType == ExpressionType.Equal`?
   - It inspects `Left`: It finds a `MemberExpression` accessing `emp.DepartmentId`.
   - It inspects `Right`: It finds a `ConstantExpression` with `Value = 5`.
   
   Because each node is a distinct, strongly-typed C# object with clear properties, 
   the ORM can safely translate that exact structure into SQL:
       WHERE DepartmentId = 5

====================================================================================================
*/