-- Select As

/*
SQL aliases are used to give a table, or a column in a table, a temporary name.

Aliases are often used to make column names more readable.

An alias only exists for the duration of that query.

An alias is created with the AS keyword.

Alias Column Syntax:

SELECT column_name AS alias_name
FROM table_name;

*/

use HR_Database;

-- can be done two ways
select FullName = FirstName + ' ' + LastName from Employees;
select FirstName + ' ' + LastName as FullName from Employees;

-- another Example:
select halfSalaries = MonthlySalary/2 from Employees;

-- another Example of derived attributes:
select ID, FirstName, MonthlySalary, MonthlySalary * 12 as YearlySalary from Employees;

-- derived Age using built-in Functions:
-- datediff(result format, start date, end date)
select FirstName, Age = datediff(year, DateOfBirth, getDate()) from Employees;


-- oldest 3 employees in company (by years)
select top 3 * , age = datediff(year, DateOfBirth, getDate()) from Employees order by age desc;

-- employees younger than 30
select * , age = datediff(year, DateOfBirth, getDate()) from Employees where (datediff(year, DateOfBirth, getDate())) < 30;

-- we cant use alias defined before WHERE, to avoid typing the datediff two times we use derived table:
-- We use a derived table so we can reference the alias "Age" in the WHERE clause:                                      using the age alias of the derived table
select * from      (select FirstName, Age = DATEDIFF(year, DateOfBirth, GETDATE()) from Employees) as EmpployeesAge      where age between 30 and 40;
