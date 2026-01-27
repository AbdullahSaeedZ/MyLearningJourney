-- Problem 28: Get all vehicles that their body is 'Coupe' or 'Hatchback' or 'Sedan' and manufactured in year 2008 or 2020 or 2021

select Bodies.BodyName, VehicleDetails.*
from VehicleDetails
join Bodies on Bodies.BodyID = VehicleDetails.BodyID
where Bodies.BodyName in (N'Coupe', N'Hatchback', N'Sedan') and VehicleDetails.Year in (2008, 2020, 2021);