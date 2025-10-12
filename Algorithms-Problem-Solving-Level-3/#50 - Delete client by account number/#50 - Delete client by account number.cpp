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
    bool MarkForDelete = false;
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
    Client.MarkForDelete = false;

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

bool IsClientFound(vector<stClientData> &vAllClients, stClientData& Client, string ClientID)
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

void PrintClientRecord(stClientData ClientRecord)
{
    cout << "\nClient Details: " << endl;
    cout << "\nAccount Number : " << ClientRecord.ID << endl;
    cout << "Pin Code       : " << ClientRecord.PINCode << endl;
    cout << "Name           : " << ClientRecord.Name << endl;
    cout << "Phone          : " << ClientRecord.Phone << endl;
    cout << "Account Balance: " << ClientRecord.AcctBalance << endl;
}

void MarkClientForDelete(vector<stClientData>& vAllClients, string ClientID)
{
    for (stClientData& Client : vAllClients)
    {
        if (Client.ID == ClientID)
        {
            Client.MarkForDelete = true;
            break;
        }
    }
}

void UpdateClientsDataToFile(string FilePath, vector<stClientData>& vAllClients)
{
    fstream File;

    File.open(FilePath, ios::out);

    if (File.is_open())
    {
        string OneLine = "";

        for (stClientData& Client : vAllClients)
        {
            if (Client.MarkForDelete == false)
            {
                OneLine = ConvertRecordToLine(Client);
                File << OneLine << endl;
                
            }
        }

        File.close();
    }


}

void DeleteClientFromFile(vector<stClientData>& vAllClients, string ClientID)
{
    string Delete = "";
    stClientData ClientRecord;
    
    if (IsClientFound(vAllClients, ClientRecord, ClientID))
    {
        PrintClientRecord(ClientRecord);

        Delete = in::AskY_N("\nAre you sure you want to delete this account? y/n ?");
        
        if (Delete == "y" || Delete == "Y")
        {
            MarkClientForDelete(vAllClients, ClientID);
            UpdateClientsDataToFile(ClientsBase, vAllClients);

            cout << "\nClient Deleted Successfully." << endl;
        }
    }
    else
    {
        cout << "\nClient with Account Number (" << ClientID << ") was not found !!\n" << endl;
    }
}

void SearchAndDeleteClient()
{
    vector<stClientData> vAllClients = LoadDataFromFile(ClientsBase);
    string ClientID = in::ReadString("Please Enter Account Number:");

    DeleteClientFromFile(vAllClients, ClientID);
}

int main()
{

    SearchAndDeleteClient();


    return 0;
}