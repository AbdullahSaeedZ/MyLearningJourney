#pragma once

#include <iostream>
#include <string>
#include <vector>
#include <fstream>
#include "clsPerson.h"
#include "clsString.h"
using namespace std;


class clsBankClient : public clsPerson
{

private:

	enum enMode { eEmptyMode = 0, eUpdateMode = 1 };
	enMode _Mode;

	string _AcctNumber;
	string _PinCode;
	float _AcctBalance;


	// static, to be able to be used by a static member (the find function), but in private to limit access to inside class only
	static clsBankClient _ConvertLineToObject(string Line, string Separator = "#//#")
	{
		vector<string> vStr = clsString::SplitStringToVector(Line, Separator);

		return clsBankClient(enMode::eUpdateMode, vStr[0], vStr[1], vStr[2], vStr[3], vStr[4], vStr[5], stoi(vStr[6]));
	}

	static clsBankClient _getEmptyClientObject()
	{
		return clsBankClient(enMode::eEmptyMode, "", "", "", "", "", "", 0);
	}

public:

	clsBankClient(enMode Mode , string AcctNumber, string PinCode, string FirstName, string LastName, string Email, string PhoneNumber, float AcctBalance)
		: clsPerson(FirstName, LastName, Email, PhoneNumber)
	{
		_Mode = Mode;
		_AcctNumber = AcctNumber;
		_PinCode = PinCode;
		_AcctBalance = AcctBalance;
	}

	// setters & getters
	
	string getAcctNumber()// Read-only
	{
		return _AcctNumber;
	}


	void setPinCode(string Pin)
	{
		_PinCode = Pin;
	}

	string getPinCode()
	{
		return _PinCode;
	}

	__declspec(property(get = getPinCode, put = setPinCode)) string PinCode;

	void setAcctBalance(float Num)
	{
		_AcctBalance = Num;
	}

	float getAcctBalance()
	{
		return _AcctBalance;
	}

	__declspec(property(get = getAcctBalance, put = setAcctBalance)) float AcctBalance;

	//

	bool IsEmpty() // to check is the object on empty mode
	{
		return (_Mode == enMode::eEmptyMode);
	}

	void Print()
	{
		cout << "\nClient Card:" << endl;
		cout << "____________________________________" << endl;
		cout << "Acct. Number: " << _AcctNumber << endl;
		cout << "First Name  : " << FirstName << endl; // using property declaration
		cout << "Last Name   : " << LastName << endl;
		cout << "Full Name   : " << getFullName() << endl;
		cout << "Email       : " << Email << endl;
		cout << "Phone       : " << PhoneNumber << endl;
		cout << "Balance     : " << _AcctBalance << " SAR" << endl;
		cout << "Password    : " << _PinCode << endl;
		cout << "____________________________________\n" << endl;
	}

	// 

	static clsBankClient Find(string AcctNumber) // static, to be used with no objects, to look for client then fill an empty one, if not found fill with empty object on empty mode.
	{
		fstream File;
		
		File.open("Clients.txt", ios::in);
		if (File.is_open())
		{
			string Line;
			while (getline(File, Line))
			{
				clsBankClient Client = _ConvertLineToObject(Line);

				if (Client._AcctNumber == AcctNumber)
				{
					File.close();
					return Client;
				}
			}

			File.close();
			return _getEmptyClientObject();
		}
	}

	static clsBankClient Find(string AcctNumber, string PinCode) // using both parameters for Login later.
	{
		fstream File;

		File.open("Clients.txt", ios::in);
		if (File.is_open())
		{
			string Line;
			while (getline(File, Line))
			{
				clsBankClient Client = _ConvertLineToObject(Line);

				if (Client.getAcctNumber() == AcctNumber && Client.PinCode == PinCode)
				{
					File.close();
					return Client;
				}
			}

			File.close();
			return _getEmptyClientObject();
		}
	}

	static bool IsClientExist(string AcctNum)
	{
		clsBankClient Client = clsBankClient::Find(AcctNum);
		return (!Client.IsEmpty());
	}


};

