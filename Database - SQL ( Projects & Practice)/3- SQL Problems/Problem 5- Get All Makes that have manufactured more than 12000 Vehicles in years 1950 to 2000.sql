-- Problem 5 : Get All Makes that have manufactured more than 12000 Vehicles in years 1950 to 2000

use VehicleMakesDB;




-- since we are using GROUP BY then we use HAVING to further filter the results
select Makes.Make , Count(*) as CarsManufactured
from VehicleDetails join Makes on Makes.MakeID = VehicleDetails.MakeID
where VehicleDetails.Year between 1950 and 2000
group by Makes.Make having Count(*) > 12000
order by CarsManufactured desc;


-- or using the subquery then use usual where clause

select * from     (select Makes.Make , Count(*) as CarsManufactured
				from VehicleDetails join Makes on Makes.MakeID = VehicleDetails.MakeID
				where VehicleDetails.Year between 1950 and 2000
				group by Makes.Make) as SubTable       where SubTable.CarsManufactured > 12000 order by SubTable.CarsManufactured desc;

