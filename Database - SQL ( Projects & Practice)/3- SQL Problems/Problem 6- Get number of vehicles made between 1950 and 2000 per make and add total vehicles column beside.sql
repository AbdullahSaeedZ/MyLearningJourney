-- Problem 6: Get number of vehicles made between 1950 and 2000 per make and add total vehicles column beside

-- similar to previuos problem + total vehicles column
-- we add the additional column as a subqery

select Makes.Make , Count(*) as NumberOfVehicles , (select count(*) from VehicleDetails) as TotalVehicles
from VehicleDetails join Makes on Makes.MakeID = VehicleDetails.MakeID
where VehicleDetails.Year between 1950 and 2000
group by Makes.Make order by NumberOfVehicles desc;
