-- Why should you name your constraints? (Short + Clear)

-- 1) Clear error messages
-- SQL Server shows the constraint name when something fails.
-- If you name it, you instantly know the problem.
-- Example:
--   Violation of PRIMARY KEY constraint 'PK_Students'.
--   Cannot insert duplicate key in 'Students'.

-- If you don’t name it, SQL Server generates trash names:
--   PK__Students__3213E83F4F7CD00D  (random, unreadable)

-- 2) Easier maintenance
-- To drop/modify a constraint, you must know its name.
-- If you named it → easy:
--   ALTER TABLE Students DROP CONSTRAINT PK_Students;

-- If SQL Server named it → you must search for it manually:
--   SELECT name FROM sys.objects WHERE type = 'F';  -- messy
