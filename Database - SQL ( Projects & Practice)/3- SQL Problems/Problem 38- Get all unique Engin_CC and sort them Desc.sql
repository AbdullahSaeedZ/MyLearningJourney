-- Problem 38: Get all unique Engin_CC and sort them Desc

select distinct Engine_CC 
from VehicleDetails
order by Engine_CC desc;



-- get All Engine_CC that did not repeat in VehicleDetails :
select Engine_CC
from VehicleDetails
group by Engine_CC
having count(*) = 1;