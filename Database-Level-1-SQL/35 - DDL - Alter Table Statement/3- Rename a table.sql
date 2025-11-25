-- changing table name by SP

-- common script for most DBs:
--alter table Employees
--rename to Emps;



use DB1;

--                old name , new name
exec sp_rename 'Employees', 'Emps';