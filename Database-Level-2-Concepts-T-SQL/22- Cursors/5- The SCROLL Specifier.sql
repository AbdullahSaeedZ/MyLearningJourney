/* ============================================================================
   LESSON 2: The SCROLL Specifier (Bidirectional Navigation)
   ============================================================================

   1. THE PROBLEM (Why SCROLL Exists)
   ----------------------------------------------------------------------------
   In legacy paging systems, interactive reporting consoles, or complex procedural 
   algorithms, code often needs to navigate non-linearly: jumping to the end, 
   stepping backward to re-evaluate a row, or leaping directly to an arbitrary 
   index position (e.g., row 50).

   `SCROLL` enables full directional freedom, instructing the engine to retain 
   positional metadata so the pointer can traverse anywhere within the result set.


   2. CORE IDEA & FETCH VARIANTS
   ----------------------------------------------------------------------------
   Enables 6 distinct FETCH operations:
   - `FETCH FIRST`          : Jumps to the very first row.
   - `FETCH LAST`           : Jumps to the very last row.
   - `FETCH NEXT`           : Steps down one row.
   - `FETCH PRIOR`          : Steps back one row.
   - `FETCH ABSOLUTE <n>`   : Jumps directly to row number <n> (1-based index).
   - `FETCH RELATIVE <n>`   : Jumps <n> rows forward (positive) or backward (negative) 
                              relative to the current position.


   3. PRACTICAL CODE EXAMPLE
   ---------------------------------------------------------------------------- */

USE C21_DB1;
GO

DECLARE @ID INT, @Name VARCHAR(50);

-- Declaring SCROLL with STATIC snapshot
DECLARE cur_ScrollDemo CURSOR STATIC SCROLL READ_ONLY FOR
SELECT TaskID, TaskName FROM LiveTasks ORDER BY TaskID;

OPEN cur_ScrollDemo;

-- 1. Jump straight to the last record
FETCH LAST FROM cur_ScrollDemo INTO @ID, @Name;
PRINT 'Last Task: ' + CAST(@ID AS VARCHAR) + ' - ' + @Name;

-- 2. Step backward one row
FETCH PRIOR FROM cur_ScrollDemo INTO @ID, @Name;
PRINT 'Prior Task: ' + CAST(@ID AS VARCHAR) + ' - ' + @Name;

-- 3. Jump to absolute row #2
FETCH ABSOLUTE 2 FROM cur_ScrollDemo INTO @ID, @Name;
PRINT 'Row #2: ' + CAST(@ID AS VARCHAR) + ' - ' + @Name;

-- 4. Jump 2 rows forward from current position
FETCH RELATIVE 2 FROM cur_ScrollDemo INTO @ID, @Name;
PRINT 'Row #4 (Relative +2): ' + CAST(@ID AS VARCHAR) + ' - ' + @Name;

CLOSE cur_ScrollDemo;
DEALLOCATE cur_ScrollDemo;
GO

/* ----------------------------------------------------------------------------
   4. PITFALLS & PERFORMANCE OVERHEAD
   - Higher Memory & I/O: SQL Server must maintain internal navigational offset 
     tables. When paired with DYNAMIC, scrolling backward requires complex, 
     costly reverse index lookups.
   - Overuse: Never use SCROLL if your loop only needs top-to-bottom processing.
   ---------------------------------------------------------------------------- */