

--select * from Accounts;
--select * from Transactions;

declare @transfereAmount decimal(10, 2) = 500.00; 

begin try

	begin transaction
		
		-- Subtracting money from sender
		update Accounts set Balance -= @transfereAmount where AccountID = 1;

		-- Adding money to receiver
		update Accounts set Balance += @transfereAmount where AccountID = 2;


		-- The changes are visible inside the current transaction,
		-- but they are not committed yet.
		-- If an error occurs and the transaction is rolled back,
		-- these changes will be undone.
		select * from Accounts;

		-- uncomment to cause an error then see the data in tables
		select 1 / 0;


		-- logging the operation
		insert into Transactions values ( 1, 2, @transfereAmount, GETDATE());

	commit transaction

end try
begin catch

	if @@TRANCOUNT > 0
		rollback transaction;

	throw; -- then catch in app or whatever to be informed or handled the right way

end catch

