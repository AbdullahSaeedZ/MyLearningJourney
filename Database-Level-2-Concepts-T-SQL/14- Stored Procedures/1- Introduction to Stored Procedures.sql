/*******************************************************************************
LESSON: Introduction to Stored Procedures (T-SQL)
================================================================================

1. WHAT IS A STORED PROCEDURE?
   A stored procedure is an encapsulated block of SQL code saved directly 
   inside SQL Server that you can run again and again.

2. WHY USE STORED PROCEDURES?
   - Performance: They are pre-compiled and saved in the database, leading 
     to faster run times.

   - Security: They add an extra security layer by keeping users away from 
     direct access to the raw tables.

   - Maintainability: Centralizing business logic in one place makes updates 
     easier and more consistent.

3. WHAT CAN YOU WRITE INSIDE A STORED PROCEDURE? (almost everything)
   - SQL Queries and DML: SELECT, INSERT, UPDATE, DELETE, and MERGE to read 
     and change data.

   - Variables: Declare local variables (DECLARE) and assign values (SET/SELECT).
   - Control Flow:
     * IF...ELSE: For decision making.
     * WHILE: For repeating a task in a loop.
     * BEGIN...END: To group statements together.
     * WAITFOR: To delay execution for a set time.
     * GOTO: To jump to a label (rarely used because it hurts readability).

   - Error Handling and Transactions:
     * TRY...CATCH: To catch and handle unexpected errors cleanly.
     * Transactions: BEGIN TRANSACTION, COMMIT, and ROLLBACK to guarantee 
       that grouped changes either all finish or all undo.

   - Dynamic SQL: Running SQL text built on the fly using EXEC or sp_executesql.
   - Calling Other Code: Calling other stored procedures or user functions.
   - Temporary Storage: Using local temp tables (#table) or table variables 
     (@table) to store work steps.
   - Cursors (will be explained later): Tools to process data row by row (slower than normal SQL, but 
     supported).
   - System Calls: Running built-in SQL Server system procedures and functions.
   - Output Parameters: Sending data values back out to whoever called the code.
   - Custom Errors: Using RAISERROR or THROW to send custom warning messages.
   - Table-Valued Parameters (TVPs): Passing an entire table into the procedure 
     as an input parameter.
   - CTEs (Common Table Expressions, explained later): Temporary, named query blocks defined at 
     the start of a statement to organize complex logic.
   - DDL Statements: Commands like CREATE, ALTER, or DROP (mostly used for temp 
     objects or inside dynamic SQL).
   - XML Handling: Storing, reading, and querying XML data structures.
   - Text and Image Handling: Older tools for large text and image data types.

4. BEST PRACTICES
   - Avoid cursors when normal set-based SQL can do the job.
   - Always write solid error handling.
   - Protect dynamic SQL from SQL injection by using parameters.
   - Check your specific SQL Server version docs, as features can change.

5. EXECUTION & EXECUTION TYPES
   Running code in SQL Server happens in two distinct ways:

   1. Dynamic Execution (Ad-Hoc / Plain Text):
      - What it is: Running raw SQL code passed as a string. It has nothing 
        to do with calling a stored procedure normally.
      - How it works: The SQL engine must read, check syntax, and figure out 
        a new plan every time the text changes.
      - Example:
        EXEC('SELECT * FROM Customers WHERE CustomerID = 101;');

   2. Pre-compiled Execution (Stored Procedures):
      - What it is: How stored procedures actually run.
      - How it works: On the very first run, SQL Server parses the code, 
        creates an optimal execution plan, and saves (caches) that plan in memory.
      - Why it is faster: Every subsequent execution skips the planning phase 
        entirely and reuses the cached plan instantly, saving CPU and time.
      - Example:
        EXEC dbo.GetCustomerOrders @CustomerID = 101;

*******************************************************************************/