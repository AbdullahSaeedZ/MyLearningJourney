-- Check Constraint
-- The CHECK constraint is used to limit the value range that can be placed in a column.
-- If you define a CHECK constraint on a column it will allow only certain values for this column.

use DB1;

create table Persons
(
	ID int not null,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	Age int check (Age >= 18)
);


-- we create constraints this way, for multiple columns:
create table Persons2
(
	ID int not null,
	FirstName nvarchar(20) not null,
	LastName nvarchar(20) not null,
	Age int ,
	City nvarchar(10),
	constraint chk_Person check (Age >= 18 and City = 'Dammam')
);

-- can drop constraint any time:
alter table Persons2
drop constraint chk_Person;