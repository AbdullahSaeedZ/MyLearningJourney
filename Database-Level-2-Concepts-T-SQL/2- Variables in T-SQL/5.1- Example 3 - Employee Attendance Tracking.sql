--select * from EmployeeAttendance;

-- number of days present, absent and on leave for a particular employee
declare @ReportMonth int;
declare @ReportYear int;
declare @TotalDays int;
declare @EmployeeID int;
declare @PresentDays int;
declare @AbsentDays int;
declare @LeaveDays int;

set @ReportMonth = 7;
set @ReportYear = 2023;
set @EmployeeID = 101;

--calculate total days in the month
select @TotalDays = day(EOMONTH(DateFromParts(@ReportYear, @ReportMonth, 1)));

-- calculate present, absent and leave dayes:
select @PresentDays = count(*)
from EmployeeAttendance 
where EmployeeID = @EmployeeID and Status = 'Present' and year(AttendanceDate) = @ReportYear and month(AttendanceDate) = @ReportMonth;

select @AbsentDays = count(*)
from EmployeeAttendance
where EmployeeID = @EmployeeID and Status = 'Absent' and year(AttendanceDate) = @ReportYear and month(AttendanceDate) = @ReportMonth;

select @LeaveDays = count(*)
from EmployeeAttendance
where EmployeeID = @EmployeeID and Status = 'Leave' and year(AttendanceDate) = @ReportYear and month(AttendanceDate) = @ReportMonth;

-- print the report:
print 'Report of Employee (ID ' + cast(@EmployeeID as varchar) + ') of year: ' + cast(@ReportYear as varchar) + ', month: ' + cast(@ReportMonth as varchar); 
print 'Total Days of the month: ' + cast(@TotalDays as varchar);
print 'Total Days Present: ' + cast(@PresentDays as varchar);
print 'Total Days Absent: ' + cast(@AbsentDays as varchar);
print 'Total Days on leave: ' + cast(@LeaveDays as varchar);