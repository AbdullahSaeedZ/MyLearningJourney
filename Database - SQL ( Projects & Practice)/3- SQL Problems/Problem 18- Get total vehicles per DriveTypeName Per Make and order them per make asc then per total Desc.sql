-- Problem 18: Get total vehicles per DriveTypeName Per Make and order them per make asc then per total Desc


select Makes.Make, DriveTypes.DriveTypeName, count(*) as TotalVehcles
from VehicleDetails
join Makes on VehicleDetails.MakeID = Makes.MakeID
join DriveTypes on VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID
group by Makes.Make, DriveTypes.DriveTypeName
order by Makes.Make asc, TotalVehcles desc;  -- order priority is the first column (make), when there is a duplicate field then the second column (total) will be rodered


