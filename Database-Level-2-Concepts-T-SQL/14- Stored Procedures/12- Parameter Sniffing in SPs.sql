/*
====================================================================
LESSON: Parameter Sniffing in SQL Server
====================================================================

1. THE PROBLEM (Why it exists)
--------------------------------------------------------------------
Compiling a query execution plan from scratch consumes CPU and time. 
To avoid doing this on every single call, SQL Server generates a plan 
once and reuses it from cache.

The catch: To build an efficient plan, the optimizer needs to guess 
how many rows will match. Without looking at runtime values, it can't 
tell whether a query will return 5 rows or 500,000 rows.


2. CORE IDEA
--------------------------------------------------------------------
"Parameter Sniffing" is the process where SQL Server inspects (sniffs) 
the parameter values passed during the FIRST execution of a procedure. 
It compiles an execution plan tailored specifically for those initial 
values and reuses it for all subsequent calls.

- The Good: High performance for uniform, predictable data.
- The Bad: If the first run uses an outlier value, every subsequent 
  normal execution gets stuck using an inefficient plan.


3. HOW IT WORKS INTERNALLY
--------------------------------------------------------------------
General Rule of Thumb:
- Small result set -> Fast pointer lookups directly to target rows.
- Large result set -> Reading straight through the table in bulk.

Scenario:
Table `Orders` has 1,000,000 rows.
- Country = 'US' -> 900,000 rows (bulk data).
- Country = 'IS' -> 10 rows (tiny subset).

Case A (Healthy Run):
1. First caller runs: `EXEC GetOrders @Country = 'US'`.
2. Optimizer inspects `'US'`, sees it returns most of the table, and 
   chooses a bulk sequential read through the data.
3. Plan is cached.

Case B (The Parameter Sniffing Problem):
1. Server restarts or plan cache clears.
2. First caller happens to run: `EXEC GetOrders @Country = 'IS'`.
3. Optimizer inspects `'IS'`, sees only 10 rows, and creates a plan 
   designed to jump directly to those specific rows.
4. Plan is cached.
5. Next caller runs: `EXEC GetOrders @Country = 'US'`.
6. SQL Server reuses the cached plan: it tries to jump around 900,000 
   times instead of reading in bulk. Disk and CPU spike, queries freeze.


4. T-SQL DEMO & COMMON SOLUTIONS
--------------------------------------------------------------------
*/

-- Problematic Procedure:
CREATE OR ALTER PROCEDURE dbo.GetOrdersByCountry
    @CountryCode VARCHAR(2)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT OrderID, OrderDate, TotalAmount
    FROM dbo.Orders
    WHERE CountryCode = @CountryCode;
END;
GO

-- FIX 1: OPTIMIZE FOR UNKNOWN
-- Tells the engine to ignore runtime values and build a safe, generic 
-- average plan using overall table statistics.
CREATE OR ALTER PROCEDURE dbo.GetOrdersByCountry_Fix1
    @CountryCode VARCHAR(2)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT OrderID, OrderDate, TotalAmount
    FROM dbo.Orders
    WHERE CountryCode = @CountryCode
    OPTION (OPTIMIZE FOR UNKNOWN);
END;
GO

-- FIX 2: OPTIMIZE FOR A SPECIFIC VALUE
-- Forces the plan to always optimize for the most common input value.
CREATE OR ALTER PROCEDURE dbo.GetOrdersByCountry_Fix2
    @CountryCode VARCHAR(2)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT OrderID, OrderDate, TotalAmount
    FROM dbo.Orders
    WHERE CountryCode = @CountryCode
    OPTION (OPTIMIZE FOR (@CountryCode = 'US'));
END;
GO

-- FIX 3: LOCAL VARIABLES (Masking)
-- Copying the parameter into a local variable hides the value during 
-- compilation, forcing SQL Server to use a generic average plan.
CREATE OR ALTER PROCEDURE dbo.GetOrdersByCountry_Fix3
    @CountryCode VARCHAR(2)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @LocalCountry VARCHAR(2) = @CountryCode;

    SELECT OrderID, OrderDate, TotalAmount
    FROM dbo.Orders
    WHERE CountryCode = @LocalCountry;
END;
GO

-- FIX 4: RECOMPILE ON EVERY RUN
-- Forces the query to build a brand-new plan each time using exact values.
CREATE OR ALTER PROCEDURE dbo.GetOrdersByCountry_Fix4
    @CountryCode VARCHAR(2)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT OrderID, OrderDate, TotalAmount
    FROM dbo.Orders
    WHERE CountryCode = @CountryCode
    OPTION (RECOMPILE);
END;
GO


/*
5. WHEN NOT TO INTERVENE & COMMON MISTAKES
--------------------------------------------------------------------
* DON'T use RECOMPILE everywhere:
  Building execution plans from scratch costs CPU time. Only use it for 
  queries that run infrequently or have massive data variance.
* DON'T intervene unless there is an actual problem:
  Parameter sniffing is a built-in performance optimization. It is 
  beneficial most of the time; only step in when data distribution 
  is heavily skewed and causing real performance drops.
*/