-- Problem 23: Get MakeID , Make, SubModelName for all vehicles that have SubModelName 'Elite'

select distinct VehicleDetails.MakeID, Makes.Make, SubModels.SubModelName
from VehicleDetails
join Makes on Makes.MakeID = VehicleDetails.MakeID
join SubModels on SubModels.SubModelID = VehicleDetails.SubModelID
where SubModelName like N'%Elite%';