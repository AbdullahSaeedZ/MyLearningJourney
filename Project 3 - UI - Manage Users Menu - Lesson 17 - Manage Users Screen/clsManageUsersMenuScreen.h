#pragma once

#include <iostream>
#include <iomanip>
#include "clsScreen.h"
using namespace std;

class clsManageUsersMenuScreen : protected clsScreen
{
private:


	enum enManageUsersMenuOptions {
		eListUsers = 1, eAddNewUser = 2, eDeleteUser = 3,
		eUpdateUser = 4, eFindUser = 5, eMainMenu = 6
	};


	// stubs

	static void _ShowListUsersScreen()
	{
		cout << "show user list.." << endl;
	}

	static void _ShowAddNewUserScreen()
	{
		cout << "Add User.." << endl;
	}

	static void _ShowDeleteUserScreen()
	{
		cout << "Delete User.." << endl;
	}

	static void _ShowUpdateUserScreen()
	{
		cout << "Update User.." << endl;
	}

	static void _ShowFindUserScreen()
	{
		cout << "Find User.." << endl;
	}

	static void _GoBackToManageUsersMenu()
	{
		cout << setw(37) << left << "" << "\n\tPress any key to go back to Manage Users Menu...\n";

		system("pause>0");
		ShowManageUsersScreen();
	}

	static short _ReadManageUsersMenuOption()
	{
		short Choice = 0;
		Choice = clsInputValidate::ReadNumInRange(1, 6, "Choose what you want to do [1 to 6]: ");
		return Choice;
	}

	static void _PerformManageUsersMenuOption(short Option)
	{

		switch (Option)
		{
		case enManageUsersMenuOptions::eListUsers:
			
			system("cls");
			_ShowListUsersScreen();
			_GoBackToManageUsersMenu();
			break;

		case enManageUsersMenuOptions::eAddNewUser:

			system("cls");
			_ShowAddNewUserScreen();
			_GoBackToManageUsersMenu();
			break;

		case enManageUsersMenuOptions::eDeleteUser:

			system("cls");
			_ShowDeleteUserScreen();
			_GoBackToManageUsersMenu();
			break;
		
		case enManageUsersMenuOptions::eUpdateUser:

			system("cls");
			_ShowUpdateUserScreen();
			_GoBackToManageUsersMenu();
			break;

		case enManageUsersMenuOptions::eFindUser:

			system("cls");
			_ShowFindUserScreen();
			_GoBackToManageUsersMenu();
			break;

		case enManageUsersMenuOptions::eMainMenu:

			break;

		}


	}



public:

	static void ShowManageUsersScreen()
	{
		system("cls");
		_DrawScreenHeader("\t  Manage Users Screen");

		cout << "===========================================\n";
		cout << "\t\t  Manage Users Menu\n";
		cout << "===========================================\n";
		cout << "\t[1] List Users.\n";
		cout << "\t[2] Add New User.\n";
		cout << "\t[3] Delete User.\n";
		cout << "\t[4] Update User.\n";
		cout << "\t[5] Find User.\n";
		cout << "\t[6] Main Menu.\n";
		cout << "===========================================\n";

		_PerformManageUsersMenuOption(_ReadManageUsersMenuOption());
	}

};

