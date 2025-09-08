#pragma once

#include <iostream>
#include "clsScreen.h"
#include "clsInputValidate.h"
#include "clsMainScreen.h"
#include "clsUser.h"
#include "Global.h"
using namespace std;

class clsLoginScreen : protected clsScreen
{

private:

	static void _Login()
	{
		string UserName, Password;

		while (true)
		{
			UserName = clsInputValidate::ReadString("\nEnter Username:");
			Password = clsInputValidate::ReadString("Enter Password:");

			if (!clsUser::IsUserExist(CurrentUser, UserName, Password))
				cout << "\nInvalid Username/Password !!" << endl;
			else
				break;
		}

		clsMainScreen::ShowMainMenuScreen();
	}


public: 


	static void ShowLoginScreen()
	{
		system("cls");
		_DrawScreenHeader("Login Screen");
		_Login();
	}


};

