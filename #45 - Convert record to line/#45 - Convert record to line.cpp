#include <iostream>
#include "MyLib.h"
using namespace std;
using namespace MyLib;

struct stClientData
{
    string ID, PINCode, Name, Phone;
    double AcctBalance;
};

stClientData ReadClientData()
{
    stClientData Client;
    cout << "Please fill Client data:\n" << endl;

    Client.ID = ReadString("Enter Account ID:");
    Client.PINCode = ReadString("Enter Pin Code:");
    Client.Name = ReadString("Enter Name:");
    Client.Phone = ReadString("Enter Phone Number:");
    Client.AcctBalance = ReadPositiveNumber("Enter Account Balance:");

    return Client;
}


string ConvertRecordToLine(stClientData Client1, string delim = "#//#")
{
    string str = "";

    str += Client1.ID + delim;
    str += Client1.Name + delim;
    str += Client1.PINCode + delim;
    str += Client1.Phone+ delim;
    str += to_string(Client1.AcctBalance);

    return str;
}


int main()
{
     
    stClientData Client1 = ReadClientData();

    cout << "\nClient Record for Saving is:" << endl;
    cout << ConvertRecordToLine(Client1) << endl;



    return 0;
}

