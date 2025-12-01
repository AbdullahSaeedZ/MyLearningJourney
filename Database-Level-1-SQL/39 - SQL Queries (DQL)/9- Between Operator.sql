-- Between Operator


use HR_Database;


select * from Employees where MonthlySalary >= 500 and MonthlySalary <= 1000;

-- shortcut:
select * from Employees where MonthlySalary between 500 and 1000;


select * from (select FirstName, Age = DATEDIFF(year, DateOfBirth, GETDATE()) from Employees) as EmpployeesAge where age between 30 and 40;