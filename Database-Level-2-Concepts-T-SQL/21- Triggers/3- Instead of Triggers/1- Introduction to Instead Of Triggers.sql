/* ============================================================================
   LESSON: Understanding INSTEAD OF Triggers (Foundations)
   ============================================================================

   1. THE CORE CONCEPT
   ----------------------------------------------------------------------------
   Normally, when you tell SQL Server to INSERT, UPDATE, or DELETE a row, 
   the engine immediately processes constraints and writes to the table.

   An INSTEAD OF trigger acts like an interceptor:
   - It catches your query before any write touches the table.
   - It tells SQL Server: "Cancel your default action. Run my code instead."
   - If the trigger code does not explicitly perform an underlying write, 
     nothing is saved to storage.


   2. SIMPLE EXECUTION FLOW
   ----------------------------------------------------------------------------

   User sends: DELETE FROM Employees WHERE ID = 5
                         │
                         ▼
        ┌──────────────────────────────────┐
        │    INSTEAD OF DELETE Trigger     │
        └────────────────┬─────────────────┘
                         │
            (Normal DELETE is CANCELLED)
                         │
                         ▼
        Trigger runs its own custom logic:
        UPDATE Employees SET IsActive = 0 WHERE ID = 5
                         │
                         ▼
             Data modified on your terms


   3. HOW IT WORKS BEHIND THE SCENES
   ----------------------------------------------------------------------------
   - The engine catches the user's command.
   - It places the incoming rows into temporary memory tables:
       * `inserted` (holds proposed new data or post-update values)
       * `deleted`  (holds data being removed or pre-update values)
   - The trigger reads these memory tables and decides what action to execute.


   4. DO YOU NEED TO MANUALLY CHECK CONSTRAINTS?
   ----------------------------------------------------------------------------
   It depends on whether your trigger eventually forwards the write:

   - IF THE TRIGGER WRITES TO THE BASE TABLE:
     NO manual check needed. When your trigger executes an INSERT or UPDATE 
     into the physical table, the engine fires all standard constraints 
     (CHECK, FOREIGN KEY, NOT NULL, UNIQUE) normally at that exact moment.

   - IF THE TRIGGER DOES NOT FORWARD THE WRITE:
     YES, you must check manually. If the trigger redirects data, runs an 
     audit log, or absorbs the command without targeting the original table, 
     the engine's table constraints are never reached. Any validation must be 
     written explicitly in your trigger logic.

   ASCII CONSTRAINT PATH:

   User executes DML
          │
          ▼
   INSTEAD OF Trigger intercepts
          │
          ├─► Trigger performs actual INSERT/UPDATE into base table
          │   └──► Engine constraints (FK, CHECK, NOT NULL) FIRE AUTOMATICALLY.
          │
          └─► Trigger halts, ignores, or redirects without base write
              └──► Constraints NEVER fire. You must validate manually.


   5. WHERE DOES THIS SHINE? (Teaser for next lesson)
   ----------------------------------------------------------------------------
   - Soft Deletes: Turning permanent DELETE queries into "archive" updates.

   - Overcoming View Limitations: Multi-table joined views in SQL Server are 
     normally read-only. An INSTEAD OF trigger intercepts writes to the view 
     and splits the columns across the underlying tables.


   6. COMMON PITFALLS & MISTAKES
   ----------------------------------------------------------------------------
   - Assuming Row-by-Row Execution: Like all T-SQL triggers, INSTEAD OF triggers 
     run ONCE per statement, not once per row. If someone updates 1,000 rows, 
     `inserted` contains 1,000 rows. Writing code that assumes only 1 row exists 
     is the most common bug.
   - Hidden Business Logic: Because standard DML statements behave differently 
     under the hood, developers querying the table might be surprised when an 
     INSERT or DELETE produces unexpected side effects.
   - Infinite Recursion: If your INSTEAD OF trigger fires on an UPDATE and 
     internally executes another UPDATE on the exact same table without care, 
     it can trigger itself repeatedly until hitting the nesting limit.
   - Accidental Constraint Bypass: Assuming the database already checked foreign 
     keys or check constraints before the trigger started. Remember: constraints 
     only validate if and when you write to a constrained table.
   ============================================================================ */