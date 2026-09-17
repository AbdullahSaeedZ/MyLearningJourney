/*
====================================================================
LESSON: Essential T-SQL String Functions
====================================================================

1. THE PROBLEM (Why they exist)
--------------------------------------------------------------------
Text data rarely enters a database clean. Queries need direct, built-in 
ways to sanitize whitespace, parse delimiters, handle casing, and 
reshape strings before sending them to client apps.


2. CORE IDEA
--------------------------------------------------------------------
Built-in scalar functions process text (VARCHAR, NVARCHAR, CHAR) 
row-by-row inside SELECT, WHERE, and GROUP BY operations.


3. HOW THEY WORK INTERNALLY
--------------------------------------------------------------------
* 1-Based Indexing: SQL Server starts positions at 1, not 0.
* Trailing Spaces: LEN() excludes trailing spaces; DATALENGTH() counts total bytes.
* SARGability Impact: Wrapping a column in a function inside a WHERE clause 
  (e.g., WHERE UPPER(Email) = 'X') prevents an Index Seek and triggers a full scan.


4. T-SQL PRACTICAL EXAMPLES
--------------------------------------------------------------------
*/

-- Test variable
DECLARE @Text VARCHAR(50) = '  Hello World!  ';

-- 1. LEN: Character count (excludes trailing spaces)
SELECT LEN(@Text) AS [LenResult]; 
-- Output: 14

-- 2. UPPER: Converts to uppercase
SELECT UPPER('john doe') AS [UpperResult]; 
-- Output: 'JOHN DOE'

-- 3. LOWER: Converts to lowercase
SELECT LOWER('Admin_USER') AS [LowerResult]; 
-- Output: 'admin_user'

-- 4. SUBSTRING: Extracts a slice (expression, start_position, length)
SELECT SUBSTRING('Database', 1, 4) AS [SubstringResult]; 
-- Output: 'Data'

-- 5. CHARINDEX: Finds substring position (target, source_string)
SELECT CHARINDEX('Server', 'SQL Server 2022') AS [CharIndexResult]; 
-- Output: 5

-- 6. REPLACE: Replaces all target matches with a new value
SELECT REPLACE('2026-09-17', '-', '/') AS [ReplaceResult]; 
-- Output: '2026/09/17'

-- 7. LTRIM: Strips leading spaces
SELECT LTRIM('   SQL') AS [LTrimResult]; 
-- Output: 'SQL'

-- 8. RTRIM: Strips trailing spaces
SELECT RTRIM('SQL   ') + '<-End' AS [RTrimResult]; 
-- Output: 'SQL<-End'

-- 9. CONCAT: Joins strings safely (automatically converts NULL to empty string)
SELECT CONCAT('User', '_', 101, NULL, '@domain.com') AS [ConcatResult]; 
-- Output: 'User_101@domain.com'

-- 10. LEFT: Takes N characters from start
SELECT LEFT('Order-98432', 5) AS [LeftResult]; 
-- Output: 'Order'

-- 11. RIGHT: Takes N characters from end
SELECT RIGHT('Order-98432', 5) AS [RightResult]; 
-- Output: '98432'

-- 12. TRIM: Strips both leading and trailing spaces (SQL Server 2017+)
SELECT TRIM('   clean text   ') AS [TrimResult]; 
-- Output: 'clean text'



/*
5. WHEN NOT TO USE THEM & COMMON MISTAKES
--------------------------------------------------------------------
* DON'T wrap indexed columns with functions in WHERE filters (breaks Index Seek).
* DON'T use '+' to concatenate nullable columns; use CONCAT() instead.
* DON'T confuse LEN() with DATALENGTH():
  - LEN('A ') = 1 (drops trailing spaces).
  - DATALENGTH(N'A') = 2 (measures storage bytes; NVARCHAR is 2 bytes/char).


6. OFFICIAL MICROSOFT REFERENCE
--------------------------------------------------------------------
Full list (PATINDEX, STRING_AGG, STRING_SPLIT, STUFF, etc.):
https://learn.microsoft.com/en-us/sql/t-sql/functions/string-functions-transact-sql?view=sql-server-ver16
*/