--select * from Sales;


declare @Year int;
declare @Month int;
declare @TotalSales decimal(10, 2);
declare @TotalTransactions int;
declare @AverageSale Decimal(10, 2);

set @Year = 2026;
set @Month = 9;

-- calculaate total sales for the specified year and month
select @TotalSales = sum(SaleAmount)
from Sales where year(SaleDate) = @Year and month(SaleDate) = @Month;

-- calculate total number of transactions
select @TotalTransactions = count(*)
from Sales where year(SaleDate) = @Year and month(SaleDate) = @Month;

-- calculate average sale value
set @AverageSale = (@TotalSales / @TotalTransactions);


-- print the report
print 'Monthly Sales Report:';
print 'Year: ' + cast(@Year as varchar);
print 'Month: ' + cast(@Month as varchar);
print 'Total Sales: ' + cast(@TotalSales as varchar);
print 'Total Transactions: ' + cast(@TotalTransactions as varchar);
print 'Average Sales: ' + cast(@AverageSale as varchar(10));