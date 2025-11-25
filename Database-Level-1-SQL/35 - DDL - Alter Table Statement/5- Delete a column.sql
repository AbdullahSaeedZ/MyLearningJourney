-- deleting a column

use DB1;

alter table Emps
drop column Gender;


-- A Primary Key is a constraint, not just a normal column.
-- Because it is a constraint, SQL Server does NOT allow:
--   - changing its data type directly
--   - deleting the column directly

-- To modify or delete a Primary Key column:
-- 1) Drop the PK constraint
-- 2) Modify the column (rename / change datatype)
-- 3) Re-add the Primary Key again if column not deleted

-- Reason:
-- Constraints protect data rules, so SQL Server blocks direct changes.
