/*
====================================================================
LESSON: RANK() vs. DENSE_RANK() in T-SQL
====================================================================

1. CORE DIFFERENCE & RULE OF THUMB
--------------------------------------------------------------------
Both functions give identical ranks to tied values. The only difference 
is whether the next rank skips numbers or stays continuous:

* RANK(): Leaves GAPS after ties (1, 1, 3...). 
  Reflects actual competitive standing (Olympics / leaderboard rules).

* DENSE_RANK(): NO GAPS after ties (1, 1, 2...). 
  Keeps numbering compact and sequential (best for "N-th highest" queries).

Visual comparison on grades [95, 95, 90, 85]:
- RANK():       1, 1, 3, 4
- DENSE_RANK(): 1, 1, 2, 3


2. COMPARISON 
--------------------------------------------------------------------
*/

USE C21_DB1;

-- Side-by-side run on your existing table:
SELECT 
    StudentID,
    Name,
    Subject,
    Grade,
    RANK()       OVER (ORDER BY Grade DESC) AS [Rank],
    DENSE_RANK() OVER (ORDER BY Grade DESC) AS [Dense_Rank]
FROM Students
ORDER BY Grade DESC;


---- using PARTITION BY with rank functions, to partition or divide ranking for each subject partition (PARTITION BY Subject)

select *, DENSE_RANK() over (partition by [Subject] order by [Grade] desc) as DenseRank
from Students order by Subject asc;



-- getting ranked 1 of each subject:
select * from 
(

select *, DENSE_RANK() over (partition by [Subject] order by [Grade] desc) as DenseRank
from Students 

) as TopStudents 
where TopStudents.DenseRank = 1 order by Grade;

