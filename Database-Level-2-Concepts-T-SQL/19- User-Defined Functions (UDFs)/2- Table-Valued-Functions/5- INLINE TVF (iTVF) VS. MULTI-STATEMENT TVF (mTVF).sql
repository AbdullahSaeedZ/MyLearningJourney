/*
====================================================================
LESSON: INLINE TVF (iTVF) VS. MULTI-STATEMENT TVF (mTVF)
====================================================================

1. CORE DIFFERENCE:
   - iTVF: A parameterized VIEW (one SELECT, no table variable).
   - mTVF: A mini STORED PROCEDURE that fills and returns a TABLE VARIABLE.

2. SYNTAX COMPARISON:

   -----------------------------+------------------------------------
   INLINE TVF (iTVF)            | MULTI-STATEMENT TVF (mTVF)
   -----------------------------+------------------------------------
   CREATE FUNCTION dbo.GetITVF  | CREATE FUNCTION dbo.GetMTVF
   (                            | (
       @DeptID INT              |     @DeptID INT
   )                            | )
   RETURNS TABLE                | RETURNS @Result TABLE
   AS                           | (
   RETURN                       |     EmpID INT,
   (                            |     EmpName VARCHAR(50)
       SELECT EmpID, EmpName    | )
       FROM dbo.Employees       | AS
       WHERE DeptID = @DeptID   | BEGIN
   );                           |     -- Can use multiple steps
                                |     INSERT INTO @Result (EmpID, EmpName)
                                |     SELECT EmpID, EmpName
                                |     FROM dbo.Employees
                                |     WHERE DeptID = @DeptID;
                                |
                                |     -- Can UPDATE / DELETE rows in @Result here before returning
                                |
                                |     RETURN;
                                | END;
   -----------------------------+------------------------------------

3. PROS AND CONS:

   +-------+----------------------------------+----------------------------------+
   | TYPE  | PROS                             | CONS                             |
   +-------+----------------------------------+----------------------------------+
   | iTVF  | - FAST: Merged into outer query  | - Only ONE SELECT statement      |
   |       | - Accurate row count estimates   | - No complex procedural logic    |
   |       | - Supports parallelism & indexes | - No internal modifications      |
   +-------+----------------------------------+----------------------------------+
   | mTVF  | - Flexible procedural logic      | - SLOWER: Uses a table variable  |
   |       | - Can run loops, IF/ELSE blocks  | - Bad row estimates (spills/lag) |
   |       | - Table variable can be altered  | - Blocks query parallelism       |
   +-------+----------------------------------+----------------------------------+

4. WHEN TO USE WHICH:
   - Default choice -> iTVF. Always choose iTVF if you can write the logic 
     inside a single SELECT query.
   - Fallback choice -> mTVF. Use mTVF ONLY when your logic is too complex 
     for one query (requires loops, temp aggregation steps, or conditional 
     branching before returning).
====================================================================
*/