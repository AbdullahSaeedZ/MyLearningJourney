-- Problem 12: Count Vehicles per make and order them by NumberOfVehicles from high to low.




select Makes.Make, count(*) as NumberOfVehicles 
from VehicleDetails
join Makes on Makes.MakeID = VehicleDetails.MakeID
group by Makes.Make
order by NumberOfVehicles desc;