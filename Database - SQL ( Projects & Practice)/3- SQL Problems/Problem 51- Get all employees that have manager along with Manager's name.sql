-- Problem 51: Get all employees that have manager along with Manager's name.


-- restoring new database:
restore database EmployeesDB
from disk = 'D:\\EmployeesDB.bak';


select * from Employees;

-- solution:


-- in self joins, we join the main table with a copy of the main table and assign it an alias to be able to compare and join both tables:

select Employees.Name, Employees.ManagerID, Employees.Salary, ManagerName = Managers.Name
from Employees
join Employees as Managers on Employees.ManagerID = Managers.EmployeeID;


-- Managers.EmployeeID is referring to managers table with employees as managers not just normal employees
