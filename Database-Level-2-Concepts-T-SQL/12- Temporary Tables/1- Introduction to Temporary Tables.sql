/*
==================================================
T-SQL TEMPORARY TABLES: COMPLETE REFERENCE
==================================================

1. WHAT IS A TEMP TABLE?
- Definition: A short-lived table in T-SQL used to store and process intermediate query results.
- Storage: Created and hosted within the system database 'tempdb'. 
- Lifecycle: Survives temporarily and drops automatically when no longer in use.
- Purpose: Simplifies complex operations that require multi-step intermediate storage.

2. ADVANTAGES
- Performance: Improves speed in complex queries by breaking execution into simpler parts.
- Complex Data Processing: Facilitates intermediate staging for intricate logic.
- Transaction Management: Reduces overhead because changes are not extensively logged.

3. TYPES & SYNTAX

    1- Local Temporary Table (#):
        * Prefix: Single hash symbol (#).
        * Scope: Visible only to the connection/session that created it.
        * Drop Rule: Automatically deleted when the creating connection closes.
        * Example:

            CREATE TABLE #LocalTemp (
                ID INT PRIMARY KEY,
                Name VARCHAR(50)
            );

    2- Global Temporary Table (##):
        * Prefix: Double hash symbol (##).
        * Scope: Visible to all concurrent database connections.
        * Drop Rule: Automatically deleted when the last active referencing connection closes.
        * Example:
            CREATE TABLE ##GlobalTemp (
                ID INT PRIMARY KEY,
                Name VARCHAR(50)
            );

5. Temp Table vs Variable Table:
    +----------------------+-------------------------------+-------------------------------+
    | Feature              | Temp Table (#Table)           | Table Variable (@Table)       |
    +----------------------+-------------------------------+-------------------------------+
    | Storage Location     | tempdb.mdf on Disk            | tempdb.mdf on Disk            |
    |                      | (Operates in RAM, flushes/    | (Operates in RAM, flushes/    |
    |                      |  spills to disk as needed)    |  spills to disk as needed)    |
    +----------------------+-------------------------------+-------------------------------+
    |                      |                               |                               |
    | Optimizer Statistics | Yes (Accurate row estimates)  | No (Historically assumes ~1)  |
    |                      |                               |                               |
    +----------------------+-------------------------------+-------------------------------+
    |                      |                               |                               |
    | Custom Indexes       | Yes (Any index after create)  | Only during creation          |
    |                      |                               |                               |
    +----------------------+-------------------------------+-------------------------------+
    |                      |                               |                               |
    | Scope                | Session / Connection          | Current batch / Routine only  |
    |                      |                               |                               |
    +----------------------+-------------------------------+-------------------------------+
    |                      |                               |                               |
    | Explicit Rollback    | Yes (Reverts with ROLLBACK)   | No (Ignores rollbacks)        |
    |                      |                               |                               |
    +----------------------+-------------------------------+-------------------------------+
    |                      |                               |                               |
    | Ideal Data Volume    | Large datasets (> 100 rows)   | Tiny datasets (< 100 rows)    |
    |                      |                               |                               |
    +----------------------+-------------------------------+-------------------------------+

4. CLEANUP BEST PRACTICE
- Although SQL Server drops temp tables automatically upon session termination, explicitly dropping them prevents resource contention in tempdb:
    DROP TABLE IF EXISTS #LocalTemp;
*/