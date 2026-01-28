--  Problem 52: Get all employees that have manager or does not have manager along with Manager's name, incase no manager name show null


-- using left join:
select Employees.Name, Employees.ManagerID, Employees.Salary, ManagerName = Managers.Name
from Employees
left join Employees as Managers on Employees.ManagerID = Managers.EmployeeID;