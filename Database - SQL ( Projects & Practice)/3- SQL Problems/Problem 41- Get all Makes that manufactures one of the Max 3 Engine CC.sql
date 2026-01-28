-- Problem 41: Get all Makes that manufactures one of the Max 3 Engine CC

select * from VehicleDetails;



select distinct Makes.Make
from VehicleDetails
join Makes on Makes.MakeID = VehicleDetails.MakeID
where VehicleDetails.Engine_CC in (select distinct top 3 Engine_CC from VehicleDetails order by Engine_CC desc);