/* ============================================================================
   LESSON: Introduction to Cursors in T-SQL
   ============================================================================

   1. THE PROBLEM (Set-Based Engine vs. Procedural Requirements)
   ----------------------------------------------------------------------------
   Relational database engines are designed from the ground up to be SET-BASED. 
   They thrive when executing operations on thousands or millions of rows 
   simultaneously using relational algebra, parallel execution paths, and 
   optimized storage reads.

   However, developers coming from procedural languages (C++, C#, Java) often 
   instinctively look for a `foreach` or `while` loop to process records one by 
   one. A cursor is T-SQL's mechanism to force the engine to step through a query 
   result set iteratively, single row by single row.


   2. CORE IDEA
   ----------------------------------------------------------------------------
   A cursor is a database pointer that navigates through a result set row-by-row. 
   Instead of asking SQL Server to transform an entire table at once, a cursor:
     1. Declares a query to fetch a dataset into memory/tempdb.
     2. Opens the stream.
     3. Fetches a single row into local T-SQL variables.
     4. Performs work on those variables.
     5. Repeats until no rows remain (@@FETCH_STATUS != 0).
     6. Closes and deallocates the pointer.


   3. HOW IT WORKS INTERNALLY (Set-Based vs. Cursor Execution)
   ----------------------------------------------------------------------------

   [SET-BASED OPERATION] (Fast, parallel, single scan)
   Query Engine ──► Scans B-Tree Index ──► Modifies 10,000 Rows in 1 Pass ──► Done!


   [CURSOR OPERATION (RBAR: Row-By-Agonizing-Row)]
   Open Cursor ──► Allocates Worktable in tempdb / Holds Locks
       │
       ▼
   FETCH NEXT ──► Context Switch ──► Process Row 1 ──► Lock Row 1
       │
       ▼
   FETCH NEXT ──► Context Switch ──► Process Row 2 ──► Lock Row 2
       │
       ▼
   ... (Repeated 10,000 times: 10,000 context switches, high tempdb thrashing)


   4. THE PRIMARY CURSOR TYPES
   ----------------------------------------------------------------------------
   - STATIC: Takes a static tempdb snapshot; ignores database changes.
   - DYNAMIC: Fully dynamic; reflects all additions, edits, and deletions live.

   * Those are movement specifiers on cursor types:
   - FORWARD_ONLY: Can only step forward one row at a time.
   - SCROLL (or SCROLLABLE): Allows jumping anywhere (PRIOR, FIRST, LAST, ABSOLUTE).
   - FAST_FORWARD: Optimized FORWARD_ONLY + READ_ONLY cursor (best performer).


     T-SQL CURSOR DEFAULTS SUMMARY
    ----------------------------------------------------------------------------

    1. TYPE SPECIFIED, NO MOVEMENT SPECIFIER:
       - Declaring STATIC  alone  ──► Defaults to SCROLL (STATIC SCROLL)
       - Declaring DYNAMIC alone  ──► Defaults to SCROLL (DYNAMIC SCROLL)
       - Declaring KEYSET  alone  ──► Defaults to SCROLL (KEYSET SCROLL)

    2. NEITHER TYPE NOR MOVEMENT SPECIFIED:
       - Blank declaration (DECLARE c CURSOR FOR ...) 
         ──► Defaults to DYNAMIC FORWARD_ONLY (or KEYSET if lacking unique indexes)


   5. PERFORMANCE RISKS: WHY CURSORS ARE A LAST RESORT
   ----------------------------------------------------------------------------
   - The RBAR Trap: "Row-By-Agonizing-Row" processing destroys the cost-based 
     query optimizer's ability to parallelize execution.
   - Tempdb Contention: Cursors spill result sets into tempdb, degrading I/O 
     throughput across the entire server.
   - Locking & Blocking: Keeping a cursor open holds shared or exclusive locks 
     far longer than standard queries, starving concurrent users.


   6. WHEN TO USE (THE ~1% EXCEPTION)
   ----------------------------------------------------------------------------
   Avoid cursors. Only use them when set-based logic is impossible:
   1. Running admin scripts per database/index (e.g., dynamic maintenance).
   2. Calling a single-row legacy Stored Procedure in a loop.
   ============================================================================ */