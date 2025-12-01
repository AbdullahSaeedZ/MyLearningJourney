-- DQL data query language, SELECT command to fetch data from database.

-- The SELECT statement is used to select data from a database.
-- The data returned is stored in a result table, called the result-set.

use HR_Database;

-- query structure:
-- select (columns) from (table);

-- can use WHERE to filter
-- select (columns) from (table) where (condition or filtering);

-- * means return all columns 

select * from Employees; -- all columns
select Employees.* from Employees; -- this is the same, all columns, tableName.columnName
select Employees.ID from Employees; -- will be used later to fetch data from multiple tables in one result table (called Join)

select ID, FirstName, LastName, MonthlySalary from Employees; -- return specific columns (returns columns results in the same order of query)


select * from Departments;

select * from Countries;