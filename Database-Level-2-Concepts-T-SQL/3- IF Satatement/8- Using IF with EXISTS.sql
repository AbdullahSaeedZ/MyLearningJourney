-- IF statements can be combined with EXISTS to check for the existence of rows in a table that meet a certain condition.

-- EXISTS () <- takes a select statement, then if the statement returned at least 1 row, then it evaluate to true, otherwise returns fale




if EXISTS (select * from Employees where Name = 'John Smith')
	print 'Employee was found';
else
	print 'Employee was not found';




