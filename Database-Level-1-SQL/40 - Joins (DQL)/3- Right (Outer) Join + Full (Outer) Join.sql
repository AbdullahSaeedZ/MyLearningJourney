-- Right (Outer) Join + Full (Outer) Join

-- Right (Outer) Join is opposite of left join
-- The RIGHT JOIN keyword returns all records from the right table (table2), and the matching records from the left table (table1). The result is 0 records from the left side, if there is no match.




use Shop_Database;

select * from Customers;
select * from Orders;


-- returning all orders rows from orders table (right) and the matching rows from Customers table (left)
select Customers.CustomerID, Customers.Name, Orders.Amount
from Customers right join Orders
on Customers.CustomerID = Orders.CustomerID;
-- will return all orders regardless having customers or not


------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


-- The FULL OUTER JOIN keyword returns all records when there is a match in left (table1) or right (table2) table records.

-- FULL OUTER JOIN and FULL JOIN are the same.


-- returning all rows from customers and orders (right and left) whether matching or not:
select Customers.CustomerID, Customers.Name, Orders.Amount
from Customers full join Orders
on Customers.CustomerID = Orders.CustomerID;
