/*
====================================================================
PART 3: Plain Comparison - OFFSET vs. Keyset
====================================================================

1. HOW EACH METHOD ACTUALLY WORKS (Visualized)
--------------------------------------------------------------------

A) OFFSET / FETCH (The "Count and Throw Away" Method)
   Imagine reading a book where you must count every single previous 
   page by hand before reading the page you want.

   Target: Page 10,000 (Rows 100,001 to 100,010)

   [Row 1] -> [Row 2] ... -> [Row 100,000] =====> [Row 100,001 to 100,010]
   |-------------------------------------|       |----------------------|
        SQL Server reads and counts                   SQL Server finally
        100,000 rows, then throws                     returns these 10 rows!
        them directly into the trash.                 (Huge waste of CPU)


B) KEYSET PAGINATION (The "Bookmark" Method)
   Instead of counting from page 1, you remember the last ID you saw 
   and jump straight there using the index.

   Target: Next 10 rows after StudentID = 500

   Index Tree (B-Tree Bookmark Jump)
               [ Root ]
              /        \
         [ 1-250 ]   [ 251-500+ ]
                          \
                   Direct jump to ID > 500 ====> [501, 502, 503... 510]
                                                 (Reads only 10 rows. Zero waste)


2. THE "DATA DRIFT" PROBLEM (Why OFFSET can show duplicates)
--------------------------------------------------------------------
Scenario: Page size = 2 rows.

Initial Data: 
Row 1: Emma (ID 1)
Row 2: Alice (ID 2)
Row 3: Bob (ID 3)
Row 4: Dave (ID 4)

User views Page 1:
- Gets: Emma (ID 1), Alice (ID 2)

While user looks at Page 1, someone inserts a new student: "Aaron" (ID 0)
New Data order: [Aaron, Emma, Alice, Bob, Dave]

User clicks Page 2 using OFFSET 2:
- Engine skips first 2 rows (Aaron, Emma)
- Engine returns next 2 rows: Alice (ID 2) and Bob (ID 3)

Result: The user sees "Alice" twice!
Keyset avoids this completely because it asks for "ID > 2", never relying 
on row position.


3. SUMMARY COMPARISON
--------------------------------------------------------------------
Feature             OFFSET / FETCH              Keyset (Seek)
------------------+---------------------------+---------------------
How it finds data  | Counts from row 1         | Jumps straight to ID
Speed on page 1    | Very Fast                 | Very Fast
Speed on page 1000 | Very Slow                 | Very Fast
Jump to page 5?    | Yes (Easy)                | No (Next/Prev only)
Duplicate on add?  | Yes (Prone to drift)      | No (Rock solid)
Best UI fit        | Buttons: [1] [2] [3]      | "Load More" / Scroll


4. SIMPLE DECISION RULE
--------------------------------------------------------------------
* Use OFFSET if:
  You are building a normal admin dashboard with page buttons (1, 2, 3...) 
  and the table has filters that keep results reasonably small.

* Use Keyset if:
  You have millions of rows, an infinite-scroll mobile feed, or an API 
  where performance cannot slow down on later pages.
*/




/*
====================================================================
WARNING: Keyset Pagination with UUIDs / Non-Sequential IDs
====================================================================

1. THE PITFALL (Why standard UUID breaks Keyset)
--------------------------------------------------------------------
Keyset pagination relies strictly on monotonic ordering (values that 
reliably increase, like 1, 2, 3...).

Standard GUIDs/UUIDs (e.g., generated via NEWID() in T-SQL or Guid.NewGuid() 
in C#) are mathematically random:
  Page 1 last row: 'a3f8...'
  Page 2 seeks:    WHERE ID > 'a3f8...'

Because random UUIDs do not reflect chronological or insertion order, 
evaluating `>` will randomly skip records or return previously seen rows. 
Keyset completely fails.


2. THE 3 PRACTICAL SOLUTIONS
--------------------------------------------------------------------

APPROACH 1: Pair the UUID with a Timestamp / Tie-Breaker (Most Common)
----------------------------------------------------------------------
Keep the UUID as your unique identity, but order and seek by the creation 
date first. Use the UUID strictly to break ties when two records share 
the exact same millisecond:

  -- Step 1: Composite Index
  -- CREATE NONCLUSTERED INDEX IX_Orders_Paging ON dbo.Orders (CreatedAt ASC, OrderUUID ASC);

  -- Step 2: Querying the next page
  DECLARE @LastCreatedAt DATETIME2 = '2026-09-18 10:15:30.1234567';
  DECLARE @LastUUID      UNIQUEIDENTIFIER = 'D4F8...';

  SELECT TOP (10)
      OrderUUID,
      CreatedAt,
      CustomerName
  FROM dbo.Orders
  WHERE (CreatedAt > @LastCreatedAt)
     OR (CreatedAt = @LastCreatedAt AND OrderUUID > @LastUUID)
  ORDER BY CreatedAt ASC, OrderUUID ASC;


APPROACH 2: Sequential GUIDs (NEWSEQUENTIALID)
----------------------------------------------------------------------
If you must use a GUID as the sole clustering and paging key, generate 
them using SQL Server's native `NEWSEQUENTIALID()` instead of random `NEWID()`.
- It creates globally unique identifiers that increment sequentially.
- Warning: Sequential GUIDs reset their sequence after Windows restarts, 
  so Approach 1 (pairing with CreatedAt) remains safer for strict timeline paging.


APPROACH 3: Modern UUIDv7
----------------------------------------------------------------------
If using modern application frameworks (e.g., .NET 9+ `Guid.CreateVersion7()`), 
UUIDv7 embeds a Unix millisecond timestamp directly into the first 48 bits 
of the GUID:
- It is naturally time-ordered and sortable.
- A plain `WHERE GuidID > @LastSeenGuid` works out of the box while 
  retaining the benefits of a distributed UUID.
*/