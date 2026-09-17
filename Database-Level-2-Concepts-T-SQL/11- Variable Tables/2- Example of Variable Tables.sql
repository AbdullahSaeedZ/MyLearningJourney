
use C21_DB1;

GO
-- we used to declare a variable using this syntax:
declare @variable int;

-- whith variable tables it is the same but we set the type as table and create the columns:
declare @EmployeesVariableTable table
(
	EmployeeID int primary key identity,
	Name varchar(50),
	Department varchar(50)
);



-- now since the variable table is created on RAM, we can insert normally and do operations
insert into @EmployeesVariableTable values ('Abdullah Saeed', 'Development');
insert into @EmployeesVariableTable values ('Mohammed Ali', 'Development');


-- The scope of a table variable is strictly limited to the current batch, stored procedure, or function.
-- Because this batch includes DECLARE, INSERT, and SELECT together, this query executes successfully:
select * from @EmployeesVariableTable;
GO

-- If you try to run the SELECT statement below on its own in a new execution, 
-- it will fail because the variable went out of scope when the previous batch completed:
-- SELECT * FROM @EmployeesTableVariable;