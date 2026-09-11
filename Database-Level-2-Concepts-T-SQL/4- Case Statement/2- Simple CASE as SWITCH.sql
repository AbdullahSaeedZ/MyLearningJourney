/*



1. Simple CASE (Exact match):
     CASE inputToBeEvaluated
         WHEN val1 THEN res1
         WHEN val2 THEN res2
         ELSE default_result
     END


*/

select EmployeeID,
	case DepartmentID
		when 1 then 'Engineering'
		when 2 then 'Development'
		when 3 then 'HR'
		else 'Other'
	end as DepartmentName
from Employees;


-- or using select statement inside the result 

select EmployeeID,
	case DepartmentID
		when 1 then (select Departments.Name from Departments where DepartmentID = 1)
		when 2 then (select Departments.Name from Departments where DepartmentID = 2)
		when 3 then (select Departments.Name from Departments where DepartmentID = 3)
		else 'Other'
	end as DepartmentName
from Employees;