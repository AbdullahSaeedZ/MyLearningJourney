/* ============================================================================
   LESSON: Transaction Scope & Error Handling in Triggers
   ============================================================================

   1. THE EXECUTION BOUNDARY (AFTER & INSTEAD OF)
   ----------------------------------------------------------------------------
   Whether a trigger is AFTER or INSTEAD OF, SQL Server places both the 
   initiating DML statement and the trigger inside the SAME implicit transaction.

   +------------------------------------------------------------------------+
   |                        IMPLICIT TRANSACTION                            |
   |                                                                        |
   |   [ DML Statement ] <---> [ Trigger (AFTER or INSTEAD OF) ]            |
   |           \                                 /                          |
   |            +---------------+---------------+                           |
   |                            |                                           |
   |                            v                                           |
   |           Does an unhandled runtime error occur?                       |
   |                     /             \                                    |
   |                   YES              NO                                  |
   |                    |                |                                  |
   |     Default behavior:               v                                  |
   |     Statement aborts, but   [ COMMIT TRANSACTION ]                     |
   |     the transaction may     (All changes persist)                      |
   |     STILL COMMIT!                                                      |
   +------------------------------------------------------------------------+


   2. THE MISCONCEPTION: "TRIGGERS ALWAYS AUTO-ROLLBACK"
   ----------------------------------------------------------------------------
   By default (XACT_ABORT OFF), SQL Server treats most trigger runtime errors 
   (like divide-by-zero, conversion failure, string truncation) as 
   STATEMENT-terminating, not TRANSACTION-terminating. 
   
   The line that failed stops, but the trigger continues to the end and 
   commits the parent transaction unless you enforce otherwise.


   3. TWO WAYS TO GUARANTEE A CLEAN ROLLBACK
   ----------------------------------------------------------------------------
   Method A: SET XACT_ABORT ON
   Tells SQL Server: "If ANY error occurs, instantly terminate and roll back 
   the entire transaction."

   Method B: Structured TRY...CATCH + THROW
   Explicitly catch violations, roll back, and raise an error back to the caller.
============================================================================ */


-- ============================================================================
-- DEMO: Bulletproof Rollback Pattern (Works for AFTER & INSTEAD OF)
-- ============================================================================

CREATE TABLE Accounts (
    AccountId INT PRIMARY KEY,
    Balance DECIMAL(10, 2)
);
GO

CREATE OR ALTER TRIGGER trg_ValidateAccountBalance
ON Accounts
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Method A: Best Practice Safety Net
    SET XACT_ABORT ON;

    -- Method B: Structured Business Rule Validation
    BEGIN TRY
        -- Check if any inserted/updated row violates business logic
        IF EXISTS (SELECT 1 FROM inserted WHERE Balance < 0)
        BEGIN
            -- User-defined errors throw to CATCH
            THROW 50001, 'Account balance cannot be negative.', 1;
        END;
    END TRY
    BEGIN CATCH
        -- Check if transaction is uncommittable or active
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END;

        -- Re-throw original error to notify the calling application
        THROW;
    END CATCH;
END;
GO

-- Test: Attempt invalid insert
-- Result: Transaction fully rolled back, zero rows committed to Accounts.
INSERT INTO Accounts (AccountId, Balance) VALUES (1, -50.00);