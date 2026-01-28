-- Problem 46: Get the highest 3 manufacturers that make the highest number of models


select top 3 Makes.Make, TotalModels = count(*)
from Makes
join MakeModels on Makes.MakeID = MakeModels.MakeID
group by Makes.Make
order by TotalModels desc;