-- Exists
-- The EXISTS operator is used to test for the existence of any record in a subquery.
-- The EXISTS operator returns TRUE if the subquery returns one or more records.

use Shop_Database;

-- this query returns a table with column named x and the value will be shown once EXISTS condition is true
select x = 'yes' 
where exists (select * from Orders where CustomerID = 3 and Amount < 600); -- if query inside Exists clause returnes at least one record then it is returning TRUE

-- if we change the EXISTS clause to be false then the x value wont be shown
select x = 'yes' 
where exists (select * from Orders where CustomerID = 3 and Amount < 0);



--------------------------
-- improving the query:
select * from Customers 
where Exists
-- now the goal of Exists is to return true or false, true if atleast one record returned
(
	select * from Orders where CustomerID = Customers.CustomerID and Amount < 600 --this can return 1000 record, so why waste the time and resources to finally return true? 
);


-- now better performance:
select * from Customers 
where Exists
(
	select top 1 * from Orders where CustomerID = Customers.CustomerID and Amount < 600 -- now if there are records, just top 1 will return from this subquery and Exists will return true
);

-- more improvemnet??
select * from Customers 
where Exists
(
	select top 1 R='y' from Orders where CustomerID = Customers.CustomerID and Amount < 600 -- why * ? no need to return all columns!! we make random column, our final goal is return true or false
);

-- so the EXISTS, tells us does that data exist or not, doesnt care about the data content itself