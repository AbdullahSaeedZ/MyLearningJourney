#pragma once

#include <iostream>
#include <iomanip>
#include "clsScreen.h"
#include "clsInputValidate.h"
#include "clsClientListScreen.h"
#include "clsAddNewClientScreen.h"
using namespace std;


//this is UI code,  main screen class calls the other scren classes which are also UI code, then those UI code classes communicate with backend code which is clsBankClient class.


class clsMainScreen : protected clsScreen
{
private:

	enum enMainMenueOptions {
		eListClients = 1, eAddNewClient = 2, eDeleteClient = 3,
		eUpdateClient = 4, eFindClient = 5, eShowTransactionsMenu = 6,
		eManageUsers = 7, eExit = 8
	};

	static void _ShowClientListScreen()
	{
		clsClientListScreen::ShowClientsList();
	}

	static void _ShowAddNewClientScreen()
	{
		clsAddNewClientScreen::AddNewClientScreen();
	}

	static void _ShowDeleteClientScreen()
	{
		system("cls");
		_DrawScreenHeader("Delete Client screen..");
	}

	static void _ShowUpdateClientScreen()
	{
		system("cls");
		_DrawScreenHeader("Update Client screen..");
	}

	static void _ShowFindClientScreen()
	{
		system("cls");
		_DrawScreenHeader("Find Client screen..");
	}

	static void _ShowTransactionMenuScreen()
	{
		system("cls");
		_DrawScreenHeader("Transaction Menu screen..");
	} 

	static void _ShowManageUsersScreen()
	{
		system("cls");
		_DrawScreenHeader("Manage  Users screen..");
	}

	static void _ShowLogoutScreen()
	{
		system("cls");
		_DrawScreenHeader("Logout screen..");
	}

	static  void _GoBackToMainMenu()
	{
		cout << setw(37) << left << "" << "\n\tPress any key to go back to Main Menu...\n";

		system("pause>0");
		ShowMainMenuScreen();
	}

	static void _ShowEndScreen()
	{
		cout << "\nEnd Screen Will be here...\n";
	}



	static short _ReadMainMenuOption()
	{
		short Choice = 0;
		Choice = clsInputValidate::ReadNumInRange(1, 8, "Choose what you want to do [1 to 8]: ");

		return Choice;
	}

	static void _PerformMainMenuOption(short Option)
	{
		switch (Option)
		{
		case enMainMenueOptions::eListClients:
		
			system("cls");
			_ShowClientListScreen();
			_GoBackToMainMenu();
			break;
		
		case enMainMenueOptions::eAddNewClient:
			system("cls");
			_ShowAddNewClientScreen();
			_GoBackToMainMenu();
			break;

		case enMainMenueOptions::eDeleteClient:
			system("cls");
			_ShowDeleteClientScreen();
			_GoBackToMainMenu();
			break;

		case enMainMenueOptions::eUpdateClient:
			system("cls");
			_ShowUpdateClientScreen();
			_GoBackToMainMenu();
			break;

		case enMainMenueOptions::eFindClient:
			system("cls");
			_ShowFindClientScreen();
			_GoBackToMainMenu();
			break;

		case enMainMenueOptions::eShowTransactionsMenu:
			system("cls");
			_ShowTransactionMenuScreen();
			break;

		case enMainMenueOptions::eManageUsers:
			system("cls");
			_ShowManageUsersScreen();
			break;

		case enMainMenueOptions::eExit:
			system("cls");
			_ShowEndScreen();
			//Login();

			break;
		}

	
	}


public:


	static void ShowMainMenuScreen()
	{
		system("cls");
		_DrawScreenHeader("\t\tMain Screen");

		cout << "===========================================\n";
		cout << "\t\tMain Menu\n";
		cout << "===========================================\n";
		cout << "\t[1] Show Client List.\n";
		cout << "\t[2] Add New Client.\n";
		cout << "\t[3] Delete Client.\n";
		cout << "\t[4] Update Client Info.\n";
		cout << "\t[5] Find Client.\n";
		cout << "\t[6] Transactions.\n";
		cout << "\t[7] Manage Users.\n";
		cout << "\t[8] Logout.\n";
		cout << "===========================================\n";

		_PerformMainMenuOption(_ReadMainMenuOption());
	}


};

