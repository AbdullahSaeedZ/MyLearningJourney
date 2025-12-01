-- Union
-- union is used to group two result sets into one result set, and they must have same columns.

-- Every SELECT statement within UNION must have the same number of columns
-- The columns must also have similar data types
-- The columns in every SELECT statement must also be in the same order




use HR_Database;

-- these two views that i created before, will use union to make them one table or result set:
select * from ActiveEmployees
union
select * from ResignedEmployees;


-- union does not return duplicate rows:
select * from Departments
union
select * from Departments;

-- if i need all rows with duplication, we use ALL:
select * from Departments
union all
select * from Departments;