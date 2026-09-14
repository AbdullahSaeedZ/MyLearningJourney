-- =========================================================================
-- TRANSACTIONS: HANDLING OPERATIONS THAT FAIL WITHOUT ERRORS
-- =========================================================================

-- When performing a transfer, an operation may fail to achieve its intended
-- result without producing a SQL error, so TRY...CATCH and transactions alone
-- cannot detect every incomplete operation. We must also validate the result.
--
-- Example: if we update an AccountID that does not exist, SQL Server affects
-- 0 rows without throwing an error, so we can check @@ROWCOUNT and use THROW
-- to trigger the CATCH block and roll back the transaction.

-- we must have multiple checks also, if balances are sufficient and such things.

/*

Non-existent ID
      ↓
UPDATE affects 0 rows
      ↓
No SQL error
      ↓
TRY...CATCH does NOT trigger
      ↓
Transaction could COMMIT
      ↓
Invalid transfer could be logged

*/

declare @transferAmount decimal(10, 2) = 500.00;

begin try

    begin transaction;

    -- Subtracting money from sender.
    -- Change AccountID to a non-existent ID to test @@ROWCOUNT.
    update Accounts set Balance -= @transferAmount where AccountID = 999;
   
    -- If AccountID 999 does not exist, the UPDATE affects 0 rows.
    if @@ROWCOUNT = 0
        throw 50001, 'Sender account does not exist.', 1;


    -- Adding money to receiver.
    update Accounts set Balance += @transferAmount where AccountID = 2;

    if @@ROWCOUNT = 0
        throw 50002, 'Receiver account does not exist.', 1;

    -- Logging the operation.
    insert into Transactions values (1, 2, @transferAmount, GETDATE());

    commit transaction;

end try
begin catch

    -- THROW above transfers execution to CATCH,
    -- where the entire transaction is rolled back.
    -- if have the transaction block committed, when there is not existent ids, then the log statement would log invalid operation
    -- so we throw in above block to preserve data integrity.
    if @@TRANCOUNT > 0
        rollback transaction;

    throw;

end catch;

