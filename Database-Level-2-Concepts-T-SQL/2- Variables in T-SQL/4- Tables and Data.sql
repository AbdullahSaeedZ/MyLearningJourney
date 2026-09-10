use C21_DB1;

create table Sales
(
	SaleID int identity primary key,
	SaleDate Date,
	SaleAmount decimal(10, 2)
);


insert into Sales (SaleDate, SaleAmount) values ('2026-9-1', 300.00);
insert into Sales (SaleDate, SaleAmount) values ('2026-9-3', 100.00);
insert into Sales (SaleDate, SaleAmount) values ('2026-9-8', 630.00);
insert into Sales (SaleDate, SaleAmount) values ('2026-4-8', 220.00);
insert into Sales (SaleDate, SaleAmount) values ('2026-3-8', 430.00);
