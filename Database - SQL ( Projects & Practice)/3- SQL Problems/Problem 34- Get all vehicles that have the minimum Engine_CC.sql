-- Problem 34: Get all vehicles that have the minimum Engine_CC


-- from last problem to be used in subquery:
select Max(VehicleDetails.Engine_CC) as MaxEngineCC , Min(VehicleDetails.Engine_CC) as MinEngineCC, AVG(VehicleDetails.Engine_CC) as AvgEngineCC
from VehicleDetails;


-- then:
select *
from VehicleDetails
where VehicleDetails.Engine_CC = (select Min(VehicleDetails.Engine_CC) as MinCC from VehicleDetails);

