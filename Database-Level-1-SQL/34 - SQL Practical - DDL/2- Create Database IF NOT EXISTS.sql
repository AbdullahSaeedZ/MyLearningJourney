-- SQL is the standard basic language (SELECT, INSERT, UPDATE...).
-- But every database uses its own extended version.

-- SQL Server → T-SQL
-- Oracle → PL/SQL
-- PostgreSQL → PL/pgSQL
-- MySQL → its own SQL dialect

-- T-SQL = SQL + Microsoft extensions (IF, ELSE, TRY/CATCH, variables...).

-- So on SQL Server, you are always writing T-SQL, not plain SQL.

-----------------
-- Create Database IF NOT EXISTS
-- we use IF statment with NOT keyword (!)
-- begin and end are like brackets of IF statement
-- SQL commands better to be in capital letters, but it will work anyway

if not exists (select * from sys.databases where name = 'DB1')
begin -- if true this executes
	create database DB1;
end
else
begin
	print('Database already exists');
end

-- if we highlight a certain line we can run it alone

-- this query will bring data of DB1 
-- select all from folder sys.databses where required database name is DB1
select * from sys.databases where name = 'DB1'

-- or we can bring data of all databases available
select * from sys.databases