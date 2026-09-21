/* ============================================================================
   LESSON NOTE 1: The Recursion Overflow Issue in Triggers
   ============================================================================
   
   1. THE CORE PROBLEM
   ----------------------------------------------------------------------------
   If a trigger performs the same DML action on the exact same table it is 
   monitoring, it can accidentally re-trigger itself. This creates an infinite 
   loop (Recursion).
   
   SQL Server will allow this loop to repeat up to 32 times (the nesting limit). 
   Once it hits level 32, the engine forcefully aborts the transaction and 
   throws Error 217 (Maximum stored procedure, function, trigger, or view 
   nesting level exceeded).

   2. VISUALIZING THE LOOP
   ----------------------------------------------------------------------------
   User executes: UPDATE Employees SET Salary = 5000
                         │
                         ▼
   ┌──────────────────────────────────────────────────┐
   │ TRIGGER: AFTER UPDATE ON Employees               │
   │                                                  │
   │   -- Developer tries to auto-update a timestamp  │
   │   UPDATE Employees SET LastModified = GETDATE()  │
   └─────────────────────┬────────────────────────────┘
                         │
                         ▼ (Fires the trigger again!)
   ┌──────────────────────────────────────────────────┐
   │ TRIGGER: AFTER UPDATE ON Employees               │
   │   UPDATE Employees SET LastModified = GETDATE()  │
   └─────────────────────┬────────────────────────────┘
                         │
                       (x32 times until CRASH)


   3. THE SOLUTION
   ----------------------------------------------------------------------------
   Always check if the specific column was updated before running recursive logic,
   or ensure your database has direct trigger recursion turned OFF (which is 
   the default, but never rely purely on defaults).

   IF NOT UPDATE(LastModified) -- Only run if we aren't the ones updating it
   BEGIN
       UPDATE Employees SET LastModified = GETDATE() ...
   END
   ============================================================================ */