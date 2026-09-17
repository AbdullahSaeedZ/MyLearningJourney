/*
1. THE PROBLEM (Why they exist)
--------------------------------------------------------------------
Pulling millions of raw rows to an application to compute business metrics 
like totals or averages wastes network bandwidth and memory. Summary math 
belongs directly on the database engine.


2. CORE IDEA
--------------------------------------------------------------------
Aggregate functions process a set of values across multiple rows and 
condense them into a single summary value. When combined with GROUP BY, 
the calculation runs independently for each distinct group.


3. QUERY DESIGN RULES (When & How to use them)
--------------------------------------------------------------------
* Grouping Rule:
  Any column in your SELECT list that is not inside an aggregate function 
  MUST be included in the GROUP BY clause.

* Filtering Rule (WHERE vs HAVING):
  - Use WHERE to filter rows BEFORE the calculation happens (e.g., active accounts only).
  - Use HAVING to filter results AFTER the calculation happens (e.g., total sales > 10,000).

* NULL Awareness:
  Aggregates (like SUM, AVG, MIN, MAX) automatically ignore NULL values. 
  COUNT(*) counts every row regardless of NULLs, while COUNT(Column) only 
  counts rows where that specific column contains data.
*/

-- Setup simulated table
DROP TABLE IF EXISTS #Employees2;
CREATE TABLE #Employees2 (
    EmployeeID INT IDENTITY(1,1),
    Department VARCHAR(50),
    Salary DECIMAL(10, 2),
    PerformanceRating DECIMAL(3, 2) NULL -- Notice nullable column
);

INSERT INTO #Employees2 (Department, Salary, PerformanceRating)
VALUES 
    ('IT', 12000.00, 4.5),
    ('IT', 15000.00, 4.8),
    ('IT', 9000.00,  NULL), -- Rating is missing
    ('HR', 8000.00,  3.8),
    ('HR', 9500.00,  4.2);


-- 1. COUNT(): Row count per group
-- Returns total rows matching each department
SELECT 
    Department, 
    COUNT(*) AS EmployeeCount
FROM #Employees2
GROUP BY Department;


-- 2. SUM(): Total numeric sum across rows
-- Computes the total payroll per department
SELECT 
    Department, 
    SUM(Salary) AS TotalSalary
FROM #Employees2
GROUP BY Department;


-- 3. AVG(): Arithmetic mean
-- Computes average rating; skips the NULL row for IT automatically
SELECT 
    Department, 
    AVG(PerformanceRating) AS AvgPerformanceRating
FROM #Employees2
GROUP BY Department;


-- 4. MIN() & MAX(): Minimum and Maximum values
-- Retrieves lowest and highest salary across the entire company (no GROUP BY needed)
SELECT 
    MIN(Salary) AS LowestSalary,
    MAX(Salary) AS HighestSalary
FROM #Employees2;


-- 5. COUNT(DISTINCT): Counting unique entries
-- Counts how many unique compensation levels exist per department
SELECT 
    Department, 
    COUNT(DISTINCT Salary) AS DistinctSalaryLevels
FROM #Employees2
GROUP BY Department;

DROP TABLE #Employees2;


/*
5. WHEN NOT TO USE THEM & COMMON MISTAKES
--------------------------------------------------------------------
* DON'T confuse WHERE with HAVING:
  - `WHERE` filters rows BEFORE aggregation occurs.
  - `HAVING` filters aggregated results AFTER groups are computed.
  -- Example:
  -- WHERE Salary > 5000       -> filters individual employees
  -- HAVING SUM(Salary) > 20000 -> filters aggregated departments

* DON'T assume AVG() accounts for NULL values as zero:
  Values: (10, 20, NULL). 
  `AVG()` evaluates to (10 + 20) / 2 = 15. 
  If NULL should count as 0, use: `AVG(ISNULL(PerformanceRating, 0))`.

* DON'T select non-aggregated columns without grouping them:
  Every column in the `SELECT` list must either be inside an aggregate 
  function or listed in the `GROUP BY` clause.


6. OFFICIAL MICROSOFT REFERENCE
--------------------------------------------------------------------
Full technical documentation and advanced aggregate functions (APPROX_COUNT_DISTINCT, STDEV, etc.):
https://learn.microsoft.com/en-us/sql/t-sql/functions/aggregate-functions-transact-sql?view=sql-server-ver16
*/