-- Like statement
-- The LIKE operator is used in a WHERE clause to search for a specified pattern in a column.

-- A wildcard character is used to substitute one or more characters in a string.
-- Wildcard characters are used with the LIKE operator. The LIKE operator is used in a WHERE clause to search for a specified pattern in a column.

-- (_) represents one, single character
-- (%) represents zero, one, or multiple characters



use HR_Database;


select * from Employees;
-- examples using wildcard % and _

-- Finds any values that start with "a" and the rest is not important "%"
select ID, FirstName from Employees where FirstName like 'a%';

-- Finds any values that end with "a"
select ID, FirstName from Employees where FirstName like '%a';

-- Finds any values that have "tell" in any position
select ID, FirstName from Employees where FirstName like '%tell%';


-- Finds any values that start with "a" and ends with "a"
select ID, FirstName from Employees where FirstName like 'a%a';


-- Finds any values that have "a" in the second position, '_' represents a letter:
select ID, FirstName from Employees where FirstName like '_a%';

-- Finds any values that have "a" in the third position
select ID, FirstName from Employees where FirstName like '__a%';

-- Finds any values that start with "a" and are at least 3 characters in length
select ID, FirstName from Employees where FirstName like 'a__%';

-- Finds any values that start with "a" and are at least 4 characters in length
select ID, FirstName from Employees where FirstName like 'a___%';

-- Finds any values that start with "a" and is only 3 letters
select ID, FirstName from Employees where FirstName like 'a__';

-- can use operator such as AND , OR:
select ID, FirstName from Employees where FirstName like 'a%' or FirstName like '%a';