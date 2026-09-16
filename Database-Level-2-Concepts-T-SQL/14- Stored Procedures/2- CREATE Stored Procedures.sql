/*
================================================================================
LESSON: Stored Procedure Syntax & Structural Forms
================================================================================

1. INTRO TO STORED PROCEDURE SYNTAX
--------------------------------------------------------------------------------
- Definition:
  A Stored Procedure (SP) is an executable routine stored in the database.
  Think of it as a compiled C# method living inside SQL Server.

- Core Anatomy:
    CREATE PROCEDURE [schema].[ProcedureName]
        @ParameterName DataType [= DefaultValue] [OUTPUT],
        ...
    AS
    BEGIN
        SET NOCOUNT ON;
        -- Procedural logic / T-SQL statements go here
    END;

-------- we can find created SPs in object explorer > DB > Programmablity > Stored Procedures > then find it

- Golden Syntax Rules:
  1. The CREATE PROCEDURE statement must be the first or only statement in a batch,
     which is why it is preceded and followed by GO.
  2. Avoid the "sp_" prefix. SQL Server checks the system 'master' database 
     first for names starting with "sp_". Prefer "usp_" (User Stored Procedure).
  3. Parameters are defined before the "AS" keyword.
  4. Always add "SET NOCOUNT ON;" right after BEGIN to prevent unnecessary 
     "n rows affected" messages across the network.

---- a SP always returns an intger, mostly 0 to indicate exit with no issues, 
     we can use this returned value as needed, if used then exits and rest of script will be ignored. (like return in c#)

2. THE 4 SIGNATURES FORMS 
--------------------------------------------------------------------------------
Like methods in C#, procedures can have different parameter shapes:

  - Form 1: Zero Parameters (Void parameterless method)
  - Form 2: Input Parameters Only (Void method with arguments)
  - Form 3: Input + OUTPUT Parameters (Method with 'out'/'ref' arguments)
  - Form 4: Parameters With Default Values (Method with optional arguments)
================================================================================
*/

USE C21_DB1;
GO

-- =============================================================================
-- FORM 1: ZERO PARAMETERS
-- C# equivalent: void ResetStatus()
-- =============================================================================
CREATE PROCEDURE usp_ResetPeopleStatus
AS
BEGIN
    SET NOCOUNT ON;

    -- Basic operation without external inputs
    UPDATE People
    SET Email = 'NO EMAIL';
END;
GO


-- Calling Form 1:
EXEC usp_ResetPeopleStatus;
go

-- =============================================================================
-- FORM 2: INPUT PARAMETERS ONLY
-- C# equivalent: void AddPerson(string firstName, string lastName, string email)
-- =============================================================================
CREATE PROCEDURE usp_AddNewPerson_NoOutput
    @FirstName VARCHAR(100),
    @LastName  VARCHAR(100),
    @Email     VARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    -- Uses incoming parameters directly
    INSERT INTO People (FirstName, LastName, Email)
    VALUES (@FirstName, @LastName, @Email);
END;
GO

-- Calling Form 2:
EXEC usp_AddNewPerson_NoOutput 
    @FirstName = 'Abdullah', 
    @LastName  = 'Alzahrani', 
    @Email     = 'A@g.com';

go
-- =============================================================================
-- FORM 3: INPUT + OUTPUT PARAMETERS
-- C# equivalent: void AddPerson(..., out int newPersonID)
-- =============================================================================
CREATE PROCEDURE usp_AddNewPerson_WithOutput
    @FirstName   VARCHAR(100),
    @LastName    VARCHAR(100),
    @Email       VARCHAR(200),
    @NewPersonID INT OUTPUT      -- Caller provides a variable to receive this
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO People (FirstName, LastName, Email)
    VALUES (@FirstName, @LastName, @Email);

    -- Assign the generated identity back to the OUTPUT variable
    SET @NewPersonID = SCOPE_IDENTITY();
END;
GO


-- Calling Form 3:
DECLARE @CreatedID INT;

EXEC usp_AddNewPerson_WithOutput 
    @FirstName   = 'Abdullah', 
    @LastName    = 'Alzahrani', 
    @Email       = 'A@g.com', 
    @NewPersonID = @CreatedID OUTPUT; -- Notice OUTPUT keyword is required on call

SELECT @CreatedID AS CreatedPersonID; -- one way to use the output variable


go
-- =============================================================================
-- FORM 4: OPTIONAL PARAMETERS (DEFAULT VALUES)
-- C# equivalent: void AddPerson(..., string email = "NotProvided@domain.com")
-- =============================================================================
CREATE PROCEDURE usp_AddNewPerson_WithDefault
    @FirstName VARCHAR(100),
    @LastName  VARCHAR(100),
    @Email     VARCHAR(200) = 'NoEmail@domain.com' -- Optional parameter
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO People (FirstName, LastName, Email)
    VALUES (@FirstName, @LastName, @Email);
END;
GO


-- Calling Form 4 (Omitting optional argument):
EXEC usp_AddNewPerson_WithDefault 
    @FirstName = 'Abdullah', 
    @LastName  = 'Alzahrani';
GO








