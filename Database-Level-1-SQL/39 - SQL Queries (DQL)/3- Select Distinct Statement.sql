-- Select Distinct Statement, it is used to return non duplicate values, works like a filter.
-- Inside a table, a column often contains many duplicate values; and sometimes you only want to list the different (distinct) values.

use HR_Database;

select DepartmentID from Employees; -- this will return all Department IDs in the table

select distinct DepartmentID from Employees; -- this returns only IDs with no duplication




select FirstName from Employees; -- this will return all first names in the table

select distinct FirstName from Employees; -- this returns only first names with no duplication


-- if we use it with multiple columns, then it will return the whole columns with no duplication, ex:
select distinct FirstName, DepartmentID from Employees; -- we see first names are repeated, but as the two columns combined, they are not repeated.