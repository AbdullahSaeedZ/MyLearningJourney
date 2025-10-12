#pragma once
#include <iostream>
#include "clsBankClient.h"
#include "clsInputValidate.h"
using namespace std;


class clsScreen
{

protected:

    static void _ReadClientInfo(clsBankClient& Client)
    {
        Client.FirstName = clsInputValidate::ReadString("\nEnter First Name: ");
        Client.LastName = clsInputValidate::ReadString("\nEnter Last Name: ");
        Client.Email = clsInputValidate::ReadString("\nEnter Email: ");
        Client.PhoneNumber = clsInputValidate::ReadString("\nEnter Phone Number: ");
        Client.PinCode = clsInputValidate::ReadString("\nEnter Pin Code: ");
        Client.AcctBalance = clsInputValidate::ReadFloatNumber("\nEnter Balance:");
    }


    // below are common function in more than one derived screen classes like update - delete - add client, so i put it here for fast use and in case of any change later will be done once here.

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

    static void _DrawScreenHeader(string Title, string SubTitle = "")
    {
        cout << "___________________________________________" << endl;
        cout << Title << endl;
        if (SubTitle != "")
        {
            cout << SubTitle << endl;
        }
        cout <<"___________________________________________\n\n";
    }

  

};

