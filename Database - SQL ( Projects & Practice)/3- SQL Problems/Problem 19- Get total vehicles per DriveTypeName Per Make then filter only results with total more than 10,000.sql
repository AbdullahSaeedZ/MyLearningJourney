-- Problem 19: Get total vehicles per DriveTypeName Per Make then filter only results with total > 10,000


select Makes.Make, DriveTypes.DriveTypeName, count(*) as TotalVehcles
from VehicleDetails
join Makes on VehicleDetails.MakeID = Makes.MakeID
join DriveTypes on VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID
group by Makes.Make, DriveTypes.DriveTypeName
having count(*) > 10000
order by Makes.Make asc, TotalVehcles desc