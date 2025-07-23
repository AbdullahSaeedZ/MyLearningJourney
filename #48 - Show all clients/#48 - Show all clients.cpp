#include <iostream>
#include <iomanip>
#include <vector>
#include <string>
#include <fstream>
#include "str.h"
using namespace str;
using namespace std;

const string ClientsDataBase = "Clients.txt";

struct stClientData
{
    string ID, PINCode, Name, Phone;
    double AcctBalance;
};

void Header(vector<stClientData> &vAllClients)
{
    cout << setw(70) << "Clients List ("<< vAllClients.size() << ") Clients(s)." << endl;
    cout << "\n--------------------------------------------------------------------------------------------------------------------------\n" << endl;
    cout << left << setw(20) << "| Account Number" << setw(20) << "| Pin Code" << setw(50) << "| Client Name" << setw(20) << "| Phone" << setw(20) << "| Balance" << endl;
    cout << "--------------------------------------------------------------------------------------------------------------------------\n" << endl;
}

vector<string> GetLinesToVector(const string FilePath)
{
    vector<string> vLines;
    fstream File;

    File.open(FilePath, ios::in);

    string Line;

    if (File.is_open())
    {
        while (getline(File, Line))
        {
            vLines.push_back(Line);
        }

        File.close();
    }

    return vLines;
}

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

vector<stClientData> JoinVctLinesToVctSrtuct()
{
    vector<string> ClientsLines = GetLinesToVector(ClientsDataBase);

    vector<stClientData> vAllClients;
    stClientData stOneClient;
    string strLine = "";

    for (string& line : ClientsLines)
    {
        strLine = line;
        stOneClient = ConvertDataLineToRecord(strLine, "#//#");
        vAllClients.push_back(stOneClient);
    }

    return vAllClients;
}

void PrintClients(vector<stClientData>& vAllClients)
{
    for (stClientData& ClientInfo : vAllClients)
    {
        cout  <<  "| " << setw(18) << ClientInfo.ID  << "| " << setw(18) << ClientInfo.PINCode << "| " << setw(48) << ClientInfo.Name << "| " << setw(18) << ClientInfo.Phone << "| " << ClientInfo.AcctBalance << endl;
    }
    cout << "\n--------------------------------------------------------------------------------------------------------------------------\n" << endl;
    
    
}

void ShowClientsFromFile()
{
    vector<stClientData> vAllClients = JoinVctLinesToVctSrtuct();
    Header(vAllClients);
    PrintClients(vAllClients);

}

int main()
{
    
    ShowClientsFromFile();


    return 0;
}

