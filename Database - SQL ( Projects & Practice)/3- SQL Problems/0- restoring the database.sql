-- prepare the normalized tables to be ready to solve the problems:

restore database VehicleMakesDB
from disk = 'D:\\VehicleMakesDB.bak';


use VehicleMakesDB;
EXEC sp_changedbowner 'sa';


select * from VehicleDetails;

select * from Makes;

select * from MakeModels;

select * from SubModels;

select * from Bodies;

select * from DriveTypes;

select * from FuelTypes;