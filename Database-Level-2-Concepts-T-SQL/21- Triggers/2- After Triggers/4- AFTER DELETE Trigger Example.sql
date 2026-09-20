/* ============================================================================
   LESSON: Implementing an AFTER DELETE Trigger (Auditing Removed Data)
   ============================================================================

   1. WHAT IS AN AFTER DELETE TRIGGER?
   ----------------------------------------------------------------------------
   An AFTER DELETE trigger fires automatically immediately after a DELETE statement 
   removes records from the target table within the active transaction.

   During a DELETE operation:
   - The 'inserted' virtual table is completely EMPTY.
   - The 'deleted' virtual table contains the full image of the REMOVED rows.


   2. DATA FLOW: THE DELETE ACTION
   ----------------------------------------------------------------------------
   When rows are deleted, SQL Server moves a copy of those rows into the 
   in-memory 'deleted' table before finalizing the transaction.

                    [ DELETE FROM Students WHERE ... ]
                                    |
            +-----------------------+-----------------------+
            |                                               |
            v                                               v
      [ Students ]                                    [ deleted ]
   (Rows removed from table)                      (Holds deleted rows)
            |                                               |
            |                                               v
            |                                   [ trg_AfterDeleteStudent ]
            |                                               |
            v                                               v (SELECT FROM deleted)
   [ Commits or Rollbacks ]                        [ StudentDeleteLog ]
                                                   (Archived audit copy)


   3. AUDIT TABLES & FOREIGN KEYS (Why No FK on the Log?)
   ----------------------------------------------------------------------------
   A common architectural question: 
   "If we delete StudentID = 1 from Students, won't having StudentID in the log 
   table break referential integrity since that student no longer exists?"

   Answer: 
   Placing a FOREIGN KEY constraint on an audit/log table is a major anti-pattern.
   Audit logs must be independent, immutable history snapshots.

   [ Active OLTP Table ]                    [ Historical Audit Table ]
   ┌─────────────────────────┐              ┌─────────────────────────┐
   │ Students                │              │ StudentDeleteLog        │
   ├─────────────────────────┤              ├─────────────────────────┤
   │ StudentID (PK)          │              │ LogID (PK)              │
   │ Name                    │              │ StudentID (Plain INT)   │ <── NO FK!
   │ Subject                 │              │ Name                    │
   │ Grade                   │              │ DeletedDateTime         │
   └─────────────────────────┘              └─────────────────────────┘

  Why the log table uses a plain INT (No Foreign Key):
   - In an AFTER DELETE trigger, the row in Students is ALREADY deleted.
   - If the log table had an FK constraint pointing to Students, inserting the deleted StudentID 
     into the log would fail immediately because that ID no longer exists in Students!
   - A plain INT avoids this constraint violation and preserves the historical fact: 
     "A student with ID 1 once existed.""
============================================================================ */


-- ============================================================================
-- 4. ENVIRONMENT SETUP
-- ============================================================================

-- Base target table
CREATE TABLE Students (
    StudentID INT PRIMARY KEY,
    Name NVARCHAR(50),
    Subject NVARCHAR(50),
    Grade INT
);

-- Dedicated audit log table to archive deleted student records
-- Notice: StudentID is a plain INT, NOT a FOREIGN KEY constraint
CREATE TABLE StudentDeleteLog (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    Name NVARCHAR(50),
    Subject NVARCHAR(50),
    Grade INT,
    DeletedBy NVARCHAR(128) DEFAULT SUSER_SNAME(),
    DeletedDateTime DATETIME DEFAULT GETDATE()
);
GO

-- Seed baseline data
INSERT INTO Students (StudentID, Name, Subject, Grade)
VALUES 
    (15, 'John Doe', 'Mathematics', 75),
    (25, 'Sarah Connor', 'Physics', 88),
    (35, 'Alex Murphy', 'Chemistry', 91);
GO


-- ============================================================================
-- 5. CREATING THE AFTER DELETE TRIGGER
-- ============================================================================
CREATE OR ALTER TRIGGER trg_AfterDeleteStudent
ON Students
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;

    /*
       1. Early Exit Guard:
          - Fires even if 0 rows matched the WHERE clause.
          - Exit early if no rows were actually removed.
    */
    IF NOT EXISTS (SELECT 1 FROM deleted)
        RETURN;

    /*
       2. Archive Deleted Rows:
          Pull directly from 'deleted' memory table.
          Handles both single-row and multi-row deletes in a set-based manner.
    */
    INSERT INTO StudentDeleteLog (StudentID, Name, Subject, Grade)
    SELECT StudentID, Name, Subject, Grade FROM deleted;
END;
GO


-- ============================================================================
-- 6. TESTING & VERIFICATION
-- ============================================================================

-- Test 1: Single-Row Delete
DELETE FROM Students 
WHERE StudentID = 11;

-- Verify log: John Doe archived with username and timestamp
SELECT * FROM StudentDeleteLog;
GO

-- Test 2: Multi-Row Batch Delete
DELETE FROM Students 
WHERE Grade between 80 and 90;

-- Verify both Sarah Connor and Alex Murphy captured in a single trigger execution:
SELECT * FROM StudentDeleteLog;
GO

-- Verify base table state:
SELECT * FROM Students;
GO
