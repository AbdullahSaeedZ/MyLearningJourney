-- Where Statement + AND , OR, NOT

use HR_Database;


-- using WHERE to filter results

select * from Employees where Gender = 'F';

select * from Employees where CountryID = 1;

-- <> means !=
select * from Employees where CountryID <> 1;

select * from Employees where MonthlySalary < 500;

-- another way to return salaries more than 500 using not:
select * from Employees where not MonthlySalary < 500;

select * from Employees where MonthlySalary >= 500;



-- using AND:
-- AND operator displays a record if all the conditions separated by AND are TRUE.
select * from Employees where MonthlySalary < 500 and Gender = 'F';

select * from Employees where DepartmentID = 1 and Gender = 'F';

-- this returns nothing, no employee works in two departments
select * from Employees where DepartmentID = 1 and DepartmentID = 2;



-- using OR:
-- OR operator displays a record if any of the conditions separated by OR is TRUE.
select * from Employees where DepartmentID = 1 or DepartmentID = 2;

select * from Employees where (DepartmentID = 1 and FirstName = 'abood') or (DepartmentID = 2 and Gender = 'M');



-- null:
-- when dealing with null, we use is - is not , cant use = or <>
select * from Employees where ExitDate is null;

select * from Employees where ExitDate is not null;
