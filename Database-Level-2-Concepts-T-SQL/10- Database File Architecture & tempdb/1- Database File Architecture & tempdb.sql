/*
====================================================================
LESSON: Database File Architecture & tempdb 
====================================================================

SECTION 1: HOW A SQL SERVER DATABASE IS STRUCTURED & LOGGED
--------------------------------------------------------------------
1. Every Database Has Two Dedicated File Types:
   - Data File (.mdf / .ndf): Stores actual permanent tables, rows, 
     and indexes on disk.
   - Transaction Log File (.ldf): A sequential record of every INSERT, 
     UPDATE, and DELETE performed on that database.

2. What Transaction Logging Does:
   - When you modify a row in your user database (e.g., C21_DB1), the 
     change is written to C21_DB1.ldf *first* before hitting disk data pages.
   - Purpose: 
     * Rollbacks: Undoing changes if an operation fails or you call ROLLBACK.
     * Crash Recovery: If the power cuts out, SQL Server replays this log 
       on startup so no committed data is lost.

3. Complete Isolation of Logs:
   - Each database manages its own independent .ldf file. 
   - Work done in your user database logs to your user database log file. 
   - None of your regular, permanent table work ever touches or logs to tempdb.

   ===================================================================
                       SQL SERVER INSTANCE
   ===================================================================
                                   |
           +-----------------------+-----------------------+
           |                                               |
           v                                               v
   +-------------------------------+               +-------------------------------+
   |     USER DATABASE             |               |     SYSTEM DATABASE           |
   |     (e.g., C21_DB1)           |               |     (tempdb)                  |
   +-------------------------------+               +-------------------------------+
           |                                               |
           |-- 1. Data File (.mdf / .ndf)                  |-- 1. Data File (tempdb.mdf)
           |      - Permanent tables                       |      - Temporary tables (#Table)
           |      - Clustered indexes                      |      - Intermediate worktables
           |      - Row data storage                       |      - Dropped / reset on restart
           |                                               |
           \-- 2. Transaction Log (.ldf)                   \-- 2. Transaction Log (tempdb.ldf)
                  - C21_DB1.ldf (Dedicated)                       - tempdb.ldf (Dedicated)
                  - Write-Ahead Logging (WAL)                     - Minimal logging
                  - Rollbacks & Crash Recovery                    - Fully isolated from User DB


SECTION 2: DEEP DIVE INTO tempdb & TRANSIENT STORAGE
--------------------------------------------------------------------
1. What tempdb Is & When It Is Involved:
   - What it is: tempdb is an independent, globally shared system database 
     created automatically on every SQL Server instance. It is NOT tied to 
     any single user database, but acts as a shared scratchpad for the engine.

   - When it is used and involved: It is invoked whenever temporary work occurs, 
     such as:
     * User-created temporary objects: Temporary Tables (#TempTable) and 
       Table Variables (@TableVar).
     * Internal engine operations: Intermediate work tables, sorting spills 
       (e.g., massive ORDER BY operations exceeding allocated memory), and 
       hash joins.

   - Unique Lifecycle: tempdb is completely wiped clean and recreated from scratch 
     every time SQL Server restarts. Nothing inside it persists.

2. How tempdb Handles Logging Differently:
   - Because tempdb is wiped clean on server restart, SQL Server does NOT 
     need crash recovery across reboots for it.

   - Therefore, tempdb runs in a special minimal-overhead logging mode 
     (Simple Recovery Model).

   - What does tempdb.ldf actually roll back?
     * If an operation modifies only regular permanent tables, ONLY the 
       User Database log file (.ldf) handles the rollback; tempdb is not involved.

     * tempdb.ldf is used strictly to roll back operations on temporary 
       objects living inside tempdb (such as Temporary Tables #TempTable, 
       which will be covered later, or failed internal sorting/hash operations).

     * If a transaction touches both a permanent table and a temporary table, 
       UserDB.ldf rolls back the permanent table while tempdb.ldf rolls back 
       the temporary table simultaneously.

3. How Table Variables Use tempdb:
   - Pages are allocated in tempdb (cached in RAM first, spilling to disk only under pressure).
   - Writes strictly to tempdb.ldf, never touching your user database log.
   - Generates minimal logging by recording only page allocations, skipping row-level changes.
   - Rollback Consequence: Because individual row modifications are not logged, changes to 
     table variables persist even if a transaction is rolled back.


====================================================================
*/