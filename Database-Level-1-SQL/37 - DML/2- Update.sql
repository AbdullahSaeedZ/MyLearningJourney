-- update command 
-- WHERE keyword is sooooo important, be carefull, if not using it, whole table will be affected.

-- UPDATE table_name
-- SET column1 = value1, column2 = value2, ...
-- WHERE condition;


use DB1;

select * from Employees;


-- the change, then the condition, if no condition then it will change all table !! be careful.
update Employees
set Name = 'abood'
where ID = 1;

-- multiple fields update
update Employees
set Name ='foooo', Salary = 1000
where ID = 2;


-- using conditions in different ways
update Employees
set Salary = Salary + 200
where Salary < 10000;

-- can use compound operators += / *= and son on
update Employees
set Salary += 1500
where Salary > 10000;
