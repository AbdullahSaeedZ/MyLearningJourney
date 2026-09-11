
-- AND
declare @age int = 20;
declare @salary decimal(10,2) = 30000;


if (@age > 18)  and (@salary > 20000)
	print 'eligible for loan';
else
	print 'not eligible for loan';


-----------------------------------------

-- OR

declare @grade char(1) = 'A';
declare @attendancePercentage int = 75;

if (@grade = 'A') or (@attendancePercentage > 70)
	print 'can take summer term';
else
	print 'cannot take summer term';


-----------------------------------------

-- NOT

declare @customerStatus varchar(10) = 'Inactive';

if not (@customerStatus = 'Active')
	print 'send re-engagement email';
else
	print 'customer is active';