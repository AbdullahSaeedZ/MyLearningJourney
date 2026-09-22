/* ============================================================================
   CHALLENGE: Organizational Hierarchy Traversal (Recursive CTE)
   ============================================================================

   1. SCHEMA SETUP & SEED DATA
   ---------------------------------------------------------------------------- */

USE C21_DB1;
GO

IF OBJECT_ID('dbo.CompanyOrg', 'U') IS NOT NULL 
    DROP TABLE dbo.CompanyOrg;
GO

CREATE TABLE CompanyOrg (
    EmployeeID INT PRIMARY KEY,
    ManagerID  INT NULL,
    Name       VARCHAR(50) NOT NULL
);
GO

INSERT INTO CompanyOrg (EmployeeID, ManagerID, Name) VALUES
(1, NULL, 'CEO'),
(2, 1,    'VP of Sales'),
(3, 1,    'VP of Marketing'),
(4, 2,    'Sales Manager'),
(5, 2,    'Sales Representative'),
(6, 3,    'Marketing Manager'),
(7, 4,    'Sales Associate'),
(8, 6,    'Marketing Specialist'),
(9, 1,    'VP IT');
GO


/* ============================================================================
   2. REQUIREMENT SPECIFICATION (ASCII DIAGRAM)
   ============================================================================

   HIERARCHY TREE:
   ----------------------------------------------------------------------------
   [Level 0]                          1: CEO
                       ┌─────────────────┼─────────────────┐
                       │                 │                 │
   [Level 1]       9: VP IT      3: VP of Marketing    2: VP of Sales
                                         │                 ┌──────────┴──────────┐
                                         │                 │                     │
   [Level 2]                    6: Marketing Manager  4: Sales Manager  5: Sales Representative
                                         │                 │
   [Level 3]                    8: Marketing Spec.    7: Sales Associate


   DATA TRANSFORMATION REQUIREMENTS:
   ----------------------------------------------------------------------------
   - Base Case (Anchor Member):
     * Identify the root node where `ManagerID IS NULL` (EmployeeID = 1).
     * Set its initial `Hierarchy` text to simply `'CEO'`.
     * Set its initial `Level` to `0`.

   - Iterative Step (Recursive Member):
     * Join child records from `CompanyOrg` to parent records already in your CTE 
       (`child.ManagerID = parent.EmployeeID`).
     * Concatenate the path: `parent.Hierarchy + ' -> ' + child.Name`.
     * Increment depth: `parent.Level + 1`.

   - Output Columns Expected:
     ┌────────────┬───────────┬──────────────────────┬──────────────────────────────────────────┬───────┐
     │ EmployeeID │ ManagerID │ Name                 │ Hierarchy                                │ Level │
     ├────────────┼───────────┼──────────────────────┼──────────────────────────────────────────┼───────┤
     │ 1          │ NULL      │ CEO                  │ CEO                                      │ 0     │
     │ 9          │ 1         │ VP IT                │ CEO -> VP IT                             │ 1     │
     │ 3          │ 1         │ VP of Marketing      │ CEO -> VP of Marketing                   │ 1     │
     │ 6          │ 3         │ Marketing Manager    │ CEO -> VP of Marketing -> Mark...        │ 2     │
     │ ...        │ ...       │ ...                  │ ...                                      │ ...   │
     └────────────┴───────────┴──────────────────────┴──────────────────────────────────────────┴───────┘


   CRITICAL ENGINE TRAP TO WATCH OUT FOR:
   ----------------------------------------------------------------------------
   In T-SQL, string columns in recursive CTEs must have a fixed, matching 
   datatype length between the Anchor and the Recursive members. 

   If you leave the Anchor's string untyped:
       `SELECT ... Name AS Hierarchy`
   The engine locks the `Hierarchy` column to `VARCHAR(50)`. 
   When the recursive step tries to concatenate paths longer than 50 characters, 
   SQL Server throws an arithmetic/string truncation error.
   
   Tip: Explicitly CAST the anchor path: `CAST(Name AS VARCHAR(MAX))` or `VARCHAR(500)`.
   ============================================================================ */


   select * from CompanyOrg;

   ;with EmployeesTree as
   (
   -- anchor as the first manager
        select EmployeeID, ManagerID, Name,
        cast(Name as varchar(max)) as Hierarchy, 0 as Level
        from CompanyOrg where EmployeeID = 1

        union all

        select Employees.EmployeeID, Employees.ManagerID, Employees.Name , 
        (Managers.Hierarchy + ' -> ' + Employees.Name), Managers.Level + 1
        from EmployeesTree as Managers  --< anchor as manager
        inner join CompanyOrg as Employees on Employees.ManagerID = Managers.EmployeeID


   )
   select * from EmployeesTree order by Hierarchy;






   /* ============================================================================
   BREADTH-FIRST TRAVERSAL: LEVEL-BY-LEVEL RECURSION
   ============================================================================

   1. HIERARCHY DIAGRAM (Level-By-Level Processing)
   ----------------------------------------------------------------------------
   SQL Server does NOT go down one branch at a time (it is not depth-first).
   It processes an ENTIRE horizontal level at once before moving deeper:

   [START] ─────────►  ┌─────────────────────────┐
                       │     ANCHOR (Level 0)    │
                       │         [1: CEO]        │  ◄── Done in 1 shot
                       └────────────┬────────────┘
                                    │
   ─────────────────────────────────┼──────────────────────────────────────────
   ITERATION 1 (Level 1):           │
   Finishes ALL direct reports to 1 │
   before going to any children:    ├───────────────┬───────────────┐
                                    ▼               ▼               ▼
                                [9: VP IT]  [3: VP Market]   [2: VP Sales]
   ─────────────────────────────────────────────────┼───────────────┼──────────
   ITERATION 2 (Level 2):                           │               │
   Takes everyone from Level 1,                     │        ┌──────┴──────┐
   and finds ALL their reports:                     ▼        ▼             ▼
                                              [6: Mkt Mgr] [4: Sales Mgr] [5: Rep]
   ─────────────────────────────────────────────────┼───────────────┼──────────
   ITERATION 3 (Level 3):                           │               │
   Takes everyone from Level 2,                     ▼               ▼
   and finds ALL their reports:               [8: Mkt Spec]   [7: Associate]
   ─────────────────────────────────────────────────┼───────────────┼──────────
   ITERATION 4:
   Looks for reports under [8] and [7] ──► Nobody found ──► STOP!




   ============================================================================
   ITERATION-BY-ITERATION ENGINE LIFECYCLE
   ============================================================================

   ──► [ITERATION 0: ANCHOR SEEDING]
       1. Execution:
          - SQL Server runs the Anchor query:
            `SELECT ... FROM CompanyOrg WHERE EmployeeID = 1`
       2. Row Materialization:
          - Produces: [ID 1: CEO | Level 0 | 'CEO']
       3. Distribution:
          - Sent to Result Accumulator (locked into final output).
          - Loaded into Current Working Set as the input for Iteration 1.


   ──► [ITERATION 1: EVALUATION & STATE SWAP]
       1. Processing:
          - The recursive query runs:
            `FROM CurrentWorkingSet Managers INNER JOIN CompanyOrg Employees`
            `ON Employees.ManagerID = Managers.EmployeeID`
          - `Managers.EmployeeID` contains only [1].
       2. Generation:
          - The join finds 3 child records in `CompanyOrg`:
            * ID 9 (VP IT)
            * ID 3 (VP of Marketing)
            * ID 2 (VP of Sales)
          - Computes Level: 0 + 1 = 1
          - Builds Hierarchy strings: 'CEO -> [Name]'
       3. State Swap (Buffer Handoff):
          - Those 3 rows are copied to the Result Accumulator.
          - The previous Working Set ([ID 1]) is WIPED/PURGED from working memory.
          - Current Working Set is replaced entirely with: [ID 9, ID 3, ID 2].


   ──► [ITERATION 2: EVALUATION & STATE SWAP]
       1. Processing:
          - The join runs again using the new Current Working Set:
            `Employees.ManagerID IN (9, 3, 2)`
       2. Generation:
          - ID 9 has no matching rows.
          - ID 3 matches ID 6 (Marketing Manager).
          - ID 2 matches ID 4 (Sales Manager) and ID 5 (Sales Rep).
          - Computes Level: 1 + 1 = 2
       3. State Swap (Buffer Handoff):
          - The 3 newly generated rows are sent to the Result Accumulator.
          - Working Set [ID 9, ID 3, ID 2] is PURGED.
          - Current Working Set is now loaded with: [ID 6, ID 4, ID 5].


   ──► [ITERATION 3: EVALUATION & STATE SWAP]
       1. Processing:
          - Join evaluates: `Employees.ManagerID IN (6, 4, 5)`.
       2. Generation:
          - ID 6 matches ID 8 (Marketing Specialist).
          - ID 4 matches ID 7 (Sales Associate).
          - ID 5 has no matching rows.
          - Computes Level: 2 + 1 = 3
       3. State Swap (Buffer Handoff):
          - Both rows sent to Result Accumulator.
          - Working Set [ID 6, ID 4, ID 5] is PURGED.
          - Current Working Set is now loaded with: [ID 8, ID 7].


   ──► [ITERATION 4: TERMINATION CHECK]
       1. Processing:
          - Join evaluates: `Employees.ManagerID IN (8, 7)`.
       2. Generation:
          - Neither employee manages anyone. The query yields 0 rows (Empty Set).
       3. Shutdown:
          - Current Working Set is EMPTY.
          - Because zero new rows were produced, the recursion loop breaks.
          - The engine releases the working memory spool and returns the full 
            Result Accumulator to the outer `ORDER BY Hierarchy` operator.
   ============================================================================ */