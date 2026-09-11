
/*
In this scenario, we will use T-SQL variables to calculate and update loyalty points for customers based on their purchase history. 
The calculation will be based on the total amount spent by the customer in a given year, 
with a simple point system where 1 point is awarded for every $10 spent.

This example demonstrates how T-SQL variables can be used for more complex calculations 
involving data from multiple tables, and how these results can be used to update records in a database, 
showcasing the power and versatility of SQL in handling real-world business scenarios.

*/

--select * from Customers;
--select * from Purchases;


declare @CustomerID int;
declare @TotalSpent decimal(10, 2);
declare @PointsEarned int;
declare @CurrentYear int; 

set @CurrentYear = 2023;
set @CustomerID = 1;

-- Calculate total amount spent by the customer in the current year
select @TotalSpent = sum(Amount)
from Purchases
where CustomerID = @CustomerID and year(PurchaseDate) = @CurrentYear;

-- Calculate loyalty points (1 point for every $10 spent)
select @PointsEarned = cast((@TotalSpent / 10) as int);

-- Update loyalty points in Customers table
update Customers
set LoyaltyPoints = (LoyaltyPoints + @PointsEarned) where CustomerID = @CustomerID;

-- Print the results
print 'CustomerID = ' + cast(@CustomerID as varchar) + ', Year: ' + cast(@CurrentYear as varchar);
print 'Total Amount spent: ' + cast(@TotalSpent as varchar);
print 'Total Ponits Earned: ' + cast(@PointsEarned as varchar);



-- This script calculates and updates the loyalty points for a customer based on their total spending in the current year.
