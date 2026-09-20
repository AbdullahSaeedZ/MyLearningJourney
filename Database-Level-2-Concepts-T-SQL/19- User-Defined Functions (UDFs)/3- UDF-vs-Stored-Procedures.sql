/*
====================================================================
LESSON: USER-DEFINED FUNCTIONS (UDFs) VS. STORED PROCEDURES (SPs)
====================================================================

1. THE PROBLEM (WHY TWO DISTINCT OBJECTS EXIST):
   In database engineering, you face two fundamentally different tasks:
   A) Data manipulation & workflow automation: You need to modify 
      tables (INSERT/UPDATE/DELETE), manage multi-step transactions, 
      handle errors, and return multiple results.
   B) Inline calculation & query composition: You need pure, reusable 
      logic embedded directly inside a SELECT, WHERE, or JOIN clause 
      without breaking the query engine's set-based evaluation.

   One construct cannot safely do both. If SQL Server allowed a function 
   inside a SELECT statement to commit transactions or modify table states, 
   query optimization, concurrency locks, and deterministic results 
   would collapse. Hence, the engine splits responsibilities.

2. ARCHITECTURAL COMPARISON:

   +-------------------+-----------------------------+-----------------------------+
   | FEATURE           | USER-DEFINED FUNCTION (UDF) | STORED PROCEDURE (SP)       |
   +-------------------+-----------------------------+-----------------------------+
   | Primary Purpose   | Compute and return values   | Execute tasks, logic, DML   |
   +-------------------+-----------------------------+-----------------------------+
   | Invocation        | Inside queries (SELECT,     | Standalone execution via    |
   |                   | WHERE, JOIN, HAVING)        | EXEC / EXECUTE              |
   +-------------------+-----------------------------+-----------------------------+
   | Return Value      | Exactly one value (scalar)  | Optional status code (INT); |
   |                   | OR a table result           | returns result sets / OUTPUT|
   +-------------------+-----------------------------+-----------------------------+
   | DML Modifications | STRICTLY FORBIDDEN on       | ALLOWED (INSERT, UPDATE,    |
   | (Side Effects)    | permanent tables            | DELETE fully supported)     |
   +-------------------+-----------------------------+-----------------------------+
   | Transactions      | NOT ALLOWED (no BEGIN TRAN, | FULLY ALLOWED (BEGIN,       |
   |                   | COMMIT, or ROLLBACK)        | COMMIT, ROLLBACK, SAVEPOINT)|
   +-------------------+-----------------------------+-----------------------------+
   | Temp Tables       | Table variables only (@Tbl);| Both temporary tables (#Tbl)|
   |                   | #TempTables are forbidden   | and table variables allowed |
   +-------------------+-----------------------------+-----------------------------+
   | Dynamic SQL       | NOT ALLOWED (EXEC() or      | FULLY ALLOWED (sp_executesql|
   |                   | sp_executesql forbidden)    | and EXEC() permitted)       |
   +-------------------+-----------------------------+-----------------------------+
   | Error Handling    | TRY...CATCH is forbidden    | TRY...CATCH fully supported |
   +-------------------+-----------------------------+-----------------------------+

3. HOW TO DECIDE (RULE OF THUMB):
   - Choose a FUNCTION when:
     * You need to compute a value directly inside a SELECT column list.
     * You need to filter rows in a WHERE clause dynamically.
     * You need a parameterized view (Inline Table-Valued Function).
     * The operation has ZERO side effects (read-only calculation).

   - Choose a STORED PROCEDURE when:
     * You need to INSERT, UPDATE, or DELETE records in database tables.
     * You need transaction management (ACID boundaries).
     * You need error handling (TRY...CATCH blocks, THROW).
     * You need dynamic SQL execution.
     * You are orchestrating multiple ETL, reporting, or batch steps.

4. COMMON OVER-ENGINEERING PITFALLS:
   - Forcing business transactions into functions: Trying to bypass UDF 
     restrictions instead of writing a clean Stored Procedure.
   - Calling Scalar UDFs over huge tables: Causes Row-By-Row (RBAR) 
     execution, ruining query parallelism and index usage.
   - Using Stored Procedures for trivial data formatting: Adding SP 
     overhead and output parameters for simple math or string operations 
     that belong in an inline function or direct T-SQL expression.
====================================================================
*/