-- break revision:

declare @counter int = 1;

print 'Break Example:';
while @counter < 10
begin

	print 'counter = ' + cast(@counter as varchar);

	if @counter = 5
	begin
		print 'Counter reached 5..Exiting loop..';
		break;
	end

	set @counter += 1;

end

-- continue keyword:
print '-----------------------------';
print 'Continue Example:';
set @counter = 0;
declare @evenNumber int;

while @counter <= 10
begin
	
	set @counter += 1;
	if @counter % 2 = 0
		print 'even numbers = ' + cast(@counter as varchar);
	else
		continue;

end