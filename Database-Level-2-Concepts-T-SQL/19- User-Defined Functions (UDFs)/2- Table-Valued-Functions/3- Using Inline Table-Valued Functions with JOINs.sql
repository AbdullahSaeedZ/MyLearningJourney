

use C21_DB1;


-- joinging the inline table valued result set with the teachers table:
select s.StudentID, s.Name as StudentName, s.Grade, t.Name as TeacherName
from dbo.GetStudentsBySubject('Math') as s
inner join Teachers as t on t.Subject = s.Subject

-- reduced query complexity and saved lines, and took advantage of reusablity of this function

-- can be also done in query editpr