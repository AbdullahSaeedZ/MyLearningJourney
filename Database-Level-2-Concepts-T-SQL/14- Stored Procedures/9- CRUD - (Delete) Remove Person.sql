
use C21_DB1;
go

create procedure usp_DeletePerson
	@PerosnID int,
	@RowCount int output
as
begin
	set nocount on --> will just prevent (1 row affected) in message area of SSMS
	-- can do whatever checks and validations

	delete People where PersonID = @PerosnID;
	set @RowCount = @@ROWCOUNT;
end
go


-- usage:

declare @rowCount int = 0;

exec usp_DeletePerson
	2, @rowCount output;

if @rowCount > 0
	print 'person deleted';
else
	print 'Deleting Failed!';