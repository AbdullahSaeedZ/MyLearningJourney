-- this is a practice to move data from old denormalized tables into new normalized tables.
-- when we make databases for a client, we dont give him those databases with no data and tables! 
-- we give him data called lookup tables, like general prepared tables.
-- for example, in the cars field, we prepare a lookup table (separate tables) of car makes table for all cars companies. 

-- this is the data cleansing phase

use CarDatabase;

-- here we can see redundant data in the Make column
select * from CarsDetails;
select Make from CarsDetails;


select distinct Make from CarsDetails order by Make asc;

select count(distinct Make) as 'Number of Makes' from CarsDetails;

-- now lets prepare the first lookup, Makes table:
create table Makes
(
	MakeID int identity(1,1) primary key not null,  -- with auto increment ID
	MakeName nvarchar(50) not null
);

-- copying distinct Make column to the new lookup table:
insert into Makes (MakeName)
select distinct Make from CarsDetails order by Make asc;

-- now the Makes lookup is ready and normalized with PK constraint and no redundant data
select * from Makes;

------------------------------------------------------------------------------------------------------

-- lets prepare the CarsDetails table to be linked to the Makes table, first add MakeID column, i will do it from designer cuz i want to be the second in order which cant be done by script in SQL Server.
select * from CarsDetails;

-- now add MakeID from Makes Table accordingly:
-- this will work like a loop going through all records one by one.
-- just to remember: Order of executing Select statement:
-- FROM → WHERE (filtering) → GROUP BY → HAVING (filtering)→ SELECT → ORDER BY → TOP
update CarsDetails
set MakeID = (select MakeID from Makes where MakeName = CarsDetails.Make);


-- after filling the MakeID in the CarsDetails, make it as FK constraint to ensure data integrity:
alter table CarsDetails
add constraint FK_Makes_CarsDetails Foreign Key (MakeID) references Makes(MakeID);

-- now no need for Make name in CarsDetails since we have a FK that links to the Makes table, so we delete it:
alter table CarsDetails
drop column Make;

-- check now: 
select * from CarsDetails;

-- need to see the records with Make name ? do a join:
select Makes.MakeName, CarsDetails.*
from Makes inner join CarsDetails
on Makes.MakeID = CarsDetails.MakeID;

-- we are done with the Makes columns, we can do cleansing for the other redundant data like Body, Model, Body and so on.