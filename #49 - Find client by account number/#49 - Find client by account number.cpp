#include <iostream>
#include <vector>
#include <fstream>
#include <string>
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

bool IsClientFound(stClientData &Client, string ClientID)
{
    vector<stClientData> vAllClients = LoadDataFromFile(ClientsBase);

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

void PrintClientRecord(stClientData ClientRecord)
{
    cout << "\nClient Details: " << endl;
    cout << "\nAccount Number : " << ClientRecord.ID << endl;
    cout << "Pin Code       : " << ClientRecord.PINCode << endl;
    cout << "Name           : " << ClientRecord.Name << endl;
    cout << "Phone          : " << ClientRecord.Phone << endl;
    cout << "Account Balance: " << ClientRecord.AcctBalance << endl;
}

void SearchForClient()
{
    string ClientID = in::ReadString("Please Enter Account Number:");
    stClientData ClientRecord;

    if (IsClientFound(ClientRecord, ClientID))
    {
        PrintClientRecord(ClientRecord);
    }
    else
    {
        cout << "\nClient with Account Number (" << ClientID << ") was not found !!\n" << endl;
    }
    
}

int main()
{
    
    SearchForClient();


    return 0;
}

