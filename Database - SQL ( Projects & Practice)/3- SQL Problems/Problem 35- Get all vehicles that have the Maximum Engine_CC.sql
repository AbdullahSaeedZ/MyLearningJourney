-- Problem 35: Get all vehicles that have the Maximum Engine_CC

select *
from VehicleDetails
where VehicleDetails.Engine_CC = (select Max(VehicleDetails.Engine_CC) as MaxCC from VehicleDetails);