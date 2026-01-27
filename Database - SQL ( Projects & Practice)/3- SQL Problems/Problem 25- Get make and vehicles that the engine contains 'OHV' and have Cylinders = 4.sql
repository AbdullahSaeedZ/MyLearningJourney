-- Problem 25: Get make and vehicles that the engine contains 'OHV' and have Cylinders = 4


select * from VehicleDetails;

select VehicleDetails.*, Makes.Make
from VehicleDetails
join Makes on Makes.MakeID = VehicleDetails.MakeID
where Engine like N'%OHV%' and Engine_Cylinders = 4;