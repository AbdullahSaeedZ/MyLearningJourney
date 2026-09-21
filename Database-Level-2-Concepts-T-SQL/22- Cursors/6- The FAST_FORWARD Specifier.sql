/* ============================================================================
   LESSON 3: The FAST_FORWARD Specifier (Engine-Optimized Read Stream)
   ============================================================================

   1. THE PROBLEM (Why FAST_FORWARD Exists)
   ----------------------------------------------------------------------------
   When an engineer needs a read-only, forward-only stream, declaring:
   `CURSOR FORWARD_ONLY READ_ONLY` leaves optimization decisions ambiguous to 
   the query optimizer—the engine still creates standard cursor execution plans 
   that may hold shared locks or build unnecessary worktables.

   `FAST_FORWARD` is a dedicated T-SQL performance specifier that tells the query 
   optimizer: "This cursor will strictly read forward, and will never perform an 
   in-place update. Apply every internal optimization available to maximize 
   throughput."


   2. CORE IDEA & INTERNAL OPTIMIZATIONS
   ----------------------------------------------------------------------------
   - Implicitly enforces `FORWARD_ONLY` and `READ_ONLY`.
   - The Query Optimizer evaluates the execution plan and dynamically selects 
     the fastest underlying physical access path (often converting it internally 
     to an optimized static or dynamic cursor plan with minimum overhead).
   - Minimizes lock duration and concurrency contention compared to standard 
     cursors.


   3. PRACTICAL CODE EXAMPLE
   ---------------------------------------------------------------------------- */

USE C21_DB1;
GO

DECLARE @TaskID INT, @TaskName VARCHAR(50);

-- FAST_FORWARD replaces both FORWARD_ONLY and READ_ONLY
-- Note: You CANNOT combine FAST_FORWARD with SCROLL (syntax error)
DECLARE cur_FastStream CURSOR FAST_FORWARD FOR
SELECT TaskID, TaskName 
FROM LiveTasks
WHERE Status = 'Pending';

OPEN cur_FastStream;

FETCH NEXT FROM cur_FastStream INTO @TaskID, @TaskName;

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT 'Fast-Streamed Task #' + CAST(@TaskID AS VARCHAR) + ': ' + @TaskName;
    FETCH NEXT FROM cur_FastStream INTO @TaskID, @TaskName;
END;

CLOSE cur_FastStream;
DEALLOCATE cur_FastStream;
GO

/* ----------------------------------------------------------------------------
   4. PITFALLS & COMPATIBILITY RULES
   - Syntax Restrictions: Mutually exclusive with `SCROLL`. You cannot write 
     `FAST_FORWARD SCROLL`.
   - Updatability: You cannot execute `UPDATE ... WHERE CURRENT OF` with a 
     FAST_FORWARD cursor; it is strictly read-only.
   - Industry Standard: In enterprise SQL Server development, if you are forced 
     to use a cursor for sequential read operations, FAST_FORWARD is the default 
     best-practice recommendation.
   ============================================================================ */