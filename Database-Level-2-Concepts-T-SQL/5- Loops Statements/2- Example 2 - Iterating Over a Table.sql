

-- we set the start counter 
declare @employeeID int;
select @employeeID = min(EmployeeID) from Employees;

-- set the end of counter 
declare @maxID int;
select @maxID = max(EmployeeID) from Employees;


declare @name varchar(50);

while @employeeID is not null and @employeeID <= @maxID
begin
	select @name = Name from Employees where EmployeeID = @employeeID;
	print 'employee ID: ' + cast(@employeeID as varchar);
	print 'employee Name: ' + @name;
	print '---------------------------------------';

	-- updating the counter
	select @employeeID = min(EmployeeID) from Employees where EmployeeID > @employeeID;
end