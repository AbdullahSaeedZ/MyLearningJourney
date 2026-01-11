-- Identity Field (Auto Increment) , gives increment values for each new record automaticaly.
-- from designer create a table then make ID as PK then at the bottom in the column properties look for Identity specification, then put is identity to yes
-- then choose seed(starting number) and increment amount

-- script:

use DB1;

select * from Departments;

create table Departments
(
-- identity(seed,increment) keyword
	ID int identity(1,1) not null primary key,
	Name nvarchar(50) not null
);

-- inserting a new record, will be assigned a new ID number automaticaly
insert into Departments
values ('HR');

-- deleting all records of table will not reset the ID incrementing values.
delete from Departments;

-- now it will be given ID number based on last number was given, even though no IDs available in the table.
insert into Departments
values ('HR');


-- last given identity number will be saved in a variable called @@identity, we can use it to see the number
print @@identity;


-- to fix this we use another command in next lesson