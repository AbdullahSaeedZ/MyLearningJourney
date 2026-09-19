
use C21_DB1;
go
-- calculating bonus for each employess based on performance rating:
select * from Employees2;
go

create function dbo.CalculateBonus
(@Salary decimal(10, 2), @PerformanceRating int)
returns decimal(10, 2)
as 
begin 
	declare @Bonus decimal(10, 2);

	if @PerformanceRating > 90
		set @Bonus = @Salary * 0.2;
	else if @PerformanceRating > 75
		set @Bonus = @Salary * 0.1;
	else
		set @Bonus = @Salary * 0.05;
		
	return @Bonus;
end
go


-- adding bonus amount for each employee based on rating
select * from Employees2;

-- old way:
select *, 
case
	when PerformanceRating > 90 then Salary * 0.2
	when PerformanceRating > 75 then Salary * 0.1
	else Salary * 0.05
end as BonusAmount
from Employees2 order by PerformanceRating desc;


-- with scalar functions:
select *, dbo.CalculateBonus(Salary, PerformanceRating) as BonusAmount
from Employees2 order by PerformanceRating desc;