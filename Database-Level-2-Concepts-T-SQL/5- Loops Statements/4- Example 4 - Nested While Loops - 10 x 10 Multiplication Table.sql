
declare @counter1 int = 1;
declare @counter2 int = 1;
declare @product int = 0;

while @counter1 <= 10
begin

	set @counter2 = 1;

	while @counter2 <= 10
	begin
		set @product = @counter1 * @counter2;
		print cast(@counter1 as varchar) + ' x ' + cast(@counter2 as varchar) + ' = ' + cast(@product as varchar);
		set @counter2 +=1;
	end

	set @counter1 += 1;

end