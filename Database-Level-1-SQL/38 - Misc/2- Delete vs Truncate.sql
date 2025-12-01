-- Delete vs Truncate




use DB1;

select * from Departments;


-- delete is DML command, deletes table records, no identity numbering reset, can delete snigle records
delete from Departments;

-- Trnucate is DLL command (DB and Table structure commands), delete all table records and reset the table, everything is reset even the identity numbering, resets entire table, cant use WHERE statments
truncate table Departments;