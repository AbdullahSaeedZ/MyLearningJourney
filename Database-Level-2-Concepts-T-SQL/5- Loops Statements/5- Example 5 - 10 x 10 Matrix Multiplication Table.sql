

declare @row int = 0;
declare @col int = 1;
declare @productResult int = 0;
declare @fullRow varchar(500) = '';

while @row <= 10
begin
	
	set @fullRow = cast(@row as varchar) + '	';
	set @col = 1;

	while @col <= 10
	begin

		if @row = 0
			set @productResult = 1 * @col;
		else
			set @productResult = @row * @col;

		set @fullRow += cast(@productResult as varchar) + '	    ';
		set @col += 1;

	end

	print @fullRow;
	set @row +=1;

end