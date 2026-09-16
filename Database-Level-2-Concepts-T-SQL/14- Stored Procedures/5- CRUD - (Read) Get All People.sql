use C21_DB1;
go 

create procedure usp_GetAllPeople
as
begin
	set nocount on;
	select * from People;
end
go



-- usage:

exec usp_GetAllPeople;
go