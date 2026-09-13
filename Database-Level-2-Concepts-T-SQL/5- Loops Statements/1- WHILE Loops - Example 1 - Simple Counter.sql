/*
In T-SQL (Transact-SQL, used with Microsoft SQL Server),
there are no FOR or DO WHILE statements as you would find in many other programming languages. 
The primary looping constructs available in T-SQL are the WHILE loop and the CURSOR, which is used to iterate over a result set row by row.

CURSOR will be explained later
*/

declare @counter int = 0;

while @counter < 5
begin
	print 'count: ' + cast(@counter as varchar);
	set @counter = @counter + 1;
end