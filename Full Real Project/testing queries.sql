
-- local drivving licenses applications view query that is used in the data grid view

select LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LicenseClasses.ClassName, People.NationalNo, 
People.FirstName +' '+ People.SecondName+' '+ISNULL(People.ThirdName + ' ', '')+ People.LastName AS FullName,
Applications.ApplicationDate,Status = 
case 
	when Applications.ApplicationStatus = 1 then 'New'
	when Applications.ApplicationStatus = 2 then 'Cancelled'
	when Applications.ApplicationStatus = 3 then 'Completed'
end , count(Tests.TestID) AS PassedTests
from LocalDrivingLicenseApplications
inner join LicenseClasses on LicenseClasses.LicenseClassID = LocalDrivingLicenseApplications.LicenseClassID
inner join Applications on Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID
inner join People on People.PersonID= Applications.ApplicantPersonID 
left join TestAppointments on TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
left join Tests on Tests.TestAppointmentID = TestAppointments.TestAppointmentID and Tests.TestResult = 1 
group by LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, LicenseClasses.ClassName, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName,
Applications.ApplicationDate,Applications.ApplicationStatus;


-- this is the Passed tests parts before adding to the main query above, in case i need to remember how i got it , run it step by step with the tables open on the other screen
select LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID, PassedTests = count(Tests.TestID)
from LocalDrivingLicenseApplications
left join TestAppointments on TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID
left join Tests on Tests.TestAppointmentID = TestAppointments.TestAppointmentID and Tests.TestResult = 1
group by  LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID



