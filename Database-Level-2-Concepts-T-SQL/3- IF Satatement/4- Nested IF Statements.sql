-- You can nest IF statements within each other for complex conditions:

Declare  @score int = 42;

if @score > 90
	begin 
	print 'grade A';
	end
else
	begin 
		if @score > 80
			begin
			print 'Grade B';
			end
		else
			begin
			print 'Failed';
			end
	end