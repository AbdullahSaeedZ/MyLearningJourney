

use C21_DB1;
go
select * from Students;
go

-- creating a scalar function that takes specific subject and returns its average grade
create function dbo.GetAverageGrade
(
	@Subject varchar(10)
)
returns int
as 
begin
	
	declare @avgGrade int;
	select @avgGrade = avg(Grade) from Students where Subject = @Subject;
	return @avgGrade;

end;
go

----------------------------------------

-- we have this teachers table
-- we want to see what is the average grade for each teacher teaching a certain subject
select * from Teachers;

-- normal way?
select Name, Subject, 
(select avg(Grade) as average from Students where Subject = t.Subject) as AverageGrade
from Teachers as t;

-- using scalar functinos:
select Name, Subject, dbo.GetAverageGrade(Subject) as AverageGrade from Teachers;
