

select * from SalesRecords;


/*
Suppose we have a table SalesRecords with columns EmployeeID, SaleAmount, and SaleDate.
We want to find the average sales amount of the top 3 employees based on their total sales.
*/


;with TotalSales as
(
    select EmployeeID, sum(SaleAmount) as Sales
    from SalesRecords group by EmployeeID
),
TopSalesEmps as
(
    select top 3 Sales
    from TotalSales order by Sales desc
)
select avg(Sales) from TopSalesEmps;