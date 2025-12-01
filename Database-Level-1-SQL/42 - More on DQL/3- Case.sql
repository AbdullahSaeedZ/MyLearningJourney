-- Case
-- it is similar to Switch case in programming
-- once a condition is true, it will stop and return the true result, if non is true, then ELSE will return, if no true and no else part, then returns null

use HR_Database;


-- we have Gender column but gives m or f, i will create a new column to show either male or female using the cases:
select ID, FirstName, LastName, GenderTitle = 
case 
	when Gender = 'M' then 'Male'
	when Gender = 'F' then 'Female'
	else 'Unknown'
end
from Employees;

------------------------------------------------------------------------------

-- multiple case statements? yessss :
select ID, FirstName, LastName, GenderTitle = 
case 
	when Gender = 'M' then 'Male'
	when Gender = 'F' then 'Female'
	else 'Unknown'
end,
EmployeeStatus = 
case 
	when ExitDate is null then 'Active'
	when ExitDate is not null then 'Resigned'
	else 'Unknown'
end
from Employees;

------------------------------------------------------------------------------

-- can do equations:
select ID, FirstName, LastName, MonthlySalary, 
NewSalary = 
case 
	when MonthlySalary < 1000 then MonthlySalary * 2
	when MonthlySalary > 1000 then MonthlySalary * 1.5
	else MonthlySalary * 1
end
from Employees;


------------------------------------------------------------------------------


-- can use it when creating views:
create view ExtraEmployeesDetails as
select ID, FirstName, LastName, GenderTitle = 
case 
	when Gender = 'M' then 'Male'
	when Gender = 'F' then 'Female'
	else 'Unknown'
end,
EmployeeStatus = 
case 
	when ExitDate is null then 'Active'
	when ExitDate is not null then 'Resigned'
	else 'Unknown'
end
from Employees;



