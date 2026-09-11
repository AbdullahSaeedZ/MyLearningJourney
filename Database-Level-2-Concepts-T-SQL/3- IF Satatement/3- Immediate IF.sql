/*
====================================================================
 IIF (Immediate IF) Function in T-SQL
====================================================================
- What it is: 
  A shorthand function for writing a simple CASE WHEN ... THEN ... ELSE statement.
  It works exactly like the ternary operator (condition ? true : false) in C#.

- Syntax: 
  IIF(boolean_expression, true_value, false_value)

- Key Differences from IF...ELSE:
  1. IF...ELSE is a control-of-flow statement used to run code blocks (BEGIN...END).
  2. IIF() is an expression that returns a concrete scalar value.
  3. IIF() can be embedded directly inside SELECT statements, WHERE clauses, 
     expressions, and PRINT statements; IF...ELSE cannot.
====================================================================
*/



-- using it in print funtion
declare @year int = 2026;

print iif(@Year >= 2000 ,'21th','20th');


-- using it in a where clause:
DECLARE @OnlyAdults BIT = 1;

-- If @OnlyAdults is 1, minimum age is 18; otherwise, minimum age is 0
SELECT Name, Age
FROM Users
WHERE Age >= IIF(@OnlyAdults = 1, 18, 0);