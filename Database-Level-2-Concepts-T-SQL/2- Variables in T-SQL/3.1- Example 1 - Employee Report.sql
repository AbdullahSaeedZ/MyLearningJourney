--select * from Departments;
--select * from Employees;

declare @DepartmentID int;
declare @StartDate date;
declare @EndDate date;
declare @TotalEmployees int;
declare @DepartmentName varchar(50);


set @DepartmentID = 3;
set @StartDate = '2022-9-1';
set @EndDate = '2023-12-10';

-- get department name from the table and assign it to the variable directly
select @DepartmentName = name from Departments where DepartmentID = @DepartmentID;

-- same here with total employees
select @TotalEmployees = count(*) from Employees
where @DepartmentName = @DepartmentName and HireDate between @StartDate and @EndDate;

-- then we print the report using the variables
Print 'Department ' + cast(@DepartmentID as varchar(2)) + ' Report:';
print 'Department Name: ' + @DepartmentName;
print 'Reporting Period: ' + cast(@StartDate as varchar(10)) + ' to ' + cast(@EndDate as varchar(10));
print 'Total Employees: ' + cast(@TotalEmployees as varchar(10)); 

