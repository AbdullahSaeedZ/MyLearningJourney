/*
====================================================================
LESSON: WITH ENCRYPTION in Stored Procedures
====================================================================

1. THE PROBLEM (Why it exists)
--------------------------------------------------------------------
When you distribute commercial database software to clients or host 
databases where users have read permissions on system catalogs, anyone 
can view your underlying business logic using:
- `sp_helptext 'dbo.ProcedureName'`
- `sys.sql_modules` table
- Right-click -> "Modify" in SSMS

Companies needed a way to protect proprietary business logic and 
prevent clients from inspecting or tampering with routine definitions.


2. CORE IDEA
--------------------------------------------------------------------
`WITH ENCRYPTION` instructs SQL Server to obfuscate the text definition 
of the stored procedure in system catalog views. The stored procedure 
still executes normally, but its raw source code cannot be read 
through standard system views or procedures.


3. HOW IT WORKS INTERNALLY
--------------------------------------------------------------------
- When compiled, SQL Server converts the plain-text definition into an 
  obfuscated/encrypted binary format inside `sys.sysobjvalues`.
- The column `definition` in `sys.sql_modules` displays `NULL`.
- Calling `sp_helptext` returns an error stating the text is encrypted.
- Important note: This is light obfuscation, NOT military-grade security. 
  Anyone with `CONTROL SERVER` or Dedicated Administrator Connection (DAC) 
  access can easily decrypt it using third-party tools or scripts.


4. T-SQL EXAMPLE
--------------------------------------------------------------------
*/

-- Creating an encrypted procedure:
CREATE OR ALTER PROCEDURE dbo.CalculateBonus
    @EmployeeID INT
WITH ENCRYPTION
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Proprietary formula hidden from general view
    SELECT @EmployeeID AS EmployeeID, 5000 * 1.15 AS CalculatedBonus;
END;
GO

-- Attempting to view the definition:
EXEC sp_helptext 'dbo.CalculateBonus';
-- Output: "The text for object 'dbo.CalculateBonus' is encrypted."

SELECT definition 
FROM sys.sql_modules 
WHERE object_id = OBJECT_ID('dbo.CalculateBonus');
-- Output: NULL


/*
5. WHEN NOT TO USE IT & COMMON MISTAKES
--------------------------------------------------------------------
* NEVER run it without keeping the original source file:
  SQL Server does not offer a native "unencrypt" command. If you lose 
  your source script in Git/source control, you cannot easily edit 
  the procedure later.
* DON'T rely on it for true secrets:
  Never put API keys, passwords, or sensitive connection strings inside 
  an encrypted procedure thinking it is secure. A database admin can 
  still reverse-engineer it in seconds.
* Over-engineering mistake:
  Applying it to internal enterprise applications. It adds zero security 
  against DBAs and creates maintenance headaches for your own development team.
*/