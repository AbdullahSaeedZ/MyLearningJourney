#pragma once

#include <iostream>
#include "clsScreen.h"
#include "clsBankClient.h"
#include "clsInputValidate.h"
using namespace std;


//this is considered UI Code, all back-end is from clsBankClient, thus we need to move the print function from the object to the class that handles UI code here.


class clsAddNewClientScreen : protected clsScreen
{

private:

    static void _ReadClientInfo(clsBankClient& Client)
    {
        Client.FirstName = clsInputValidate::ReadString("\nEnter First Name: ");
        Client.LastName = clsInputValidate::ReadString("\nEnter Last Name: ");
        Client.Email = clsInputValidate::ReadString("\nEnter Email: ");
        Client.PhoneNumber = clsInputValidate::ReadString("\nEnter Phone Number: ");
        Client.PinCode = clsInputValidate::ReadString("\nEnter Pin Code: ");
        Client.AcctBalance = clsInputValidate::ReadFloatNumber("\nEnter Balance:");
    }

    static void _PrintClientInfo(clsBankClient& Client)
    {
        cout << "\nClient Card:" << endl;
        cout << "____________________________________" << endl;
        cout << "Acct. Number: " << Client.getAcctNumber() << endl;
        cout << "First Name  : " << Client.FirstName << endl; // using property declaration
        cout << "Last Name   : " << Client.LastName << endl;
        cout << "Full Name   : " << Client.getFullName() << endl;
        cout << "Email       : " << Client.Email << endl;
        cout << "Phone       : " << Client.PhoneNumber << endl;
        cout << "Balance     : " << Client.AcctBalance << " SAR" << endl;
        cout << "Password    : " << Client.PinCode << endl;
        cout << "____________________________________\n" << endl;
    }



public:

    static void AddNewClientScreen()
    {
        
        clsScreen::_DrawScreenHeader("\t\tAdd New Client Screen");

        string AcctNumber = clsInputValidate::ReadString("Enter Account Number: ");
        while (clsBankClient::IsClientExist(AcctNumber))
        {
            AcctNumber = clsInputValidate::ReadString("Account Already Exists, Enter Another Account Number: ");
        }

        clsBankClient ClientToAdd = clsBankClient::GetAddNewClientObject(AcctNumber);
        _ReadClientInfo(ClientToAdd);

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
            _PrintClientInfo(ClientToAdd);
        }
        }

    }



};

