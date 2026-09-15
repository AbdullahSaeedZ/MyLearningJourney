/*
===============================================================================
SCENARIO:
You run an online store.
You have a "Sales" table with 10 million rows.
At midnight, your job needs to do two tasks for today's orders:
  1. Give bonus points to customers who bought items today.
  2. Send a warning list of customers who spent over $5,000 today.

WHY NOT DO IT DIRECTLY (Without Temp Table)?
If you use simple subqueries or joins directly on "Sales":
- SQL Server reads all 10 million rows to update the points.
- Then, it reads all 10 million rows AGAIN to find the high spenders.
- Reading a huge table two times wastes CPU, disk, and locks the table.

THE FIX (WHEN TO USE #TEMP):
- Read the huge "Sales" table ONCE.
- Filter only today's rows into a small temporary table (say, 5,000 rows).
- Use this tiny table for Task 1, then use it again for Task 2.
- Fast, low memory, no repeated heavy work.
===============================================================================
*/

-- PHASE 1: ENTERING & CLEARING THE "DANGER ZONE"
-- Goal: Query the 10,000,000-row production table ONCE, extract today's summary,
--       and exit immediately to release shared locks and free up disk I/O.

-- Step 1: Create a lightweight staging table in tempdb
-- Adding a PRIMARY KEY gives us an automatic clustered index for fast downstream joins.
create table #DailyCustomerTotals (
    CustomerID int primary key,
    TotalToday decimal(10, 2)
);

-- Step 2: [THE DANGER ZONE] Read the 10M-row table ONCE
-- We scan 'Sales' to aggregate orders for today only.
-- Once this finishes, our exposure to the massive production table is 100% done.
insert into #DailyCustomerTotals (CustomerID, TotalToday)
select CustomerID, sum(Amount)
from Sales
where OrderDate >= cast(getdate() as date)
group by CustomerID;


-- PHASE 2: SAFE EXECUTION & TASK PROCESSING
-- Status: 'Sales' is now completely untouched and safe from lock contention.
-- We use our tiny staging table (~5,000 rows) to perform all required tasks.

-- Step 3: Task 1 - Update permanent customer points
-- Fast indexed join: Matches tiny #DailyCustomerTotals against Customers by CustomerID.
-- Eliminates the need to re-scan Sales to calculate point increments.
update c
set c.RewardPoints = c.RewardPoints + cast(t.TotalToday / 10 as int)
from Customers c
inner join #DailyCustomerTotals t on c.CustomerID = t.CustomerID;

-- Step 4: Task 2 - Identify and flag high spenders
-- Reuses the pre-calculated numbers from the temp table.
-- Customers table is only accessed to fetch contact details (Name, Email).
select c.CustomerName, c.Email, t.TotalToday
from Customers c
inner join #DailyCustomerTotals t on c.CustomerID = t.CustomerID
where t.TotalToday >= 5000;


-- CLEANUP
-- Step 5: Deallocate the temporary table and release tempdb resources
drop table #DailyCustomerTotals;

/*
===============================================================================
WHY NOT A TABLE VARIABLE (@DailyTotals) HERE?
===============================================================================

1. THE "BLIND GUESS" PROBLEM (CARDINALITY ESTIMATION):
- A temp table (#) builds full STATISTICS (histograms). SQL Server knows 
  exactly how many rows are inside and what data looks like.
- A table variable (@) has NO statistics. Historically, SQL Server always 
  blindly guesses it has exactly 1 row (or a fixed low guess).

2. WHAT HAPPENS IN OUR SCENARIO:
- In our scenario, today's sales could have 5,000 or 50,000 customers.
- When SQL Server joins @DailyTotals to Customers, it thinks:
    "Oh, it's just 1 row! I will do a Nested Loop join."
- A Nested Loop join for 50,000 rows performs 50,000 separate index lookups 
  against the Customers table. This murders your CPU and disk.
- With a #Temp table, SQL Server sees 50,000 rows and correctly picks a 
  Hash Join or Merge Join, running in milliseconds.

3. PARALLELISM:
- Queries reading from #Temp tables can use multiple CPU cores (parallelism).
- Modifications to @Table variables run strictly on a single thread.

RULE OF THUMB:
- Use Table Variable (@): Very tiny sets (under 100 rows) or table parameters.
- Use Temp Table (#): Anything larger, aggregated summaries, or heavy joins.
===============================================================================
*/