/*
====================================================================
 LESSON 2: INTRODUCTION TO VARIABLES IN T-SQL
====================================================================

1. WHAT IS A VARIABLE?
----------------------
A variable in T-SQL is an object that holds a single data value of a 
specific type in memory. It temporarily stores data during the execution of 
your code batch, stored procedure, or trigger.


2. VARIABLES VS. PROGRAMMING LANGUAGES (C#, C++, etc.)
------------------------------------------------------
If you come from C# or C++, T-SQL variables work on the exact same principles:
* State storage: They hold values in memory rather than writing to disk.
* Mathematical operations: You can perform addition (+), subtraction (-), 
  multiplication (*), division (/), and modulo (%).
* Value reassignment: You can overwrite, increment, or aggregate values over time.
* String concatenation: You can combine text values dynamically.


3. DECLARATION & INITIALIZATION
-------------------------------
* Variables always start with the `@` prefix.
* Syntax: 
    DECLARE @VariableName DataType;
    
* Example: 
    DECLARE @EmployeeName VARCHAR(50);


4. ASSIGNING VALUES
-------------------
You can assign values to variables using either SET or SELECT:
* Using SET:    SET @EmployeeName = 'John Doe';
* Using SELECT: SELECT @EmployeeName = 'John Doe';

(Engineering Tip: Use SET for simple, single-variable scalar assignments. 
Use SELECT when extracting values directly from table columns).


5. VARIABLE SCOPE (LIFETIME)
----------------------------
* T-SQL variables are strictly local to the batch, stored procedure, 
  or trigger where they are declared.
* They cease to exist immediately once the batch or procedure finishes 
  (e.g., encountering a `GO` separator clears all declared variables).


6. COMMON DATA TYPES
--------------------
* Integers:         INT, SMALLINT, BIGINT
* Exact Decimals:   DECIMAL, NUMERIC
* Text/Strings:     CHAR, VARCHAR
* Date & Time:      DATE, DATETIME


7. SYSTEM VARIABLES (SPECIAL FUNCTIONS)
---------------------------------------
T-SQL provides global system functions (prefixed with `@@`) that return 
state information:
* @@IDENTITY:  Returns the last-inserted auto-increment ID value.
* @@ROWCOUNT:  Returns the number of rows affected by the last query.


8. BEST PRACTICES
-----------------
* Always initialize variables to avoid unexpected NULL comparisons.
* Choose appropriate data types and lengths to avoid memory waste.
* Use descriptive names rather than vague abbreviations.
====================================================================
*/

-- =================================================================
-- PRACTICAL DEMO: Declaring, Assigning, and Using Variables
-- =================================================================

-- 1. Declare and initialize variables
DECLARE @StudentName VARCHAR(50) = 'John Doe';
DECLARE @DepartmentId INT = 2;
DECLARE @RowsProcessed INT;

-- 2. Use variable inside a query predicate
-- SELECT * FROM Students WHERE Name = @@StudentName;

-- 3. Working with system functions
-- Example: Imagine an INSERT or UPDATE statement ran here:
-- UPDATE Students SET DepartmentId = @DepartmentId WHERE Name = @@StudentName;

-- Capture the number of rows affected
SET @RowsProcessed = @@ROWCOUNT;

-- Display output
PRINT 'Target Students: ' + @StudentName;
PRINT 'Rows Affected: ' + CAST(@RowsProcessed AS VARCHAR);





-- =================================================================
-- PRACTICAL DEMO: Operations, Reassignment, and Query Filtering
-- =================================================================

-- 1. Declare and initialize
DECLARE @BaseSalary DECIMAL(10, 2) = 5000.00;
DECLARE @BonusRate DECIMAL(4, 2) = 0.15;
DECLARE @TotalCompensation DECIMAL(10, 2);

-- 2. Perform arithmetic operations (just like C# / C++)
SET @TotalCompensation = @BaseSalary + (@BaseSalary * @BonusRate);

-- 3. String concatenation and output
DECLARE @EmployeeName VARCHAR(50) = 'John Doe';
PRINT 'Employee: ' + @EmployeeName;
PRINT 'Calculated Total: $' + CAST(@TotalCompensation AS VARCHAR);

-- 4. Using variables in database operations
-- SELECT * FROM Employees WHERE Salary >= @TotalCompensation;


