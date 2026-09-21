USE C21_DB1;
GO

/* ============================================================================
   LESSON: Inserting into Multi-Table Views using INSTEAD OF INSERT Triggers
   ============================================================================

   1. THE LIMITATION
   ----------------------------------------------------------------------------
   Just like updates, SQL Server does not permit an INSERT statement directly 
   into a view if that insert supplies values meant for multiple underlying base 
   tables. Doing so produces Msg 4405:
   "View or function is not updatable because the modification affects multiple 
    base tables."


   2. THE CORE PROBLEM TO SOLVE (Key Generation & Sequencing)
   ----------------------------------------------------------------------------
   When inserting records across two related tables:
   - PersonalInfo holds the primary key / identity (StudentID).
   - AcademicInfo depends on that exact StudentID as a foreign key.

   An INSTEAD OF INSERT trigger must:
     a. Intercept the incoming row(s) from `inserted`.
     b. Insert the student data into PersonalInfo first.
     c. Capture or map the generated `StudentID`.
     d. Insert the remaining academic columns into AcademicInfo with that ID.
   ============================================================================ */


/* ============================================================================
   3. TRIGGER IMPLEMENTATION
   ============================================================================ */

CREATE OR ALTER TRIGGER trg_InsteadOfInsertStudentView
ON StudentView
INSTEAD OF INSERT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    /* 
       Triggers run inside an implicit transaction, but automatic rollback 
       on runtime errors is turned OFF by default. 
       Because we execute multiple related writes here, enable `SET XACT_ABORT ON;` 
       at the start so any failure immediately rolls back the entire batch. */

    -- Step A: Insert into the primary table first to be able to reference its PK (PersonalInfo)
    INSERT INTO PersonalInfo (StudentID, Name, Address)
    SELECT StudentID,Name,Address
    FROM inserted;

    -- if the table has an auto increment ID, then capture it in a variable using the @@identity

    -- Step B: Insert into the dependent child table (AcademicInfo)
    INSERT INTO AcademicInfo (StudentID, Course, Grade)
    SELECT StudentID, Course, Grade
    FROM inserted;
   
END;
GO


/* ============================================================================
   4. VERIFICATION & TESTING
   ============================================================================ */

-- Check records before the insert
SELECT * FROM StudentView;
GO

-- Execute the INSERT against the composite view
INSERT INTO StudentView (StudentID, Name, Address, Course, Grade)
VALUES (11, 'Saad', 'Riyadh', 'SQL Server', '95');
GO

-- Verify that the data was distributed to both base tables
SELECT * FROM PersonalInfo WHERE Name = 'Saad';
SELECT * FROM AcademicInfo WHERE StudentID = 11;
SELECT * FROM StudentView  WHERE Name = 'Saad';
GO