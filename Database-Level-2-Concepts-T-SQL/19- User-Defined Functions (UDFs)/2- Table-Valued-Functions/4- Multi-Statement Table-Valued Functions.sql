/*
====================================================================
OBJECT: Multi-Statement Table-Valued Function (mTVF)
NAME:   dbo.GetTopPerformingStudents
PURPOSE: Returns top 5 students into a table variable.
====================================================================

EXPLANATION:
1. Returns a TABLE VARIABLE:
   - You MUST declare the return table name (@ResultTable) and define 
     all its columns manually.

2. NOT READ-ONLY inside the function:
   - Because it is a table variable, you CAN modify it before returning.
   - You can run INSERT, UPDATE, and DELETE operations directly on 
     @ResultTable inside the function body.

3. Multi-Statement Table-Valued Function (mTVF)   vs.   INLINE TVF (iTVF):
   - Inline TVF: Single SELECT, NO BEGIN...END, columns are automatic, 
     READ-ONLY, faster.

   - Multi-Statement TVF: Multiple statements, USES BEGIN...END, 
     manual columns, MODIFIABLE internally, slower.

====================================================================
SYNTAX:
====================================================================
*/

use C21_DB1;
go


create function dbo.GetTopPerformingStudents
() /*optional parameters*/
returns @ResultTable table
(
	StudentID int,
	StudentName varchar(50),
	Subject Varchar(50),
	Grade int
)
as
begin
	insert into @ResultTable (StudentID, StudentName, Subject, Grade)
	select top 5 StudentID, Name, Subject, Grade
	from Students order by Grade desc;

	return;
end
go


-- usage:
select * from Students;

-- will return top 5 grades, then we filter it and use it as we need
select *
from dbo.GetTopPerformingStudents() as mtvf
where mtvf.Grade >= 90
order by mtvf.Grade desc

