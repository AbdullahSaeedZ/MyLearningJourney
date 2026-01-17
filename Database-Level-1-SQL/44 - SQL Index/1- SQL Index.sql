-- SQL Index:

-- Idea of Index:
-- When you run a SELECT query, SQL normally scans the entire table row by row 
-- to find the matching data (this is slow on large tables).
-- An index creates a small, sorted structure for specific columns, 
-- so SQL can search that structure instead of scanning the whole table.
-- This shortcut makes SELECT queries much faster and more efficient.

-- Purpose of indexes:
-- They speed up data retrieval (SELECT), but slow down data modifications 
-- (INSERT, UPDATE, DELETE) because the index must also be updated.

-- Two main types of indexes:
-- 1) Clustered Index
-- 2) Non-Clustered (Normal) Index

-- Clustered Index:
-- The fastest for data retrieval because it physically orders the rows inside the same table we have.
-- A table can only have ONE clustered indexand best practice to be used for primary keys.
-- The Primary Key creates a clustered index by default (unless specified otherwise, not recommended).

-- Non-Clustered (normal) Index:
-- This type creates a separate hidden structure (table) that stores the indexed column values
-- in a sorted way + pointers back to the actual table rows.
-- It’s slightly slower than clustered but still very effective.
-- You can create multiple non-clustered indexes on the same table.

-- Important note:
-- Do NOT index every column.
-- Only index columns that are frequently used in WHERE conditions, JOINs, or ORDER BY.
------------------------------------------------------------------------------------------------------

use DB2;

create table Persons2
(
	ID int not null primary key,             -- once table is created, a cluster index is created for PK column, any new records in this table will be ordered ascending by the PK (ID cluster indexed).
	LastName nvarchar(50) not null,
	FirstName nvarchar(50) not null,
	Age int
);

-- go to table name then right click -> script table as -> create to -> new query ....
-- new page with script will show up, this is the things that are done by default with the creation of the table,
-- we can see the cluster index in ascending order and much more.

------------------------------------------------------------------------------------------------------

-- creating non-cluster index:
create index idx_LastName
on Persons2 (LastName);

-- now it is done, we cant see it, but the database engine will take care of it.
-- once a new value(or any update), engine will insert in the Persons2 table and also the hidden table for the LastName Index.
-- when we make a query, it will check if this column has index then it will go to the index table and get the data.


-- dropping Index:
drop index Persons2.idx_LastName;

------------------------------------------------------------------------------------------------------

-- can make index for multiple columns:
create index idx_FullName
on Persons2 (LastName, FirstName);

-- dropping:
drop index Persons2.idx_FullName;