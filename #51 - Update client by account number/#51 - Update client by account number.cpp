#include <iostream>
#include <vector>
#include <fstream>
#include "str.h"
#include "in.h"
using namespace std;

const string ClientsBase = "Clients.txt";

struct stClientData
{
    string ID, PINCode, Name, Phone;
    double AcctBalance;
};

stClientData ConvertDataLineToRecord(string Line, string Delim = "#//#")
{
    vector<string> Records = str::SplitStringToVector(Line, Delim);
    stClientData Client;

    Client.ID = Records[0];
    Client.Name = Records[1];
    Client.PINCode = Records[2];
    Client.Phone = Records[3];
    Client.AcctBalance = stod(Records[4]);

    return Client;
}

string ConvertRecordToLine(stClientData Client1, string delim = "#//#")
{
    string str = "";

    str += Client1.ID + delim;
    str += Client1.Name + delim;
    str += Client1.PINCode + delim;
    str += Client1.Phone + delim;
    str += to_string(Client1.AcctBalance);

    return str;
}

vector<stClientData> LoadDataFromFile(string FilePath)
{
    vector<stClientData> vAllClients;
    fstream File;
    File.open(FilePath, ios::in);

    if (File.is_open())
    {
        string OneLine = "";
        stClientData OneClient;

        while (getline(File, OneLine))
        {
            OneClient = ConvertDataLineToRecord(OneLine);
            vAllClients.push_back(OneClient);
        }

        File.close();
    }

    return vAllClients;
}

void PrintClientRecord(stClientData ClientRecord)
{
    cout << "\nClient Details: " << endl;
    cout << "\nAccount Number : " << ClientRecord.ID << endl;
    cout << "Pin Code       : " << ClientRecord.PINCode << endl;
    cout << "Name           : " << ClientRecord.Name << endl;
    cout << "Phone          : " << ClientRecord.Phone << endl;
    cout << "Account Balance: " << ClientRecord.AcctBalance << endl;
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

stClientData ReadClientData(stClientData &Client)
{
    
    cout << "\nEnter PinCode? ";
    getline(cin >> ws, Client.PINCode);

    cout << "Enter Name? ";
    getline(cin, Client.Name);

    cout << "Enter Phone? ";
    getline(cin, Client.Phone);

    cout << "Enter AccountBalance? ";
    cin >> Client.AcctBalance;

    return Client;
}

void UpdateClientBase(vector<stClientData>& vAllClients, string FilePath)
{
    fstream File;
    File.open(FilePath, ios::out);

    if (File.is_open())
    {
        string OneLine = "";

        for (stClientData& record : vAllClients)
        {
            OneLine = ConvertRecordToLine(record);
            File << OneLine << endl;
        }

        File.close();
    }
}

void ApplyChanges(vector<stClientData>& vAllClients, string ClientID)
{
    stClientData Client;

    if (IsClientFound(vAllClients, Client, ClientID))
    {       
        PrintClientRecord(Client);
        string Ask = in::AskY_N("\nAre you sure you want to update Client Data? y/n ?");

        if (Ask == "y" || Ask == "Y")
        {
            for (stClientData& record : vAllClients)
            {
                if (record.ID == ClientID)
                {
                    record = ReadClientData(record);
                    break;
                }
            }

            UpdateClientBase(vAllClients, ClientsBase);
            cout << "\nClient Data Updated Successfully." << endl;
        }
    }
    else
    {
        cout << "\nAccount Number (" << ClientID << ") was not found !" << endl;
    }


}

void UpdateClientsData()
{
    vector<stClientData> vAllClients = LoadDataFromFile(ClientsBase);
    string ClientID = in::ReadString("Enter the Account Number:");

    ApplyChanges(vAllClients, ClientID);

}

int main()
{
    
    UpdateClientsData();


    return 0;
}

