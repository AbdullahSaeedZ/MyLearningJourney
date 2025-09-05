#pragma once


#include <iostream>
#include "clsScreen.h"
#include "clsInputValidate.h"
#include "clsUser.h"
using namespace std;



class clsAddUserScreen : protected clsScreen
{
private :

	static void _GivePermissions(clsUser &User)
	{
		cout << "\nEnter Permissions: " << endl;

		if (clsInputValidate::ReadBoolean("\nFull Access?"))
		{
			User.Permission = -1;
			return;
		}
		
		if (clsInputValidate::ReadBoolean("\nAccess To Show Clients?"))
		{
			User.Permission += clsUser::enPermission::pShowClients;
		}
		
		if (clsInputValidate::ReadBoolean("\nAccess To Add Clients?"))
		{
			User.Permission += clsUser::enPermission::pAddClient;
		}

		if (clsInputValidate::ReadBoolean("\nAccess To Delete Clients?"))
		{
			User.Permission += clsUser::enPermission::pDeleteClient;
		}

		if (clsInputValidate::ReadBoolean("\nAccess To Update Clients?"))
		{
			User.Permission += clsUser::enPermission::pUpdateClient;
		}

		if (clsInputValidate::ReadBoolean("\nAccess To Find Clients?"))
		{
			User.Permission += clsUser::enPermission::pFindClient;
		}

		if (clsInputValidate::ReadBoolean("\nAccess To Transactions?"))
		{
			User.Permission += clsUser::enPermission::pTransaction;
		}

		if (clsInputValidate::ReadBoolean("\nAccess To Manage Users?"))
		{
			User.Permission += clsUser::enPermission::pManageUsers;
		}

	}

	



public:

	static void ShowAddNewUserScreen()
	{
		_DrawScreenHeader("\t Add New User Screen");

		clsUser UserToAdd;

		string UserName = clsInputValidate::ReadString("Enter User Name:");
		while (clsUser::IsUserExist(UserToAdd, UserName))
		{
			UserName = clsInputValidate::ReadString("User Name Already Exist, Enter Another User Name:");
		}

		UserToAdd = clsUser::GetAddNewUserObject(UserName);

		clsScreen::_ReadUserInfo(UserToAdd);
		_GivePermissions(UserToAdd);
		clsScreen::_PrintUser(UserToAdd);

		if (clsInputValidate::ReadBoolean("\nAre You Sure You Want To Add This User?"))
		{
			clsUser::enSaveResults SavingResult = UserToAdd.Save();

			switch (SavingResult)
			{
			case clsUser::enSaveResults::eSuccedded:

				cout << "\nUser Added Successfully!" << endl;
				break;

			case clsUser::enSaveResults::eFailedEmptyObject:

				cout << "\nError, User was not saved because it's Empty!" << endl;
			}

		}
		else
		{
			cout << "\nOperation was cancelled!" << endl;
		}

	}


};

