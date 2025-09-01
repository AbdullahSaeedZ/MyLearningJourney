#include <iostream>
#include "clsBankClient.h"
#include "clsInputValidate.h"
using namespace std;

void ReadClientInfo(clsBankClient& Client)
{
    Client.FirstName = clsInputValidate::ReadString("\nEnter First Name: ");
    Client.LastName = clsInputValidate::ReadString("\nEnter Last Name: ");
    Client.Email = clsInputValidate::ReadString("\nEnter Email: ");
    Client.PhoneNumber = clsInputValidate::ReadString("\nEnter Phone Number: ");
    Client.PinCode = clsInputValidate::ReadString("\nEnter Pin Code: ");
    Client.AcctBalance = clsInputValidate::ReadFloatNumber("\nEnter Balance:");
}


void AddNewClient()
{
    string AcctNumber = clsInputValidate::ReadString("Enter Account Number: ");
    
    while (clsBankClient::IsClientExist(AcctNumber))
    {
        AcctNumber = clsInputValidate::ReadString("Account Already Exists, Enter Another Account Number: ");
    }

    clsBankClient ClientToAdd = clsBankClient::GetAddNewClientObject(AcctNumber);
    ReadClientInfo(ClientToAdd);

    clsBankClient::enSaveResults SaveResult = ClientToAdd.Save();

    switch (SaveResult)
    {
    case clsBankClient::enSaveResults::eFailedEmptyObject:
    {
        cout << "Error, Object is Empty! " << endl;
    }
    case clsBankClient::enSaveResults::eFiledAcctNumerExist:
    {
        cout << "Error, Account Number Already Exist!" << endl;
    }
    case clsBankClient::enSaveResults::eSuccedded:
    {
        cout << "Client Added Successfully!" << endl;
        ClientToAdd.Print();
    }
    }

}

int main()
{
    
    AddNewClient();
    
    
    return 0;
}

