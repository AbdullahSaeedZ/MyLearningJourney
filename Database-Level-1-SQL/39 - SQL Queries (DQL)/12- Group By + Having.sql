-- Having is used with filtering result of GROUP BY (aggregate functions)
-- it is like where but used with group by.

-- The HAVING clause was added to SQL because the WHERE keyword cannot be used with aggregate functions in a direct way.
-- The idea is that the WHERE clause filters individual rows before the GROUP BY operation.
-- HAVING, on the other hand, is used to filter groups after the aggregation process.


use HR_Database;
-- this is showing info per each department:
select DepartmentID,
		TotalCount = count(MonthlySalary),
		TotalSum = Sum(MonthlySalary),
		Average = avg(MonthlySalary),
		MinSalary = min(MonthlySalary),
		MaxSalary = max(MonthlySalary) 

		from Employees group by DepartmentID
		order by DepartmentID;

-- i want to show these info per department but only show for departments with over 100 employee, i cant use where to filter, we use having:

select DepartmentID,
		TotalCount = count(ID),
		TotalSum = Sum(MonthlySalary),
		Average = avg(MonthlySalary),
		MinSalary = min(MonthlySalary),
		MaxSalary = max(MonthlySalary) 

		from Employees group by DepartmentID having count(ID) > 100
		order by DepartmentID;


-- when filtering results of group by, best practice is to use group by and having, but we must know:
-- we cant use where after group by, we use having , but there is an indirect way to use where after group by, we use subquery:
select * from 
(
	select DepartmentID,
		TotalCount = count(ID),
		TotalSum = Sum(MonthlySalary),
		Average = avg(MonthlySalary),
		MinSalary = min(MonthlySalary),
		MaxSalary = max(MonthlySalary) 

		from Employees group by DepartmentID
) 
as subTable where TotalCount > 100 
order by DepartmentID;

