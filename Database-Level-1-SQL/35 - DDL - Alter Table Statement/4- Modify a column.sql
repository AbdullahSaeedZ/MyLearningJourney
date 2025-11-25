-- modifying a column properties, like data type and constraints

use DB1;

alter table Emps
alter column Name nvarchar(100) not null;
--           name of column, new data type, new constrant update (if none then it will be nullable by default)
-- if the column name consists of more than one word, use "name here"
