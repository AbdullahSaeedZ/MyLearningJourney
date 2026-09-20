/* ============================================================================
   LESSON: Understanding Dynamic SQL in Stored Procedures
   ============================================================================

   1. THE PROBLEM (Why does it exist?)
   ----------------------------------------------------------------------------
   Standard (static) SQL requires the database engine to parse, compile, and 
   validate table names, column names, and syntax before execution begins.
   
   Because of this, standard SQL does NOT allow parameters for structural 
   elements such as table names or column lists:

       -- THIS WILL FAIL TO COMPILE:
       CREATE PROCEDURE GetRecords @TableName NVARCHAR(50)
       AS
       BEGIN
           SELECT * FROM @TableName; -- Syntax error! Table name cannot be a variable.
       END;

   When you build generic utilities, administrative scripts, or complex search 
   screens where table names, columns, or filter clauses are not known until the 
   caller actually executes the code, static SQL hits a hard wall.


   2. WHY IS IT CALLED "DYNAMIC"?
   ----------------------------------------------------------------------------
   Static SQL is fixed at compile time:
   The query text is baked into the stored procedure definition.

   Dynamic SQL changes its shape at runtime:
   The SQL statement itself does not exist as code until the stored procedure runs. 
   It is assembled as a plain string inside memory, adapting its structure based 
   on input, and only then passed to the engine to be evaluated.


   3. HOW TO USE DYNAMIC SQL: TWO PRIMARY METHODS
   ----------------------------------------------------------------------------
   Method A: EXECUTE (or EXEC)
   - Evaluates a raw SQL string.
   - Fast to write, but basic and lacks native parameter definition features.

   Method B: sp_executesql
   - Built-in system stored procedure.
   - Industry standard for dynamic queries.
   - Reuses cached execution plans when parameterized and handles Unicode cleanly.
============================================================================ */


-- ============================================================================
-- DEMONSTRATION SETUP: Creating Mock Tables
-- ============================================================================
CREATE TABLE Employees11 (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(50)
);

CREATE TABLE Contractors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(50)
);

INSERT INTO Employees11 (FullName) VALUES ('Alice Smith'), ('Bob Jones');
INSERT INTO Contractors (FullName) VALUES ('Charlie Brown');
GO


-- ============================================================================
-- APPROACH 1: Using EXECUTE (@SQLString)
-- ============================================================================
CREATE OR ALTER PROCEDURE QueryTableBasic
    @TableName NVARCHAR(128)
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Declare a string variable to hold the query text.
    DECLARE @SQL NVARCHAR(MAX);

    -- 2. Construct the query dynamically by string concatenation.
    SET @SQL = N'SELECT * FROM ' + @TableName;

    -- 3. Run the constructed string.
    EXECUTE(@SQL);
END;
GO

-- How to call:
EXEC QueryTableBasic @TableName = 'Employees11';
EXEC QueryTableBasic @TableName = 'Contractors';
GO


-- ============================================================================
-- APPROACH 2: Using sp_executesql (Preferred Practice)
-- ============================================================================
CREATE OR ALTER PROCEDURE QueryTableAdvanced
    @TableName NVARCHAR(128)
AS
BEGIN
    SET NOCOUNT ON;

    -- 1. Use NVARCHAR(MAX) because sp_executesql requires a Unicode string.
    DECLARE @SQL NVARCHAR(MAX);

    -- 2. QUOTENAME wraps the table name in brackets: [TableName].
    --    This ensures SQL Server treats it as a single, valid identifier.
    SET @SQL = N'SELECT * FROM ' + QUOTENAME(@TableName);

    -- 3. Execute the statement via system procedure.
    EXEC sys.sp_executesql @stmt = @SQL;
END;
GO

-- How to call:
EXEC QueryTableAdvanced @TableName = 'Employees11';
EXEC QueryTableAdvanced @TableName = 'Contractors';
GO


-- ============================================================================
-- SEEING THE "DYNAMIC" NATURE IN ACTION: Adaptive Query Assembly
-- ============================================================================
-- This example demonstrates why it is called "dynamic":
-- The final query string changes its structure depending on caller input.

CREATE OR ALTER PROCEDURE FilterEmployees11Dynamic
    @SearchName NVARCHAR(50) = NULL,
    @OrderByCol NVARCHAR(50) = N'Id'
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @SQL NVARCHAR(MAX);

    -- Base query structure:
    SET @SQL = N'SELECT Id, FullName FROM dbo.Employees11 WHERE 1 = 1 ';

    -- Dynamically append conditions only if the caller supplied a value:
    IF @SearchName IS NOT NULL
    BEGIN
        SET @SQL = @SQL + N'AND FullName LIKE ''%' + @SearchName + N'%'' ';
    END;

    -- Dynamically change the ordering column at runtime:
    SET @SQL = @SQL + N'ORDER BY ' + QUOTENAME(@OrderByCol);

    -- Print statement reveals the query changing shape in the Messages window:
    PRINT '--- Dynamically Generated Query ---';
    PRINT @SQL;

    -- Execute the generated result:
    EXEC sys.sp_executesql @stmt = @SQL;
END;
GO

-- Case 1: Minimal execution
-- Generates: SELECT Id, FullName FROM dbo.Employees11 WHERE 1 = 1 ORDER BY [Id]
EXEC FilterEmployees11Dynamic;

-- Case 2: Full dynamic execution
-- Generates: SELECT Id, FullName FROM dbo.Employees11 WHERE 1 = 1 AND FullName LIKE '%Alice%' ORDER BY [FullName]
EXEC FilterEmployees11Dynamic @SearchName = 'Alice', @OrderByCol = 'FullName';
GO


/* ============================================================================
   CONSIDERATIONS FOR DYNAMIC SQL IN STORED PROCEDURES
   ----------------------------------------------------------------------------
   1. SQL Injection:
      Dynamic SQL can be vulnerable to injection attacks if inputs are 
      concatenated directly into the query string. (We will cover how to 
      prevent this in the next lesson).

   2. Debugging and Maintenance:
      Harder to debug than static SQL because syntax errors only appear at 
      runtime, not when compiling the procedure. Tip: Use PRINT @SQL to 
      inspect the generated string.

   3. Performance:
      Static queries reuse the same execution plan every time (caching). Dynamic queries 
      often force SQL Server to re-generate the execution plan from scratch on 
      every run, which slows down the database.

   4. Security and Permissions:
      Normally, granting a user permission to run a stored procedure is enough. 
      With dynamic SQL, SQL Server checks permissions against the actual tables, 
      meaning the user might need direct access to the tables to run the query.
============================================================================ */