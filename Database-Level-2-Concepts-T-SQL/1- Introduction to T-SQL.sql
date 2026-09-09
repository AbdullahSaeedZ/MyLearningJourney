/*
====================================================================
 LESSON 1: INTRODUCTION TO TRANSACT-SQL (T-SQL)
====================================================================

1. WHAT IS T-SQL?
-----------------
Transact-SQL (T-SQL) is Microsoft's proprietary extension to standard 
SQL (Structured Query Language). It serves as the primary engine-level 
programming language for Microsoft SQL Server and Azure SQL Database.

While ANSI-standard SQL focuses purely on declarative querying (telling 
the database *what* data you want), T-SQL adds procedural programming 
capabilities (allowing you to control *how* logic executes step-by-step).


2. KEY CAPABILITIES
-------------------
* Standard SQL Support:
  - DDL (Data Definition Language): CREATE, ALTER, DROP
  - DML (Data Manipulation Language): SELECT, INSERT, UPDATE, DELETE
  - DCL (Data Control Language): GRANT, REVOKE, DENY

* Procedural Extensions:
  - Variables: Declare and assign in-memory values (e.g., DECLARE @Id INT)
  - Control-of-Flow: IF...ELSE, WHILE, and CASE constructs
  - Built-in Functions: Extensive string, mathematical, and date/time manipulation

* Modularity & Performance:
  - Stored Procedures & Functions: Encapsulate logic for reusability, 
    reduced network traffic, and optimized execution plans.

* Transaction & Error Management:
  - All-or-Nothing Transactions: Group statements so that either all changes 
    save successfully or none do (BEGIN TRAN, COMMIT, ROLLBACK).
  - Structured Error Handling: Intercept and handle errors safely using 
    TRY...CATCH blocks without crashing your scripts.

* Security:
  - Detailed Access Control: Restrict access precisely to specific tables, 
    views, or actions instead of granting broad database permissions.
  - Built-in Data Encryption: Protect sensitive values at rest and in transit.


3. ECOSYSTEM CONTEXT: T-SQL vs. PL/SQL
--------------------------------------
Both are procedural extensions built on the foundational SQL standard, 
tailored to specific RDBMS engines:
* T-SQL:   Microsoft ecosystem (SQL Server, Azure SQL, Synapse)
* PL/SQL:  Oracle Corporation (Oracle Database)
====================================================================
*/

-- =================================================================
-- BRIEF EXAMPLE: Standard SQL vs. T-SQL Procedural Extension
-- =================================================================

-- 1. Standard SQL: Declarative query
-- SELECT FirstName, LastName FROM Employees WHERE DepartmentID = 1;

-- 2. T-SQL Procedural Extension: Variables, Control-of-Flow, Error Handling
BEGIN TRY
    -- Declare local variables
    DECLARE @DepartmentID INT = 1;
    DECLARE @BonusThreshold INT = 50000;

    -- Control-of-flow check
    IF @BonusThreshold > 40000
    BEGIN
        PRINT 'Processing high-tier bonuses for Department: ' + CAST(@DepartmentID AS VARCHAR);
    END
    ELSE
    BEGIN
        PRINT 'Standard tier processing.';
    END
END TRY
BEGIN CATCH
    -- Structured error handling
    PRINT 'Error Number: ' + CAST(ERROR_NUMBER() AS VARCHAR);
    PRINT 'Error Message: ' + ERROR_MESSAGE();
END CATCH;