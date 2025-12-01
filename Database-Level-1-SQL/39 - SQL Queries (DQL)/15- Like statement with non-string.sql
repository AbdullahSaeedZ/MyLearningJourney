-- Like statement with non-string:
-- Like is only used for strings, to use it with numbers we have to convert the number into string then use like:
-- the converting is not affecting the original table, it is for the query only.

use HR_Database;
select * from Employees;
-- for Integers, convert an integer to a string using the CAST or CONVERT function and then apply the LIKE statement.
-- ex: find ID that starts with 1:
select ID, FirstName from Employees where cast(ID as varchar) like '1%';




-- with dates , we use this simple query:
select FirstName, HireDate from Employees where HireDate >= '1995-1-1';

-- but if i need to look for specific patterns then convert and use LIKE :

-- with Dates, each date format or type has different way, but using Convert function will work for all date types:
-- using CONVERT with style 23 forces any date type to the format yyyy-mm-dd, which makes LIKE workable.
-- find employees who were hired in 1995:
select FirstName, HireDate from Employees where convert(varchar(10), HireDate, 23) like '1995%';

