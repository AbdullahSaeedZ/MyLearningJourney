-- In Operator

use HR_Database;


select * from Employees where DepartmentID = 1 or DepartmentID = 2;

select * from Employees where DepartmentID = 1 or DepartmentID = 2 or DepartmentID = 7;

select * from Employees where DepartmentID = 1 or DepartmentID = 2 or DepartmentID = 5 or DepartmentID = 7;

-- short cut for or statements: 
-- used to check if something falls in value set
select * from Employees where FirstName in ('Jacob','Brooks','Harper');

select * from Employees where DepartmentID in (1,2,5,7); --  (1,2,5,7) there are called set of values



-- returning the departments that have employees with less than 210 salary
select DepartmentID from Employees where MonthlySalary <= 210; -- this resulted in set of values (3,5,7,4) in the result table

-- we can use the above set of values in another way:
-- return department names column from department table where the IDs fall in (3,5,7,4) <- departments that have less than 210 salary
select Name from Departments where ID in (select DepartmentID from Employees where MonthlySalary <= 210);





