/* ============================================================================
   LESSON NOTE: The Foreign Key Cascade Conflict with INSTEAD OF Triggers
   ============================================================================

   1. THE CORE CONFLICT
   ----------------------------------------------------------------------------
   - `ON DELETE CASCADE` tells SQL Server:
       "Physically wipe out child rows when a parent row is deleted."
   - An `INSTEAD OF DELETE` trigger tells SQL Server:
       "Cancel the physical delete on the parent. Run my custom code instead."

   These two rules directly contradict each other. Because the engine cannot 
   determine whether child rows should cascade-delete when the parent delete 
   is intercepted, SQL Server strictly FORBIDS combining them.


   2. CODE EXAMPLE: PROVOKING THE ERROR
   ---------------------------------------------------------------------------- */

-- Step A: Create the Parent Table
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(50) NOT NULL
);
GO

-- Step B: Create Child Table with ON DELETE CASCADE
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    EmployeeName VARCHAR(50) NOT NULL,
    DepartmentID INT,
    CONSTRAINT FK_Employees_Departments 
        FOREIGN KEY (DepartmentID) 
        REFERENCES Departments(DepartmentID) 
        ON DELETE CASCADE -- <--- The conflicting rule
);
GO

-- Step C: Attempting to create the trigger on the referenced parent
CREATE OR ALTER TRIGGER trg_InsteadOfDeleteDepartment
ON Departments
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    -- Trying to implement a soft delete
    UPDATE Departments 
    SET DepartmentName = DepartmentName + ' (Archived)'
    WHERE DepartmentID IN (SELECT DepartmentID FROM deleted);
END;
GO

/* ----------------------------------------------------------------------------
   RESULT:
   Msg 10752, Level 16, State 1
   "Cannot create INSTEAD OF DELETE or INSTEAD OF UPDATE TRIGGER 
    'trg_InsteadOfDeleteDepartment' on table 'Departments'. 
    This is because the table has a FOREIGN KEY with cascading DELETE or UPDATE."
   ---------------------------------------------------------------------------- */


/* ============================================================================
   3. THE SOLUTION / ARCHITECTURAL PATTERN
   ----------------------------------------------------------------------------
   - Use standard Foreign Keys with default `ON DELETE NO ACTION`.
   - Manage child row behavior (soft delete, reassign, or delete) manually 
     inside the parent's INSTEAD OF trigger body.
   ============================================================================ */