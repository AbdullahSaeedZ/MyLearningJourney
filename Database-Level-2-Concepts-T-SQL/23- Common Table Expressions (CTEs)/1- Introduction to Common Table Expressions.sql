/* ============================================================================
   LESSON: Common Table Expressions (CTEs) in T-SQL
   ============================================================================

   1. THE PROBLEM (Why CTEs Exist)
   ----------------------------------------------------------------------------
   Complex SQL logic often requires multi-stage data transformations (e.g., 
   filtering, aggregating, and then joining back to detailed records). 

   Before CTEs, developers had two suboptimal choices:
     - Deeply Nested Subqueries: "Inside-out" code where the innermost logic 
       is buried 3–4 levels deep, destroying readability and maintainability.
     - Temporary Tables (#Tables): Writing intermediate results to tempdb, 
       which incurs physical disk I/O, schema allocation, and manual cleanup.

   A Common Table Expression (CTE) solves this by defining a named, readable, 
   inline temporary result set that exists only for the duration of a single 
   statement (SELECT, INSERT, UPDATE, or DELETE).


   2. CORE IDEA & SYNTAX RULES
   ----------------------------------------------------------------------------
   - A CTE is declared using the `WITH` keyword followed by the query definition.
   - The semicolon (;) rule: T-SQL requires the statement immediately preceding 
     a `WITH` clause to terminate with a semicolon. The industry convention is 
     to prefix the CTE with `;WITH` to avoid batch syntax errors.
   - Single-statement scope: Once the primary query executing the CTE finishes, 
     the CTE disappears immediately from execution scope.


   3. HOW IT WORKS INTERNALLY (The Optimizer Reality)
   ----------------------------------------------------------------------------
   A common misconception is that CTEs materialize data into memory or tempdb 
   like a temporary table. They do NOT.

   The Query Optimizer treats a non-recursive CTE exactly like an inline VIEW 
   or derived table:
     - The CTE text is substituted directly into the outer query.
     - If you reference the same CTE twice in the outer query (e.g., self-join), 
       the CTE query is evaluated TWICE. It is not cached.

   [Inline Expansion Model]
   CTE Definition ──► Injected directly into Query Plan ──► Single Execution Tree


   4. COMPARISON: CTE vs. SUBQUERY vs. TEMP TABLE
   ----------------------------------------------------------------------------
   ┌───────────────┬─────────────────┬───────────────────┬────────────────────┐
   │ Feature       │ CTE             │ Derived Subquery  │ Temporary Table    │
   ├───────────────┼─────────────────┼───────────────────┼────────────────────┤
   │ Readability   │ High (top-down) │ Low (inside-out)  │ Moderate           │
   │ Reusability   │ In same query   │ Once only         │ Entire session     │
   │ Materialized? │ No (Virtual)    │ No (Virtual)      │ Yes (in tempdb)    │
   │ Indexing      │ No              │ No                │ Yes                │
   │ Recursion     │ Yes             │ No                │ No                 │
   └───────────────┴─────────────────┴───────────────────┴────────────────────┘


   5. PRACTICAL CODE EXAMPLES
   ---------------------------------------------------------------------------- */

USE C21_DB1;
GO

-- Clean up any previous test table
IF OBJECT_ID('dbo.Employees6', 'U') IS NOT NULL 
    DROP TABLE dbo.Employees6;
GO

CREATE TABLE Employees6 (
    EmployeeID INT PRIMARY KEY,
    Name       VARCHAR(50) NOT NULL,
    Department VARCHAR(50) NOT NULL,
    Sales      DECIMAL(10, 2) NOT NULL
);
GO

INSERT INTO Employees6 (EmployeeID, Name, Department, Sales) VALUES
(1, 'Khalid', 'Sales',       12000.00),
(2, 'Sarah',  'Sales',       18500.00),
(3, 'Omar',   'Engineering', 0.00),
(4, 'Reem',   'Sales',       9400.00),
(5, 'Fahad',  'HR',          0.00);
GO


-- ----------------------------------------------------------------------------
-- Example A: Simple Filtered CTE
-- ----------------------------------------------------------------------------
;WITH SalesStaff AS
(
    SELECT EmployeeID, Name, Sales
    FROM Employees6
    WHERE Department = 'Sales'
)
SELECT EmployeeID, Name, Sales
FROM SalesStaff
ORDER BY Sales DESC;
GO


-- ----------------------------------------------------------------------------
-- Example B: Multi-CTE Chaining (Pipelines)
-- You can define multiple CTEs separated by commas under a single WITH statement
-- ----------------------------------------------------------------------------
;WITH DepartmentTotals AS
(
    SELECT Department, SUM(Sales) AS TotalDepartmentSales
    FROM Employees6
    GROUP BY Department
),
HighYieldDepartments AS
(
    SELECT Department, TotalDepartmentSales
    FROM DepartmentTotals
    WHERE TotalDepartmentSales > 10000
)
SELECT e.Name, e.Department, e.Sales, d.TotalDepartmentSales
FROM Employees6 AS e
INNER JOIN HighYieldDepartments AS d
    ON e.Department = d.Department;
GO


/* ============================================================================
   6. WHEN NOT TO USE & PITFALLS
   ----------------------------------------------------------------------------
   - The Multi-Reference Trap: Referencing a complex, CPU-heavy CTE multiple 
     times in the same statement causes SQL Server to re-execute that expensive 
     logic for each reference. If a dataset is heavy and reused across multiple 
     joins, materialize it into a `#TempTable` instead.
   - Index Limitations: You cannot create an index on a CTE. If your intermediate 
     set has 500,000 rows and needs index seeks, write to `#TempTable` and index it.
   - Non-Terminated Preceding Statements: Forgetting the semicolon before `WITH` 
     triggers error 319 ("Incorrect syntax near the keyword 'with'").
   ============================================================================ */