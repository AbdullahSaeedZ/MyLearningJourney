/*
====================================================================================================
               EXPRESSION TREES - LESSON 1: THE CORE MOTIVATION & WHAT IS A TREE?
====================================================================================================

1. THE PURPOSE / GOAL OF EXPRESSION TREES:
   The core purpose of Expression Trees is to treat code as DATA instead of EXECUTABLE INSTRUCTIONS.

   Instead of running code directly in RAM, an Expression Tree provides an inspectable 
   "blueprint" of your logic. While this is a powerful C# feature used in advanced scenarios 
   like dynamic sorting, runtime code generation, and compiler design, our primary focus in LINQ 
   is preparing for Entity Framework Core (EF Core). 

   EF Core relies heavily on Expression Trees to inspect your C# queries at runtime and translate 
   them dynamically into database query strings (such as SQL) rather than executing them locally.


2. THE PROBLEM (Why Delegates Fall Short for ORMs):
   Suppose you write:
       Func<Employee, bool> isSenior = emp => emp.Salary > 10000;

   A `Func` is compiled directly into IL (Intermediate Language) machine instructions.
   To the runtime, that delegate is an opaque black box. You can execute it with input, 
   but you CANNOT open it up and inspect it.
   
   If an ORM (like Entity Framework) only received a `Func`:
   - It cannot know you checked the `Salary` column.
   - It cannot know you used the `>` operator.
   - It cannot know the threshold was `10000`.
   
   Because it cannot inspect the code, it cannot translate it into a dynamic database query string:
       SELECT * FROM Employees WHERE Salary > 10000;

   Without being able to read inside the logic, the ORM would have to download the ENTIRE table 
   into memory first, then run your `Func` locally. On large databases, that kills performance.


3. WHAT IS A GENERAL TREE DATA STRUCTURE?
   In computer science, a Tree is a hierarchical data structure composed of connected nodes:
   - Root Node   : The top-level entry point representing the entire statement.
   - Branch Nodes: Intermediate connector nodes (operations) that have children.
   - Leaf Nodes  : The lowest endpoints with no children (values, constants, or variables).

   Visualization of a Multi-Level Expression: (5 + 3) * 2

                     [ * ]               <-- ROOT NODE (Multiplication)
                    /     \
                 [ + ]    [ 2 ]          <-- [ + ] is an BRANCH NODE (Sub operation)
                /     \                  <-- [ 2 ] is a LEAF NODE (Constant, leaf = no children)
             [ 5 ]   [ 3 ]               <-- LEAF NODES (Constants, leaf = no children)


4. WHAT IS AN EXPRESSION TREE?
   An Expression Tree takes your C# code and segments it into individual, distinct nodes in a tree.
   
   Instead of baking the logic into a solid block of IL machine code, it breaks the code into 
   pieces so external tools (like EF Core) can inspect each piece individually:
   - It reads the Root to know it is a Lambda.
   - It inspects the Branches to understand the operators (==, >, %).
   - It inspects the Leaves to extract column names and parameter values.

   Visualization for: num % 2 == 0

                   [ Lambda ]            <-- ROOT NODE (The function wrapper)
                       |
                     [ == ]              <-- BRANCH NODE (Equality comparison)
                    /      \
                 [ % ]     [ 0 ]         <-- [ % ] is a BRANCH NODE (Modulo operation)
                /     \                  <-- [ 0 ] is a LEAF NODE (Constant value)
            [ num ]   [ 2 ]              <-- LEAF NODES (Parameter & Constant value)

   By segmenting the code this way, EF Core walks through each node step-by-step, maps `[ num ]` 
   to a table column, maps `[ % ]` and `[ == ]` to database syntax, and builds the query 
   string dynamically without needing to execute the C# code in memory.


5. SUMMARY:
   - Delegate (Func<T, TResult>)             : Executable logic (a black box you can only run).
   - Expression Tree (Expression<TDelegate>) : Inspectable data (a blueprint segmented into nodes).

Official Reference:
- Microsoft Learn: Expression Trees (C#)
  https://learn.microsoft.com/en-us/dotnet/csharp/advanced-topics/expression-trees/
====================================================================================================
*/