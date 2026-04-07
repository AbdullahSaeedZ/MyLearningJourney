create database testDVLD;

create table Countries
(
CountryID int not null identity(1,1),
constraint PK_PersonID primary key(CountryID),
CountryName nvarchar(50) not null
constraint unq_Country unique(CountryName)
);

create table People
(
PersonID int not null identity(1,1),
constraint PK_PeoplePersonID primary key(PersonID),
NationalNo int not null,
constraint unq_NationalNo unique(NationalNo),
FirstName nvarchar(20) not null,
SecondName nvarchar(20) not null,
ThirdName nvarchar(20),
LastName nvarchar(20) not null,
DateOfBirth date not null,
Gender nchar not null,
Address nvarchar(100) not null,
Phone nvarchar(10) not null,
Email nvarchar(100) not null,
CountryID int,
constraint FK_CountryID foreign key(CountryID) references Countries(CountryID),
ImagePath nvarchar(200)
);


create table Users
(
UserID int not null identity(1,1),
constraint PK_UsersUerID primary key(UserID),
PersonID int,
constraint FK_UsersPersonID foreign key(PersonID) references People(PersonID),
UserName nvarchar(20) not null,
constraint unq_UserName unique(UserName),
Password nvarchar(50) not null,
IsActive bit not null,
constraint ch_UsersIsActive check(IsActive = 0 or IsActive = 1)
);




create table ApplicationTypes
(
AppTypeID int not null identity(1,1),
constraint PK_AppTypesID primary key(AppTypeID),
TypeName nvarchar(50) not null,
constraint unq_AppTypeName unique(TypeName),
TypeFees smallmoney not null
);

create table Applications
(
ApplicationID int not null identity(1,1),
constraint PK_ApplicationsAppID primary key(ApplicationID),
PersonID int,
constraint FK_ApplicationsPersonID foreign key(PersonID) references People(PersonID),
AppTypeID int, 
constraint FK_ApplicationsAppTypeID foreign key(AppTypeID) references ApplicationTypes(AppTypeID),
ApplicationDate DateTime not null,
Status tinyint not null, -- check designer description, to be enums in code
LastStatusDate DateTime not null,
CreatedByUserID int not null,
constraint FK_ApplicationsUserID foreign key(CreatedByUserID) references Users(UserID),
);




create table LocalLicenseTypes
(
LicenseTypeID int not null identity(1,1),
constraint PK_LocalLicesneTypesID primary key(LicenseTypeID),
TypeTitle nvarchar(50) not null,
TypeDescription nvarchar(200) not null,
MinAllowedAge tinyint not null,
DefaultValidityLength tinyint not null,
TypeFees smallmoney not null
);

create table LocalDrivingLicenseApplications
(
LocalLicenseAppID int not null identity(1,1),
constraint PK_LocalLicenseAppID primary key(LocalLicenseAppID),
ApplicationID int not null,
constraint FK_LocalLicense_ApplicaitonID foreign key(ApplicationID) references Applications(ApplicationID),
LicenseTypeID int not null,
constraint FK_LocalLicense_LicenseTypeID foreign key(LicenseTypeID) references LocalLicenseTypes(LicenseTypeID)
);



create table TestTypes
(
TestTypeID int not null identity(1,1),
constraint PK_TestTypesID primary key(TestTypeID),
TypeTitle nvarchar(50) not null,
TypeDescription nvarchar(200) not null,
TypeFees smallmoney not null
);

create table TestAppointments
(
TestAppointmentID int not null identity(1,1),
constraint PK_TestAppointmentID primary key(TestAppointmentID),
TestTypeID int not null,
constraint FK_TestAppointments_TestTypeID foreign key(TestTypeID) references TestTypes(TestTypeID),
LocalLicenseAppID int not null,
constraint FK_TestAppointments_LocalLicenseAppID foreign key(LocalLicenseAppID) references LocalDrivingLicenseApplications(LocalLicenseAppID),
AppointmentDate datetime not null,
PaidFees smallmoney not null,
IsLocked bit not null,
RetakeTestApplicationID int null, -- filled once applied for a retake
constraint FK_Licenses_RetakeApplicaitonID foreign key(RetakeTestApplicationID) references Applications(ApplicationID),
CreatedByUserID int not null,
constraint FK_TestAppointmentsUserID foreign key(CreatedByUserID) references Users(UserID)
);



create table Tests
(
TestID int not null identity(1,1),
constraint PK_ConductedTestID primary key(TestID),
TestAppointmentID int not null,
constraint FK_Tests_TestAppointmentID foreign key(TestAppointmentID) references TestAppointments(TestAppointmentID),
TestResult bit not null,
Notes nvarchar(100),
CreatedByUserID int not null,
constraint FK_Tests_UserID foreign key(CreatedByUserID) references Users(UserID)
);



create table Drivers
(
DriverID int not null identity(1,1),
constraint PK_DriversID primary key(DriverID),
CreatedByUserID int not null,
constraint FK_Drivers_UserID foreign key(CreatedByUserID) references Users(UserID),
CreatedDate datetime not null
);

create table Licenses
(
LicenseID int not null identity(1,1),
constraint PK_LicenseID primary key (LicenseID),
ApplicationID int not null,
constraint FK_Licenses_ApplicaitonID foreign key(ApplicationID) references Applications(ApplicationID),
DriverID int not null,
constraint FK_Licenses_DriverID foreign key(DriverID) references Drivers(DriverID),
LicenseTypeID int not null,
constraint FK_Licenses_LicenseTypeID foreign key(LicenseTypeID) references LocalLicenseTypes(LicenseTypeID),
IssueDate datetime not null,
ExpDate datetime not null,
Notes nvarchar(200),
PaidFees smallmoney not null,
IssueReason int not null check(IssueReason in (1,2,3,4,5)), -- reasons in design description, will be enum in business layer
IsActive bit not null,
CreatedByUserID int not null,
constraint FK_Licenses_UserID foreign key(CreatedByUserID) references Users(UserID),
);




create table DetainedLicenses
(
DetainID int not null identity(1,1),
constraint PK_DetainID primary key (DetainID),
LicenseID int not null,
constraint FK_DetainedLicenses_LicenseID foreign key(LicenseID) references Licenses(LicenseID),
DetainDate datetime not null,
DetentionReason nvarchar(200) not null,
CreatedByUserID int not null,
constraint FK_DetainedLicenses_UserID foreign key(CreatedByUserID) references Users(UserID),
IsReleased bit not null,
FinePaid smallmoney null,
ReleaseDate datetime null,
ReleasedByUserID int null,
constraint FK_DetainedLicenses_ReleasedByUserID foreign key(ReleasedByUserID) references Users(UserID),
ReleaseApplicationID int null,
constraint FK_DetainedLicenses_ApplicaitonID foreign key(ReleaseApplicationID) references Applications(ApplicationID),
);

create table InternationalLicenses
(
InterLicenseID int not null identity(1,1),
constraint PK_InterLicenseID primary key (InterLicenseID),
DriverID int not null,
constraint FK_InterLicense_DriverID foreign key(DriverID) references Drivers(DriverID),
IssuedUsingLicenseID int not null,
constraint FK_InterLicense_LicenseID foreign key(IssuedUsingLicenseID) references Licenses(LicenseID),
IssueDate datetime not null,
ExpDate datetime not null,
IsActive bit not null,
CreatedByUserID int not null,
constraint FK_InterLicense_UserID foreign key(CreatedByUserID) references Users(UserID),
);