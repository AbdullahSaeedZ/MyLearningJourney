E-- Delete Statement is to delete records in a table

-- DELETE FROM table_name
-- WHERE condition;


use DB1;

select * from Employees;

-- this will delete all records
--Delete from Employee; 


-- delete a record that meet condition
Delete from Employees
where Salary < 2000;

delete from Employees
where Phone is null; -- this is how to type null ,  we type is null not = null
