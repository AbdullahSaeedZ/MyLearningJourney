

select PerformanceCategory,count(*) as NumberOfEmployees, avg(Salary) as AverageSalary
from
(
select Name, Salary, 
case
	when PerformanceRating >= 80 then 'High'
	when PerformanceRating >= 60 then 'Medium'
	else 'Low'
end as PerformanceCategory
from Employees2
) as PerformanceTable group by PerformanceCategory;