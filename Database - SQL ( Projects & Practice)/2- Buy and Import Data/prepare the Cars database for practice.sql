-- we can buy or get any free data sets from websites like kaggle.com
-- we have the cars dataset in the folder with 3 files, one is ready for databases but this one isnt for SQL Server so we ignore it.
-- one file is the data presented in excel sheet, we can import it to the SQL Server by going to any database then tasks then import flat file and follow the wizard.


-- the data is not that perfect, we just import it then we can do the data Cleansing phase.


create database CarDatabase;
use CarDatabase;


select * from CarsDetails;
