-- Create Table, can be by mouse or script:

-- data types in tables (more in next lesson):
-- char(n): fixed-length; ASCII only; keeps unused spaces; wastes storage.
-- nchar(n): fixed-length; supports Unicode (all languages); safer for multilingual data.
-- varchar(n): variable-length; ASCII only; saves space because it stores only actual characters used.
-- nvarchar(n): variable-length; Unicode support; best for names, languages, emojis, etc.

use DB1;

-- create command then table then name of table
-- open brackets and fill culomns (name type Null/NotNull)

create table Employees
(
	ID int not null,
	Name nvarchar(50) not null,
	Phone nvarchar(50) null,
	Salary smallmoney not null,
	primary key (ID)
);