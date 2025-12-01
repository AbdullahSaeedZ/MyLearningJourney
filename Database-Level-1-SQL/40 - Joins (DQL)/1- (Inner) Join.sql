-- (Inner) Join
-- there are 4 types of Joins:
-- first one is inner join, often called join, it is the most used type.

-- Inner JOIN clause is used to combine rows from two or more tables, based on a related column between them.
-- ex: customers table and orders table, using inner join will return a result table of customers with orders
-- no orders without customers, no customers without orders, only customers with orders.


use Shop_Database;

-- first run these two queries together, the two tables are not linked with references.
-- also there is issue of referential integrity, in orders table there are customers that dont exist in customers table
select * from Customers;
select * from Orders;

-- to fix the referential integrity, we take the intersected data of the two tables into one result table.
-- we take customers that have orders and put them in a new table using inner join:

select Customers.CustomerID, Customers.Name, Orders.Amount 
from Customers inner join Orders
on Customers.CustomerID = Orders.CustomerID;  -- on works sams as WHERE but for joins



-- another example to take employees ID, firstName from emp table, and department name from dept table, join them in one table:

use HR_Database;

select Employees.ID, Employees.FirstName, Departments.Name as DeptName
from Employees inner join Departments
on Employees.DepartmentID = Departments.ID; -- where each employee has deptID; two tables based on a common column

-- we can use WHERE also:
select Employees.ID, Employees.FirstName, Departments.Name as DeptName
from Employees inner join Departments
on Employees.DepartmentID = Departments.ID
where Departments.Name = 'IT';


-- we can design the query in the Query Designer, right click anywhere: then select tables and check needed columns then copy past the query:
SELECT   Employees.ID, Employees.FirstName, Departments.Name as DeptName, Countries.Name AS Country
FROM      Employees INNER JOIN
                Departments ON Employees.DepartmentID = Departments.ID INNER JOIN
                Countries ON Employees.CountryID = Countries.ID;


