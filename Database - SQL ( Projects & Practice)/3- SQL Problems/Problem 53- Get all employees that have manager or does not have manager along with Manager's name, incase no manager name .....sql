-- Problem 53: Get all employees that have manager or does not have manager along with Manager's name, incase no manager name the same employee name as manager to himself


select * from Employees;



select Employees.Name, Employees.ManagerID, Employees.Salary, ManagerName = 
case
	when Employees.ManagerID is not null then Managers.Name
	else Employees.Name
end
from Employees
left join Employees as Managers on Employees.ManagerID = Managers.EmployeeID;

