/*
====================================================================
PART 2: Keyset Pagination (The Seek Method)
====================================================================

1. THE PROBLEM (Why it exists)
--------------------------------------------------------------------
As seen in Part 1, OFFSET/FETCH degrades severely on deep pages 
(OFFSET 1,000,000 rows) because the database engine must scan and discard 
all preceding rows.

Additionally, OFFSET suffers from the "Drift Bug": if a new row is 
inserted or deleted while a user navigates between pages, rows shift, 
causing users to see duplicate rows or skip records entirely.


2. CORE IDEA
--------------------------------------------------------------------
Keyset Pagination (also known as the Seek Method) eliminates row skipping. 
Instead of passing an arbitrary offset number, the application tracks 
the unique key (e.g., ID, Timestamp) of the last item received on 
the current page.

The next page simply queries: 
"Give me the next N rows where ID > @LastSeenID ordered by ID ASC."


3. HOW IT WORKS INTERNALLY
--------------------------------------------------------------------
* Direct B-Tree Navigation (Index Seek):
  Because the query filters using `WHERE ID > @LastSeenID`, SQL Server 
  does not scan prior records. It performs a direct Index Seek to the 
  exact leaf page containing `@LastSeenID` and reads only the requested rows.

* Time Complexity:
  - OFFSET / FETCH : O(N) where N is the total rows prior to the page.
  - Keyset Pagination: O(K) where K is strictly the page size fetched.
  - Performance remains identical whether requesting Page 1 or Page 100,000.


4. T-SQL IMPLEMENTATION
--------------------------------------------------------------------
*/

USE C21_DB1;

-- Page size configuration
DECLARE @RowsPerPage INT = 3;

-- STEP 1: Fetching the very first page
-- On the first page, no reference ID exists yet.
SELECT TOP (@RowsPerPage)
    StudentID,
    Name,
    [Subject],
    Grade
FROM Students
ORDER BY StudentID ASC;

-- The client/API receives the data and saves the last primary key.
-- Suppose the last row returned had StudentID = 3.


-- STEP 2: Fetching the next page (Keyset Seek)
-- The application sends back @LastStudentID to retrieve subsequent records.
DECLARE @LastStudentID INT = 3; 

SELECT TOP (@RowsPerPage)
    StudentID,
    Name,
    [Subject],
    Grade
FROM Students
WHERE StudentID > @LastStudentID -- Direct index entry point
ORDER BY StudentID ASC;


/*
5. IMPLEMENTATION REQUIREMENTS & CONSTRAINTS
--------------------------------------------------------------------
* Mandatory Index:
  The column(s) used in the WHERE and ORDER BY clauses (e.g., StudentID) 
  must have an index (Clustered or Non-Clustered). Without an index, 
  it falls back to a table scan.

* Uniqueness Requirement:
  The sort key must be strictly unique. If sorting by non-unique columns 
  (e.g., Grade or CreatedDate), append a tie-breaker:
  `ORDER BY Grade DESC, StudentID ASC`

* Navigation Limitation:
  Keyset pagination does NOT support arbitrary jumping (e.g., "Jump to Page 42"). 
  It only supports sequential navigation: Next and Previous.
*/