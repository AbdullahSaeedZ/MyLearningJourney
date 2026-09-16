use C21_DB1;
go

create procedure usp_GetPersonByID_1
	@personID int
as
begin
	set nocount on;
	select * from People where PersonID = @personID;
end
go


-- usage:

exec usp_GetPersonByID_1
		1;