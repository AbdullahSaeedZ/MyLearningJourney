/*
========================================================================================================
 LESSON: TEMPORARY TABLES (#Temp) VS TABLE VARIABLES (@Table) VS PERMANENT TABLES (dbo.Table)
========================================================================================================

1. THE PROBLEM
   SQL queries often need staging areas for intermediate results:
   filtering big data in stages, storing calculations, or looping.
   You need a way to hold transient data without creating permanent
   junk in your actual database schema.

2. CORE DIFFERENCE
   - #Temp Table: A real physical table created inside tempdb.
     It has statistics, can have indexes, and participates in transactions.
   - @Table Variable: A variable scoped to the batch/procedure.
     It also lives in tempdb, but has NO column statistics and
     ignores transaction rollbacks.
   - Permanent Table: A regular database table stored in your user database.
     It persists permanently, has full statistics, supports all constraints/indexes,
     and participates in full backup/recovery.

========================================================================================================
 COMPARISON MATRIX
========================================================================================================

Feature             | #Temp Table (#T)           | Table Variable (@T)       | Permanent Table (dbo.T)
--------------------+----------------------------+---------------------------+--------------------------
Syntax              | CREATE TABLE #T (...)      | DECLARE @T TABLE (...)    | CREATE TABLE dbo.T (...)
Scope               | Session / Stored Proc      | Batch / Block only        | Global (All Users/DB)
Statistics          | YES (optimizer knows size) | NO (estimates 1 row)*     | YES (optimizer knows size)
Indexes             | Clustered & Non-Clustered  | Primary Key / Unique only | Clustered & Non-Clustered
ALTER Table?        | YES                        | NO                        | YES
Transaction Rollback| Rolled back                | NOT rolled back           | Rolled back
Survives Restart?   | NO                         | NO                        | YES
Included in Backups?| NO                         | NO                        | YES

========================================================================================================================
 STORAGE ARCHITECTURE COMPARISON
========================================================================================================================

Table Type          | Physical Location         | Active Execution  | Cleanup / Persistence
--------------------+---------------------------+-------------------+---------------------------------------------------
Permanent (dbo.T)   | Disk (YourDatabase.mdf)   | Cached in RAM     | Persists permanently (survives restarts/backups)
Temp Table (#T)     | Disk (tempdb.mdf)         | Cached in RAM     | Cleaned up when session / stored procedure drops
Table Variable (@T) | Disk (tempdb.mdf)         | Cached in RAM     | Cleaned up when batch / block execution ends

========================================================================================================================

========================================================================================================
 HOW THEY WORK INTERNALLY
========================================================================================================

A common myth is that Table Variables live purely in RAM. 
Both use tempdb. The real performance difference is STATISTICS:

  #Temp Table:
    Query Optimizer checks statistics -> sees 500,000 rows -> 
    picks the right approach like Hash Join / Parallel Plan -> FAST.

  @Table Variable:
    Query Optimizer assumes 1 row -> picks a Nested Loops join ->
    iterates 500,000 times -> SLOW.

  Permanent Table:
    Has full statistics and metadata updated by maintenance jobs or auto-stats,
    stored on permanent database data files (.mdf/.ndf).

========================================================================================================
 TRANSACTION BEHAVIOR (CRITICAL DIFFERENCE)
========================================================================================================
*/

-- Example 1: Table Variable ignores ROLLBACK
DECLARE @VarTable TABLE (ID INT);
BEGIN TRANSACTION;
    INSERT INTO @VarTable VALUES (1);
ROLLBACK TRANSACTION;

SELECT * FROM @VarTable; 
-- Result: Returns 1 row! (Data remains despite ROLLBACK)


-- Example 2: Temp Table obeys ROLLBACK
CREATE TABLE #TempTable (ID INT);
BEGIN TRANSACTION;
    INSERT INTO #TempTable VALUES (1);
ROLLBACK TRANSACTION;

SELECT * FROM #TempTable; 
-- Result: Returns 0 rows. (Data was rolled back cleanly)
DROP TABLE #TempTable;


-- Example 3: Permanent Table obeys ROLLBACK
CREATE TABLE dbo.PermTable (ID INT);
BEGIN TRANSACTION;
    INSERT INTO dbo.PermTable VALUES (1);
ROLLBACK TRANSACTION;

SELECT * FROM dbo.PermTable; 
-- Result: Returns 0 rows. (Data was rolled back cleanly)
DROP TABLE dbo.PermTable;

/*
========================================================================================================
 WHEN TO USE EACH
========================================================================================================

Use Table Variables (@Table) when:
- Row count is tiny (under 100 rows).
- You are writing a User-Defined Function (UDF):
  SQL Server does not allow #Temp tables inside functions.
  If a function returns a table, it MUST use a Table Variable.
- You want data to survive an explicit ROLLBACK (e.g., an error log).

Use Temp Tables (#Temp) when:
- Row count is medium to large (100+ rows).
- You need to join the staging data with other large tables.
- You need extra indexes on non-primary columns.
- You need the staging data to respect transaction boundaries:
  If a transaction fails and rolls back, any changes made to your
  temp table also undo automatically. It will not leave stale data.

Use Permanent Tables (dbo.Table) when:
- The data must persist long-term across sessions, restarts, and reboots.
- The data must be accessible by multiple users, services, or sessions concurrently.
- The data is part of the application domain model and must be backed up.

========================================================================================================
 RULE OF THUMB
========================================================================================================

                             +---------------------------------+
                             | Does data need to survive after |
                             |   the session/query finishes?   |
                             +----------------+----------------+
                                              |
                             +----------------+----------------+
                             |                                 |
                            YES                                NO
                             |                                 |
                             v                                 v
                     Use Permanent Table               Transient data:
                        (dbo.Table)              +-------------------------------+
                                                 |  How many rows will you hold? |
                                                 +---------------+---------------+
                                                                 |
                                                  +--------------+--------------+
                                                  |                             |
                                             < 100 rows                   100+ rows
                                                  |                             |
                                                  v                             v
                                         Use Table Variable              Use Temp Table
                                             (@Table)                       (#Temp)

Clarification on row count:
If you are strictly working with under 100 rows, @Table is completely
safe and fine. The advice "default to #Temp" exists because developers
often start with 50 rows, but real-world data grows to 50,000 rows
later. When that happens, @Table tanks query performance, while #Temp
scales smoothly.
*/