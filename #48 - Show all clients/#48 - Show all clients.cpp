#include <iostream>
#include <iomanip>
#include <vector>
#include <string>
#include <fstream>
#include "str.h"
using namespace str;
using namespace std;

const string ClientsDataBase = "Clients.txt";

struct stClientRecords
{
    string ID, PINCode, Name, Phone;
    double AcctBalance;
};

void Header(vector<stClientRecords> &vAllClients)
{
    cout << setw(70) << "Clients List ("<< vAllClients.size() << ") Clients(s)." << endl;
    cout << "\n--------------------------------------------------------------------------------------------------------------------------\n" << endl;
    cout << left << setw(20) << "| Account Number" << setw(20) << "| Pin Code" << setw(50) << "| Client Name" << setw(20) << "| Phone" << setw(20) << "| Balance" << endl;
    cout << "--------------------------------------------------------------------------------------------------------------------------\n" << endl;
}

stClientRecords ConvertDataLineToRecord(string Line, string Delim = "#//#")
{
    vector<string> Records = str::SplitStringToVector(Line, Delim);
    stClientRecords Client;

    Client.ID = Records[0];
    Client.Name = Records[1];
    Client.PINCode = Records[2];
    Client.Phone = Records[3];
    Client.AcctBalance = stod(Records[4]);

    return Client;
}

vector<stClientRecords> LoadClientsDataFromFile(string FilePath)
{
    vector<stClientRecords> vAllClients;
    vector<string> vLines;
    fstream File;

    File.open(FilePath, ios::in);
    if (File.is_open())
    {
        stClientRecords stOneClient;
        string strLine = "";

        while (getline(File, strLine))
        {
            stOneClient = ConvertDataLineToRecord(strLine);
            vAllClients.push_back(stOneClient);
        }

        File.close();
    }


    return vAllClients;
}

void PrintClients(vector<stClientRecords>& vAllClients)
{
    for (stClientRecords& ClientInfo : vAllClients)
    {
        cout << "| " << setw(18) << ClientInfo.ID;
        cout << "| " << setw(18) << ClientInfo.PINCode;
        cout << "| " << setw(48) << ClientInfo.Name;
        cout << "| " << setw(18) << ClientInfo.Phone;
        cout << "| " << ClientInfo.AcctBalance << endl;
    }
    cout << "\n--------------------------------------------------------------------------------------------------------------------------\n" << endl;
    
    
}

void ShowClientsFromFile()
{
    vector<stClientRecords> vAllClients = LoadClientsDataFromFile(ClientsDataBase);
    Header(vAllClients);
    PrintClients(vAllClients);

}

int main()
{
    
    ShowClientsFromFile();


    return 0;
}

