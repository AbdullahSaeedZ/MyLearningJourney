/* ============================================================================
   LESSON: Implementing an AFTER INSERT Trigger (Auditing & Logging)
   ============================================================================

   1. WHAT IS AN AFTER INSERT TRIGGER?
   ----------------------------------------------------------------------------
   An AFTER INSERT trigger fires automatically immediately after an INSERT statement 
   successfully adds records to the target table within the active transaction. 
   
   It is primarily used to perform immediate secondary actions such as:
   - Writing historical/audit logs.
   - Synchronizing records to related reporting tables.
   - Incrementing cached counter columns.


   2. DATA FLOW: THE INSERT ACTION
   ----------------------------------------------------------------------------
   When a user inserts data, SQL Server writes the rows to the target table 
   and simultaneously populates the virtual 'inserted' table in memory. 
   The trigger then reads directly from 'inserted' to perform logging.

          [ INSERT INTO Students ]
                     |
         +-----------+-----------+
         |                       |
         v                       v
   [ Students ]            [ inserted ] (Virtual Table in Memory)
   (Record added)          | - Holds the new row(s)
                           |
                           v
              [ trg_AfterInsertStudent ]
                           |
                           v (SELECT ... FROM inserted)
                [ StudentInsertLog ]
                (Audit record saved)


   3. ENVIRONMENT SETUP
   ---------------------------------------------------------------------------- */

-- Base target table (we already have it)
/*
CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Subject NVARCHAR(50),
    Grade INT
);
*/

-- Dedicated audit log table
CREATE TABLE StudentInsertLog (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    Name NVARCHAR(50),
    Subject NVARCHAR(50),
    Grade INT,
    InsertedDateTime DATETIME DEFAULT GETDATE()
);
GO


-- ============================================================================
-- 4. CREATING THE AFTER INSERT TRIGGER
-- ============================================================================
create or alter trigger trg_AfterInsertStudent on Students
after insert
as
begin
 -- Suppress row-count messages to prevent network/client driver noise
    set nocount on
    
    /*
       Notice we use 'SELECT ... FROM inserted'.
       This naturally handles both single-row and multi-row bulk inserts.
    */
    insert into StudentInsertLog (StudentID, Name, Subject, Grade)
    select StudentID, Name, Subject, Grade from inserted;

end
GO



-- ============================================================================
-- 5. TESTING & VERIFICATION
-- ============================================================================

-- Test 1: Single-Row Insert
INSERT INTO Students (StudentID, Name, Subject, Grade)
VALUES (12, 'John Doe', 'Mathematics', 85);

-- Verify log entry:
SELECT * FROM StudentInsertLog;
GO

-- Test 2: Multi-Row Insert Verification
-- (Proves the trigger processes full batch sets, not just single rows)
INSERT INTO Students (StudentID, Name, Subject, Grade)
VALUES 
    (22, 'Sarah Connor', 'Physics', 92),
    (33, 'Alex Murphy', 'Chemistry', 78);

-- Verify both records were audited in a single trigger execution:
SELECT * FROM StudentInsertLog;
GO






