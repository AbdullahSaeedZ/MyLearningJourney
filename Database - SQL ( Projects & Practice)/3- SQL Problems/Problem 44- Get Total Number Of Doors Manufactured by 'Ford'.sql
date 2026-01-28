-- Problem 44: Get Total Number Of Doors Manufactured by 'Ford'

select Makes.Make, Doors = sum(VehicleDetails.NumDoors)
from VehicleDetails
join Makes on Makes.MakeID = VehicleDetails.MakeID
group by Makes.Make
having Makes.Make = N'Ford';