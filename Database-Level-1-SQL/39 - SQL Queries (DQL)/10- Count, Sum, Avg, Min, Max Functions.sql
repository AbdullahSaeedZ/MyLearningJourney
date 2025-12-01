-- Count, Sum, Avg, Min, Max Functions

--Aggregated functions in SQL Server are functions that operate on a set of values and return a single aggregated value as a result.
-- Examples include functions like SUM, AVG, COUNT, MIN, and MAX. 
-- They are named as such because they "aggregate" or combine multiple rows into a single value based on the specified operation
-- (e.g., summing up values, finding the average, counting rows).

use HR_Database;


select NumberOfSalaries = COUNT(MonthlySalary) , -- does not count null values
		SumOfSalaries = Sum(MonthlySalary), 
		AverageSalaries = Avg(MonthlySalary) ,  -- does not count null values
		MinSalary = Min(MonthlySalary), 
		MaxSalary = Max(MonthlySalary)
from Employees;

-- with where:
select NumberOfSalaries = COUNT(MonthlySalary) , 
		SumOfSalaries = Sum(MonthlySalary), 
		AverageSalaries = Avg(MonthlySalary) ,  
		MinSalary = Min(MonthlySalary), 
		MaxSalary = Max(MonthlySalary)
from Employees where DepartmentID = 4;

-- ExitDate can be null which is for working emps, or resigned emps if date value.
-- since COUNT can work with only non-null values, we can count how many resigned employees:
select ResignedEmployees = count(ExitDate) from Employees;

-- here ID cant be null, so COUNT will count all IDs
select TotalEmployees = count(ID) from Employees;


select CurrentEmployees = count(ID) from Employees where ExitDate is null;