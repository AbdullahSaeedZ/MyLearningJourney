-- Problem 22: Get percentage of vehicles that has no doors specified



select TotalNoDoorNum, TotalVehicles, (cast(TotalNoDoorNum as float)/ cast(TotalVehicles as float)) * 100 as Perc
from 
(
	select   (select count(*) from VehicleDetails where VehicleDetails.NumDoors is null) as TotalNoDoorNum  , count(*) as TotalVehicles
	from VehicleDetails
) as Sub;

