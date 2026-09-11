
--Including ELSE allows an alternate action if the condition is false

declare @year int = 2026;


if @year > 2000
	begin 
	print '21st century';
	end
else
	begin
	print '20th or erlier century';
	end