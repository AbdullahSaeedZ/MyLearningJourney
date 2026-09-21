/* ============================================================================
   LESSON: Working with STATIC Cursors in T-SQL
   ============================================================================

   1. THE PROBLEM (Why Use a STATIC Cursor?)
   ----------------------------------------------------------------------------
   When iterating through records for non-database tasks (like dispatching 
   emails, generating export files, or executing external system calls), the 
   process can take seconds or minutes. 

   If you iterate over a live table using a regular dynamic cursor:
     - Other users inserting, updating, or deleting rows during the run can 
       cause phantom reads, skipped records, or duplicate processing.
     - Long-lived shared locks can block other active connections.

   A STATIC cursor solves this by taking an isolated, point-in-time snapshot 
   of the query result into tempdb when the cursor opens. Any changes made to 
   the base table afterward are completely invisible to the cursor.


   2. THE 5-STEP CURSOR LIFECYCLE
   ----------------------------------------------------------------------------
   Every cursor strictly follows this operational lifecycle:

   [1. DECLARE] ──► Define the query and cursor attributes (STATIC, READ_ONLY)
        │
        ▼
   [2. OPEN]    ──► Materialize snapshot into tempdb worktable
        │
        ▼
   [3. FETCH]   ──► Read first row; loop WHILE @@FETCH_STATUS = 0
        │
        ▼
   [4. CLOSE]   ──► Release the active result set and locks
        │
        ▼
   [5. DEALLOC] ──► Destroy cursor reference and free memory completely




   3. PRACTICAL CODE: Simulating Sending Monthly Report Emails
   ---------------------------------------------------------------------------- */

USE C21_DB1;
GO

-- Declare local variables to hold row-level data
DECLARE @CustomerID   INT;
DECLARE @CustomerName VARCHAR(100);
DECLARE @Email        VARCHAR(150);

-- Step 1: Declare the cursor as STATIC and READ_ONLY
-- and we give it the result set that it will be working on
DECLARE cur_CustomerEmails CURSOR STATIC READ_ONLY FOR
SELECT CustomerID, Name, Email FROM Customers;

-- Step 2: Open the cursor (takes snapshot into tempdb)
OPEN cur_CustomerEmails;

-- Step 3: Fetch the first row into our variables
FETCH NEXT FROM cur_CustomerEmails 
INTO @CustomerID, @CustomerName, @Email;

-- Loop as long as FETCH is successful (0 = success, -1 = end of data, -2 = missing row)
WHILE @@FETCH_STATUS = 0
BEGIN
    -- Simulated non-database work (e.g., dispatching external email API)
    PRINT '----------------------------------------------------';
    PRINT 'Sending To: ' + @Email + ' (ID: ' + CAST(@CustomerID AS VARCHAR) + ')';
    PRINT 'Subject   : Monthly Report';
    PRINT 'Body      : Dear ' + @CustomerName + ', your monthly report is ready.';
    
    -- Advance to the next row
    FETCH NEXT FROM cur_CustomerEmails 
    INTO @CustomerID, @CustomerName, @Email;
END;

-- Step 4: Close the active data stream
CLOSE cur_CustomerEmails;

-- Step 5: Deallocate pointer to free internal server memory
DEALLOCATE cur_CustomerEmails;
GO


/* ============================================================================
   4. KEY TAKEAWAYS & BEST PRACTICES
   ----------------------------------------------------------------------------
   - @@FETCH_STATUS Scope: Always re-fetch inside the loop at the very bottom. 
     If you forget the secondary `FETCH NEXT`, `@@FETCH_STATUS` remains 0, 
     producing an infinite loop.
   - Always Pair with READ_ONLY: Since a STATIC cursor operates on a disconnected 
     tempdb snapshot, you cannot use it to update base rows with `WHERE CURRENT OF`. 
     Marking it `READ_ONLY` clarifies intent and avoids lock overhead.
   - Resource Cleanup: `CLOSE` releases the active result set, but `DEALLOCATE` 
     is mandatory to release the metadata pointer. Failing to deallocate leaves 
     cursor handles hanging in the session.
   ============================================================================ */