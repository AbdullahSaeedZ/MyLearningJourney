#include <iostream>
#include "clsBankClient.h"
#include "clsInputValidate.h"
using namespace std;


// this is considered UI code, these functions will communicate with back end functions (inside classes).


void ReadClientInfo(clsBankClient& Client)
{
    Client.FirstName = clsInputValidate::ReadString("\nEnter First Name: ");
    Client.LastName = clsInputValidate::ReadString("\nEnter Last Name: ");
    Client.Email = clsInputValidate::ReadString("\nEnter Email: ");
    Client.PhoneNumber = clsInputValidate::ReadString("\nEnter Phone Number: ");
    Client.PinCode = clsInputValidate::ReadString("\nEnter Pin Code: ");
    Client.AcctBalance = clsInputValidate::ReadFloatNumber("\nEnter Balance:");
}


void UpdateClient()
{
    
    string AccountNumber = "";
    AccountNumber = clsInputValidate::ReadString("\nEnter Client Account Number:");

    clsBankClient ClientToUpdate;

    while (!clsBankClient::IsClientExist(ClientToUpdate, AccountNumber))
    {
        AccountNumber = clsInputValidate::ReadString("\nNo Account Found, Enter Account Number:");
    }

    ClientToUpdate.Print();

    cout << "\n\nUpdate Client Info:" << endl;
    cout << "_________________________" << endl;
    ReadClientInfo(ClientToUpdate);


    clsBankClient::enSaveResults SaveResult;

    // save functions will apply changes and return the result in enums. then we deal with the enum as we want in the UI, if succedded or if failed due to empty object.
    // even though we made sure the object is not empty in the while loop above, but we do it as defensive programming and to saperate UI from Backend.
    SaveResult = ClientToUpdate.Save();

    switch (SaveResult)
    {
    case clsBankClient::enSaveResults::eSuccedded: 
    {
        cout << "\nAccount Updated successfully!" << endl;
        ClientToUpdate.Print();
        break;
    }
    case clsBankClient::enSaveResults::eFailedEmptyObject:
    {
        cout << "\nError, Account was not Updated because it is empty!" << endl;
        break;
    }
    }


}

int main()
{
    
    
    UpdateClient();
    
    
    
    return 0;
}

