-- Using CASE in ORDER BY (Custom Sorting)
-- as we know, order by will sort based on a column that is already defined
-- but using CASE after order by, is like creating that column value to rank based on, without any existent column:

-- sorting (ranking) based on existent column values
select * from Sales
order by SaleAmount;


-- sorting (ranking) based on new defined column values
select *, 
	case
		when SaleAmount > 299 then 1
		else 2
	end as SalesRank
from Sales
order by SalesRank;


-- sorting (ranking) based on values we created jsut to rank, Like Guid random sorting example we took before
select * from Sales
order by 
case
	when SaleAmount > 299 then 1
	else 2
end;



-- notice how it is not ordered by SalesAmount, so result came with 300 being first, then 630 being second
-- cuz the goal was to sort them based on custom criteria not on the amount
-- we can just add SalesAmount asc as a second criteria