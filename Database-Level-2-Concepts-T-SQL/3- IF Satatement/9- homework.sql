-- homework:

/*
====================================================================
 T-SQL Script Requirements: Driver License Evaluation
====================================================================

1. Existence Check (IF EXISTS):
   - Declare an integer variable @PersonID and assign a test value.
   - Check if the person exists in the People table.
   - If NOT found:
     * Print: "The person does not exist in the system."
     * Terminate execution (RETURN).

2. Retrieve Profile & Check Driver Status:
   - If the person exists:
     * Fetch the full name into @FullName.
     * Check if the person exists in the Drivers table.

3. Scenario A: Person IS a Driver:
   - Check if they have at least one active license in Licenses (IsActive = 1).
   
   - If an active license exists:
     * Calculate the sum of PaidFees from Applications into @TotalFees.
     * IF @TotalFees > 500:
       - Print: "Driver [@FullName] is a VIP client; license is active with total payments: [@TotalFees]."
     * ELSE:
       - Print: "Driver [@FullName] has an active license with standard payments: [@TotalFees]."
       
   - If NO active license exists:
     * Print: "Hey [@FullName], all your licenses are expired or revoked; visit the traffic department immediately."

4. Scenario B: Person is NOT a Driver:
   - Check the Applications table for any ongoing application (ApplicationStatus = 1 / New).
   - If an ongoing application exists:
     * Print: "Hey [@FullName], finish your exams to become a licensed driver."
   - If no ongoing application exists:
     * Print: "Hey [@FullName], apply for a license and avoid driving illegally."
====================================================================
*/


use DVLD;

declare @PersonID int = 9;
declare @FullName varchar(50);
declare @TotalPaidFees decimal(10, 2);

if not exists (select * from People where PersonID = @PersonID)
    begin
        print 'Person with id: ' + cast(@PersonID as varchar) + ' was not found';
        return;
    end
else
    begin

        select @FullName = concat(FirstName,' ', SecondName, ' ', isnull(ThirdName + ' ', '') + LastName) from People where PersonID = @PersonID;

        -- if a diver
        if Exists (select * from Drivers where PersonID = @PersonID)
            begin
                
                -- if has an active license
                if Exists (select A=1 from Licenses inner join Drivers on Licenses.DriverID = Drivers.DriverID
                            where Drivers.PersonID = @PersonID and Licenses.IsActive = 1)
                    begin
                        -- calculatin total paid fees from all applications
                        select @TotalPaidFees = sum(PaidFees) from Applications where ApplicantPersonID = @PersonID;
                        if @TotalPaidFees > 500
                            print 'Driver: ' + @FullName + ' is a vip client; license is active with total payments:' + cast(@TotalPaidFees as varchar);
                        else
                            print 'Driver: ' + @FullName + ' has an active license with standard payments: ' + cast(@TotalPaidFees as varchar);
                    end
                else
                    print 'Hey '  + @FullName + ', all your licenses are expired or revoked; visit the traffic department immediately';
            end
        else
            begin
            -- when not a driver, check for open applications:
                if exists (select a=1 from Applications where ApplicantPersonID = @PersonID and ApplicationStatus = 1)
                    print 'Hey '  + @FullName + ', finish your exams to become a licensed driver';
                else
                    print 'Hey '  + @FullName + ', apply for a license and avoid driving illegally';
            end
    end