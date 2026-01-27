-- Problem 32: Get all Vehicle_Display_Name, year, Age for vehicles that their age between 15 and 25 years old

select Vehicle_Display_Name, year, CarAge = YEAR(getdate()) - VehicleDetails.Year
from VehicleDetails
where (YEAR(getdate()) - VehicleDetails.Year) between 15 and 25
order by CarAge desc;


-- or:


select *
from 
(
	select Vehicle_Display_Name, year, CarAge = YEAR(getdate()) - VehicleDetails.Year
	from VehicleDetails
) as sub 
where sub.CarAge between 15 and 25
order by CarAge desc;