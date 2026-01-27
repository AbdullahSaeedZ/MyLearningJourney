-- Problem 29: Return found=1 if there is any vehicle made in year 1950

select found= 1
from VehicleDetails
where exists (select top 1 * from VehicleDetails where Year = 1960); -- once one record is found then the subquery returns ture


-- another way:

select Found =
case 
	when exists (select 1 from VehicleDetails where Year = 1960)   then 1
	else 0
end;