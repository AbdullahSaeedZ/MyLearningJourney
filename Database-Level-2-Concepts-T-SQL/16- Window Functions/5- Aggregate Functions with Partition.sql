/*
LESSON: Aggregate Functions + PARTITION BY (Window Aggregates)

1. THE PROBLEM
--------------------------------------------------------------------
A regular `GROUP BY` collapses your rows into a single summary line per 
group, losing individual student details (StudentID, Name, Grade).


2. CORE IDEA
--------------------------------------------------------------------
Adding `OVER (PARTITION BY ...)` turns a standard aggregate (COUNT, AVG, 
SUM) into a "Window Aggregate". 

It calculates the summary metric for each group, but stamps that result 
onto EVERY individual row without collapsing the dataset.

*/

USE C21_DB1;

SELECT *,
    -- Counts total students enrolled in THIS student's specific subject
    COUNT(*)   OVER (PARTITION BY [Subject]) AS NumberOfStudents,
    -- Computes the mean grade for THIS student's specific subject
    AVG(Grade) OVER (PARTITION BY [Subject]) AS AverageSubjectGrade
FROM Students;

/*
Result Behavior:
Every student keeps their own row, but now has the subject's headcount 
and average right next to their personal grade for instant comparison.


4. RULE OF THUMB
--------------------------------------------------------------------
* Need ONLY summary totals? -> Use `GROUP BY` (collapses rows).
* Need row-level details AND group calculations side-by-side? 
  -> Use `AGGREGATE() OVER (PARTITION BY ...)` (preserves rows).
*/