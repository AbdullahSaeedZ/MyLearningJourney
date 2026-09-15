/*
====================================================================
LESSON: Table Variables in T-SQL (Comprehensive Guide)
====================================================================

1. PROBLEM (Why it exists):
   - When building database logic, you frequently need to temporarily store 
     and manipulate a set of records for quick operations. Relying on permanent 
     storage or unmanaged mechanisms creates management clutter, locking overhead, 
     and excessive system overhead.


2. INTRODUCTION & CORE IDEA:
   - Table variables in T-SQL are used to store a set of records temporarily, 
     similar to temporary tables.

   - They are declared using the DECLARE statement.
   - Scope: Strictly limited to the batch, stored procedure, or function 
     in which they are defined.

   - (Note: Temporary tables are an alternative storage mechanism that will 
     be explained in detail in a later lesson).


 3. ADVANTAGES OF TABLE VARIABLES:
   - Performance: For small datasets, table variables can be faster because 
     they can reside in memory (RAM of computer allocated for the Database Server) and are not written to disk.
     But if large set of data inserted in that variable table, then the server will spill them on disk.

   - Transaction Log: Operations on table variables generate fewer log records 
     (transaction logging is the process performed by the server to record all 
     data changes (all operation even select and such) to disk for recovery and rollbacks),
     which provides noticeable performance benefits.

   - Scope Management: The isolated scope to a batch, stored procedure, or 
     function simplifies transaction management and error handling.


4. DIFFERENCES BETWEEN TABLE VARIABLES AND TEMPORARY TABLES 
   *(Note: Temporary tables will be fully explained in a later lesson)*:

   - Logging and Transactions: Table variables feature minimal logging for modifications. 
     However, they do not participate fully in transactions; if a transaction is 
     rolled back, changes made to a table variable within that transaction are *not* rolled back.

   - Statistics: SQL Server does not create statistics on table variables (statistics 
     are internal metadata collected by the server about data distribution to help 
     the query optimizer choose the fastest execution path), whereas temporary tables 
     handle statistics differently.

   - Scope and Lifetime: Temporary tables exist until they are explicitly dropped 
     or the session/connection is closed, whereas table variables exist only within 
     the batch, stored procedure, or function.


5. LIMITATIONS OF TABLE VARIABLES:
   - Indexing: By default, you can only create a primary key index at the time of 
     declaration. Additional indexing options are limited.
   - Statistics: Lack of statistics can lead to suboptimal query plans for large data sets.


6. BEST PRACTICES:
   - Data Size Consideration: Prefer table variables for small datasets or simple operations.
   - Scope and Lifetime: Use table variables when you need a temporary storage 
     mechanism within a single batch or stored procedure.


7. CONCLUSION:
   - Table variables in T-SQL provide a convenient way to temporarily store and 
     manipulate small sets of data.
   - They are particularly useful for quick operations and in scenarios where minimal 
     logging and transactional scope are important.
   - Understanding when and how to use table variables, as opposed to temporary tables 
     or other types of temporary storage (which will be covered in subsequent lessons), 
     is an important skill in SQL programming and database design.
====================================================================
*/