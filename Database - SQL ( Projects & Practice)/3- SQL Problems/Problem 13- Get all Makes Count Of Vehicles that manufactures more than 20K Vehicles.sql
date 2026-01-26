-- Problem 13: Get all Makes/Count Of Vehicles that manufactures more than 20K Vehicles


select Makes.Make, count(*) as NumberOfVehicles 
from VehicleDetails
join Makes on Makes.MakeID = VehicleDetails.MakeID
group by Makes.Make
having count(*) > 20000
order by NumberOfVehicles desc;
