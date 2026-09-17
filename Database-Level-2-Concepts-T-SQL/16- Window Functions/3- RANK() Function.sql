/*
====================================================================
LESSON: RANK() Function in T-SQL
====================================================================

1. THE PROBLEM (Why it exists)
--------------------------------------------------------------------
In our previous lesson, ROW_NUMBER() assigned strict, unique numbers 
(1, 2, 3, 4...) to every row. 

However, in competitions, grading, and sales leaderboards, ties happen. 
If two students both score 88, giving one student rank #3 and the other 
rank #4 arbitrarily is unfair. We need a ranking mechanism that acknowledges 
identical scores with equal ranks.


2. CORE IDEA & BEHAVIOR
--------------------------------------------------------------------
`RANK()` assigns the exact same rank to identical values (ties).

* THE "GAPPED" BEHAVIOR:
  When ties occur, RANK() skips subsequent rank numbers to account for 
  how many rows shared that rank.
  - Notice your result: Dave (88) and Isabella (88) BOTH get Rank 3.
  - The next student, Bob (85), gets Rank 5.
  - *** RANK 4 IS MISSING! ***

* PREVIEW / SOLUTION IN NEXT LESSON:
  If your business rules require continuous numbering without gaps 
  (1, 2, 3, 3, 4 instead of 1, 2, 3, 3, 5), SQL Server provides 
  `DENSE_RANK()`. We will cover `DENSE_RANK()` in the next lesson.


3. WHY USE RANK() IF IT SKIPS NUMBERS? (Why it's not "incomplete")
--------------------------------------------------------------------
Skipping numbers is not a bug; it is the official standard definition 
of sports, academic, and Olympic ranking:

1. Accurate Headcount / Position Representation:
   Bob is the 5th best student in the school, NOT the 4th. Four people 
   scored higher than or equal to him (Emma, Alice, Dave, Isabella). Calling 
   Bob #4 misrepresents his actual competitive position among the 9 students.

2. Percentiles and Quotas:
   If a scholarship or bonus is awarded strictly to the "Top 3 Students":
   - Rank 1: Emma
   - Rank 2: Alice
   - Rank 3: Dave & Isabella
   That already fills 4 spots! If Bob were called #4, an automated process 
   looking for top-tier cutoff boundaries would be distorted.


4. T-SQL DEMO
--------------------------------------------------------------------
*/

USE C21_DB1;

-- Generates tied ranks with gaps:
SELECT 
    StudentID,
    Name,
    Subject,
    Grade,
    RANK() OVER (ORDER BY Grade DESC) AS [Rank]
FROM Students
ORDER BY Grade DESC;

/*
Result Breakdown:
StudentID | Name     | Grade | Rank | Reason
----------+----------+-------+------+-----------------------------------
5         | Emma     | 92    | 1    | Top score
1         | Alice    | 90    | 2    | Second
4         | Dave     | 88    | 3    | Tied for 3rd
9         | Isabella | 88    | 3    | Tied for 3rd (takes up the 4th spot)
2         | Bob      | 85    | 5    | 5th student overall (Rank 4 skipped)
*/