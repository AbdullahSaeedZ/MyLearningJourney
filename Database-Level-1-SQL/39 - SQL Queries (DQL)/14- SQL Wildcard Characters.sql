-- SQL Wildcard Characters
-- A wildcard character is used to substitute one or more characters in a STRING.
-- Wildcard characters are used with the LIKE operator. The LIKE operator is used in a WHERE clause to search for a specified pattern in a column.


--   _    :   Mohamm_d  -> Mohammed, Mohammad...
--   %    :   'bl%'     -> black, blue ...
--   []   :   h[ao]t    -> hat, hot.....
--   '^'  :   h[^ao]t   -> hit, not hot, not hat...
--   a-b  :   c[a-b]t   -> cat, cbt....

use HR_Database;


-- prepare data for the example:
update Employees
set FirstName = 'Mohammed' where ID = 285;

update Employees
set FirstName = 'Mohammad' where ID = 286;

-- now we have two records with Mohammed but in different spelling a and e
-----------------------------------------------------
-- to look for all Mohammed with both spelling e and a, we use [] wildcard which search for Mohammed and Mohammad
select ID, FirstName from Employees where FirstName like 'Mohamm[ea]d';

-- using (_) to indicate that there is a letter here but i dont know it exactly:
select ID, FirstName from Employees where FirstName like 'Mohamm_d';

-- we can use NOT to ignore all Mohammed and Mohammad:
select ID, FirstName from Employees where FirstName not like 'Mohamm[ea]d';

-- returns hot or hat
select ID, FirstName from Employees where FirstName like 'h[oa]t';


-- we can use ^ to ignore results, same as (not like):
select ID, FirstName from Employees where FirstName like 'h[^oa]t';

-- shortcut for OR statment, instead of this:
select ID, FirstName from Employees where FirstName like 'a%' or FirstName like 'b%' or FirstName like 'c%';
-- it will be:
select ID, FirstName from Employees where FirstName like '[abc]%';

-----------------------------------------------------

-- returns first names begins with ALL letters from a to k [a-k]
select ID, FirstName from Employees where FirstName like '[a-k]%';

-----------------------------------------------------




--  some exercises
--Get Employees whose:

--1- first name Is exactly 5 characters long, ends with a vowel:
select FirstName from Employees where FirstName like '____[aeiou]';


--2- First names that Begin with S or T, and have 6 total letters
select FirstName from Employees where FirstName like '[st]_____';


--3- Last names where the second letter is a, and it ends with n
select FirstName from Employees where FirstName like '_a%n';


--4- Last names that Start with 'M', and the second letter is a vowel
select FirstName, LastName from Employees where LastName like 'M[aeiou]%';




