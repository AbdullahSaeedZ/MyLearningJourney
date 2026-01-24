-- Problem 7: Get number of vehicles made between 1950 and 2000 per make and add total vehicles column beside it, then calculate it's percentage

/*
Order of executing Select statement:

FROM → WHERE (filtering) → GROUP BY → HAVING (filtering)→ SELECT → ORDER BY → TOP
*/


-- so this is the last problem:
select Makes.Make , Count(*) as NumberOfVehicles , (select count(*) from VehicleDetails) as TotalVehicles
from VehicleDetails join Makes on Makes.MakeID = VehicleDetails.MakeID
where VehicleDetails.Year between 1950 and 2000
group by Makes.Make order by NumberOfVehicles desc;

-- how to add the precentage column ? we must devide the two columns (NumberOfVehicles / VehicleDetails) in a third column
-- but to be able to access these two columns we have to make them exist first as subqery then access the resulted table and use its columns 


-- we use cast function to show accurate numbers, otherwise all will be rounded to 0.
select * , (cast(SubTable.NumberOfVehicles as float) / cast(SubTable.TotalVehicles as float)) * 100 as Perc 
from (select Makes.Make , Count(*) as NumberOfVehicles , (select count(*) from VehicleDetails) as TotalVehicles
from VehicleDetails join Makes on Makes.MakeID = VehicleDetails.MakeID
where VehicleDetails.Year between 1950 and 2000
group by Makes.Make) as SubTable order by SubTable.NumberOfVehicles desc;

