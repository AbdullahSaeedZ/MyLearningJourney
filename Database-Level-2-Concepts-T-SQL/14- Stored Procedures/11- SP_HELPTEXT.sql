/*
The sp_helptext command in SQL Server is a system stored procedure that is
used to retrieve the text definition of a stored procedure, function, trigger, view, or user-defined function
in a SQL Server database. It is a useful tool for developers and database administrators to examine 
the source code or the SQL statements within these database objects.
*/

--Syntax:
--   sp_helptext 'object_name';

--usage:
use C21_DB1;

exec sp_helptext 'usp_AddNewPerson';