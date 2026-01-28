-- Problem 49: Get the Lowest Manufacturers manufactured the lowest number of models
-- remember that they could be more than one manufacturer have the same lowest number of models


-- to get min number of models then lated find Makes that have this number:
select Min(sub.NumberOfModels) as MinNumbr 
	from (
			select MakeID, COUNT(*) AS NumberOfModels
			from MakeModels
			group by MakeID
		) as sub;



-- now get the makes that have this min number of models:
select Makes.Make , count(*) as TotalModelsMancufactured
from Makes
join MakeModels on MakeModels.MakeID = Makes.MakeID
group by Makes.Make
having Count(*) =	(select Min(sub.NumberOfModels) as MinNumbr 
						from (
								select MakeID, COUNT(*) AS NumberOfModels
								from MakeModels
								group by MakeID
							) as sub)
;
