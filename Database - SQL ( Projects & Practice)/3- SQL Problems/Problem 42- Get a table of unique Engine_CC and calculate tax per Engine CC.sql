-- Problem 42: Get a table of unique Engine_CC and calculate tax per Engine CC



select distinct Engine_CC , Tax =   -- 2- then tax will be put for all records, THEN duplicates will be dumped to result in only distinct, waste of time and resourses
case 
	when Engine_cc between 0 and 1000 then 100
	when Engine_cc between 1001 and 2000 then 200
	when Engine_cc between 2001 and 4000 then 300
	when Engine_cc between 4001 and 6000 then 400
	when Engine_cc between 6001 and 8000 then 500
	when Engine_cc > 8000 then 600
	else 0
end
from VehicleDetails   -- 1- this means all records (not unique) will be fetched
order by Engine_CC desc;



------------------------------------------------------------------------------------------------------



-- this is a better soluion:
select Engine_CC, Tax =                     -- 2- then those unique will have Tax assigned, no duplicate records dumped, no time and resources wasted
case 
	when Engine_cc between 0 and 1000 then 100
	when Engine_cc between 1001 and 2000 then 200
	when Engine_cc between 2001 and 4000 then 300
	when Engine_cc between 4001 and 6000 then 400
	when Engine_cc between 6001 and 8000 then 500
	when Engine_cc > 8000 then 600
	else 0
end
from ( select distinct Engine_CC from VehicleDetails) as sub       -- 1- this fetches only unique records
order by Engine_CC desc;