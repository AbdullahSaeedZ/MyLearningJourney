/*
    Problem:
    A Window Function may need an order to perform its calculation,
    while the final query may separately need an order for displaying rows.

    There are TWO different ORDER BY clauses:

    1. ORDER BY inside OVER()
       -> defines the order used BY THE WINDOW FUNCTION.

    2. ORDER BY at the end of SELECT
       -> defines the order of the FINAL RESULT SET.

    They can be the same, but they serve different purposes.

    Rule of thumb:

    OVER (ORDER BY ...)  = "How should the function process/compare rows?"
    ORDER BY ...         = "How should SQL display the result?"
*/

use C21_DB1;

select StudentID, Name,
    lag(Grade, 1) over (order by Grade desc) as PreviousGrade,
    Grade,
    lead(Grade, 1) over (order by Grade desc) as NextGrade
from Students
order by Grade desc;


/*
    Think of it as:

    Students
       |
       |-- OVER (ORDER BY Grade DESC)
       |       -> establishes the window's order
       |       -> LAG / LEAD use this order
       |
       `-- ORDER BY Grade DESC
               -> sorts the final displayed rows


    IMPORTANT:
    Not every Window Function needs ORDER BY inside OVER().

    Aggregate Window Functions can work without it:

        SUM(Grade)   OVER (PARTITION BY ...)
        AVG(Grade)   OVER (PARTITION BY ...)
        COUNT(*)     OVER (PARTITION BY ...)

    ORDER BY is required when the calculation depends on row position,
    such as:

        LAG / LEAD
        ROW_NUMBER
        RANK / DENSE_RANK
        FIRST_VALUE / LAST_VALUE
*/