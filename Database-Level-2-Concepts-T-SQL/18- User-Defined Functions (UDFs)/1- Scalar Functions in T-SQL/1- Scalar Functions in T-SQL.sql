/*
====================================================================
LESSON: SCALAR FUNCTIONS IN T-SQL (INTRODUCTION)
====================================================================

1. THE PROBLEM (WHY THEY EXIST):
   In complex database logic, you often need to perform recurring
   calculations, string transformations, or business checks. 
   Without functions, you are forced to repeat the same calculation 
   across multiple queries or views. This violates DRY (Don't Repeat
   Yourself) principles and makes changes error-prone.

2. DEFINITION:
   A Scalar User-Defined Function (UDF) is a database object that:
   - Accepts zero or more input parameters.
   - Executes a block of deterministic or non-deterministic logic.
   - Returns exactly ONE scalar value (e.g., INT, VARCHAR, DATETIME).

3. WHEN TO USE:
   - Reusable formulas (e.g., tax calculation, unit conversion).
   - Standardizing string manipulation (e.g., formatting names).
   - Encapsulating small business checks that return a single value.

4. HOW TO USE:

   **** THEY ARE READONLY, meaning we cant use it to insert or update 
   **** USED INLINE = inside qurey, unlike stored procedures
   - Placement: Anywhere an expression is allowed in T-SQL:
     * SELECT column list
     * WHERE clauses
     * ORDER BY clauses
     * JOIN conditions
   - Execution Rule: Must ALWAYS be invoked using a two-part name 
     (e.g., schema.function_name -> dbo.GetAverageGrade).

5. BASIC SYNTAX:
*/
   CREATE FUNCTION [schema_name].[function_name]
   (
       @Parameter1 DataType,
       @Parameter2 DataType = DefaultValue
   )
   RETURNS int -- or any type
   AS
   BEGIN
       -- 1. Declare local variables
       DECLARE @Result int;

       -- 2. Execute calculation or logic
       -- SELECT / SET logic here...

       -- 3. Return the single value
       RETURN @Result;
   END;


   -- can be found in DB > Programmability > Functions > Scalar-Values-Funtions

/*

6. CRITICAL PITFALLS & PERFORMANCE CONSIDERATIONS:
   - Row-By-Row Execution (RBAR): If called inside a SELECT statement 
     over thousands of rows, SQL Server executes the function once per 
     row, which degrades performance.
   - Data Access: Using queries inside scalar functions can prevent 
     parallel execution plans and cause blocking. Use them sparingly 
     over large datasets; prefer inline table-valued functions (iTVFs) 
     for set-based data retrieval.
====================================================================
*/