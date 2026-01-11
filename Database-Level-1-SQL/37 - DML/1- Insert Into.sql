-- DML, Data Manipulation Language, to manipulate data of database.
-- can do it from table -> right click -> edit top 200 rows -> edit there.

-- prepare needed script then highlight needed line to execute

use DB1;

-- brings data of table
select * from Employees;


-- insert one record 
insert into Employees
values 
(1, 'abdullah', '054322', 89000);  -- values must be in the same order of columns



-- insert multiple records at a time 
insert into Employees
values 
(2, 'emp2', '3424423', 43000) , 
(3, 'emp3', '654654', 53000) ,
(4, 'emp4', '23323', 55000);


-- insert one record with nulls
insert into Employees
values 
(6, 'temp', null, 89000);



-- insert records with certain selected fields
insert into Employees (ID, Name) -- this will be rejected, cuz it will insert Salary field as null, which is not allowed as we specified in constraints
values
(5, 'fofo');


-- insert records with certain selected fields
insert into Employees (ID, Name, Salary) -- here it is ok, cuz those are mandatory (not null), and the rest are nullable
values
(7, 'fofo', 9900);