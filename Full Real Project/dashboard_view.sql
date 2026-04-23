create view Dashboard_View as
select 
(select count(TestID) from Tests) as TotalTests, (select count(TestID) from Tests where TestResult = 1) as TotalPassedTests,
(select count(ApplicationID) from Applications) as TotalApplications, (select count(ApplicationID) from Applications where ApplicationStatus = 3) as TotalApplicationsCompleted,
(select count(DriverID) from Drivers) as TotalDrivers, (select count(PersonID) from People) as TotalPeople, (select count(UserID) from Users) as TotalUsers,
(select count(LicenseID) from Licenses) as TotalLicenses, 

(select  (select (ISNULL(result1.total, 0) + ISNULL(result2.total, 0) + ISNULL(result3.total, 0) + ISNULL(result4.total, 0)) as PaidFees from
(select sum(PaidFees) as total from Applications where MONTH(ApplicationDate) = MONTH(GETDATE()) and YEAR(ApplicationDate) = YEAR(GETDATE())) as result1,
(select sum(PaidFees) as total from TestAppointments where MONTH(AppointmentDate) = MONTH(GETDATE()) and YEAR(AppointmentDate) = YEAR(GETDATE())) as result2,
(select sum(FineFees) as total from DetainedLicenses where IsReleased = 1 and MONTH(ReleaseDate) = MONTH(GETDATE()) and YEAR(ReleaseDate) = YEAR(GETDATE())) as result3,
(select sum(PaidFees) as total from Licenses where MONTH(IssueDate) = MONTH(GETDATE()) and YEAR(IssueDate) = YEAR(GETDATE())) as result4))
as TotalPaidFeesThisMonth, 

(select (ISNULL(result1.total, 0) + ISNULL(result2.total, 0) + ISNULL(result3.total, 0) + ISNULL(result4.total, 0)) as PaidFees from
(select sum(PaidFees) as total from Applications ) as result1,
(select sum(PaidFees) as total from TestAppointments ) as result2,
(select sum(FineFees) as total from DetainedLicenses  where IsReleased = 1 ) as result3,
(select sum(PaidFees) as total from Licenses ) as result4)
as TotalPaidFeesAllTime;


