

use C21_DB1;
go

create procedure usp_UpdatePerson
	@PerosnID int,
	@FirstName varchar(100),
	@LastName varchar(100),
	@Email varchar(100),
	@RowCount int output
as
begin
	set nocount on --> will just prevent (1 row affected) in message area of SSMS
	-- can do whatever checks and validations

	update People
	set FirstName = @FirstName, LastName = @LastName, Email = @Email
	where PersonID = @PerosnID;

	set @RowCount = @@ROWCOUNT;
end
go


-- usage:

declare @rowCount int = 0;

exec usp_UpdatePerson
	2, 'Ali', 'AlOtaibi', '511@m.com', @rowCount output;

if @rowCount > 0
	print 'person updated';
else
	print 'Updating Failed!';