-- =========================================================================
-- TRANSACTIONS IN T-SQL: INTRODUCTION
-- =========================================================================

-- 1. THE PROBLEM
--
-- Some operations require multiple database changes that must succeed
-- together.
--
-- Example: transferring $500 between two bank accounts requires:
--
--     1. Subtract $500 from the sender.
--     2. Add $500 to the receiver.
--
-- Without a transaction, the first operation could succeed while the
-- second fails, leaving the database in an incorrect state.
--
-- Transactions solve this by treating related operations as one unit.



-- 2. CORE IDEA
--
-- A transaction groups multiple database operations into one logical unit.
--
--     BEGIN TRANSACTION
--          |
--       Operation 1
--       Operation 2
--          |
--     COMMIT / ROLLBACK
--
-- COMMIT    -> Keep the changes.
-- ROLLBACK  -> Undo the changes made by the transaction.



-- 3. ACID PROPERTIES
--
-- Atomicity:
--     ALL-OR-NOTHING
--     All related changes succeed together as ONE SINGLE UNIT, or the transaction is rolled back.
--
-- Consistency:
--     VALID STATE
--     The transaction moves the database from one valid state to another
--     valid state according to its rules, keeping same constraints and rules.
--
-- Isolation:
--     Concurrent transactions should not incorrectly see each other's
--     intermediate changes.
--
--     Real-world example:
--     You transfer $500 from Account A to Account B.
--     Another user checking the accounts should not see the transfer halfway
--     through, such as A losing $500 while B has not received it yet.
--
-- Durability:
--     PERMANENT AFTER COMMIT
--     Once COMMIT succeeds, the committed changes are preserved even if
--     the database server crashes afterward.
--
--     Real-world example:
--     You successfully transfer $500 and receive confirmation.
--     The server crashes one second later, but the completed transfer
--     must still exist when the database comes back online.
--
-- IMPORTANT:
-- ACID describes the transaction as a whole, not individual statements.
-- Before COMMIT, SQL Server records the transaction's changes in its
-- transaction log, but the changes are not yet permanently committed.
-- Once COMMIT succeeds, the changes become permanent and visible as part
-- of the committed database state. This allows SQL Server to ROLLBACK the
-- transaction if something fails before the final commit.




-- 4. PRACTICAL EXAMPLE: MONEY TRANSFER

-- @@TRANCOUNT:
-- A SQL Server system variable that shows the number of active transaction
-- levels on the current connection.
-- After BEGIN TRANSACTION, @@TRANCOUNT is 1; if we inspect it before COMMIT,
-- we will see a value of 1.
-- Here, we check if @@TRANCOUNT > 0 before ROLLBACK to make sure there is an
-- active transaction to roll back, preventing a rollback error.


BEGIN TRY
    BEGIN TRANSACTION;

    -- Deduct money from the sender.
    UPDATE Accounts
    SET Balance = Balance - 500.00
    WHERE AccountID = 101;

    -- Add money to the receiver.
    UPDATE Accounts
    SET Balance = Balance + 500.00
    WHERE AccountID = 102;

    -- Record the completed transfer.
    INSERT INTO TransferLogs
        (SenderID, ReceiverID, Amount, TransferDate)
    VALUES
        (101, 102, 500.00, GETDATE());

    -- All operations succeeded, so make the transaction permanent.
    COMMIT TRANSACTION;

END TRY
BEGIN CATCH

    -- If any operation fails, undo all changes made by this transaction.
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;


-- HOW ACID APPLIES TO THIS EXAMPLE:
--
-- Atomicity:
--     The account updates and the log entry are treated as one unit.
--     If any operation fails, all changes are rolled back.
--
-- Consistency:
--     A successful transfer moves $500 from one account to another and
--     keeps the database in a valid state according to its rules.
--
-- Isolation:
--     Other concurrent transactions should not incorrectly observe the
--     transfer halfway through.
--
-- Durability:
--     After COMMIT succeeds, the transfer and log entry remain committed
--     even if the server crashes afterward.



-- 5. BEST PRACTICES
--
-- - Use transactions when multiple operations must succeed or fail together.
--
-- - Keep transactions SHORT.
--   A transaction that stays open for a long time can hold database locks (locking tables being updated).
--   Other transactions may then have to WAIT for those locks to be released,
--   causing BLOCKING and reducing concurrency.
--
-- - Use TRY...CATCH with important multi-step transactions.
--
-- - Do not explicitly wrap every isolated statement in a transaction.
--
--   Example:
--
--       BEGIN TRANSACTION;
--
--       UPDATE Users
--       SET Name = 'Abdullah'
--       WHERE UserID = 1;
--
--       COMMIT TRANSACTION;
--
--   If this is one independent operation, the UPDATE statement is already
--   atomic by itself, so an explicit transaction usually adds no benefit.