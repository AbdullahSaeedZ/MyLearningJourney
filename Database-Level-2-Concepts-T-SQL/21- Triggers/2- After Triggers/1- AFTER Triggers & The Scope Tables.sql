/* ============================================================================
   LESSON: Introduction to AFTER Triggers & The Scope Tables
   ============================================================================

   1. THE CORE MECHANIC: WHAT HAPPENS ON "AFTER"?
   ----------------------------------------------------------------------------
   An AFTER trigger executes only after the initiating DML statement 
   (INSERT, UPDATE, or DELETE) has written its changes to the target table 
   inside the current transaction.

   If an error occurs or a ROLLBACK is issued inside the trigger, all changes 
   made by both the triggering statement and the trigger itself are undone.


   2. THE 3 TABLES ACCESSIBLE IN TRIGGER SCOPE
   ----------------------------------------------------------------------------
   Inside the execution scope of an AFTER trigger, you have access to three tables:

   1. The Target Table (Physical)  : The actual table being modified.
   2. The 'inserted' Table (Memory): Virtual table holding new/incoming rows.
   3. The 'deleted' Table (Memory) : Virtual table holding removed/old rows.


   +-------------------------------------------------------------------------+
   | DML Operation | 'inserted' Table Contains     | 'deleted' Table Contains|
   +---------------+-------------------------------+-------------------------+
   | INSERT        | The newly added rows          | [EMPTY]                 |
   | DELETE        | [EMPTY]                       | The removed rows        |
   | UPDATE        | The new post-update values    | The old pre-update rows |
   +-------------------------------------------------------------------------+


   3. ASCII ARCHITECTURE: SCOPE TABLES IN ACTION
   ----------------------------------------------------------------------------

   DML Statement (INSERT / UPDATE / DELETE)
          |
          +--------------------------------------------+
          |                                            |
          v                                            v
   [ Target Table ]                           [ Memory Buffer ]
   (Data modified)                                     |
          |                      +---------------------+---------------------+
          |                      |                                           |
          |                      v                                           v
          |              +---------------+                           +---------------+
          |              |   inserted    |                           |    deleted    |
          |              +---------------+                           +---------------+
          |              (New row image)                             (Old row image)
          |                      |                                           |
          +----------------------+---------------------+---------------------+
                                 |
                                 v
                     +-----------------------+
                     |  AFTER Trigger Scope  |
                     |                       |
                     |  SELECT * FROM        |
                     |  inserted / deleted   |
                     +-----------------------+


   4. GENERAL SYNTAX OF AN AFTER TRIGGER
   ----------------------------------------------------------------------------

   CREATE OR ALTER TRIGGER schema_name.trigger_name
   ON schema_name.target_table
   AFTER INSERT [, UPDATE, DELETE]
   AS
   BEGIN
       SET NOCOUNT ON;

       -- Trigger Logic Here
       -- Can query: target_table, inserted, deleted

   END;


   5. CRITICAL EXECUTION RULES
   ----------------------------------------------------------------------------
   1. Scope Lifetime:
      The `inserted` and `deleted` tables exist only in memory during the 
      execution of that specific trigger call. Once the trigger completes, 
      they are destroyed.

   2. Multi-Row Awareness:
      If an INSERT statement adds 1,000 rows at once, the trigger fires ONCE, 
      and the `inserted` table contains all 1,000 rows simultaneously. 
      Never write logic assuming `inserted` has only one row.
============================================================================ */