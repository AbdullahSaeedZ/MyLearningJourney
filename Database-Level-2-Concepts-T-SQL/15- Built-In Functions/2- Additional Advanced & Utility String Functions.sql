/*
====================================================================
SECTION: Additional Advanced & Utility String Functions
====================================================================
*/

-- 1. STRING_AGG
-- Definition:
-- Aggregates column values across multiple rows into a single delimited 
-- string within a GROUP BY scope (SQL Server 2017+). Replaces legacy XML hacks.

DROP TABLE IF EXISTS #Employees;
CREATE TABLE #Employees (Department VARCHAR(30), Name VARCHAR(50));
INSERT INTO #Employees VALUES 
('IT', 'Fahad'), ('IT', 'Saud'), ('HR', 'Mona');

SELECT 
    Department, 
    STRING_AGG(Name, ', ') AS EmployeeNames, 
    COUNT(*) AS EmployeeCount
FROM #Employees
GROUP BY Department;
-- Output:
-- Department | EmployeeNames | EmployeeCount
-- HR         | Mona          | 1
-- IT         | Fahad, Saud   | 2

DROP TABLE #Employees;


-- 2. CONCAT_WS (Concatenate With Separator)
-- Definition:
-- Joins multiple strings using a separator specified in the first argument. 
-- Crucially, it skips NULL values automatically without leaving dangling delimiters.

SELECT CONCAT_WS(', ', 'Riyadh', NULL, 'Saudi Arabia', '11564') AS [Address];
-- Output: 'Riyadh, Saudi Arabia, 11564'


-- 3. DIFFERENCE
-- Definition:
-- Evaluates the phonetic similarity of two strings using the SOUNDEX algorithm. 
-- Returns an integer from 0 (completely different) to 4 (strong phonetic match).

SELECT 
    DIFFERENCE('Smith', 'Smyth') AS [CloseMatch],      -- Output: 4
    DIFFERENCE('Abdullah', 'Abdalla') AS [NearMatch],  -- Output: 4
    DIFFERENCE('Apple', 'Banana') AS [NoMatch];        -- Output: 1 or 0


-- 4. STRING_SPLIT
-- Definition:
-- A table-valued function that parses a delimited string and transforms it 
-- into a relational set of rows. Ideal for passing CSV arrays into WHERE IN (...).

SELECT value 
FROM STRING_SPLIT('Red,Green,Blue,Yellow', ',');
-- Output:
-- value
-- -----
-- Red
-- Green
-- Blue
-- Yellow


-- 5. PATINDEX
-- Definition:
-- Returns the 1-based starting position of a pattern inside a string. 
-- Unlike CHARINDEX, it supports wildcards (% and _) and regex-style character ranges.

SELECT PATINDEX('%[0-9]%', 'Order#98432') AS [FirstDigitPosition];
-- Output: 7 (the position where digit '9' starts)


-- 6. REPLICATE
-- Definition:
-- Repeats a string value a specified number of times. Often used for manual 
-- zero-padding, formatting masks, or fixed-width text generation.

SELECT REPLICATE('0', 5 - LEN('42')) + '42' AS [ZeroPaddedID];
-- Output: '00042'