-- Problem 43: Get Make and Total Number Of Doors Manufactured Per Make

select Makes.Make, TotalNumberOfDoors = sum(VehicleDetails.NumDoors)
from VehicleDetails
join Makes on Makes.MakeID = VehicleDetails.MakeID
group by Makes.Make
order by TotalNumberOfDoors desc;