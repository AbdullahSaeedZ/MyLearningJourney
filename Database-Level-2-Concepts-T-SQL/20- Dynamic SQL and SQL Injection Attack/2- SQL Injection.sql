/* ============================================================================
   LESSON: SQL Injection in T-SQL (Authentication Bypass Scenario)
   ============================================================================

1. THE CORE PROBLEM: CODE VS. DATA AMBIGUITY
   ----------------------------------------------------------------------------
   The SQL engine interprets text based on structural symbols like quotes ('), 
   dashes (--), spaces, and semicolons (;).

   When you use string concatenation:
       Engine cannot tell where your "SQL command" ends and the "User's Data" begins.
   
   The engine treats whatever arrives in that combined string as raw code instructions.


   2. STEP-BY-STEP: BREAKING DOWN THE TEXT BOX INPUT
   ----------------------------------------------------------------------------
   Suppose you have a C# backend handling a login button:

       string query = "SELECT * FROM Users WHERE Username = '" + txtUser.Text 
                    + "' AND Password = '" + txtPass.Text + "'";

   The developer expects:
       txtUser.Text -> "john"
       txtPass.Text -> "123456"
       Result: SELECT * FROM Users WHERE Username = 'john' AND Password = '123456'

   Now look at what an attacker enters into the Username UI text box:
       admin' --

   Let's dissect each character in "admin' --":
   
   1. admin : The target account name.
   2. '     : THE BREAKOUT CHARACTER. It forces the SQL parser to close the 
              string literal earlier than the developer intended.
   3. Space : Separates the token.
   4. --    : THE SQL COMMENT OPERATOR. Tells SQL Server: "Ignore everything 
              after these two dashes on this line."

   When concatenated:
       SELECT * FROM Users WHERE Username = 'admin' --' AND Password = '...'
                                            |____|   |______________________|
                                            Active       IGNORED BY SQL ENGINE
                                            Filter        (Treated as comments)

   SQL Server actually executes only this:
       SELECT * FROM Users WHERE Username = 'admin'

   Because the password check was commented out, the query returns true, 
   and the application logs the attacker in as admin without checking any password.

   --- Another attempt can be deleting a table by typing into the username input:
       '; DROP TABLE Users; --

       Which concatenates into: 
       SELECT * FROM Users WHERE Username = ''; DROP TABLE Users; --' AND Password = '...'
============================================================================ */

-- Setup mock table
CREATE TABLE Users11 (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50),
    PasswordHash NVARCHAR(50)
);

INSERT INTO Users11 (Username, PasswordHash) 
VALUES ('admin', 'Secret123'), ('guest', 'Pass123');
GO

-- Vulnerable Dynamic Query:
DECLARE @UsernameInput NVARCHAR(50) = N'admin'' --';
DECLARE @PasswordInput NVARCHAR(50) = N'wrong_password';

DECLARE @SQL NVARCHAR(MAX);

-- Unsafe string concatenation:
SET @SQL = N'SELECT * FROM Users11 WHERE Username = ''' + @UsernameInput 
         + N''' AND PasswordHash = ''' + @PasswordInput + N'''';

-- Inspect the generated query:
-- Result: SELECT * FROM Users11 WHERE Username = 'admin' --' AND PasswordHash = 'wrong_password'
PRINT '--- Generated Injected Query ---';
PRINT @SQL;

-- Executing this returns the admin row without a valid password:
EXECUTE(@SQL);
GO


/* ============================================================================
   4. HOW TO PREVENT IT: PARAMETERIZED QUERIES
   ----------------------------------------------------------------------------
   Never concatenate data variables into SQL statements. 
   Parameters guarantee the SQL engine treats input strictly as literal values, 
   never as executable code.
============================================================================ */

-- Solution A: Static Query (Default Best Practice)
DECLARE @SafeUser NVARCHAR(50) = N'admin'' --';
DECLARE @SafePass NVARCHAR(50) = N'wrong_password';

-- Safe: The engine checks for a literal username equal to: admin' --
SELECT * FROM Users11 WHERE Username = @SafeUser AND PasswordHash = @SafePass;
GO

-- Solution B: Parameterized Dynamic SQL with sp_executesql
-- (If dynamic SQL is genuinely required, always define a parameter list)
DECLARE @DynamicUser NVARCHAR(50) = N'admin'' --';
DECLARE @DynamicPass NVARCHAR(50) = N'wrong_password';

DECLARE @SQLStmt NVARCHAR(MAX);
DECLARE @ParamDefinitions NVARCHAR(500);

SET @SQLStmt = N'SELECT * FROM Users11 WHERE Username = @UserParam AND PasswordHash = @PassParam';

SET @ParamDefinitions = N'@UserParam NVARCHAR(50), @PassParam NVARCHAR(50)';

EXEC sys.sp_executesql 
    @stmt = @SQLStmt,
    @params = @ParamDefinitions,
    @UserParam = @DynamicUser,
    @PassParam = @DynamicPass;
GO