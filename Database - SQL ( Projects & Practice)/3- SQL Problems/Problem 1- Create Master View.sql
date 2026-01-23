--   Problem 1: Create Master View
-- a view table showing everything


select * from VehicleDetails;



-- use query designer, no need to memorize syntax as long as we understand the concept of joins.
-- we used left join rathar than inner join, cuz inner join wont bring records with null values which VehicleDetails has
-- so we use VehicleDetails left join the other tables, which will bring all records of left table with only matching columns from other tables
/*
الخلاصة:
INNER JOIN = أريد فقط السجلات التي لها تطابق
LEFT JOIN = أريد كل السجلات من الجدول الأساسي حتى لو ما لها تطابق
*/

create view VehicleMasterTable as
SELECT   VehicleDetails.ID, VehicleDetails.MakeID, Makes.Make, VehicleDetails.ModelID, MakeModels.ModelName, VehicleDetails.SubModelID, SubModels.SubModelName, VehicleDetails.BodyID, Bodies.BodyName, 
                VehicleDetails.Vehicle_Display_Name, VehicleDetails.Year, VehicleDetails.DriveTypeID, DriveTypes.DriveTypeName, VehicleDetails.Engine, VehicleDetails.Engine_CC, VehicleDetails.Engine_Cylinders, VehicleDetails.Engine_Liter_Display, 
                VehicleDetails.FuelTypeID, FuelTypes.FuelTypeName, VehicleDetails.NumDoors
FROM      VehicleDetails LEFT OUTER JOIN
                Bodies ON VehicleDetails.BodyID = Bodies.BodyID LEFT OUTER JOIN
                MakeModels ON VehicleDetails.ModelID = MakeModels.ModelID LEFT OUTER JOIN
                SubModels ON MakeModels.ModelID = SubModels.ModelID AND VehicleDetails.SubModelID = SubModels.SubModelID LEFT OUTER JOIN
                Makes ON MakeModels.MakeID = Makes.MakeID AND VehicleDetails.MakeID = Makes.MakeID LEFT OUTER JOIN
                DriveTypes ON VehicleDetails.DriveTypeID = DriveTypes.DriveTypeID LEFT OUTER JOIN
                FuelTypes ON VehicleDetails.FuelTypeID = FuelTypes.FuelTypeID

select * from VehicleMasterTable;


select  VD.ID, M.MakeID,M.Make,MM.ModelID,mm.ModelName,SM.SubModelID,SM.SubModelName,B.BodyID,B.BodyName,VD.Vehicle_Display_Name,VD.Year,DT.DriveTypeID,DT.DriveTypeName,vd.Engine,Engine_CC,vd.Engine_Cylinders,vd.Engine_Liter_Display,FT.FuelTypeID,FT.FuelTypeName,VD.NumDoors  from VehicleDetails VD join Makes M on m.MakeID=VD.MakeID
join MakeModels MM on MM.ModelID=VD.ModelID 
join SubModels SM on SM.SubModelID=VD.SubModelID 
join Bodies B on B.BodyID=VD.BodyID 
join DriveTypes DT on DT.DriveTypeID=VD.DriveTypeID
join FuelTypes FT on FT.FuelTypeID=VD.FuelTypeID