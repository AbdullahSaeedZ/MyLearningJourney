use C21_DB1;

go 

create procedure usp_AddNewPerson
	@FirstName varchar(100),
	@LastName varchar(100),
	@Email varchar(200),
	@NewID int output
as
begin
	set nocount on;
	
	insert into People (FirstName, LastName, Email) values (@FirstName, @LastName, @Email);
	set @NewID = SCOPE_IDENTITY();
end

go


-- now we call it
declare @CreatedID int = null;

exec usp_AddNewPerson 
		'Abdullah', 'Alzahrani', 'A@A.com', @NewID = @CreatedID output;

if @CreatedID is not null
	print 'Person Added Successfully, new ID = ' + cast(@CreatedID as varchar);
else
	print 'Error while adding new person';

go