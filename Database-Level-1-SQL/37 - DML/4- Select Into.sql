-- Select Into
-- used to copy data from existing table to a new table that will be created automaticaly 
-- it will only copy data, no constraints copoied

-- select * (all columns or specific columns)
-- into new_table_name
-- from existing_table;

use DB1;

select * from Employees;


select *
into EmployeesCopy1
from Employees;

select * from EmployeesCopy1;


-- copy certain columns to a new table
select ID, Name
into EmpsCopy2
from Employees;

select * from EmpsCopy2;


-- can use conditions to copy table
select *
into ConditionTable
from Employees
where Salary > 10000;

select * from ConditionTable;

-- trick to copy table columns but with no data
-- where 5=7 is false , so no matching data will be copied hence new table with empty data.
select *
into EmptyTable
from Employees
where 5=7; 

select * from EmptyTable;