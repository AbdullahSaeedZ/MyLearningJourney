/*
====================================================================
LESSON: TABLE-VALUED FUNCTIONS (TVFs) IN T-SQL (INTRODUCTION)
====================================================================

1. THE PROBLEM (WHY THEY EXIST):
   Standard Views allow you to encapsulate reusable SELECT logic, 
   but Views cannot accept parameters. On the other hand, Stored 
   Procedures can accept parameters, but you cannot easily JOIN, 
   FILTER, or aggregate their output directly inside another SELECT 
   statement without inserting data into temporary staging tables first.
   
   Table-Valued Functions (TVFs) solve this dilemma: they behave like 
   parameterized views that return a structured dataset (table) directly 
   into the caller's query pipeline.

2. DEFINITION:
   A Table-Valued Function (TVF) is a User-Defined Function (UDF) that:
   - Accepts zero or more input parameters.
   - Evaluates read-only T-SQL logic.
   - Returns a result set with rows and columns (the TABLE data type) 
     rather than a single scalar value.

3. THE TWO TYPES OF TVFs (SIMPLIFIED):

   +-------------------+-----------------------------+-----------------------------+
   | WHAT TO LOOK AT   | INLINE TVF (iTVF)           | MULTI-STATEMENT TVF (mTVF)  |
   +-------------------+-----------------------------+-----------------------------+
   | Simple Idea       | A View that takes parameters| A mini-script that fills    |
   |                   |                             | a temporary table           |
   +-------------------+-----------------------------+-----------------------------+
   | How it looks      | Just one RETURN statement   | Uses BEGIN...END with       |
   |                   | with a single SELECT query  | multiple SQL statements     |
   +-------------------+-----------------------------+-----------------------------+
   | Table Columns     | SQL figures out the column  | You must manually declare   |
   |                   | types from your SELECT      | every column name and type  |
   +-------------------+-----------------------------+-----------------------------+
   | How SQL sees it   | Merges it directly into the | Treats it like a black box; |
   |                   | main query plan             | runs it step-by-step        |
   +-------------------+-----------------------------+-----------------------------+
   | Performance       | Fast (always your 1st choice| Slower (use only when logic |
   |                   | for basic queries)          | cannot fit in one SELECT)   |
   +-------------------+-----------------------------+-----------------------------+

4. SYNTAX OVERVIEW:
*/
   -- A) INLINE TABLE-VALUED FUNCTION (iTVF): ****** READONLY function
   CREATE FUNCTION [schema_name].[fn_GetInlineData]
   (@Param1 INT)
   RETURNS TABLE
   AS
   RETURN
   (
       SELECT Column1, Column2
       FROM dbo.SourceTable
       WHERE Column1 = @Param1
   );

   -- B) MULTI-STATEMENT TABLE-VALUED FUNCTION (mTVF):
   CREATE FUNCTION [schema_name].[fn_GetMultiData]
   (@Param1 INT)
   RETURNS @ResultTable TABLE
   (
       Column1 INT,
       Column2 NVARCHAR(50)
   )
   AS
   BEGIN
       -- Procedural data population
       INSERT INTO @ResultTable (Column1, Column2)
       SELECT Column1, Column2
       FROM dbo.SourceTable
       WHERE Column1 = @Param1;

       RETURN;
   END;

/*
5. WHEN TO USE:
   - Use Inline TVFs (iTVFs) as the default choice whenever you need 
     parameterized, reusable tabular logic that can be queried directly 
     in the FROM clause or combined using CROSS APPLY / OUTER APPLY.
   - Use Multi-Statement TVFs (mTVFs) only when the result set cannot 
     be expressed in a single set-based query and strictly requires 
     complex procedural operations (e.g., loops, branching logic, or 
     multi-step aggregation).

6. PITFALLS TO AVOID:
   - Defaulting to mTVFs out of habit: An mTVF forces SQL Server to populate 
     an internal table variable, which can lead to bad cardinality estimates 
     and suboptimal execution plans. Prefer iTVFs whenever possible.
   - Modifying Permanent Tables: Like all functions in T-SQL, TVFs cannot 
     execute DML (INSERT, UPDATE, DELETE) against base database tables.
====================================================================
*/