-- Problem 4 : Get number vehicles made between 1950 and 2000 per make,  and order them by Number Of Vehicles Descending


-- when we need info per something, we use group by

select Makes.Make, count(*) as NumberOfOldVehicles 
from VehicleDetails join Makes on VehicleDetails.MakeID = Makes.MakeID  -- join
where VehicleDetails.Year between 1950 and 2000 
group by Makes.Make         -- group result by make 
order by NumberOfOldVehicles desc;

