-- Select Top Statement

-- SELECT TOP (number|percent) column_name(s)
-- FROM table_name
-- WHERE condition;

use HR_Database;

-- returns all data
select * from Employees;

-- returns top 5 of all columns (not ordered by any thing)
select top 5 * from Employees;

-- returns top 10% of all columns (10% of 1000 is 100)
select top 10 percent * from Employees;


-- Q\ bring list of employees taking the highest 5 salaries:

-- first: find what are top 5 highest salaries (not employees, the salary itself):
select distinct top 5 MonthlySalary from Employees order by MonthlySalary desc;

-- second: bring a list of those whose salaries are in the values set of 5 highest salaries.
select ID, FirstName, MonthlySalary from Employees where MonthlySalary in (select distinct top 5 MonthlySalary from Employees order by MonthlySalary desc) order by MonthlySalary desc;



-- samll quiz with sub queries:
select * from Employees;

select * from Departments;

select FirstName,DepartmentID from Employees where DepartmentID in (1,3,5);

select * from Employees where DepartmentID not in (4,2);

select firstName from Employees where MonthlySalary in ( select distinct top 5 MonthlySalary from Employees order by MonthlySalary desc ) order by MonthlySalary desc;

select FirstName, DepartmentID from Employees where MonthlySalary in (select distinct MonthlySalary from Employees where DepartmentID = 4) ;

