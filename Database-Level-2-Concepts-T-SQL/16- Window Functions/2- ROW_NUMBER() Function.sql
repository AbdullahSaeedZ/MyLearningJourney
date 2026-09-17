/*
====================================================================
LESSON: ROW_NUMBER() and the OVER() Clause in T-SQL
====================================================================

1. THE PROBLEM (Why it exists)
--------------------------------------------------------------------
Standard aggregates (`GROUP BY`) collapse rows, destroying detail. 
Plain `ORDER BY` sorts the display but gives you no dynamic rank 
or row index in the result set to filter on (e.g., "get the top 1 
student per class" or "paginate rows 11 to 20").


2. CORE IDEA & RULE OF THUMB
--------------------------------------------------------------------
`ROW_NUMBER()` is a window function that assigns a sequential integer 
(1, 2, 3...) to each row.

* RULE OF THUMB FOR `OVER`:
  Think of `OVER` as setting the "window" or scope of vision.
  It answers: "In what order, and across what slice of data, should 
  this calculation look?"

* KEYWORD MENTAL MODEL:
  - OVER (ORDER BY ...)          -> "Number them sequentially sorted by this."
  - OVER (PARTITION BY ... ORDER BY ...) -> "Reset numbering back to 1 for every group."


3. SYNTAX BLUEPRINT
--------------------------------------------------------------------
ROW_NUMBER() OVER (
    [PARTITION BY grouping_column]  -- Optional: resets counter to 1 per group
    ORDER BY sort_column [ASC|DESC] -- Mandatory: decides who gets 1st, 2nd, etc.
)
*/

USE C21_DB1;

-- 1. Plain sorted query: Orders rows visually, but produces no row counter.
SELECT * FROM Students ORDER BY Grade DESC;


-- 2. Adding ROW_NUMBER() with OVER:
-- Generates an explicit 'RowNumber' column calculated by highest grade first.
select *, ROW_NUMBER() over (order by Grade desc) as RowColumn
from Students order by Grade desc;


-- 3. Advanced common usage: Resetting count per group with PARTITION BY
-- Ranks students within their Subject independently (1st in English, 1st in Math, etc.)
select *, ROW_NUMBER() over (partition by [Subject] order by [Grade] desc) as RowColumn
from Students;




--------------------- note on order by clauses ----------------------

/*
    Logical processing order:

    FROM → WHERE → GROUP BY → HAVING
                              ↓
                     Intermediate Result Set
                              ↓
                         SELECT
                    (Window Functions)
                              ↓
                         ORDER BY
                              ↓
                       Final Result


    Window functions operate on the intermediate result set,
    not on the final output after the outer ORDER BY.

    Example:
*/
SELECT Name, Grade, ROW_NUMBER() OVER (ORDER BY Grade DESC) AS RowNumber
FROM Students WHERE Grade >= 60 ORDER BY Name;


/*
    Key rule:

    OVER(...)        → Defines how the window function is calculated.
    ORDER BY outside → Defines how the final rows are displayed.

    Therefore, the two ORDER BY clauses can produce different orders.

    Example result:

    Name    Grade    RowNumber
    --------------------------
    Ali     80       2
    Ahmed   90       1
    Omar    70       3

    RowNumber is based on Grade DESC,
    while the final output is displayed by Name.
*/