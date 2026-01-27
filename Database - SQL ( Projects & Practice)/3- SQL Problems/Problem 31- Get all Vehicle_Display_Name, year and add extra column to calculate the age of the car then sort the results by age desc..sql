-- Problem 31: Get all Vehicle_Display_Name, year and add extra column to calculate the age of the car then sort the results by age desc.


select Vehicle_Display_Name, year, CarAge = DATEDIFF(YEAR,VehicleDetails.Year, getdate())  -- this wont work cuz year columns is smallint, and the datediff takes date format not integers
from VehicleDetails
order by CarAge desc;


-- we use this bult in function, YEAR(getdate()) this will give the current year as int
select Vehicle_Display_Name, year, CarAge = YEAR(getdate()) - VehicleDetails.Year
from VehicleDetails
order by CarAge desc;