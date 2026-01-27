-- Problem 37: Get total vehicles that have Engin_CC above average

select *
from VehicleDetails
where VehicleDetails.Engine_CC > (select Avg(VehicleDetails.Engine_CC) as AvgCC from VehicleDetails);