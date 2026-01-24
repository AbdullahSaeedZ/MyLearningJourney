-- Problem 8: Get Make, FuelTypeName and Number of Vehicles per FuelType per Make
-- grouping result per two things not only one:



select Makes.Make, FuelTypes.FuelTypeName, count(*) as NumberOfVehicles from VehicleDetails
join Makes on Makes.MakeID = VehicleDetails.MakeID
join FuelTypes on FuelTypes.FuelTypeID = VehicleDetails.FuelTypeID
where VehicleDetails.Year between 1950 and 2000
group by Makes.Make , FuelTypes.FuelTypeName    -- note every column in SELECT must be in GROUP BY unless it is an aggregate function
order by Makes.Make asc;


