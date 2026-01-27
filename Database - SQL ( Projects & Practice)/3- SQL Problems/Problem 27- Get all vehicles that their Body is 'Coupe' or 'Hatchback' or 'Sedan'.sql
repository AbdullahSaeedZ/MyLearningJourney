-- Problem 27: Get all vehicles that their Body is 'Coupe' or 'Hatchback' or 'Sedan'

select Bodies.BodyName, VehicleDetails.*
from VehicleDetails
join Bodies on Bodies.BodyID = VehicleDetails.BodyID
where Bodies.BodyName in (N'Coupe', N'Hatchback', N'Sedan');