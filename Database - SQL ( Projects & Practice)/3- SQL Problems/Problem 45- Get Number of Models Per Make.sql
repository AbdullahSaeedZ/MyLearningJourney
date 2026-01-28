-- Problem 45: Get Number of Models Per Make

select * from VehicleDetails;


select Makes.Make, TotalModels = count(*)
from Makes
join MakeModels on Makes.MakeID = MakeModels.MakeID
group by Makes.Make
order by TotalModels desc;