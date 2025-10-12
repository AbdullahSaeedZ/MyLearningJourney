#include <iostream>
#include <vector>
#include <fstream>
#include <iomanip>
#include "in.h"
#include "str.h"
using namespace std;

const string ClientBase = "Clients.txt";

enum enChoice { ShowList = 1, AddClient = 2, DeleteClient = 3, UpdateClient = 4, FindClient = 5, Transaction = 6, Exit = 7 };
enum enTransChoice {Deposit = 1, Withdraw = 2, TotalBalances = 3, BackToMenu = 4};

struct stClientData
{
    string ID, PINCode, Name, Phone;
    double AcctBalance;
    bool MarkForDelete = false;
};

double ReadAmount(string Message)
{
    double Number = 0;
    do
    {
        cout << Message << endl;
        cin >> Number;

        if (cin.fail())
        {
            // if other than numbers entered system will fail.
            cin.clear();                // to clear the failure
            cin.ignore(10000, '\n');    // to ignore what was entered before, to clean the buffer
            cout << "Invalid input! Please enter a number." << endl;
            continue;
        }

    } while (Number <= 0);

    return Number;
}

void ShowMenu()
{
    system("cls");
    cout << "===========================================" << endl;
    cout << "             Main Menu Screen" << endl;
    cout << "===========================================" << endl;
    cout << left << setw(30) << "[1] Show Clients List." << endl;
    cout << setw(30) << "[2] Add New Client." << endl;
    cout << setw(30) << "[3] Delete Client." << endl;
    cout << setw(30) << "[4] Update Client Info." << endl;
    cout << setw(30) << "[5] Find Client." << endl;
    cout << setw(30) << "[6] Transaction." << endl;
    cout << setw(30) << "[7] Exit." << endl;
    cout << "===========================================" << endl;
}


void ClientListHeader(vector<stClientData>& vAllClients)
{

    cout << "--------------------------------------------------------------------------------------------------------------------------\n" << endl;
    cout << "                                        Clients List (" << vAllClients.size() << ") Clients(s)." << endl;
    cout << "\n--------------------------------------------------------------------------------------------------------------------------" << endl;
    cout << "| " << setw(18) << "Account Number"
        << "| " << setw(18) << "Pin Code"
        << "| " << setw(48) << "Client Name"
        << "| " << setw(18) << "Phone"
        << "| " << setw(18) << "Balance" << endl;
    cout << "--------------------------------------------------------------------------------------------------------------------------\n" << endl;
}

void ShowClientsList(vector<stClientData>& vAllClients)
{
    ClientListHeader(vAllClients);

    for (stClientData& ClientInfo : vAllClients)
    {
        cout << "| " << setw(18) << ClientInfo.ID
            << "| " << setw(18) << ClientInfo.PINCode
            << "| " << setw(48) << ClientInfo.Name
            << "| " << setw(18) << ClientInfo.Phone
            << "| " << setw(18) << ClientInfo.AcctBalance << endl;
    }
    cout << "\n--------------------------------------------------------------------------------------------------------------------------\n" << endl;


}


stClientData ConvertDataLineToRecord(string Line, string Delim = "#//#")
{
    vector<string> Records = str::SplitStringToVector(Line, Delim);
    stClientData Client;

    Client.ID = Records[0];
    Client.PINCode = Records[1];
    Client.Name = Records[2];
    Client.Phone = Records[3];
    Client.AcctBalance = stod(Records[4]);

    return Client;
}

string ConvertRecordToLine(stClientData Client1, string delim = "#//#")
{
    string str = "";

    str += Client1.ID + delim;
    str += Client1.PINCode + delim;
    str += Client1.Name + delim;
    str += Client1.Phone + delim;
    str += to_string(Client1.AcctBalance);

    return str;
}

bool IsIDFound(vector<stClientData>& vAllClients, string ClientID)
{
    for (stClientData& record : vAllClients)
    {
        if (record.ID == ClientID)
        {
            return true;
        }
    }
    return false;
}

bool IsClientFound(vector<stClientData>& vAllClients, stClientData& Client, string ClientID)
{
    for (stClientData& record : vAllClients)
    {
        if (record.ID == ClientID)
        {
            Client = record;
            return true;
        }
    }
    return false;
}


vector<stClientData> LoadDataFromFile(string FilePath)
{
    vector<stClientData> vAllClients;
    fstream File;

    File.open(FilePath, ios::in);

    if (File.is_open())
    {
        string Line = "";
        stClientData Record;

        while (getline(File, Line))
        {
            Record = ConvertDataLineToRecord(Line);
            vAllClients.push_back(Record);
        }

        File.close();
    }

    return vAllClients;
}

stClientData ReadClientData(vector<stClientData>& vAllClients)
{
    stClientData Client;


    cout << "Enter Account Number? "; // Usage of std::ws will extract all the whitespace character  
    getline(cin >> ws, Client.ID);

    while (IsIDFound(vAllClients, Client.ID))
    {
        cout << "Client with [" << Client.ID << "] already exists, enter another Account number: ";
        getline(cin, Client.ID);
    }

    cout << "Enter PinCode? ";
    getline(cin, Client.PINCode);

    cout << "Enter Name? ";
    getline(cin, Client.Name);

    cout << "Enter Phone? ";
    getline(cin, Client.Phone);

    cout << "Enter AccountBalance? ";
    cin >> Client.AcctBalance;

    return Client;
}


void AddClientHeader()
{
    cout << "\n--------------------------------" << endl;
    cout << setw(40) << "Add New Clients Screen" << endl;
    cout << "--------------------------------\n";
    cout << "Adding New Client:\n" << endl;
}

void AddNewClient(vector<stClientData>& vAllClients)
{
    string Again = "";
    fstream File;
    File.open(ClientBase, ios::out | ios::app);

    do
    {
        system("cls");
        AddClientHeader();

        if (File.is_open())
        {
            stClientData NewClient = ReadClientData(vAllClients);
            string Line = ConvertRecordToLine(NewClient);
            File << Line << endl;

        }

        cout << "\nClient Added Successfully !" << endl;

        vAllClients = LoadDataFromFile(ClientBase);

        Again = in::AskY_N("\nDo you want to add more clients? y/n?");

    } while (Again == "y" || Again == "Y");

    File.close();
}


void PrintDataRecord(stClientData Client)
{
    cout << "\n--------------------------------" << endl;
    cout << "Account ID: " << Client.ID << endl;
    cout << "Pin Code  : " << Client.PINCode << endl;
    cout << "Name      : " << Client.Name << endl;
    cout << "Phone     : " << Client.Phone << endl;
    cout << "Balance   : " << Client.AcctBalance << endl;
    cout << "--------------------------------\n" << endl;
}

void DeleteHeader()
{
    cout << "\n--------------------------------" << endl;
    cout << setw(50) << "Delete Client Screen" << endl;
    cout << "--------------------------------\n" << endl;
}

void MarkForDelete(vector<stClientData>& vAllClients, string ClientID)
{
    for (stClientData& record : vAllClients)
    {
        if (record.ID == ClientID)
        {
            record.MarkForDelete = true;
            break;
        }
    }
}

void UpdateClientsAfterDelete(vector<stClientData>& vAllClients, string ClientID)
{
    string Line = "";
    fstream File;
    File.open(ClientBase, ios::out);

    if (File.is_open())
    {
        for (stClientData& record : vAllClients)
        {
            if (record.MarkForDelete == false)
            {
                Line = ConvertRecordToLine(record);
                File << Line << endl;
            }
        }

        File.close();
    }
}

void DeleteOneClient(vector<stClientData>& vAllClients, string ClientID)
{
    MarkForDelete(vAllClients, ClientID);
    UpdateClientsAfterDelete(vAllClients, ClientID);
}

void DeleteClientProcess(vector<stClientData>& vAllClients)
{
    stClientData Client;
    string Again = "";
    string sure = "";
    string ClientID = "";

    do
    {
        system("cls");
        DeleteHeader();

        ClientID = in::ReadString("\nPlease enter Account Number: ");
        if (IsClientFound(vAllClients, Client, ClientID))
        {
            PrintDataRecord(Client);

            sure = in::AskY_N("\nAre you sure you want to delete this client ? y/n ? ");
            if (sure == "y" || sure == "Y")
            {
                DeleteOneClient(vAllClients, ClientID);
                vAllClients = LoadDataFromFile(ClientBase);
                cout << "\nClient Deleted Successfully !" << endl;
            }
        }
        else
        {
            cout << "\nClient with this Account Number Doesn`t exist !" << endl;
        }


        Again = in::AskY_N("\nDo you want to delete other clients? y/n?");

    } while (Again == "y" || Again == "Y");

}


void UpdateHeader()
{
    cout << "\n--------------------------------" << endl;
    cout << setw(50) << "Update Client Info Screen" << endl;
    cout << "--------------------------------\n";
}

stClientData ReadRecordUpdate(string ClientID)
{
    stClientData Client;

    Client.ID = ClientID;

    cout << "Enter PinCode? ";
    getline(cin >> ws, Client.PINCode);

    cout << "Enter Name? ";
    getline(cin, Client.Name);

    cout << "Enter Phone? ";
    getline(cin, Client.Phone);

    cout << "Enter AccountBalance? ";
    cin >> Client.AcctBalance;

    return Client;
}

void UpdateOneClient(vector<stClientData>& vAllClients, string ClientID)
{
    for (stClientData& record : vAllClients)
    {
        if (record.ID == ClientID)
        {
            record = ReadRecordUpdate(ClientID);
            break;
        }
    }
}

void LoadVectorToFile(vector<stClientData>& vAllClients)
{
    string Line = "";
    fstream File;
    File.open(ClientBase, ios::out);

    if (File.is_open())
    {
        for (stClientData& record : vAllClients)
        {
            Line = ConvertRecordToLine(record);
            File << Line << endl;
        }

        File.close();
    }
}

void UpdateClientInfo(vector<stClientData>& vAllClients)
{
    stClientData Client;
    string Again = "";
    string sure = "";
    string ClientID = "";

    do
    {
        system("cls");
        UpdateHeader();

        ClientID = in::ReadString("\nPlease enter Account Number: ");
        if (IsClientFound(vAllClients, Client, ClientID))
        {
            cout << "\nClient Details: " << endl;
            PrintDataRecord(Client);

            sure = in::AskY_N("\nAre you sure you want to update this client ? y/n ? ");
            if (sure == "y" || sure == "Y")
            {
                UpdateOneClient(vAllClients, ClientID);
                LoadVectorToFile(vAllClients);
                vAllClients = LoadDataFromFile(ClientBase);
                cout << "\nClient Info Updated Successfully !" << endl;
            }
        }
        else
        {
            cout << "\nClient with this Account Number Doesn`t exist !" << endl;
        }


        Again = in::AskY_N("\nDo you want to update other clients info? y/n?");

    } while (Again == "y" || Again == "Y");

}


void FindHeader()
{
    cout << "\n--------------------------------" << endl;
    cout << setw(50) << "Find Client Screen" << endl;
    cout << "--------------------------------\n";
}

void ShowClientInfo(vector<stClientData>& vAllClients)
{
    stClientData Client;
    string Again = "";
    string ClientID = "";

    do
    {
        system("cls");
        FindHeader();

        ClientID = in::ReadString("\nPlease enter Account Number: ");
        if (IsClientFound(vAllClients, Client, ClientID))
        {
            cout << "\nClient Details: " << endl;
            PrintDataRecord(Client);
        }
        else
        {
            cout << "\nClient with this Account Number Doesn`t exist !" << endl;
        }


        Again = in::AskY_N("\nDo you want to find other clients info? y/n?");

    } while (Again == "y" || Again == "Y");
}


void TransactionScreen()
{
    cout << "\n--------------------------------" << endl;
    cout << setw(50) << "Transaction Menu Screen" << endl;
    cout << "--------------------------------\n";
    cout << "[1] Deposit." << endl;
    cout << "[2] Withdraw." << endl;
    cout << "[3] Total Balances." << endl;
    cout << "[4] Back To Main Menu." << endl;

}

void DepositHeader()
{
    cout << "\n--------------------------------" << endl;
    cout << setw(50) << "Deposit Screen" << endl;
    cout << "--------------------------------\n";
}

void DepositToClient(vector<stClientData>& vAllClients, string ClientID, double Amount)
{
    string sure = "";

    sure = in::AskY_N("\nAre you sure you want to perform this transaction ? y/n?");

    if (sure == "y" || sure == "Y")
    {
        for (stClientData& record : vAllClients)
        {
            if (record.ID == ClientID)
            {
                record.AcctBalance += Amount;
                break;
            }
        }

        cout << "\nTransaction performed successfully !!" << endl;
    }

}

void ShowNewBalance(vector<stClientData>& vAllClients, string ClientID)
{
    for (stClientData& record : vAllClients)
    {
        if (record.ID == ClientID)
        {
            cout << "\nNew Balance: " << record.AcctBalance << endl;
            break;
        }
    }
}

void DepositProcess(vector<stClientData>& vAllClients)
{
    string ClientID = "";
    string Again = "";
    stClientData Client;
    double DepositAmount = 0;

    do
    {
        system("cls");
        DepositHeader();
        ClientID = in::ReadString("\nPlease enter Account Number:");

        if (IsClientFound(vAllClients, Client, ClientID))
        {
            cout << "\nClient Details: " << endl;
            PrintDataRecord(Client);

            DepositAmount = ReadAmount("Please enter deposit amount:");
            DepositToClient(vAllClients, ClientID, DepositAmount);

            LoadVectorToFile(vAllClients);
            vAllClients = LoadDataFromFile(ClientBase);

            ShowNewBalance(vAllClients, ClientID);
        }
        else
        {
            cout << "\nClient with this Account Number Doesn`t exist !" << endl;
        }

        Again = in::AskY_N("\nDo you want to deposit to other clients? y/n?");

    } while (Again == "y" || Again == "Y");


}


void WithdrawHeader()
{
    cout << "\n--------------------------------" << endl;
    cout << setw(50) << "Withdraw Screen" << endl;
    cout << "--------------------------------\n";
}

void WithdrawFromClient(vector<stClientData>& vAllClients, string ClientID, double Amount)
{
    string sure = "";

    sure = in::AskY_N("\nAre you sure you want to perform this transaction ? y/n?");

    if (sure == "y" || sure == "Y")
    {
        for (stClientData& record : vAllClients)
        {
            if (record.ID == ClientID)
            {
                record.AcctBalance -= Amount;
                break;
            }
        }

        cout << "\nTransaction performed successfully !!" << endl;
    }

}

void WithdrawProcess(vector<stClientData>& vAllClients)
{
    string ClientID = "";
    string Again = "";
    stClientData Client;
    double WithdrawAmount = 0;

    do
    {
        system("cls");
        WithdrawHeader();
        ClientID = in::ReadString("\nPlease enter Account Number:");

        if (IsClientFound(vAllClients, Client, ClientID))
        {
            cout << "\nClient Details: " << endl;
            PrintDataRecord(Client);

            WithdrawAmount = ReadAmount("\nPlease enter Withdraw amount:");
            while (WithdrawAmount > Client.AcctBalance)
            {
                cout << "\nAmount exceeds the balance, you can withdraw up to: " << Client.AcctBalance << endl;
                WithdrawAmount = ReadAmount("Please enter Withdraw amount:");
            }

            WithdrawFromClient(vAllClients, ClientID, WithdrawAmount);

            LoadVectorToFile(vAllClients);
            vAllClients = LoadDataFromFile(ClientBase);

            ShowNewBalance(vAllClients, ClientID);
        }
        else
        {
            cout << "\nClient with this Account Number Doesn`t exist !" << endl;
        }

        Again = in::AskY_N("\nDo you want to withdraw from other clients? y/n?");

    } while (Again == "y" || Again == "Y");

}


void ShowTotalBalances(const vector<stClientData>& vAllClients)
{
    double TotalBalances = 0;

        cout << "--------------------------------------------------------------------------------------------------------------------------\n" << endl;
        cout << "                                        Balances List (" << vAllClients.size() << ") Clients(s)." << endl;
        cout << "\n--------------------------------------------------------------------------------------------------------------------------" << endl;
        cout << "| " << setw(18) << "Account Number"
             << "| " << setw(70) << "Client Name"
             << "| " << setw(18) << "Balance" << endl;
        cout << "--------------------------------------------------------------------------------------------------------------------------\n" << endl;

        for (const stClientData& ClientInfo : vAllClients)
        {
            cout << "| " << setw(18) << ClientInfo.ID
                 << "| " << setw(70) << ClientInfo.Name
                 << "| " << setw(18) << ClientInfo.AcctBalance << endl;

            TotalBalances += ClientInfo.AcctBalance;
        }
        cout << "\n--------------------------------------------------------------------------------------------------------------------------\n" << endl;
        cout << "\n                                                              Total Balances = " << TotalBalances << endl;
        
}

void TransactionProcess(vector<stClientData>& vAllClients)
{
    short Choice;

    do
    {
        system("cls");
        TransactionScreen();
        Choice = in::ReadPositiveNumInRange("Choose what to do from the list [1 to 4]: ", 1, 4);

        if (Choice == enTransChoice::Deposit)
        {
            system("cls");
            DepositProcess(vAllClients);
            system("pause");
        }
        else if (Choice == enTransChoice::Withdraw)
        {
            system("cls");
            WithdrawProcess(vAllClients);
            system("pause");
        }
        else if (Choice == enTransChoice::TotalBalances)
        {
            system("cls");
            ShowTotalBalances(vAllClients);
            system("pause");
        }
        

    } while(Choice != enTransChoice::BackToMenu);


}

void StartProgram()
{
    vector<stClientData> vAllClients = LoadDataFromFile(ClientBase);
    short Choice = 0;

    do
    {
        system("cls");
        ShowMenu();
        Choice = in::ReadPositiveNumInRange("Choose what to do from the list [1 to 7]: ", 1, 7);

        if (Choice == enChoice::ShowList)
        {
            system("cls");
            ShowClientsList(vAllClients);
            system("pause");
        }
        else if (Choice == enChoice::AddClient)
        {
            system("cls");
            AddNewClient(vAllClients);
            system("pause");
        }
        else if (Choice == enChoice::DeleteClient)
        {
            system("cls");
            DeleteClientProcess(vAllClients);
            system("pause");
        }
        else if (Choice == enChoice::UpdateClient)
        {
            system("cls");
            UpdateClientInfo(vAllClients);
            system("pause");
        }
        else if (Choice == enChoice::FindClient)
        {
            system("cls");
            ShowClientInfo(vAllClients);
            system("pause");
        }
        else  if (Choice == enChoice::Transaction)
        {
            system("cls");
            TransactionProcess(vAllClients);
            system("pause");
        }
        else
        {
            system("cls");
            cout << "\n--------------------------------\n" << endl;
            cout << setw(25) << "End of Program :)" << endl;
            cout << "\n--------------------------------" << endl;
            cout << "                  Abdullah Saeed" << endl;
            cout << "                       25/7/2025\n\n" << endl;
            system("pause");
        }

    } while (Choice != enChoice::Exit);



}

int main()
{

    StartProgram();


    return 0;
}

