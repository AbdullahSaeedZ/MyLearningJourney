-- Problem 47: Get the highest number of models manufactured


select Max(NumberOfModels) as MaxNumberOfModels
from
(
	select MakeID, COUNT(*) as NumberOfModels
	from MakeModels 
	group by MakeID 
) sub;

