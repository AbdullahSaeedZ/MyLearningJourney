-- Problem 50: Get all Fuel Types , each time the result should be showed in random order

select * from FuelTypes
order by NewID();  -- shuffling using GUID for each row