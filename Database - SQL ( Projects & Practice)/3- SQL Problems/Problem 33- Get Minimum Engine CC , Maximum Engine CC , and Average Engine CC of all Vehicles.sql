-- Problem 33: Get Minimum Engine CC , Maximum Engine CC , and Average Engine CC of all Vehicles

select * from VehicleDetails;


select Max(VehicleDetails.Engine_CC) as MaxEngineCC , Min(VehicleDetails.Engine_CC) as MinEngineCC, AVG(VehicleDetails.Engine_CC) as AvgEngineCC
from VehicleDetails;