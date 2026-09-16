/*
================================================================================
LESSON: Managing Stored Procedures with DDL (ALTER, CREATE OR ALTER, DROP)
================================================================================

1. THE PROBLEM
--------------------------------------------------------------------------------
- As application requirements change, you frequently need to update a procedure's
  logic or completely delete it.
- If you run "CREATE PROCEDURE" on an object that already exists, SQL Server 
  throws an error: "There is already an object named '...' in the database."
- If you simply "DROP" and re-"CREATE" an existing procedure to update it, you 
  destroy all explicit security permissions (like GRANT EXECUTE) assigned to it, 
  and dependencies tracked in system metadata get disrupted.


2. THE CORE DDL COMMANDS
--------------------------------------------------------------------------------
- ALTER PROCEDURE:
  Updates the internal definition of an existing procedure while preserving its
  object ID, dependencies, and granted security permissions. 
  Fails if the procedure does NOT exist.

- CREATE OR ALTER PROCEDURE:
  The modern standard (introduced in SQL Server 2016 SP1). Creates the object if 
  it is missing, or alters it in place if it exists. 
  Preserves permissions and removes the need for defensive check-and-drop scripts.

- DROP PROCEDURE:
  Completely removes the stored procedure from the database catalog.


3. TECHNICAL RULES
--------------------------------------------------------------------------------
1. Each command must be the first or only statement in a query batch (preceded 
   and followed by GO).
2. "IF EXISTS" should always be used with DROP to ensure deployment scripts are 
   idempotent (running the script multiple times won't throw errors).
================================================================================
*/

USE C21_DB1;
GO

-- =============================================================================
-- 1. BASELINE: Creating the Initial Procedure
-- =============================================================================
CREATE PROCEDURE usp_AddNewPerson
    @FirstName VARCHAR(100),
    @LastName  VARCHAR(100),
    @Email     VARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO People (FirstName, LastName, Email)
    VALUES (@FirstName, @LastName, @Email);
END;
GO


-- =============================================================================
-- 2. ALTER: Updating Logic Without Dropping Permissions
-- Scenario: We want to ensure emails are always saved in lower case.
-- Note: ALTER fails with error 3701 if the procedure doesn't already exist.
-- =============================================================================
ALTER PROCEDURE usp_AddNewPerson
    @FirstName VARCHAR(100),
    @LastName  VARCHAR(100),
    @Email     VARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO People (FirstName, LastName, Email)
    VALUES (@FirstName, @LastName, LOWER(@Email)); -- Modified logic
END;
GO


-- =============================================================================
-- 3. CREATE OR ALTER: The Preferred Modern Syntax
-- Scenario: Works regardless of whether the procedure already exists or not.
-- Ideal for database deployment pipelines and migration scripts.
-- =============================================================================
CREATE OR ALTER PROCEDURE usp_AddNewPerson
    @FirstName VARCHAR(100),
    @LastName  VARCHAR(100),
    @Email     VARCHAR(200),
    @NewPersonID INT OUTPUT = NULL -- Added optional output parameter
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO People (FirstName, LastName, Email)
    VALUES (@FirstName, @LastName, LOWER(@Email));

    SET @NewPersonID = SCOPE_IDENTITY();
END;
GO


-- =============================================================================
-- 4. DROP: Deleting the Procedure
-- Use "IF EXISTS" to avoid errors if the procedure is already gone.
-- =============================================================================

-- Modern syntax (SQL Server 2016+):
DROP PROCEDURE IF EXISTS usp_AddNewPerson;
GO

-- Legacy check pattern (still seen in older codebases):
/*
IF OBJECT_ID('usp_AddNewPerson', 'P') IS NOT NULL
    DROP PROCEDURE usp_AddNewPerson;
GO
*/


/*
================================================================================
PITFALLS & SENIOR DEV TAKEAWAYS
================================================================================
1. Never DROP + CREATE to change logic in production:
   Dropping a procedure wipes out user permissions (e.g., GRANT EXECUTE TO AppUser). 
   Always use ALTER or CREATE OR ALTER to update code safely.

2. Signature changes affect callers immediately:
   Altering parameters (e.g., adding a non-optional parameter or renaming one) 
   will immediately break any C# ADO.NET calls or views/scripts relying on the old 
   signature.
================================================================================
*/