-- Left (Outer) Join
-- second type of Joins is Left Join
-- The LEFT JOIN keyword returns all records from the left table (table1), and the matching records from the right table (table2). The result is 0 records from the right side, if there is no match.
-- Left Join = Left outer Join

use Shop_Database;

select * from Customers;
select * from Orders;


select Customers.CustomerID, Customers.Name, Orders.Amount 
from Customers left join Orders 
on Customers.CustomerID = Orders.CustomerID;

-- from query designer , select tables then needed columns, and right click on the relation itself and choose select all rows from the left table.