/*
====================================================================
 CASE Expression in T-SQL
====================================================================
- Core Concept:
  T-SQL lacks a dedicated SWITCH statement. CASE fills this role as 
  an inline expression (similar to switch expressions in modern C#).

- Nature & Scope:
  Not a procedural control-of-flow statement; it cannot run blocks of code.
  Must be embedded directly inside set-based query clauses:
  SELECT, UPDATE, INSERT, DELETE, and ORDER BY.
  (Use IF...ELSE or WHILE for procedural control flow).

- Two Formats:
  1. Simple CASE (Exact match):
     CASE input_expression
         WHEN val1 THEN res1
         WHEN val2 THEN res2
         ELSE default_result
     END

  2. Searched CASE (Boolean predicates):
     CASE
         WHEN condition1 THEN res1
         WHEN condition2 THEN res2
         ELSE default_result
     END

- Critical Gotchas & Best Practices:
  - If no condition matches and ELSE is omitted, CASE returns NULL.
  - All return values (THEN and ELSE) must share compatible data types.
  - Keep nesting minimal to maintain readability and avoid execution overhead.

- Examples:
====================================================================
*/

-- 1. Simple CASE (Exact match on a specific column)
SELECT ApplicationID, ApplicationStatus,
    CASE ApplicationStatus
        WHEN 1 THEN 'New'
        WHEN 2 THEN 'Cancelled'
        WHEN 3 THEN 'Completed'
        ELSE 'Unknown'
    END AS StatusName
FROM Applications;

-- 2. Searched CASE (Flexible boolean conditions / ranges)
SELECT PersonID,
    CASE 
        WHEN Gender = 0 THEN 'Male'
        WHEN Gender = 1 THEN 'Female'
        ELSE 'Unkown'
    END AS Gender
FROM People;