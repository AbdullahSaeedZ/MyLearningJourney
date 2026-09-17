/*
====================================================================
LESSON: Essential T-SQL Date & Time Functions
====================================================================

1. CORE IDEA
--------------------------------------------------------------------
T-SQL provides scalar temporal functions to retrieve current system time, 
extract specific date intervals (year, month, day), perform date math 
(additions, differences), and convert between binary temporal structures 
and human-readable string formats.

2. HOW THEY WORK INTERNALLY
--------------------------------------------------------------------
* SARGability Impact:
  Wrapping date columns in functions (e.g., `WHERE YEAR(OrderDate) = 2026`) 
  invalidates index usage (causes full table scans). Use range boundaries 
  instead: `WHERE OrderDate >= '2026-01-01' AND OrderDate < '2027-01-01'`.


*/

-- Setup a base reference date for examples
DECLARE @TargetDate DATETIME2 = '2026-09-17 14:30:45.1234567';


-- 1. GETDATE()
-- Definition: Returns current database server date and time as DATETIME (3ms accuracy).
SELECT GETDATE() AS [GetDateResult];


-- 2. SYSDATETIME()
-- Definition: Returns current server date and time as DATETIME2(7) (100ns accuracy).
SELECT SYSDATETIME() AS [SysDateTimeResult];


-- 3. DATEADD()
-- Definition: Adds or subtracts a specific count of datepart units to a date.
SELECT DATEADD(day, 14, @TargetDate) AS [TwoWeeksLater],
       DATEADD(month, -1, @TargetDate) AS [OneMonthPrior];


-- 4. DATEDIFF()
-- Definition: Counts boundary crossings of a specified unit between two dates.
SELECT DATEDIFF(day, '2026-01-01', @TargetDate) AS [DaysPassedThisYear];


-- 5. DATEPART()
-- Definition: Returns an integer representing a specific part of a date.
SELECT DATEPART(quarter, @TargetDate) AS [CurrentQuarter],
       DATEPART(hour, @TargetDate) AS [Hour24];


-- 6. DATENAME()
-- Definition: Returns a localized character string representing the date part.
SELECT DATENAME(weekday, @TargetDate) AS [DayName],     -- e.g., 'Thursday'
       DATENAME(month, @TargetDate) AS [MonthName];     -- e.g., 'September'


-- 7. DAY(), MONTH(), YEAR()
-- Definition: Shorthand integer extractors for standard calendar components.
SELECT 
    DAY(@TargetDate)   AS [DayNumber],   -- 17
    MONTH(@TargetDate) AS [MonthNumber], -- 9
    YEAR(@TargetDate)  AS [YearNumber];  -- 2026


-- 8. EOMONTH()
-- Definition: Computes the last day of the month for the specified date (SQL Server 2012+).
SELECT EOMONTH(@TargetDate) AS [EndOfCurrentMonth],
       EOMONTH(@TargetDate, 1) AS [EndOfNextMonth]; -- Optional month offset


-- 9. CAST()
-- Definition: ANSI-standard conversion between compatible data types.
SELECT CAST(@TargetDate AS DATE) AS [DateOnly],
       CAST(@TargetDate AS TIME(0)) AS [TimeWithoutFraction];


-- 10. CONVERT()
-- Definition: SQL Server-specific conversion supporting explicit regional style numbers.
-- Style 120 = Canonical ODBC (yyyy-mm-dd hh:mi:ss)
-- Style 103 = British/French standard (dd/mm/yyyy)
SELECT CONVERT(VARCHAR(10), @TargetDate, 120) AS [ODBC_Date],
       CONVERT(VARCHAR(10), @TargetDate, 103) AS [UK_Date];


-- 11. DATEFROMPARTS()
-- Definition: Assembles whole numbers directly into a valid DATE data type.
SELECT DATEFROMPARTS(2026, 9, 17) AS [ConstructedDate];


-- 12. ISDATE()
-- Definition: Validates whether an expression evaluates to a recognized date/time value.
-- Returns 1 (valid) or 0 (invalid).
SELECT ISDATE('2026-09-17') AS [IsValidDate],
       ISDATE('2026-02-31') AS [IsInvalidDate];


/*
5. WHEN NOT TO USE THEM & COMMON MISTAKES
--------------------------------------------------------------------
* DON'T filter indexed columns with date extractors:
  -- BAD (Non-SARGable; scans whole table):
  -- WHERE YEAR(OrderDate) = 2026 AND MONTH(OrderDate) = 9
  -- GOOD (SARGable; utilizes Index Seek):
  -- WHERE OrderDate >= '2026-09-01' AND OrderDate < '2026-10-01'

* DON'T use FORMAT() for high-volume row processing:
  `FORMAT(OrderDate, 'yyyy-MM-dd')` relies on the .NET CLR runtime internally 
  and is significantly slower than native `CONVERT()` when running over 
  millions of rows.

* DON'T assume DATEDIFF checks elapsed duration:
  `DATEDIFF(year, '2025-12-31', '2026-01-01')` returns 1, even though 
  only 24 hours elapsed.


6. OFFICIAL MICROSOFT REFERENCE
--------------------------------------------------------------------
Full technical documentation and additional functions:
https://learn.microsoft.com/en-us/sql/t-sql/functions/date-and-time-data-types-and-functions-transact-sql?view=sql-server-ver16
*/