/*
You cannot use UPDATE or INSERT statements in Inline Table-Valued Functions (ITVFs) in T-SQL. 
Inline Table-Valued Functions are designed to be read-only,
and they return a table variable that is essentially a result of a single SELECT statement.
Since these functions are read-only, they cannot modify the data in the database,
which means you cannot perform data manipulation operations like INSERT, UPDATE, DELETE, or MERGE within them.

The primary purpose of an ITVF is to encapsulate a SELECT query. 
This limitation ensures that the function remains deterministic
and does not change the state of the database

SYNTAX OVERVIEW:
   -- A) INLINE TABLE-VALUED FUNCTION (iTVF): ****** READONLY function
   CREATE FUNCTION [schema_name].[fn_GetInlineData]
   (@Param1 INT)
   RETURNS TABLE
   AS
   RETURN
   (
       SELECT Column1, Column2  FROM dbo.SourceTable HERE Column1 = @Param1
   );
*/

use C21_DB1;
go


create function dbo.GetStudentsBySubject
( @Subject varchar(50) ) returns table
as
return
(
	select * from Students where Subject = @Subject
)
go

-- using the inline-table-valued-function to get a result set and show it:
select * from dbo.GetStudentsBySubject('Math');

-- can perform operations on it like any result set:
select avg(Grade) as AverageGrade from dbo.GetStudentsBySubject('Math');