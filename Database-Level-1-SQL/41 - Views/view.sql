-- view
-- a view is a virtual table based on the result-set of an SQL statement.
-- A view always shows up-to-date data! The database engine recreates the view, every time a user queries it.

-- it is a shortcut for the query not a real table, it will return a table resulted from the query


use HR_Database;

select * from Employees where ExitDate is null;
-- result of this query can be saved in a virtual table (view) and used easily in other queries:

create view ActiveEmployees as
select * from Employees where ExitDate is null;
-- now this virtual table is saved (can be found in explorer)
-- ActiveEmployees is a shortcut for that long query, every time we use it, the long query is called


-- one advantage is i can give a user access to a short detailed table rather than letting him see all details of employees:

create view ShortEmployeeTable as
select ID, FirstName, LastName, Gender from Employees;

select * from ShortEmployeeTable;

-- now user can see only this virtual table, better than exposing all details from the main table