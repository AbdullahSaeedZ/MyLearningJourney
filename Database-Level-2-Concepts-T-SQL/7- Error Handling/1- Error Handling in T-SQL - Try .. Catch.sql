use C21_DB1;

/*
create table Employees3
(
	EmployeeID int primary key,
	Name varchar(50),
	Position varchar(50)
);
*/


-- example of generating an error of adding multiple records with same ID
--insert into Employees3 (EmployeeID, Name, Position) values (1, 'Abdullah', 'SE'); -- will succeed
--insert into Employees3 (EmployeeID, Name, Position) values (1, 'Ali', 'DevOps Eng') -- will crash



-- using try-catch block, which its sole job is error interception
begin try

	insert into Employees3 (EmployeeID, Name, Position) values (2, 'Mohammed', 'SE'); -- will succeed
	insert into Employees3 (EmployeeID, Name, Position) values (2, 'Ali', 'ML Eng') -- will throw

end try
begin catch

	print 'Error Caught: ' + error_message(); -- < will be explained in details
	-- No Automatic Rollback for transactions, this is only error interception, where we can handle errors in anyway

end catch