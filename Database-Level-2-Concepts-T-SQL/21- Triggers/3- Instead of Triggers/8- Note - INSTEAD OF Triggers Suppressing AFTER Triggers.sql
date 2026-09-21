/* ============================================================================
   LESSON NOTE 2: INSTEAD OF Triggers Suppressing AFTER Triggers
   ============================================================================

   1. THE CORE CONFLICT
   ----------------------------------------------------------------------------
   You can have both an INSTEAD OF trigger and an AFTER trigger on the same 
   table. However, an AFTER trigger ONLY fires if the default database engine 
   operation successfully touches the physical table.

   Because an INSTEAD OF trigger intercepts and cancels that default engine 
   operation, the AFTER trigger will NEVER fire—unless your INSTEAD OF trigger 
   explicitly executes the exact base table write.


   2. ASCII EXECUTION PATH
   ----------------------------------------------------------------------------
   User runs: INSERT INTO Orders ...
                      │
                      ▼
   ┌────────────────────────────────────────────────┐
   │ INSTEAD OF INSERT TRIGGER Fires                │
   │                                                │
   │  Does this trigger run block runs              │
   │  INSERT INTO Orders statement (system insert)? │
   └─────────┬─────────────────────────┬─────────-──┘
             │                         │
            YES                        NO (Redirects, ignores, or errors)
             │                         │
             ▼                         ▼
   ┌────────────────────┐    ┌────────────────────┐
   │ AFTER INSERT       │    │ AFTER INSERT       │
   │ TRIGGER FIRES      │    │ TRIGGER IS CANCELED│
   └────────────────────┘    └────────────────────┘


   3. THE TAKEAWAY
   ----------------------------------------------------------------------------
   If you add an INSTEAD OF trigger to absorb or redirect commands (like doing 
   a soft delete instead of a hard delete), any existing AFTER triggers for 
   that action on the table will be completely bypassed and silenced.
   ============================================================================ */