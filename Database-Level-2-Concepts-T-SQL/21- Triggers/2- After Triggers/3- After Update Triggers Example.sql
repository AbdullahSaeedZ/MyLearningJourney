/* ============================================================================
   LESSON: Implementing an AFTER UPDATE Trigger (Auditing Data Changes)
   ============================================================================

   1. WHAT IS AN AFTER UPDATE TRIGGER?
   ----------------------------------------------------------------------------
   An AFTER UPDATE trigger fires automatically immediately after an UPDATE statement 
   successfully modifies records in the target table within the active transaction.

   Unlike INSERT (which only has new values) or DELETE (which only has old values), 
   an UPDATE event in SQL Server is treated internally as a paired operation:
       - DELETE the old row image.
       - INSERT the new row image.

   Therefore, BOTH the 'deleted' and 'inserted' virtual tables are populated:
       - 'deleted'  : Contains the values BEFORE the update.
       - 'inserted' : Contains the values AFTER the update.


   2. DATA FLOW: THE UPDATE ACTION
   ----------------------------------------------------------------------------
   When a row is updated, SQL Server exposes both states simultaneously. 
   Joining these two virtual tables by their primary key lets you capture 
   the exact before-and-after values.

                    [ UPDATE Students SET ... ]
                                 |
         +-----------------------+-----------------------+
         |                       |                       |
         v                       v                       v
   [ Students ]            [ deleted ]             [ inserted ]
   (Updated in table)      (Old values)            (New values)
         |                       \                       /
         |                        \                     /
         v                         v                   v
   [ Commits or Rollbacks ]       [ trg_AfterUpdateStudent ]
                                             |
                                             v (JOIN deleted & inserted)
                                    [ StudentUpdateLog ]
                                    (Old vs New logged)


   3. ENVIRONMENT SETUP
   ---------------------------------------------------------------------------- */

-- Base target table
CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Subject NVARCHAR(50),
    Grade INT
);

-- Dedicated audit log table tracking before & after values
CREATE TABLE StudentUpdateLog (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    OldGrade INT,
    NewGrade INT,
    UpdatedDateTime DATETIME DEFAULT GETDATE()
);
GO

-- Seed baseline data
INSERT INTO Students (StudentID, Name, Subject, Grade)
VALUES 
    (1, 'John Doe', 'Mathematics', 75),
    (2, 'Sarah Connor', 'Physics', 88);
GO


-- ============================================================================
-- 4. CREATING THE AFTER UPDATE TRIGGER
-- ============================================================================
CREATE OR ALTER TRIGGER trg_AfterUpdateStudent
ON Students
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    /*
       1. Early Exit Guards:
          - "AFTER" means execution order, not that data changed.
          - It fires even if 0 rows matched the UPDATE query.
          - It fires even if the new value equals the old value.
          - UPDATE(Column) only checks if it was inclided in 
            the SET clause of update statement that fired this trigger.
          - Exit early to prevent wasted CPU work.
    */
    IF NOT EXISTS (SELECT 1 FROM inserted)
        RETURN;

    IF NOT UPDATE(Grade)
        RETURN;

    INSERT INTO StudentUpdateLog (StudentID, OldGrade, NewGrade)
    SELECT 
        d.StudentID,
        d.Grade AS OldGrade,
        i.Grade AS NewGrade
    FROM deleted d
    INNER JOIN inserted i ON d.StudentID = i.StudentID
    WHERE d.Grade <> i.Grade; -- Log only if the grade actually changed
END;
GO


-- ============================================================================
-- 5. TESTING & VERIFICATION
-- ============================================================================

-- Test 1: Single-Row Update
UPDATE Students 
SET Grade = 90 
WHERE StudentID = 1;

-- Verify log: OldGrade was 75, NewGrade is now 90
SELECT * FROM StudentUpdateLog;
GO

-- Test 2: Multi-Row Batch Update
UPDATE Students 
SET Grade = Grade + 5;

-- Verify both modified rows captured in a single trigger execution:
SELECT * FROM StudentUpdateLog;
GO


