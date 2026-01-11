-- Sorting using Order By

use HR_Database;

-- this returns data based on how they are stored and ordered in the database
select ID, FirstName, MonthlySalary from Employees where DepartmentID = 1;

-- Note: Ascending uses ASCII order.
-- A = 65, B = 66, so ascending is 65 -> 66 -> 67 (A -> B -> C).
-- Descending is the opposite: Z -> Y -> X.



-- order by, default is Ascending A to Z 
-- same data returned but ordered by monthly salary from lowest to highest
select ID, FirstName, MonthlySalary from Employees where DepartmentID = 1 order by MonthlySalary;
-- this is the same, just explicitly typing ASC:
select ID, FirstName, MonthlySalary from Employees where DepartmentID = 1 order by MonthlySalary asc;


-- or by first name (ascending by default):
select ID, FirstName, MonthlySalary from Employees where DepartmentID = 1 order by FirstName;
-- order by + desc:
select ID, FirstName, MonthlySalary from Employees where DepartmentID = 1 order by FirstName desc;



-- order by multiple columns:                                            first column is the priority, second columns will affect when there is duplicate in first column, if not then no impact
select ID, FirstName, MonthlySalary from Employees where DepartmentID = 1 order by FirstName asc, MonthlySalary desc;
select ID, FirstName, MonthlySalary from Employees where DepartmentID = 1 order by FirstName desc, MonthlySalary asc;
select ID, FirstName, MonthlySalary from Employees where DepartmentID = 1 order by  MonthlySalary asc, FirstName desc;

select Gender, MonthlySalary from Employees order by MonthlySalary desc;