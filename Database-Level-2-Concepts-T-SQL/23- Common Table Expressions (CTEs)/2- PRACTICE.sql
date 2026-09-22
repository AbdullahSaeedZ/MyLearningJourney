select * from Employees6;


/*
CHALLENGE 1: Department Averages & Comparison (Basic CTE + JOIN)
   ----------------------------------------------------------------------------
   - CTE Name: `DeptSales`
   - Goal: Calculate average sales per department.
   - Main Query: Join `DeptSales` to `Employees6` on `Department`.
   - Output: `Name`, `Department`, `Sales`, `AverageDepartmentSales` (DECIMAL(10,2)).
*/

;with DeptSales as
(
	select Department, cast(avg(Sales) as decimal(10,2)) as AvgSales from Employees6
	group by Department
)
select e.Name, e.Department, e.Sales, DeptSales.avgSales as AverageDepartmentSales
from Employees6 e
inner join DeptSales on DeptSales.Department = e.Department;

-------------------------------------------------------

/*
CHALLENGE 2: Top Performers Above Company Average (Chained CTEs + CROSS JOIN)
   ----------------------------------------------------------------------------
   - CTE 1: `OverallAvg` -> Calculate company-wide average sales (single scalar row).
   - CTE 2: `SalesAboveAvg` -> CROSS JOIN `Employees6` with `OverallAvg` 
             where `Sales > CompanyAvgSales`.
   - Main Query: Select `EmployeeID`, `Name`, `Sales` from `SalesAboveAvg` 
     ordered by `Sales DESC`.
*/

;with OverallAvg as
(
	select avg(Sales) as AllAvg from Employees6

),
SalesAboveAvg as
(
	select * 
	from Employees6 e
	cross join OverallAvg o
	where e.Sales > o.AllAvg
	
)
select Name, Department, Sales
from SalesAboveAvg 

/* ----------------------------------------------------------------------------
   NOTE: CROSS JOIN (Cartesian Product with a 1-Row Table)
   ----------------------------------------------------------------------------
   - A CROSS JOIN pairs every row from the left table with every row from 
     the right table (no ON clause).
   - When joining an N-row table to a 1-row aggregate table, the math is:
     N rows * 1 row = N rows.
   - It attaches the single scalar value to every detail row, allowing direct 
     row-by-row comparisons in WHERE or SELECT.

   Employees6 (5 rows)         OverallAvg (1 row)       Result of CROSS JOIN
   --------------------        ------------------       --------------------
   Khalid (12,000)      ──────►  [ 7,980 ]        ──►   Khalid | 12,000 | 7,980
   Sarah  (18,500)      ──────►  [ 7,980 ]        ──►   Sarah  | 18,500 | 7,980
   Omar   (0)           ──────►  [ 7,980 ]        ──►   Omar   |      0 | 7,980
   Reem   (9,400)       ──────►  [ 7,980 ]        ──►   Reem   |  9,400 | 7,980
   Fahad  (0)           ──────►  [ 7,980 ]        ──►   Fahad  |      0 | 7,980

   WARNING: WHY YOU MUST BE CAREFUL WITH CROSS JOIN
   ----------------------------------------------------------------------------
   When used on multi-row tables, row counts multiply exponentially (N * M):

   Table A (2 rows):  [Khalid], [Sarah]
   Table B (2 rows):  [Red], [Blue]

   A CROSS JOIN B:
   1. Khalid ─► Red
   2. Khalid ─► Blue
   3. Sarah  ─► Red
   4. Sarah  ─► Blue
   (2 * 2 = 4 total rows)

   If Table A has 10,000 rows and Table B has 10,000 rows, CROSS JOIN produces 
   100,000,000 rows, exhausting tempdb and crashing query performance.
   ---------------------------------------------------------------------------- */



   ---------------------

   /*
   CHALLENGE 3: Sales Ranking per Department (CTE + Window Function)
   ----------------------------------------------------------------------------
   - CTE Name: `RankedStaff`
   - Window Logic: Compute `ROW_NUMBER() OVER(PARTITION BY Department ORDER BY Sales DESC)` 
     as `SalesRank`.
   - Main Query: Filter `SalesRank = 1` and `Sales > 0.00`.
   - Output: Department top-performers (`Department`, `Name`, `Sales`).
   */


   ;with RankedStaff as
   (
		select *, ROW_NUMBER() over(partition by Department order by Sales desc) as SalesRank
		from Employees6
   )
   select * 
   from RankedStaff 
   where SalesRank = 1 and Sales > 0
