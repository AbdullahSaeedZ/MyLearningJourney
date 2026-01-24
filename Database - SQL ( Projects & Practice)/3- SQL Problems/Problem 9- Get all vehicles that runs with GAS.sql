--  Problem 9: Get all vehicles that runs with GAS



select VehicleDetails.*, FuelTypes.FuelTypeName 
from VehicleDetails join FuelTypes on FuelTypes.FuelTypeID = VehicleDetails.FuelTypeID
where FuelTypeName = N'GAS';

-- String literals:
-- 'any text'  = is a VARCHAR literal
-- N'text' = the N makes it NVARCHAR (Unicode) literal

-- If the column is NVARCHAR and you use 'text' which is by default a VARCHAR,
-- then SQL Server will do an implicit conversion to match types, which may hurt performance (index usage).
-- So use N'text' to match NVARCHAR columns and avoid implicit conversion.

-- If the column is VARCHAR, use 'text' (no N) to match the column type.