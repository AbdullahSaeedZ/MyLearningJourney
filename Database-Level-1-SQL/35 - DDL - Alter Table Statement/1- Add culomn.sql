-- ALTER (means modify or change) is used to modify an existing table structure NOT table data (add, drop, change columns).
-- by right click on culomns then design and add there or by script:


use DB1;

-- since we are using DB1, so sys.tables means DB1.tables
-- create table if not created
if not exists (select * from sys.tables where name = 'Employees')
begin
	create table Employees
	(
		ID int not null, Name nvarchar(50) not null, Phone nvarchar(10) null, Salary smallmoney not null, primary key (ID)
	);
end

-- to add a culomn:

alter table Employees
add Gender char(1) not null;    -- can add more than one culomn: add.. , add..;


