-- Problem 54: Get All Employees managed by 'Mohammed'



select Employees.Name, Employees.ManagerID, Employees.Salary, ManagerName = Managers.Name
from Employees
join Employees as Managers on Employees.ManagerID = Managers.EmployeeID
where Managers.Name = N'Mohammed';