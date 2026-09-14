/*
  ===========================================================================
  LESSON: Legacy Error Handling using @@ERROR in T-SQL
  ===========================================================================

  1. PROBLEM:
     Before modern TRY...CATCH constructs were introduced, database developers 
     had no built-in control-flow blocks to intercept runtime errors gracefully. 
     If a statement failed, the application or script would crash unless errors 
     were checked manually after every single command.

  2. CORE IDEA:
     The @@ERROR function is a system function that returns the error number 
     of the immediately preceding T-SQL statement. If the statement succeeded, 
     it returns 0. Because it resets to 0 after every new statement, it must 
     be checked immediately following the risky operation.


  3. The modern alternative to using @@ERROR, is the try-catch block
  ===========================================================================
  PRACTICAL EXAMPLE:
  ===========================================================================
*/

use C21_DB1;

DECLARE @errorNumber INT = 0;

-- Example 1: Attempting an insert that might violate constraints (e.g., duplicate primary key)
INSERT INTO Departments (DepartmentID, Name) 
VALUES (1, 'Business'); -- Assuming DepartmentID 1 already exists

-- Capture @@ERROR immediately before any other statement resets it
SET @errorNumber = @@ERROR;

-- Check if an error occurred from the previous statement
IF @errorNumber <> 0
BEGIN
    PRINT 'Error caught manually via @@ERROR. Error Number: ' + CAST(@errorNumber AS VARCHAR);
    -- Handle the error or rollback manually here
END
ELSE
BEGIN
    PRINT 'Statement executed successfully with no errors.';
END;




--------------------------------------------------------------------------------------------------------------------------
-- Example 2: Sequential statements require checking @@ERROR after EACH command
INSERT INTO Departments (DepartmentID, Name) VALUES (1, 'Engineering');

SET @errorNumber = @@ERROR;
IF @errorNumber <> 0
BEGIN
    PRINT 'Error occurred on second insert. Error Number: ' + CAST(@errorNumber AS VARCHAR);
END;

-- checking after the next command
INSERT INTO Departments (DepartmentID, Name) VALUES (1, 'Engineering');

SET @errorNumber = @@ERROR;
IF @errorNumber <> 0
BEGIN
    PRINT 'Error occurred on second insert. Error Number: ' + CAST(@errorNumber AS VARCHAR);
END;

-- and so on