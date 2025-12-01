-- Foreign key constraint 

-- we will create a cutomers table then orders table, orders belong to customers, so we will reference orders to customers, PK of customers as FK in orders.

use DB1;
-- Method 1:

-- first to create the main table which is Customers
-- this table does not have a FK
create table Customers
(
	ID int not null primary key,
	First_name nvarchar(50) ,
	Last_name nvarchar(50) ,
	Age int,
	Country nvarchar(10)
);


-- secondly we create the table that will be referenced to the main table:
create table Orders
(
	Order_ID int not null primary key,
	Item varchar(40),
	Amount int ,
	Customer_ID int references Customers(ID) -- this is how we link this field to the PK of Customers table 
);
-- see in the explorer, Orders table has Customers ID as FK, also:
-- right click on this query file -> Design query in Editor -> choose the two tables, then will show relational schema with the relation and FK

-- Referential Inegrity Examples:
-- in designer of Orders tables, if we add a record and we link it to any random FK (PK of Customers) that doesnt exist, it will show error, cuz this is considered problem of referntial integrity.
-- if we were to delete Customers table, it will show error, cuz it is referenced by Orders table, the right way is to delete Orders to eleminate any referencing then delete Customers table.




-- Method 2:
-- we can create another table without referencing in creation phase, then we reference it later this way:
create table NoLinkTable
(
	Order_ID int not null primary key,
	Item varchar(40),
	Amount int ,
	Customer_ID int -- no reference yet
);

--or the DDL command alter:
alter table NoLinkTable
add foreign key (Customer_ID) references Customers(ID);

-- Method 3:
-- anytime using mouse: designer for any non linked table -> right click on the column -> relations -> tables and columns then choose PK and FK and save
