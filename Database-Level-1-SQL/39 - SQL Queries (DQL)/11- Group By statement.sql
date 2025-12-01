-- Group By statement

--The GROUP BY statement is often used with aggregate functions (COUNT(), MAX(), MIN(), SUM(), AVG()) to group the result-set by one or more columns.

use HR_Database;
select * from Employees;

-- using aggregate functions for the whole table:
select TotalCount = count(MonthlySalary),
		TotalSum = Sum(MonthlySalary),
		Average = avg(MonthlySalary),
		MinSalary = min(MonthlySalary),
		MaxSalary = max(MonthlySalary) 

		from Employees;

-- what if i need it to show data per Departments ? i go one by one ?
select TotalCount = count(MonthlySalary),
		TotalSum = Sum(MonthlySalary),
		Average = avg(MonthlySalary),
		MinSalary = min(MonthlySalary),
		MaxSalary = max(MonthlySalary) 

		from Employees where DepartmentID = 1; -- then 2, then 3 ?... too long process


-- we use GROUP BY:
select DepartmentID,
		TotalCount = count(MonthlySalary),
		TotalSum = Sum(MonthlySalary),
		Average = avg(MonthlySalary),
		MinSalary = min(MonthlySalary),
		MaxSalary = max(MonthlySalary) 

		from Employees group by DepartmentID
		order by DepartmentID;



-- example we want to use aggregate functions to see info per age (group by age):
select DATEDIFF(YEAR, DateOfBirth, getDate()) as age,
		TotalCount = count(ID),
		TotalSum = Sum(MonthlySalary),
		Average = avg(MonthlySalary),
		MinSalary = min(MonthlySalary),
		MaxSalary = max(MonthlySalary) 

		from Employees  group by (DATEDIFF(YEAR, DateOfBirth, getDate()))
		order by age desc;