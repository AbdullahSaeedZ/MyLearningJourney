/*
====================================================================
PART 1: Pagination Using OFFSET and FETCH NEXT
====================================================================

1. THE PROBLEM (Why it exists)
--------------------------------------------------------------------
Database tables easily grow to millions of rows. Sending all records 
over the network to a client application (web page, desktop grid, or 
mobile screen) causes massive memory consumption, slow network transfer, 
and freezing user interfaces.

Applications need a standardized way to request data in discrete chunks 
(pages) on demand.


2. CORE IDEA & SYNTAX
--------------------------------------------------------------------
Introduced in SQL Server 2012, `OFFSET` and `FETCH NEXT` extend the 
`ORDER BY` clause to provide ANSI-standard row-skipping and paging.

- OFFSET: Defines how many rows to skip from the beginning.
- FETCH NEXT: Defines how many rows to return after skipping.

Golden Formula:
  OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
  FETCH NEXT @RowsPerPage ROWS ONLY;


3. HOW IT WORKS INTERNALLY (The Hidden Cost)
--------------------------------------------------------------------
`OFFSET` does NOT magically jump directly to the target record index. 
To guarantee accurate ordering, the SQL Server engine must read and 
sort all preceding rows before discarding them.

- Page 1  (Offset 0): Blazing fast. Reads rows 1 to 50.
- Page 10,000 (Offset 1,000,000 rows): Extremely slow. The engine scans and 
  sorts 1,000,000 preceding rows, throws them away, and then returns 
  the next 50 rows.


4. T-SQL IMPLEMENTATION
--------------------------------------------------------------------
*/

USE C21_DB1;

-- Define paging parameters (commonly passed by application backend)
DECLARE @PageNumber  INT = 2; -- Target page
DECLARE @RowsPerPage INT = 3; -- Page size

SELECT 
    StudentID,
    Name,
    [Subject],
    Grade
FROM Students
ORDER BY StudentID ASC -- Mandatory: Paging requires deterministic sorting
OFFSET (@PageNumber - 1) * @RowsPerPage ROWS
FETCH NEXT @RowsPerPage ROWS ONLY;

/*
Execution Walkthrough:
* If @PageNumber = 1: OFFSET 0  ROWS -> Returns rows 1 to 3.
* If @PageNumber = 2: OFFSET 3  ROWS -> Skips rows 1-3, returns rows 4 to 6.
* If @PageNumber = 3: OFFSET 6  ROWS -> Skips rows 1-6, returns rows 7 to 9.
*/


/*
5. WHEN TO USE & REAL-WORLD BEHAVIOR
--------------------------------------------------------------------
* BEST FOR:
  - Classic numbered UIs with direct page navigation (e.g., [1] [2] [3] ... [10]).
  - Small to medium datasets or administrative search grids.

* REAL-WORLD USER REALITY:
  Real humans rarely browse beyond page 3 or 4. If they do not find 
  what they need, they change search keywords, apply filters (date, 
  status, department), or alter the sort order. Therefore, OFFSET / FETCH 
  remains sufficient for most UI search forms despite its deep-paging flaw.

* OVER-ENGINEERING MISTAKE:
  Using OFFSET / FETCH for infinite scroll feeds (e.g., social feeds or 
  massive log viewers) where users scroll down thousands of records. 
  For that pattern, Keyset Pagination (File 2) is required.
*/