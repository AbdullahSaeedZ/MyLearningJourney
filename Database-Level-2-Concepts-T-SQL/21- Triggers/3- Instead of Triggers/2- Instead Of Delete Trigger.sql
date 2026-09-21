

use C21_DB1;

-- adding a new column to simulate a soft delete:
alter table Students
add IsActive bit default 1 with values;

go


-- creating the instead of trigger
-- which will intercepts DELETE commands and converts them into soft-delete updates:
create or alter trigger trg_InsteadOfDeleteStudent on Students
instead of delete
as
begin
	
	set nocount on;

	update Students
	set IsActive = 0
	from Students as s
	inner join deleted as d on d.StudentID = s.StudentID

end
go


-- check before operation:
select * from Students;

-- now we try the overridden delete:
delete Students
where StudentID = 4;