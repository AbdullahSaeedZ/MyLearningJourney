

declare @startDate Date = '2026-09-01';
declare @endDate Date = '2026-09-30';

;with MonthCTE as
(
	select @startDate as DateValue

	union all

	select dateadd(day, 1, DateValue) from MonthCTE where DateValue < @endDate
)
select * from MonthCTE