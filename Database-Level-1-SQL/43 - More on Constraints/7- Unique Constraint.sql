-- Unique Constraint
-- The UNIQUE constraint ensures that all values in a column are different.

-- A PRIMARY KEY constraint automatically has a UNIQUE constraint.
-- Both the UNIQUE and PRIMARY KEY constraints provide a guarantee for uniqueness for a column or set of columns.
-- you can have many UNIQUE constraints per table, but only one PRIMARY KEY constraint per table.

-- difference between primary key and unique constraints: primary key dose not allow null, but unique allows null. 
-- only one PK, but can have multiple uniqe constraint in one table

-- in a unique constraint, null values are typically allowed but only one null value is allowed per column when the constraint is applied. this situation is fixed using index.

create database DB2;
use DB2;

create table Persons
(
	ID int not null,
	FirstName nvarchar(10),
	Phone nvarchar(10) unique
);

-- or :

create table Persons
(
	ID int not null,
	FirstName nvarchar(10),
	Phone nvarchar(10),
	constraint unq_Phone unique (Phone)
);


-- adding unique anytime:
alter table Persons
add unique (ID);

-- or :
alter table Persons
add constraint unq_Person unique (ID, FirstName);


-- drop:
alter table Persons
drop constraint unq_Person;



