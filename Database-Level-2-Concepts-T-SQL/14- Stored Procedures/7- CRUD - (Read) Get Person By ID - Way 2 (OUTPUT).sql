/*
another way is to create SP_GetPersonByID2 stored procedure so 
that it retrieves a person's information as output parameters instead of a standard result set, 
you need to declare output parameters for each piece of information you want to retrieve.
In this case, that would be FirstName, LastName, and Email.

If the person is not found in the database when using the SP_GetPersonByID stored procedure,
you can include an additional output parameter that indicates whether a record was found. 
This parameter can be a boolean or an integer flag (often used in SQL Server).
*/

use C21_DB1;
go

create procedure usp_GetPersonByID_2
	@personID int, 
	@FirstName varchar(100) output,
	@LastName varchar(100) output,
	@Email varchar(100) output,
	@IsFound bit output
as
begin
	set nocount on

	if exists (select a=1 from People where PersonID = @personID)
	begin
		select @FirstName = FirstName, @LastName = LastName, @Email = Email
		from People where PersonID = @personID;

		set @IsFound = 1;
	end
	else
	begin
		set @IsFound = 0;
	end
end
go

-- usage:

declare	@FirstName varchar(100); 
declare	@LastName varchar(100);
declare	@Email varchar(100);
declare	@IsFound bit;

exec usp_GetPersonByID_2
	1, @FirstName output, @LastName output, @Email output, @IsFound output;


if @IsFound = 1
	select @FirstName as FirstName, @LastName as LastName, @Email as Email;
else
	print 'person was not found';