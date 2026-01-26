-- Problem 11: Get Total Makes that runs with GAS


-- from last problem:
select Distinct Makes.Make 
from VehicleDetails join Makes on Makes.MakeID = VehicleDetails.MakeID
					join FuelTypes on FuelTypes.FuelTypeID = VehicleDetails.FuelTypeID
where FuelTypeName = N'Gas';



-- then:
select count(*) as TotalMakesOnGas 
from ( 
	select Distinct Makes.Make
	from VehicleDetails
	join Makes on Makes.MakeID = VehicleDetails.MakeID
	join FuelTypes on FuelTypes.FuelTypeID = VehicleDetails.FuelTypeID
	where FuelTypeName = N'Gas'
) as Sub ; -- any subquery needs to get an alias