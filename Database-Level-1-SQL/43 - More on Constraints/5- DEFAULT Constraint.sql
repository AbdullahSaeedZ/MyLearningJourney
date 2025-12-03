-- DEFAULT Constraint
-- The DEFAULT constraint is used to set a default value for a column.
-- The default value will be added to all new records, if no other value is specified.

create database DB_DefaultConstraint;

use DB_DefaultConstraint;

create table Persons
(
	ID int not null primary key,
	FirstName nvarchar(30) not null,
	LastName nvarchar(30) not null,
	age int not null, 
	City nvarchar(20) default 'Dammam'  --this means if no value enterd, then it is Dammam by default.
);

select * from Persons;

-- add record to check:
insert into Persons (ID, FirstName, LastName, age)
values 
(2,'fawaz', 'alzahrani', 22);


-- to drop the constraint we need to know its name, but in Persons we didnt give it a name, so we use this script to get the name:
EXEC sp_helpconstraint 'Persons';

-- now we can drop, see below examples

----------------------------------------------------------------------------------

-- we can use functions as default like date:
create table Orders
(
	ID int not null ,
	OrderNumber int not null,
	OrderDate date default getdate()
);

select * from Orders;

insert into Orders(ID, OrderNumber) values 
(1, 3242);

----------------------------------------------------------------------------------
-- create a new column to see how to add constraints on existing columns:
alter table Orders
add City nvarchar(20);

-- add the constrinat and give it a unique name:
alter table Orders
add constraint df_City
default 'Khobar' for City;

-- dropping a constraint:
alter table Orders
drop constraint df_City;
