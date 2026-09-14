-- @@ROWCOUNT: T-SQL system function returning the number of rows affected by the last executed statement.
-- Purpose: Tracks modifications and data interactions performed on tables.
-- Important Usage Note: Must be checked immediately; any subsequent statement resets its value.
-- Common Use Cases: Verifying operation success or executing conditional logic based on affected row counts.

-- Behavior by Statement Type:
--   - DML (INSERT, UPDATE, DELETE) & DQL (SELECT): Returns a number because they directly modify or query table data.
--   - Utility/Control (SET, IF, WHILE, BEGIN...END, EXEC): Resets to 0 because these commands do not affect table rows.


use C21_DB1;

-- moving all employees from department 4 to dept 3
update Employees
set DepartmentID = 3 where DepartmentID = 4;

select @@ROWCOUNT as RowsAffected;

-- any subsequent statement (even a PRINT) resets its value!!!!