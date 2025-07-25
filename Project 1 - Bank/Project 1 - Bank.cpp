#include <iostream>
#include <vector>
#include <fstream>
#include <iomanip>
#include "in.h"
#include "str.h"
using namespace std;

const string ClientBase = "Clients.txt";

enum enChoice { ShowList = 1, AddClient = 2, DeleteClient = 3, UpdateClient = 4, FindClient = 5, Exit = 6 };

struct stClientData
{
    string ID, PINCode, Name, Phone;
    double AcctBalance;
    bool MarkForDelete = false;
};

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
    cout << setw(30) << "[6] Exit." << endl;
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

bool IsClientFound(vector<stClientData>& vAllClients, stClientData &Client, string ClientID)
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
        if (IsClientFound(vAllClients,Client, ClientID))
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

void StartProgram()
{
    vector<stClientData> vAllClients = LoadDataFromFile(ClientBase);
    short Choice = 0;

    do
    {
        ShowMenu();
        Choice = in::ReadPositiveNumInRange("Choose what to do from the list [1 to 6]: ", 1, 6);

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

