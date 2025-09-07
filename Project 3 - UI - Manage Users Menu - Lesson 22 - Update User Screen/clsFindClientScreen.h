#pragma once

#include <iostream>
#include "clsScreen.h"
#include "clsBankClient.h"
#include "clsInputValidate.h"
using namespace std;

class clsFindClientScreen : protected clsScreen
{

public:


    static  void FindClientScreen()
    {
        clsScreen::_DrawScreenHeader("\t\tFind Client Screen");

        clsBankClient ClientToFind;
        string AcctNumber = clsInputValidate::ReadString("Enter Account Number:");

        while (!clsBankClient::IsClientExist(ClientToFind, AcctNumber))
        {
            AcctNumber = clsInputValidate::ReadString("Account Number Does not Exist, Enter Account Number:");
        }

        clsScreen::_PrintClientInfo(ClientToFind);
    }

};

