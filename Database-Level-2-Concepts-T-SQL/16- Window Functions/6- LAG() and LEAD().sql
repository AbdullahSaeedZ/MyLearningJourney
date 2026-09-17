/*
    Problem:
    Sometimes we need to compare each row with the row before or after it.
    Regular SELECT queries do not provide an easy way to access neighboring rows.

    LAG()  -> gets a value from a previous row.
    LEAD() -> gets a value from a following row.

    Syntax:
    LAG(column, offset, default)  OVER (ORDER BY ...)
    LEAD(column, offset, default) OVER (ORDER BY ...)

    offset  -> how many rows backward/forward. Default = 1.
    default -> value returned when no previous/next row exists. Default = NULL.

    Important:
    ORDER BY inside OVER() defines what "previous" and "next" mean.
*/

use C21_DB1;

select StudentID, Name,
    lag(Grade, 1) over (order by Grade desc) as PreviousGrade,
    Grade,
    lead(Grade, 1) over (order by Grade desc) as NextGrade
from Students
order by Grade desc;


/*
    If the ordered rows are:

    Grade:       95   90   85   80
                  ↓    ↓    ↓    ↓
    LAG:        NULL   95   90   85
    LEAD:         90   85   80  NULL

    LAG  looks backward.
    LEAD looks forward.
*/