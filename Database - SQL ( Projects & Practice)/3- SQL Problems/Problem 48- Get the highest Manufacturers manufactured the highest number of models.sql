-- Problem 48:Get the highest Manufacturers manufactured the highest number of models

-- remember that they could be more than one manufacturer have the same high number of models

select Makes.Make , count(*) as TotalModelsMancufactured
from Makes
join MakeModels on MakeModels.MakeID = Makes.MakeID
group by Makes.Make
having Count(*) = ( select Max(NumberOfModels) as MaxNumberOfModels
					from (
							select MakeID, COUNT(*) as NumberOfModels
							from 
							MakeModels 
							group by MakeID ) as sub
					);



