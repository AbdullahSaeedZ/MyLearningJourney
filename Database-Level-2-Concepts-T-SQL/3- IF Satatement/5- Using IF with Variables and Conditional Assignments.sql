--Variables can be used within an IF statement for dynamic conditions

declare @max int;
declare @a int = 10;
declare @b int = 5;

if @a > @b
	set @max = @a;
else
	set @max = @b;

print 'max = ' + cast(@max as varchar);

-- or using immediate if:

print 'iif: max = ' + iif(@a > @b, cast(@a as varchar), cast(@b as varchar));