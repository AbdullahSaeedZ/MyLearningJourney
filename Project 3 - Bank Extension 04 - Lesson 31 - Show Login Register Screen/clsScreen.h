#pragma once
#include <iostream>
#include <iomanip>
#include "clsBankClient.h"
#include "clsUser.h"
#include "clsInputValidate.h"
#include "clsDate.h"
#include "Global.h"
using namespace std;


class clsScreen
{
protected:


    static void _DrawScreenHeader(string Title, string SubTitle = "")
    {
        cout << "________________________________________________________________________________________________" << endl;
        cout << "           User: " + CurrentUser.UserName << right << setw(60) <<  Title << endl;
        cout << "           Date: " << clsDate::Print(clsDate());
        cout << setw(55) << ((SubTitle != "") ? SubTitle : "");
        cout << "\n________________________________________________________________________________________________\n\n";
    }

    static bool HasPermission(short UserPermissions, clsUser::enPermission RequiredPermission)
    {
        if ((UserPermissions == clsUser::enPermission::pAll) || (UserPermissions & RequiredPermission))
            return true;
        else
        {
            _DrawScreenHeader("\t Access Denied, Contact Your Admin!");
            return false;
        }
        
    }



    // below are common function in more than one derived screen classes like update - delete - add client, so i put it here for fast use and in case of any change later will be done once here.

    static void _ReadUserInfo(clsUser& User)
    {
        User.FirstName = clsInputValidate::ReadString("\nEnter FirstName : ");
        User.LastName = clsInputValidate::ReadString("\nEnter LastName: ");
        User.Email = clsInputValidate::ReadString("\nEnter Email: ");
        User.PhoneNumber = clsInputValidate::ReadString("\nEnter Phone: ");
        User.Password = clsInputValidate::ReadString("\nEnter Password: ");

    }

    static void _PrintUser(clsUser& User)
    {
        cout << "\nUser Card:";
        cout << "\n___________________";
        cout << "\nFirstName   : " << User.FirstName;
        cout << "\nLastName    : " << User.LastName;
        cout << "\nFull Name   : " << User.getFullName();
        cout << "\nEmail       : " << User.Email;
        cout << "\nPhone       : " << User.PhoneNumber;
        cout << "\nUser Name   : " << User.UserName;
        cout << "\nPassword    : " << User.Password;
        cout << "\nPermissions : " << User.Permission;
        cout << "\n___________________\n";

    }

    static void _ReadClientInfo(clsBankClient& Client)
    {
        Client.FirstName = clsInputValidate::ReadString("\nEnter First Name: ");
        Client.LastName = clsInputValidate::ReadString("\nEnter Last Name: ");
        Client.Email = clsInputValidate::ReadString("\nEnter Email: ");
        Client.PhoneNumber = clsInputValidate::ReadString("\nEnter Phone Number: ");
        Client.PinCode = clsInputValidate::ReadString("\nEnter Pin Code: ");
        Client.AcctBalance = clsInputValidate::ReadFloatNumber("\nEnter Balance:");
    }

    static void _PrintClientInfo(clsBankClient &Client)
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

  

};

