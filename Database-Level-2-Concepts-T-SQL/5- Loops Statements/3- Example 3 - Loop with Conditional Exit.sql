-- using the break keyword to exit a loop

declare @Balance decimal(10, 2) = 700;
declare @WithdrawAmount decimal(10, 2) = 100

while @Balance > 0
begin

	if @Balance <= 300
	begin
		print '----------Balance Reached the limit, exiting the loop...----------';
		break;
	end

	set @balance -= @WithdrawAmount;
	print 'withdew 100 SAR from Balance';
	print 'New Balance: ' + cast(@Balance as varchar);

	
end