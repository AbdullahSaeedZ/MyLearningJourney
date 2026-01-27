-- Problem 26: Get all vehicles that their body is 'Sport Utility' and Year > 2020

select VehicleDetails.* , Bodies.BodyName 
from VehicleDetails
join Bodies on Bodies.BodyID = VehicleDetails.BodyID
where Bodies.BodyName = N'Sport Utility' and VehicleDetails.Year > 2020;