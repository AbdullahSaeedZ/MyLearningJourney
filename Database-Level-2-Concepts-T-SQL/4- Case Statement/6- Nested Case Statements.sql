-- basically, case statement is just an if statement that is used inside a SET statement
-- hence we can do nested statements!

select *, 
case
	when Department = 'Sales' then
		case
			when PerformanceRating > 90 then Salary * 0.30
			when PerformanceRating between 75 and 90 then Salary * 0.25
			when PerformanceRating < 75 then Salary * 0.20
			else Salary * 0.15
		end
	when Department = 'HR' then
		case
			when PerformanceRating > 90 then Salary * 0.20
			when PerformanceRating between 75 and 90 then Salary * 0.15
			when PerformanceRating < 75 then Salary * 0.10
			else Salary * 0.05
		end
	else
		case
			when PerformanceRating > 90 then Salary * 0.15
				when PerformanceRating between 75 and 90 then Salary * 0.10
				when PerformanceRating < 75 then Salary * 0.07
				else Salary * 0.03
		end
end as Bonus
from Employees2;