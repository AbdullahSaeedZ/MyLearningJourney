-- Alter command to rename existed culomn, but SQL Server uses stored procedures to do that:

use DB1;

-- note: the below command works in most databases, but in SQL server it does not.
--alter table Employees
--rename column Gender to NewName;


-- ALTER TABLE RENAME COLUMN doesn't work in SQL Server.
-- Instead, SQL Server uses a built-in stored procedure called sp_rename.

-- "sp_rename" = a system stored procedure.
-- "sp" means "Stored Procedure" (a pre-built function inside SQL Server).

-- Stored Procedures are SQL blocks saved inside the database.
-- They contain logic that SQL Server can execute like a function.

-- sp_rename is provided by Microsoft to rename:
--   columns, tables, indexes, constraints, etc.

-- "exec" = short for EXECUTE.
-- It runs a stored procedure or a SQL command.

-- Syntax:
-- exec sp_rename 'table.oldName', 'newName', 'type of object to alter, COLUMN';


exec sp_rename 'Employees.NewName', 'Gender', 'COLUMN';