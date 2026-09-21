USE C21_DB1;
GO

/* ============================================================================
   LESSON: Updating Multi-Table Views using INSTEAD OF UPDATE Triggers
   ============================================================================

   1. THE LIMITATION
   ----------------------------------------------------------------------------
   In SQL Server, a VIEW joining multiple tables cannot be updated across 
   more than one underlying table in a single statement. Running an UPDATE that 
   touches columns belonging to both tables results in Msg 4405:
   "View or function is not updatable because the modification affects multiple 
    base tables."


   2. THE SOLUTION
   ----------------------------------------------------------------------------
   An INSTEAD OF UPDATE trigger intercepts the write request against the view. 
   It reads the proposed values from the `inserted` table and splits them into 
   individual UPDATE statements targeting each base table independently.
   ============================================================================ */




CREATE OR ALTER TRIGGER trg_InsteadOfUpdateStudentView ON StudentView
INSTEAD OF UPDATE
AS
BEGIN

    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    /* 
       Triggers run inside an implicit transaction, but automatic rollback 
       on runtime errors is turned OFF by default. 
       Because we execute multiple related writes here, enable `SET XACT_ABORT ON;` 
       at the start so any failure immediately rolls back the entire batch. */

    -- Update Base Table 1: Personal Details
    UPDATE p
    SET p.Name    = i.Name, 
        p.Address = i.Address
    FROM PersonalInfo AS p
    INNER JOIN inserted AS i 
        ON p.StudentID = i.StudentID;

    -- Update Base Table 2: Academic Details
    UPDATE a
    SET a.Course = i.Course, 
        a.Grade  = i.Grade
    FROM AcademicInfo AS a
    INNER JOIN inserted AS i 
        ON a.StudentID = i.StudentID;

        /* NOTE ON OMITTED COLUMNS:
       Columns not specified in the caller's UPDATE statement retain their 
       CURRENT values inside the `inserted` pseudo-table (they do NOT turn NULL). 
       Therefore, assigning them directly preserves existing data. */
END;
GO


/* ============================================================================
   3. VERIFICATION & TESTING
   ============================================================================ */

-- Verify data prior to update
SELECT * FROM StudentView WHERE StudentID = 1;
GO

-- Execute the multi-table update via the view
UPDATE StudentView
SET Name   = 'Abdullah',
    Course = 'C#',
    Grade  = '100'
WHERE StudentID = 1;
GO

-- Verify base tables and view reflection
SELECT * FROM PersonalInfo WHERE StudentID = 1;
SELECT * FROM AcademicInfo WHERE StudentID = 1;
SELECT * FROM StudentView  WHERE StudentID = 1;
GO