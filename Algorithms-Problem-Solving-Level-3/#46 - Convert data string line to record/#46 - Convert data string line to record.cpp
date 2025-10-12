#include <iostream>
#include "MyLib.h"
using namespace std;
using namespace MyLib;

struct stClientData
{
    string ID, PINCode, Name, Phone;
    double AcctBalance;
};

stClientData ConvertDataLineToRecord(string Line, string Delim = "#//#")
{
    vector<string> Records = SplitStringToVector(Line, Delim);
    stClientData Client;

    Client.ID = Records[0];
    Client.PINCode = Records[1];
    Client.Name = Records[2];
    Client.Phone = Records[3];
    Client.AcctBalance = stod(Records[4]);
    
    return Client;
}


void PrintDataRecord(stClientData Client)
{
    cout << "Account ID: " << Client.ID << endl;
    cout << "Pin Code  : " << Client.PINCode << endl;
    cout << "Name      : " << Client.Name << endl;
    cout << "Phone     : " << Client.Phone << endl;
    cout << "Balance   : " << Client.AcctBalance << endl;
}
int main()
{
    string DataLine = "A150#//#1234#//#Abdullah Saeed#//#05435346#//#54353.000000";
    stClientData Client1 = ConvertDataLineToRecord(DataLine, "#//#");

    cout << "\n\nClient Record is:" << endl;
    cout << DataLine << endl;

    cout << "\nExtracted Client Record:" << endl;
    PrintDataRecord(Client1);



    return 0;
}

