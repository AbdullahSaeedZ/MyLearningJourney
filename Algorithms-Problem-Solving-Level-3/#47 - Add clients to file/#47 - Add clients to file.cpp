#include <iostream>
#include <string>
#include <fstream>
using namespace std;


const string ClientsDataBase = "Clients.txt";

struct stClientData
{
    string ID, PINCode, Name, Phone;
    double AcctBalance;
};

stClientData ReadClientData()
{
    stClientData Client;
    cout << "Enter Account Number? "; // Usage of std::ws will extract all the whitespace character  
    getline(cin >> ws, Client.ID);

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

void AddDataLineToFile(string FilePath, string strDataLine)
{
    fstream DataBase;

    DataBase.open(FilePath, ios::out | ios::app);

    if (DataBase.is_open())
    {
        DataBase << strDataLine << endl;
    }

    DataBase.close();
}

void AddNewClient()
{
    stClientData Client = ReadClientData();

    AddDataLineToFile(ClientsDataBase, ConvertRecordToLine(Client, "#//#"));
}

void AddClients()
{
    
    char Again = 'Y';

    do
    {
        cout << "Adding New Client:\n" << endl;

        AddNewClient();

        cout << "\nClient added, do you want to add new clients?" << endl;
        cin >> Again;

        system("cls");

    } while (toupper(Again) == 'Y');
}

int main()
{
    
    AddClients();



    return 0;
}

