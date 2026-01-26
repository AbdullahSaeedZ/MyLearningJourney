-- Problem 16: Get all Makes that manufactures DriveTypeName = FWD


select distinct Makes.Make, DriveTypes.DriveTypeName
from VehicleDetails 
join DriveTypes on VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID
join Makes on VehicleDetails.MakeID = Makes.MakeID
where DriveTypeName = N'FWD';