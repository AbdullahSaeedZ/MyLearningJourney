/* ============================================================================
   LESSON: Introduction to Database Triggers in T-SQL
   ============================================================================

   1. THE PROBLEM (Why do triggers exist?)
   ----------------------------------------------------------------------------
   Standard constraints (CHECK, FOREIGN KEY, DEFAULT) only validate static, 
   single-table rules. Stored procedures can enforce complex logic, but only if 
   every developer remembers to call them. 
   
   If someone runs an ad-hoc query or an application writes directly to a table, 
   business rules, audit trails, and synchronization can be bypassed. Triggers 
   exist to enforce behavior automatically at the storage engine level.


   2. WHAT IS A TRIGGER?
   ----------------------------------------------------------------------------
   A trigger is a special type of stored procedure that fires automatically 
   in response to specific events on a table or view (such as INSERT, UPDATE, 
   or DELETE). Unlike stored procedures, you cannot execute a trigger manually 
   via `EXEC TriggerName`.

   +-------------------------------------------------------------+
   |                       SQL SERVER ENGINE                     |
   |                                                             |
   |   User / App                                                |
   |       |                                                     |
   |       v                                                     |
   |  [ DML Query ] ---------->[ Target Table ]                  |
   |  (INSERT/UPDATE/DELETE)          |                          |
   |                                  v                          |
   |                         << Event Detected! >>               |
   |                                  |                          |
   |                                  v                          |
   |                           [ TRIGGER FIRES ]                 |
   |                            (Custom Action)                  |
   +-------------------------------------------------------------+


   3. THE THREE CORE COMPONENTS OF A TRIGGER
   ----------------------------------------------------------------------------
   Every trigger consists of:
   - Trigger Event    : Specifies the event activating the trigger (INSERT, UPDATE, DELETE).
   - Trigger Condition: Defines criteria that must be met to run the code.
   - Trigger Action   : The actual SQL code executed when activated.

          +--------------------+
          |   Trigger Event    |  --> INSERT, UPDATE, DELETE
          +---------+----------+
                    |
                    v
          +--------------------+
          | Trigger Condition  |  --> Evaluation check
          +---------+----------+
                    |
                    v
          +--------------------+
          |   Trigger Action   |  --> The executed SQL statements
          +--------------------+


   4. TRIGGER CLASSIFICATION BY EXECUTION TIMING
   ----------------------------------------------------------------------------
   Triggers are classified into two types based on when they execute:

                            +-------------------+
                            |   Trigger Types   |
                            +---------+---------+
                                      |
                 +--------------------+--------------------+
                 |                                         |
                 v                                         v
       +-------------------+                     +----------------------+
       | 1-AFTER Trigger   |                     | 2-INSTEAD OF Trigger |
       +---------+---------+                     +---------+------------+
                 |                                         |
         Fires AFTER data                          Fires INSTEAD OF
         modifications occur                      the triggering event
                 |                                         |
        +--------+--------+                       +--------+--------+
        |                 |                       |                 |
        v                 v                       v                 v
   [Use Cases]        [Sub-types]            [Use Cases]       [Behavior]
   - Auditing         - After Insert         - Complex         - Overrides default
   - Logging          - After Update           business rules  action
                      - After Delete


   5. PRIMARY USE CASES
   ----------------------------------------------------------------------------
   - Enforcing Business Rules : Validate complex requirements before allowing data changes.
   - Auditing & Logging       : Track changes (who, when, what data was altered).
   - Data Synchronization     : Keep related tables/databases aligned in real-time.
   - Automatic Updates        : Auto-update dependent fields or tables when events occur.


   6. PITFALLS & PRAGMATIC TAKEAWAYS
   ----------------------------------------------------------------------------
   1. Hidden Side Effects:
      Triggers fire silently in the background, making logic tracing and debugging 
      harder to follow than explicit application code.

   2. Multi-Row Execution:
      In SQL Server, a trigger fires once per statement, not once per row. 
      Logic must always handle multi-row sets cleanly.

   3. Transaction Scope:
      Triggers run within the same transaction as the triggering statement. 
      Any long-running trigger logic directly extends transaction locks.



   7. NOTE: created triggeres can be found in object explorer > DB > tables > targeted table > triggeres
============================================================================ */