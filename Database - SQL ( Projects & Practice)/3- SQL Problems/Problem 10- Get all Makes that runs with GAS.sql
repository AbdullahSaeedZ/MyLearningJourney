-- Problem 10: Get all Makes that runs with GAS

-- needed columns are in two tables that are linked together through the Vehicles table,
-- so we join these two to the Vehicle table then choose which to show:

select Distinct Makes.Make, FuelTypes.FuelTypeName
from VehicleDetails join Makes on Makes.MakeID = VehicleDetails.MakeID
					join FuelTypes on FuelTypes.FuelTypeID = VehicleDetails.FuelTypeID
where FuelTypeName = N'Gas';


