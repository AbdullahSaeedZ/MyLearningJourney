/* ============================================================================
   LESSON 1: The FORWARD_ONLY Specifier (Unidirectional Stream)
   ============================================================================

   1. THE PROBLEM (Why FORWARD_ONLY Exists)
   ----------------------------------------------------------------------------
   When iterating through records sequentially (e.g., streaming logs, exporting 
   data, or dispatching notifications), preserving historical cursor positions 
   wastes engine memory. If an engineer declares a cursor without directional 
   constraints, the engine might construct bidirectional index tracking or 
   tempdb bookmarks that will never be used.

   `FORWARD_ONLY` tells SQL Server: "I will only step through this dataset 
   linearly from first to last. Do not allocate resources to track where I have 
   already been."


   2. CORE IDEA & INTERNAL BEHAVIOR
   ----------------------------------------------------------------------------
   - Only supports `FETCH NEXT`.
   - Any attempt to run `FETCH PRIOR`, `FETCH FIRST`, or `FETCH ABSOLUTE` 
     immediately throws Error 16911.
   - Discards row position history as the cursor advances, minimizing memory 
     footprint.


   3. PRACTICAL CODE EXAMPLE
   ---------------------------------------------------------------------------- */

USE C21_DB1;
GO

DECLARE @ID INT, @Message VARCHAR(100);

-- Explicitly specifying FORWARD_ONLY with STATIC
DECLARE cur_ForwardOnly CURSOR STATIC FORWARD_ONLY READ_ONLY FOR
SELECT TaskID, TaskName FROM LiveTasks ORDER BY TaskID;

OPEN cur_ForwardOnly;

-- Only FETCH NEXT is valid
FETCH NEXT FROM cur_ForwardOnly INTO @ID, @Message;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Processing #' + CAST(@ID AS VARCHAR) + ': ' + @Message;
    FETCH NEXT FROM cur_ForwardOnly INTO @ID, @Message;
END;

CLOSE cur_ForwardOnly;
DEALLOCATE cur_ForwardOnly;
GO

/* ----------------------------------------------------------------------------
   4. PITFALLS & ENGINE CHARACTERISTICS
   - Irreversible Pointer: You cannot rewind or inspect previous rows. If logic 
     requires comparing against the prior row, you must cache the previous 
     row's values in local variables manually.
   ---------------------------------------------------------------------------- */