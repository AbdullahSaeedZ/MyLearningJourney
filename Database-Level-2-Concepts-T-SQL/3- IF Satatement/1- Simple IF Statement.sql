/*
The IF statement in T-SQL is a control-of-flow language construct that
allows you to execute or skip a statement block based on a specified condition. 
It is similar to "if-then" logic found in many programming languages.
*/



--syntax:

declare @x int = 3, @y int = 1;


-- can use >, <, =, != (or <>), <=, >=
if @x > @y
begin 
	print 'x is bigger than y';
end

-- or if the block is of one line:

if @x > @y
	print 'x is bigger than y';

-- the begin - end act as the brackects in c# {}
