
/*
1. SESSIONS & USERS:
   - A session (SPID) is a single, distinct database connection.
   - It is tied to one connection at a time, not shared among multiple users.

2. LOCAL TEMP TABLE (#Table):
   - Scope: Private strictly to the exact connection (SPID) that created it.
   - Other Connections: Completely invisible, even to the same user 
     opening a second query tab or connection.

   - Lifecycle: Dropped when the creating session terminates or dropped manually
3. GLOBAL TEMP TABLE (##Table):
   - Scope: Public across the entire SQL Server instance.
   - Other Connections: Visible, readable, and modifiable by any user 
     or login connected from any session.

	 Lifecycle: 
   * Manual: Dropped anytime via DROP TABLE ##Table;
   * Automatic: Dropped only after the creating session ends AND 
     all active queries referencing it finish
*/


use C21_DB1;


-- Single #: Local temp table, accessible only by the current connection/session (SPID) that created it.
-- Double ##: Global temp table, accessible by all users across all active connections on the instance.
create table #EmployeesTemp
(
	EmployeeID int primary key identity,
	Name varchar(50),
	Department varchar(50)
);


insert into #EmployeesTemp (Name, Department) values ('Abdullah', 'IT');
insert into #EmployeesTemp (Name, Department) values ('Nasser', 'IT');


select * from #EmployeesTemp; -- test the auto dropping when session ends, closing the query tab session which created the table

-- is it a best practice to drop the table when done, it will be dropped once session ends anyway
drop table #EmployeesTemp;