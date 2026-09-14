/*
create table Products
(
    ProductID int primary key,
    StockQuantity int
);

insert into Products values (1, 100);
insert into Products values (2, 50);
insert into Products values (3, 75);
*/
/*
  ===========================================================================
  LESSON: T-SQL Error Handling & The THROW Statement
  ===========================================================================

  1. PROBLEM:
     Standard SQL engine errors do not align with domain-specific business rules 
     (e.g., preventing negative inventory quantities). Developers needed a 
     controlled mechanism to trigger custom errors, log them locally for auditing, 
     and bubble them up to the calling application without crashing execution 
     silently or leaking across scopes.

  2. CORE IDEA:
     The THROW statement generates custom errors with specific numbers, messages, 
     and states. Additionally, when called without parameters inside a 
     CATCH block, it acts like C#'s parameterless `throw;` to re-throw and bubble 
     up the active error.

  3. SYNTAX:
     THROW error_number, message, state;

  4. HOW IT WORKS INTERNALLY (PARAMETERS & BEHAVIOR):
     - error_number: A constant or variable between 50,000 and 2,147,483,647. 
       This can serve as a standard error reference defined across our company 
       for specific validation checks (e.g., using 51000 for negative quantities).

     - message: The error message text. It should be a string less than 
       2048 characters.

     - state: A constant or variable between 0 and 255. This can be 
       utilized as a subcategory to identify the exact sub-context or specific 
       code branch where the error was triggered.

     - Re-throwing (THROW;): Calling THROW with zero arguments inside a CATCH 
       block passes on (bubbles up) the current active error unchanged.


  ===========================================================================
  PRACTICAL EXAMPLES
  ===========================================================================
*/

---------------------------------------------------------------------------
-- SCENARIO 1: Throwing a Custom Company Error (with Standard Number & State)
---------------------------------------------------------------------------
DECLARE @NewStockQty INT = -5;

BEGIN TRY

    -- Using company standard error number 51000 for negative stock, 
    -- and state 1 as a subcategory indicator for the inventory module.
    IF @NewStockQty < 0
        THROW 51000, 'Stock quantity cannot be negative.', 1;

    UPDATE Products SET StockQuantity = @NewStockQty WHERE ProductID = 1; -- will not execute if error thrown
    
END TRY
BEGIN CATCH
    SELECT 
        ERROR_NUMBER() AS ErrorNumber,
        ERROR_MESSAGE() AS ErrorMessage,
        ERROR_STATE() AS ErrorState; -- Captures our subcategory state (1)
END CATCH;


---------------------------------------------------------------------------
-- SCENARIO 2: Re-throwing / Bubbling Up (Like C#'s `throw;`)
---------------------------------------------------------------------------
BEGIN TRY
    -- Simulating a failure or custom rule violation
    THROW 51001, 'Critical inventory validation failed.', 2;
END TRY
BEGIN CATCH
    -- Step 1: Log the error internally for database auditing
    -- INSERT INTO ErrorAuditLog (ErrorMsg) VALUES (ERROR_MESSAGE());

    -- Step 2: Pass the exact same error on to the caller/application 
    -- (Just like `throw;` in C# to preserve the exception pipeline)
    THROW; 
END CATCH;


---------------------------------------------------------------------------
-- SCENARIO 3: Throwing Outside a TRY Block (Like C# Code Blocks)
---------------------------------------------------------------------------
-- Just like C#, you do NOT need a TRY block to throw an error. 
-- You can trigger a custom error anywhere in your script or stored procedure:
DECLARE @UserRole VARCHAR(50) = 'Guest';

IF @UserRole = 'Guest'
    THROW 50403, 'Unauthorized access attempt detected.', 1;