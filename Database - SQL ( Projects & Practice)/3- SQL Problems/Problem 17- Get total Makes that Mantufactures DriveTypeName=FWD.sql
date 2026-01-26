-- Problem 17: Get total Makes that Mantufactures DriveTypeName=FWD



-- from last problem:
select distinct Makes.Make, DriveTypes.DriveTypeName
from VehicleDetails 
join DriveTypes on VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID
join Makes on VehicleDetails.MakeID = Makes.MakeID
where DriveTypeName = N'FWD';



-- then:
select count(*) as TotalFWDMakes
from (
select distinct Makes.Make, DriveTypes.DriveTypeName
from VehicleDetails 
join DriveTypes on VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID
join Makes on VehicleDetails.MakeID = Makes.MakeID
where DriveTypeName = N'FWD') as Sub;