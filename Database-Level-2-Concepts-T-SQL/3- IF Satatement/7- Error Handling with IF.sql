/*
====================================================================
 @@ERROR Summary (T-SQL)
====================================================================
- Execution Flow:
  T-SQL runs sequentially line-by-line. SQL Server inspects the outcome 
  of each individual statement immediately after execution and updates 
  @@ERROR before proceeding to the next line.

- Core Function:
  Holds the error number of the most recently executed statement.
  Returns 0 if the statement ran successfully.

- Reset Behavior:
  Automatically resets to 0 after every statement execution.
  Must be evaluated or stored into a variable immediately.

- Primary Use Case:
  Legacy error handling with IF statements to control COMMIT or ROLLBACK.

- Modern Standard:
  Superseded by TRY...CATCH blocks, which catch severe connection-level 
  errors that @@ERROR fails to intercept.
====================================================================
*/



declare @errorValue int;

-- generate an error for demo:
insert into Customers (Name)
values (12);

-- we must capture the error value before it is reset:
set @errorValue = @@ERROR;


if @errorValue <> 0
	print 'Error Value: ' + cast(@errorValue as varchar);
else
	print 'No Error';