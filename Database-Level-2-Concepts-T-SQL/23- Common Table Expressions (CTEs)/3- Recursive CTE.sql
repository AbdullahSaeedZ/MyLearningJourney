/* ============================================================================
   LESSON: UNION, UNION ALL, AND RECURSIVE CTES IN T-SQL
   ============================================================================

   PART 1: UNDERSTANDING UNION VS. UNION ALL
   ----------------------------------------------------------------------------
   Before looking at recursion, you need to understand how SQL Server stacks 
   two queries on top of each other.

   Think of queries like buckets of blocks:
     - `UNION` stacks the buckets, inspects every row, and THROWS AWAY duplicates.
     - `UNION ALL` stacks the buckets and dumps EVERYTHING together directly.


   ASCII DIAGRAM: UNION VS. UNION ALL
   ----------------------------------------------------------------------------

   Bucket A:  [ 1 ] , [ 2 ]
   Bucket B:  [ 2 ] , [ 3 ]

   1. USING UNION (Removes duplicates, sorts/hashes the data):

      Bucket A [ 1, 2 ]
             +           ──►  [Distinct Filter]  ──►  Result: [ 1 ]
      Bucket B [ 2, 3 ]                                       [ 2 ]  (one '2' dropped)
                                                              [ 3 ]

   2. USING UNION ALL (Blindly appends, zero checks, super fast):

      Bucket A [ 1, 2 ]
             +           ──►  [Append Direct]   ──►  Result: [ 1 ]
      Bucket B [ 2, 3 ]                                      [ 2 ]
                                                             [ 2 ]  (both kept!)
                                                             [ 3 ]


   T-SQL CODE: UNION VS. UNION ALL IN ACTION
   ---------------------------------------------------------------------------- */

USE C21_DB1;
GO

-- Example 1: UNION removes the duplicate 'Coffee'
SELECT 'Coffee' AS Item
UNION
SELECT 'Coffee' AS Item;
-- Result: 1 row ('Coffee')


-- Example 2: UNION ALL keeps both rows
SELECT 'Coffee' AS Item
UNION ALL
SELECT 'Coffee' AS Item;
-- Result: 2 rows ('Coffee', 'Coffee')
GO


/* ============================================================================
   PART 2: RECURSIVE CTES (LOOPS IN SQL)
   ============================================================================

   1. THE PROBLEM
   ----------------------------------------------------------------------------
   SQL is built for flat tables. But what if you need to generate a series of 
   numbers (1, 2, 3, 4, 5) or walk down a family tree?
   
   You need a way to loop. A Recursive CTE is simply a query that calls itself 
   until a stopping rule says "stop."


   2. THE 3 REQUIRED PIECES
   ----------------------------------------------------------------------------
   Every recursive CTE needs:
     1. The Anchor (Where to start)
     2. UNION ALL  (The glue - SQL Server strictly requires UNION ALL here)
     3. The Recursive Step (How to get the next row + when to stop)


   ASCII DIAGRAM: HOW THE RECURSIVE LOOP WORKS
   ----------------------------------------------------------------------------

   Let's generate numbers from 1 to 3:

   STEP 0: RUN THE ANCHOR (Executes only once)
   ┌───────────────────────┐
   │ Anchor: SELECT 1      │ ──► Produces: [ 1 ]
   └───────────────────────┘
                                   │
                                   ▼
   STEP 1: RUN RECURSIVE QUERY ON PREVIOUS RESULT
   ┌───────────────────────┐
   │ Input:  [ 1 ]         │
   │ Action: 1 + 1         │ ──► Produces: [ 2 ]
   │ Check:  2 <= 3 ? YES  │
   └───────────────────────┘
                                   │
                                   ▼
   STEP 2: RUN RECURSIVE QUERY ON PREVIOUS RESULT
   ┌───────────────────────┐
   │ Input:  [ 2 ]         │
   │ Action: 2 + 1         │ ──► Produces: [ 3 ]
   │ Check:  3 <= 3 ? YES  │
   └───────────────────────┘
                                   │
                                   ▼
   STEP 3: RUN RECURSIVE QUERY ON PREVIOUS RESULT
   ┌───────────────────────┐
   │ Input:  [ 3 ]         │
   │ Action: 3 + 1         │ ──► Produces: [ 4 ]
   │ Check:  4 <= 3 ? NO!  │ ──► STOP! (Returns 0 rows, loop ends)
   └───────────────────────┘
                                   │
                                   ▼
   FINAL STACKED OUTPUT (UNION ALL):
   [ 1 ]
   [ 2 ]
   [ 3 ]


   3. PRACTICAL CODE: NUMBER GENERATOR
   ---------------------------------------------------------------------------- */

;WITH CountToThree AS
(
    -- 1. ANCHOR: Start at 1
    SELECT 1 AS MyNumber

    UNION ALL

    -- 2. RECURSIVE STEP: Take previous number, add 1
    SELECT MyNumber + 1 FROM CountToThree WHERE MyNumber < 3  -- 3. STOP CONDITION: Stop when MyNumber reaches 3
)
SELECT MyNumber FROM CountToThree;
GO

/* ============================================================================
   HOW RECURSIVE CTES ACTUALLY WORK INTERNALLY
   ============================================================================

   1. THE ANCHOR IS A "ONE-TIME LAUNCHPAD"
   ----------------------------------------------------------------------------
   The Anchor query runs EXACTLY ONCE at the very start (T = 0).
   - It produces the initial seed row: [ 1 ].
   - The engine saves [ 1 ] into the final results and passes it to the loop.
   - The Anchor is NEVER touched, re-evaluated, or re-run again.


   2. WHAT KEYWORD ACTUALLY TRIGGERS THE RECURSION?
   ----------------------------------------------------------------------------
   There is NO special keyword like "RECURSE" or "LOOP".
   
   The recursion is triggered solely by the self-reference in the FROM clause:
   
          FROM CountToThree  <-- THIS IS THE TRIGGER
   
   When SQL Server sees the CTE referencing its OWN NAME inside its own definition, 
   the query optimizer treats it as a recursive stream rather than a normal table.


   3. THE ENGINE'S HIDDEN "CONVEYOR BELT"
   ----------------------------------------------------------------------------
   Internally, SQL Server uses an operator called the Index Spool (a hidden queue):

   [Launchpad]
   Anchor runs ONCE ──► produces [ 1 ] ──► dropped onto conveyor belt
                                                 │
                                                 ▼
   ┌─────────────────────────────────────────────────────────────┐
   │ THE LOOP (Only the Recursive Member below UNION ALL runs):  │
   │                                                             │
   │  1. Pulls [ 1 ] from belt ──► 1 + 1 = [ 2 ] ──► onto belt  │
   │  2. Pulls [ 2 ] from belt ──► 2 + 1 = [ 3 ] ──► onto belt  │
   │  3. Pulls [ 3 ] from belt ──► 3 < 3 is FALSE ──► belt empty │
   └─────────────────────────────────────────────────────────────┘
                                                 │
                                                 ▼
   Belt is empty ──► The engine halts. ──► Returns [ 1, 2, 3 ].


   4. SUMMARY FOR YOUR PRACTICE FILE
   ----------------------------------------------------------------------------
   - Anchor: Starts the process once, then goes dormant.
   - Trigger: The CTE name inside `FROM <CTEName>` tells the engine to pull from 
     the previous step's output.
   - Loop Body: The query below `UNION ALL` is the only part that loops.
   - Stop Signal: The loop ends when `WHERE` returns zero rows.
   ============================================================================ */



   -- printing even numbers:

   ;with EvenNumbers as
   (
        select 0 as AnchorNumber
        
        union all

        select AnchorNumber + 2 from EvenNumbers where AnchorNumber < 10
   )
   select * from EvenNumbers;


/* ============================================================================
   PART 4: SAFETY RULE (INFINITE LOOPS)
   ----------------------------------------------------------------------------
   If you forget the WHERE condition (or write a bad one), the loop runs forever.
   
   To protect your server, SQL Server stops the query automatically after 
   100 loops with this error:
   "The statement terminated. The maximum recursion 100 has been exhausted..."

   If you intentionally need to loop more than 100 times, you tell SQL Server 
   at the very bottom using `OPTION (MAXRECURSION <number>)`:

   ;WITH Numbers AS ( ... )
   SELECT * FROM Numbers
   OPTION (MAXRECURSION 500); -- Allows up to 500 loops
   ============================================================================ */