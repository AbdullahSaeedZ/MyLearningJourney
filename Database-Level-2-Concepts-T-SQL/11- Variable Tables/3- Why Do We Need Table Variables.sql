/*
====================================================================
LESSON: Why Do We Need Table Variables? (Views vs. Table Variables)
====================================================================

1. THE PROBLEM (Why Views are not enough):
   - A common beginner assumption is: "If I have Views to shape, filter, 
     and present customized table data to my C# application, why do I need 
     Table Variables?"
   - A View is purely a **saved SELECT query definition**. It holds NO physical 
     data of its own. It merely mirrors and queries the underlying physical 
     tables in real-time every time you call it.
   - Views cannot hold temporary state, cannot be modified step-by-step 
     using iterative or multi-stage logic, and cannot serve as an isolated 
     local scratchpad within a single execution script.

2. CORE IDEA:
   - A View is an **external, permanent window** for reading data from physical tables.
   - A Table Variable is a **private, temporary container** that holds physical rows 
     in memory/tempdb strictly for the duration of a single execution block.
   - You use table variables when database logic requires a local, isolated staging 
     area to manipulate intermediate results without altering production tables or 
     cluttering the database.

3. PRACTICAL SCENARIO: Multi-Step Intermediate Calculations (Scenario A)
   - Problem: You need to calculate custom annual bonuses and performance ratings 
     for a subset of employees in a department, update their numbers conditionally, 
     and inspect the final calculated report all within a single script run without 
     writing untested changes directly into the real permanent Employees table.
   - Why a View Fails: A View cannot perform step-by-step UPDATE operations or 
     hold calculated temporary stages.
   - Why a Table Variable Wins: It acts as an isolated sandbox.
*/

-- BATCH DEMONSTRATION:
-- Step 1: Declare the temporary scratchpad
DECLARE @EmployeeBonusStaging TABLE (
    EmployeeID INT PRIMARY KEY,
    FullName NVARCHAR(100),
    Salary DECIMAL(10, 2),
    BonusAmount DECIMAL(10, 2),
    PerformanceGrade CHAR(1)
);

-- Step 2: Extract only the target subset from an existing table into the isolated staging area
-- (Simulated using direct INSERTs; in practice, this can be an INSERT INTO ... SELECT)
INSERT INTO @EmployeeBonusStaging (EmployeeID, FullName, Salary, BonusAmount, PerformanceGrade)
VALUES 
    (101, 'Abdullah Saeed', 12000.00, 0.00, 'A'),
    (102, 'Fahad Mohammed',  9500.00, 0.00, 'B'),
    (103, 'Ali Hassan',      8000.00, 0.00, 'C');

-- Step 3: Multi-step manipulation (Procedural updates impossible inside a standard View)
-- Apply 15% bonus for Grade A
UPDATE @EmployeeBonusStaging
SET BonusAmount = Salary * 0.15
WHERE PerformanceGrade = 'A';

-- Apply 10% bonus for Grade B
UPDATE @EmployeeBonusStaging
SET BonusAmount = Salary * 0.10
WHERE PerformanceGrade = 'B';

-- Apply flat 500 bonus for others
UPDATE @EmployeeBonusStaging
SET BonusAmount = 500.00
WHERE PerformanceGrade NOT IN ('A', 'B');

-- Step 4: Return the final calculated result set
SELECT 
    EmployeeID,
    FullName,
    Salary,
    BonusAmount,
    (Salary + BonusAmount) AS TotalCompensation,
    PerformanceGrade
FROM @EmployeeBonusStaging;

-- At this point, the batch ends, the memory is cleared, 
-- and your actual physical production tables remain completely untouched.
GO

/*
====================================================================
4. SUMMARY COMPARISON:
   - Use a VIEW when:
     * Your C# application needs a clean, reusable query to read data.
     * You want security abstraction (hiding specific columns from users).
     * The logic fits inside a single, declarative SELECT statement.

   - Use a TABLE VARIABLE when:
     * You need an isolated staging workspace within a script or routine.
     * You must perform multi-stage data transformations (INSERT, then UPDATE, 
       then SELECT) before returning a final result.
     * You need a sandbox to calculate or test data without touching real records.
====================================================================
*/