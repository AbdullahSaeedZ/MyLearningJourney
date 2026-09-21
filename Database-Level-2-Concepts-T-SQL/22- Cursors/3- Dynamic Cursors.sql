/* ============================================================================
   LESSON: DYNAMIC Cursors in T-SQL (Complete Deep-Dive)
   ============================================================================

   1. THE PROBLEM (Why DYNAMIC Cursors Exist)
   ----------------------------------------------------------------------------
   When processing records one-by-one in an active database, a STATIC cursor 
   takes a disconnected snapshot into tempdb. 

   If another user or background job inserts a critical row, edits a status, 
   or deletes a record while your cursor is running, a STATIC cursor remains 
   blind to those updates because it only reads from its stale snapshot.

   A DYNAMIC cursor keeps the data stream live. As the cursor pointer moves, 
   it queries the actual underlying index and data pages, seeing updates, 
   newly inserted rows, and deletions in real time.


   2. CORE IDEA & INTERNAL FLOW
   ----------------------------------------------------------------------------
   Instead of copying the full result set to tempdb:
   - The engine establishes a dynamic cursor position against the base table.
   - Each FETCH command navigates directly across the table's index structure.
   - Any row added ahead of the current pointer position will naturally be 
     encountered when the pointer reaches that key value.

   ASCII FLOW COMPARISON:

   [STATIC CURSOR]
   OPEN ──► Copies entire table into tempdb worktable (snapshot)
            FETCH ──► Reads tempdb only (changes to base table are ignored)

   [DYNAMIC CURSOR]
   OPEN ──► Anchors dynamic pointer to base table index
       │
       ▼
   FETCH ──► Live index seek/scan (sees real-time table state)
       │
       ▼
   (External INSERT happens here ahead of pointer)
       │
       ▼
   FETCH ──► Reads the newly added row automatically


   3. PRACTICAL DEMONSTRATION: Mid-Loop Row Injection
   ---------------------------------------------------------------------------- */

USE C21_DB1;
GO

-- Clean up any previous test table
IF OBJECT_ID('dbo.LiveTasks', 'U') IS NOT NULL 
    DROP TABLE dbo.LiveTasks;
GO

-- Create base table with a clustered primary key (determines traversal order)
CREATE TABLE LiveTasks (
    TaskID      INT PRIMARY KEY,
    TaskName    VARCHAR(50) NOT NULL,
    Status      VARCHAR(20) NOT NULL
);
GO

-- Seed 5 initial tasks
INSERT INTO LiveTasks (TaskID, TaskName, Status) VALUES
(1, 'Database Backup',      'Pending'),
(2, 'Generate Invoices',    'Pending'),
(3, 'Verify Subscriptions', 'Pending'),
(4, 'Clear Temp Tables',    'Pending'),
(5, 'Sync User Accounts',   'Pending');
GO

-- Declare variables to capture row values
DECLARE @TaskID   INT;
DECLARE @TaskName VARCHAR(50);
DECLARE @Status   VARCHAR(20);

-- Declare the DYNAMIC cursor
DECLARE cur_LiveDemo CURSOR DYNAMIC FOR  SELECT TaskID, TaskName, Status FROM LiveTasks WHERE Status = 'Pending';

-- Open the live pointer
OPEN cur_LiveDemo;

-- Fetch the first row
FETCH NEXT FROM cur_LiveDemo INTO @TaskID, @TaskName, @Status;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT '>>> Fetching: ID=' + CAST(@TaskID AS VARCHAR) + ' | ' + @TaskName;

    -- Inject Task #6 after processing Task #2 to see how this cursor is dynamic
    -- Since TaskID 6 has a higher key than the current position, the cursor will find it
    IF @TaskID = 2
    BEGIN
        PRINT '    [EVENT] Inserting Task #6 (Emergency Audit) mid-loop...';
        INSERT INTO LiveTasks (TaskID, TaskName, Status) VALUES (6, 'Emergency Audit', 'Pending');
    END

    -- Fetch the next row from the live table
    FETCH NEXT FROM cur_LiveDemo 
    INTO @TaskID, @TaskName, @Status;
END;

-- Clean up resources
CLOSE cur_LiveDemo;
DEALLOCATE cur_LiveDemo;
GO


/* ============================================================================
   4. EXPECTED OUTPUT IN MESSAGES TAB
   ----------------------------------------------------------------------------
   >>> Fetching: ID=1 | Database Backup
   >>> Fetching: ID=2 | Generate Invoices
       [EVENT] Inserting Task #6 (Emergency Audit) mid-loop...
   >>> Fetching: ID=3 | Verify Subscriptions
   >>> Fetching: ID=4 | Clear Temp Tables
   >>> Fetching: ID=5 | Sync User Accounts
   >>> Fetching: ID=6 | Emergency Audit     <-- DETECTED DYNAMICALLY!
   ============================================================================ */


/* ============================================================================
   5. PITFALLS & PERFORMANCE RISKS
   ----------------------------------------------------------------------------
   - Phantom Inserts & Order Shifts: Because the result set is live, rows can 
     shift or appear unexpectedly if concurrent transactions insert or update data.
   - High Engine Overhead: Every `FETCH NEXT` triggers an active lookup against 
     the index structure rather than reading cached rows from tempdb.
   - Locking Contention: Traversing live pages under standard isolation levels 
     can cause lock escalation or deadlocks with concurrent transactions writing 
     to the same tables.
   ============================================================================ */