
select
    Vision  = max(case when TestAppointments.TestTypeID = 1 and Tests.TestResult = 1 then 1 else 0 end),
    Written = max(case when TestAppointments.TestTypeID = 2 and Tests.TestResult = 1 then 1 else 0 end),
    Street  = max(case when TestAppointments.TestTypeID = 3 and Tests.TestResult = 1 then 1 else 0 end)
from TestAppointments
inner join Tests on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
where TestAppointments.LocalDrivingLicenseApplicationID = 36;

-- used max to check if at least there is one passed test of a specific type,
-- example for vision it might be 2 tests passed, so max will do max(1,0,1) then return 1 which is max of those 3 tests,
-- even though business logic prevents multiple passed tests for the same test type and same application, but errors can happen
-- and this query is better than the one i wrote before :)


 
select LocalDrivingLicenseApplications.*, Vision  = max(case when TestAppointments.TestTypeID = 1 and Tests.TestResult = 1 then 1 else 0 end),
									      Written = max(case when TestAppointments.TestTypeID = 2 and Tests.TestResult = 1 then 1 else 0 end),
									      Street  = max(case when TestAppointments.TestTypeID = 3 and Tests.TestResult = 1 then 1 else 0 end)
from LocalDrivingLicenseApplications
left join TestAppointments on TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
left join Tests on Tests.TestAppointmentID = TestAppointments.TestAppointmentID
where LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = 36
group by LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LocalDrivingLicenseApplications.ApplicationID,LocalDrivingLicenseApplications.LicenseClassID

    -- أضف باقي أعمدة lda هنا إذا موجودة
