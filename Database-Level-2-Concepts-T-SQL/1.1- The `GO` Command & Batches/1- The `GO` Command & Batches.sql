/*
====================================================================
LESSON: The `GO` Command & Batches in T-SQL
====================================================================

1. THE PROBLEM (Why it exists):
   - When executing large SQL scripts (e.g., creating a database, adding 
     tables, creating stored procedures, and inserting seed data), sending 
     all commands as a single monolithic block fails. 
   - Certain DDL statements (like `CREATE PROCEDURE` or `CREATE VIEW`) 
     are required by SQL Server to be the very first statement in a query block.
   - If one syntax check fails in a single block, the entire script halts. 
   - A mechanism was needed to chop scripts into distinct, sequential execution 
     units.

2. CORE IDEA & PLACEMENT:
   - `GO` is **NOT** a T-SQL statement. The SQL Server engine does not understand 
     the word `GO`.
   - `GO` is a **client-side batch separator** recognized by tools like SSMS, 
     Azure Data Studio, and `sqlcmd`.
   - **Placement Rule:** `GO` is placed on its own line immediately after the end 
     of a batch. When the client tool encounters the word `GO`, it knows that 
     all statements written above it (since the previous `GO` or start of file) 
     constitute the completed batch. The client slices that block and sends it 
     over the wire to the SQL Server engine before proceeding.

3. HOW IT WORKS INTERNALLY & VARIABLE SCOPE:
   - A "Batch" is a set of one or more T-SQL statements sent at the same time 
     from a client to SQL Server for compilation and execution.
   - Variables (scalar and table variables) have their lifetime bound to the **batch**.
   - When `GO` is encountered, the client signals the end of the batch. The engine 
     finishes executing that batch, frees its local execution plan context, and 
     destroys all local variables declared inside it.
   - Bonus internal capability: `GO [count]` executes the preceding batch multiple 
     times (e.g., `GO 5` executes the batch 5 times sequentially).

4. PRACTICAL MINIMAL EXAMPLE:
*/

-- BATCH 1:
DECLARE @BatchNumber INT = 1;
SELECT @BatchNumber AS OutputColumn;

-- Placed on its own line right after the statements above.
-- The client intercepts this line and sends Batch 1 to the engine.
-- The variable @BatchNumber is allocated, used, and cleared from engine memory.
GO 

-- BATCH 2:
-- Running the following line will throw an error: "Must declare the scalar variable @BatchNumber"
-- because @BatchNumber died when Batch 1 terminated at GO.
-- SELECT @BatchNumber;

-- Demonstrating batch repetition:
PRINT 'Executing a batch repeatedly:';
GO 3 -- Executes the preceding PRINT batch 3 times

/*
====================================================================
5. WHEN NOT TO USE IT & COMMON OVER-ENGINEERING MISTAKES:
   - Dynamic SQL / App Code: Never write `GO` inside strings passed to 
     ADO.NET (`SqlCommand.CommandText`) or stored procedures. Your C# code 
     talks directly to the engine protocol (TDS), which will throw a syntax 
     error on the word `GO`.
   - Transaction Misconceptions: `GO` does not commit or roll back transactions. 
     A transaction opened with `BEGIN TRAN` can span across multiple `GO` batch 
     separators until an explicit `COMMIT` or `ROLLBACK` is issued.
   - Overuse: Scattering `GO` after every single statement adds unnecessary 
     network overhead and fragments variable access unnecessarily.
====================================================================
*/