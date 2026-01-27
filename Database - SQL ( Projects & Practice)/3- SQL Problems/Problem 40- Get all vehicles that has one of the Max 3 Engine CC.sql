-- Problem 40: Get all vehicles that has one of the Max 3 Engine CC

select *
from VehicleDetails
where Engine_CC in (select distinct top 3 Engine_CC from VehicleDetails order by Engine_CC desc);  -- ORDER BY clause is allowed in the subquery cuz of the top keyword, otherwise it is not allowed