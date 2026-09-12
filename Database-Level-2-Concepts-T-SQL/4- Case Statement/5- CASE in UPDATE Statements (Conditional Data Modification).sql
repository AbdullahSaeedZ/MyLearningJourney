update Employees2
set Salary =
case 
	when PerformanceRating > 90 then Salary * 1.15
	when PerformanceRating between 75 and 90 then Salary * 1.10
	when PerformanceRating between 50 and 74 then Salary * 1.05
	else Salary
end;