-- Problem 36: Get all vehicles that have Engin_CC below average



select *
from VehicleDetails
where VehicleDetails.Engine_CC < (select Avg(VehicleDetails.Engine_CC) as AvgCC from VehicleDetails);