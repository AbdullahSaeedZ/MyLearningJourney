#include <iostream>
#include <vector>
#include <fstream>
#include <iomanip>
#include "in.h"
#include "str.h"
using namespace std;

const string ClientBase = "Clients.txt";
const string UserBase = "Users.txt";

//in bits for bitwise
enum enPermission { pShowClients = 1, pAddClient = 2, pDeleteClient = 4, pUpdateClient = 8, pFindClient = 16, pTransaction = 32, pManageUsers = 64 };
enum enChoice { eShowList = 1, eAddClient = 2, eDeleteClient = 3, eUpdateClient = 4, eFindClient = 5, eTransaction = 6, eManageUsers = 7, eLogout = 8 };
enum enTransChoice { Deposit = 1, Withdraw = 2, TotalBalances = 3, BackToMenu = 4 };
enum enManageOption { eListUser = 1, eAddUser = 2, eDeleteUser = 3, eUpdateUser = 4, eFindUser = 5, eMainMenu = 6 };

struct stClientData
{
    string ID, PINCode, Name, Phone;
    double AcctBalance;
    bool MarkForDelete = false;
};
struct stUser
{
    string UserName = "";
    string Password = "";
    short Permission = 0;
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

void ShowMenu(string UserName)
{
    system("cls");
    cout << "Current User: " << UserName << endl;
    cout << "===========================================" << endl;
    cout << "             Main Menu Screen" << endl;
    cout << "===========================================" << endl;
    cout << left << setw(30) << "[1] Show Clients List." << endl;
    cout << setw(30) << "[2] Add New Client." << endl;
    cout << setw(30) << "[3] Delete Client." << endl;
    cout << setw(30) << "[4] Update Client Info." << endl;
    cout << setw(30) << "[5] Find Client." << endl;
    cout << setw(30) << "[6] Transaction." << endl;
    cout << setw(30) << "[7] Manage Users." << endl;
    cout << setw(30) << "[8] Logout." << endl;
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


void TransactionScreen(string Username)
{
    cout << "Current User: " << Username << endl;
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

void TransactionProcess(vector<stClientData>& vAllClients, string Username)
{
    short Choice;

    do
    {
        system("cls");
        TransactionScreen(Username);
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


    } while (Choice != enTransChoice::BackToMenu);


}






void LoginHeader()
{
    cout << "\n--------------------------------" << endl;
    cout << "           Login Screen" << endl;
    cout << "--------------------------------\n";
}

bool IsUserFound(vector<stUser>& vAllUsers, stUser& User)
{
    for (stUser& record : vAllUsers)
    {
        if (record.UserName == User.UserName && record.Password == User.Password)
        {
            User = record;
            return true;
        }
    }
    return false;
}

stUser ReadAndValidateLogin(vector<stUser> vAllUsers)
{
    LoginHeader();

    stUser User;
    cout << "Enter User Name: "; // Usage of std::ws will extract all the whitespace character  
    getline(cin >> ws, User.UserName);

    cout << "Enter Password: ";
    getline(cin, User.Password);

    while (!IsUserFound(vAllUsers, User))
    {
        system("cls");
        LoginHeader();
        cout << "Invalid UserName/Password!" << endl;
        cout << "Enter User Name: ";
        getline(cin, User.UserName);
        cout << "Enter Password: ";
        getline(cin, User.Password);
    }
    return User;
}

string ConvertUserRecordToLine(stUser User1, string delim = "#//#")
{
    string str = "";

    str += User1.UserName + delim;
    str += User1.Password + delim;
    str += to_string(User1.Permission);

    return str;
}

stUser ConvertUserLineToRecord(string Line, string Delim = "#//#")
{
    vector<string> Records = str::SplitStringToVector(Line, Delim);
    stUser User;

    User.UserName = Records[0];
    User.Password = Records[1];
    User.Permission = stoi(Records[2]);

    return User;
}

vector<stUser> LoadUsersFromFile(string FilePath)
{
    vector<stUser> vAllUsers;
    fstream File;

    File.open(FilePath, ios::in);

    if (File.is_open())
    {
        string Line = "";
        stUser Record;

        while (getline(File, Line))
        {
            Record = ConvertUserLineToRecord(Line);
            vAllUsers.push_back(Record);
        }

        File.close();
    }

    return vAllUsers;
}


void ShowManageMenu(string Username)
{
    system("cls");
    cout << "Current User: " << Username << endl;
    cout << "===========================================" << endl;
    cout << "             Manage Users Menu Screen" << endl;
    cout << "===========================================" << endl;
    cout << left << setw(30) << "[1] List Users." << endl;
    cout << setw(30) << "[2] Add New User." << endl;
    cout << setw(30) << "[3] Delete User." << endl;
    cout << setw(30) << "[4] Update User." << endl;
    cout << setw(30) << "[5] Find User." << endl;
    cout << setw(30) << "[6] Main Menu." << endl;
    cout << "===========================================" << endl;
}

void ShowUsersList(const vector<stUser>& vAllUsers)
{
    cout << "--------------------------------------------------------------------------------------------------------------------------\n" << endl;
    cout << "                                        Users List (" << vAllUsers.size() << ") Users(s)." << endl;
    cout << "\n--------------------------------------------------------------------------------------------------------------------------" << endl;
    cout << "| " << setw(22) << "User Name"
        << "| " << setw(18) << "Password"
        << "| " << setw(18) << "Permission" << endl;
    cout << "--------------------------------------------------------------------------------------------------------------------------\n" << endl;

    for (const stUser& UserInfo : vAllUsers)
    {
        cout << "| " << setw(22) << UserInfo.UserName
            << "| " << setw(18) << UserInfo.Password
            << "| " << setw(18) << UserInfo.Permission << endl;

        
    }
    cout << "\n--------------------------------------------------------------------------------------------------------------------------\n" << endl;
}


bool IsUserNameFound(const vector<stUser>& vAllUsers, string UserName)
{
    for (const stUser& record : vAllUsers)
    {
        if (record.UserName == UserName)
        {
            return true;
        }
    }
    return false;
}

short GivePermission()
{
    short Permission = 0;

    string Full = in::ReadString("\nDo you want to give full access ? y / n ?");
    if (Full == "y" || Full == "Y")
    {
        return Permission = -1;
    }
    else
    {
        string ShowCient = in::ReadString("\nDo you want to give access to Show Clients ? y / n ?");
        if (ShowCient == "y" || ShowCient == "Y")
        {
            Permission = Permission | enPermission::pShowClients;
        }

        string AddClient = in::ReadString("\nDo you want to give access to Add New Clients ? y / n ?");
        if (AddClient == "y" || AddClient == "Y")
        {
            Permission = Permission | enPermission::pAddClient;
        }

        string DeleteClient = in::ReadString("\nDo you want to give access to Delete Clients ? y / n ?");
        if (DeleteClient == "y" || DeleteClient == "Y")
        {
            Permission = Permission | enPermission::pDeleteClient;
        }

        string UpdateClients = in::ReadString("\nDo you want to give access to Update Clients ? y / n ?");
        if (UpdateClients == "y" || UpdateClients == "Y")
        {
            Permission = Permission | enPermission::pUpdateClient;
        }

        string FindClient = in::ReadString("\nDo you want to give access to Find Clients ? y / n ?");
        if (FindClient == "y" || FindClient == "Y")
        {
            Permission = Permission | enPermission::pFindClient;
        }

        string Transactions = in::ReadString("\nDo you want to give access to Transactions ? y / n ?");
        if (Transactions == "y" || Transactions == "Y")
        {
            Permission = Permission | enPermission::pTransaction;
        }

        string Managing = in::ReadString("\nDo you want to give access to Manage Clients ? y / n ?");
        if (Managing == "y" || Managing == "Y")
        {
            Permission = Permission | enPermission::pManageUsers;
        }
    }

    return Permission;
}

stUser ReadNewUser(const vector<stUser>& vAllUsers)
{
    stUser User;
    cout << "Enter User Name: "; // Usage of std::ws will extract all the whitespace character  
    getline(cin >> ws, User.UserName);

    while (IsUserNameFound(vAllUsers, User.UserName))
    {
        cout << "User with [" << User.UserName << "] Already Exists!" << endl;
        cout << "Enter Another User Name: ";
        getline(cin, User.UserName);
    }

    cout << "Enter Password: ";
    getline(cin, User.Password);

    User.Permission = GivePermission();

    return User;
}

void AddUserHeader()
{
    cout << "\n--------------------------------" << endl;
    cout << "       Add New User Screen" << endl;
    cout << "--------------------------------\n";
}

void AddNewUserProcess(vector<stUser>& vAllUsers)
{
    string Again = "";
    fstream File;
    File.open(UserBase, ios::out | ios::app);

    do
    {
        system("cls");
        AddUserHeader();

        if (File.is_open())
        {
            stUser NewUser = ReadNewUser(vAllUsers);
            string Line = ConvertUserRecordToLine(NewUser);
            File << Line << endl;

        }

        cout << "\nUser Added Successfully !" << endl;

        vAllUsers = LoadUsersFromFile(UserBase);

        Again = in::AskY_N("\nDo you want to add more Users? y/n?");

    } while (Again == "y" || Again == "Y");

    File.close();
}


void PrintUserRecord(stUser User)
{
    cout << "\n--------------------------------" << endl;
    cout << "Username  : " << User.UserName << endl;
    cout << "Password  : " << User.Password << endl;
    cout << "Permission: " << User.Permission << endl;
    cout << "--------------------------------\n" << endl;
}

void DeleteUserHeader()
{
    cout << "\n--------------------------------" << endl;
    cout << setw(50) << "Delete User Screen" << endl;
    cout << "--------------------------------\n" << endl;
}

void MarkUserForDelete(vector<stUser>& vAllUsers, string UserName)
{
    for (stUser& record : vAllUsers)
    {
        if (record.UserName == UserName)
        {
            record.MarkForDelete = true;
            break;
        }
    }
}

void UpdateUsersAfterDelete(vector<stUser>& vAllUsers, string UserName)
{
    string Line = "";
    fstream File;
    File.open(UserBase, ios::out);

    if (File.is_open())
    {
        for (stUser& record : vAllUsers)
        {
            if (record.MarkForDelete == false)
            {
                Line = ConvertUserRecordToLine(record);
                File << Line << endl;
            }
        }

        File.close();
    }
}

void DeleteOneUser(vector<stUser>& vAllUsers, string UserName)
{
    MarkUserForDelete(vAllUsers, UserName);
    UpdateUsersAfterDelete(vAllUsers, UserName);
}

bool IsUserNameFound(const vector<stUser>& vAllUsers, string UserName, stUser &ToBeFilled)
{
    for (const stUser& record : vAllUsers)
    {
        if (record.UserName == UserName)
        {
            ToBeFilled = record;
            return true;
        }
    }
    return false;
}

void DeleteUserProcess(vector<stUser>& vAllUsers)
{
    stUser User;
    string Again = "";
    string sure = "";
    string UserName = "";
    

    do
    {
        system("cls");
        DeleteUserHeader();

        UserName = in::ReadString("\nPlease enter Username: ");

        if (UserName == "Admin")
        {
            cout << "\nAdmin Cannot be Deleted!" << endl;
            break;
        }

        if (IsUserNameFound(vAllUsers, UserName, User))
        {
            PrintUserRecord(User);

            sure = in::AskY_N("\nAre you sure you want to delete this User ? y/n ? ");
            if (sure == "y" || sure == "Y")
            {
                DeleteOneUser(vAllUsers, UserName);
                vAllUsers = LoadUsersFromFile(UserBase);
                cout << "\nUser Deleted Successfully !" << endl;
            }
        }
        else
        {
            cout << "\nUser with this Username Doesn`t exist !" << endl;
        }


        Again = in::AskY_N("\nDo you want to delete other Users? y/n?");

    } while (Again == "y" || Again == "Y");

}


void UpdateUserHeader()
{
    cout << "\n--------------------------------" << endl;
    cout << "    Update User Info Screen" << endl;
    cout << "--------------------------------\n";
}

stUser ReadUserRecordUpdate(string UserName)
{
    stUser User;

    User.UserName = UserName;

    cout << "Enter New Password? ";
    getline(cin >> ws, User.Password);

    User.Permission = GivePermission();

    return User;
}

void UpdateOneUser(vector<stUser>& vAllUsers, string UserName)
{
    for (stUser& record : vAllUsers)
    {
        if (record.UserName == UserName)
        {
            record = ReadUserRecordUpdate(UserName);
            break;
        }
    }
}

void LoadVectorToFile(vector<stUser>& vAllUsers)
{
    string Line = "";
    fstream File;
    File.open(UserBase, ios::out);

    if (File.is_open())
    {
        for (stUser& record : vAllUsers)
        {
            Line = ConvertUserRecordToLine(record);
            File << Line << endl;
        }

        File.close();
    }
}

void UpdateUserProcess(vector<stUser>& vAllUsers)
{
    stUser User;
    string Again = "";
    string sure = "";
    string UserName = "";

    do
    {
        system("cls");
        UpdateUserHeader();

        UserName = in::ReadString("\nPlease enter Username: ");
        if (IsUserNameFound(vAllUsers, UserName, User))
        {
            cout << "\nUser Details: " << endl;
            PrintUserRecord(User);

            sure = in::AskY_N("\nAre you sure you want to update this User ? y/n ? ");
            if (sure == "y" || sure == "Y")
            {
                UpdateOneUser(vAllUsers, UserName);
                LoadVectorToFile(vAllUsers);
                vAllUsers = LoadUsersFromFile(UserBase);
                cout << "\nUser Info Updated Successfully !" << endl;
            }
        }
        else
        {
            cout << "\nUser with this Username Doesn`t exist !" << endl;
        }


        Again = in::AskY_N("\nDo you want to update other Users info? y/n?");

    } while (Again == "y" || Again == "Y");

}



void FindUserHeader()
{
    cout << "\n--------------------------------" << endl;
    cout <<  "     Find User Screen" << endl;
    cout << "--------------------------------\n";
}

void ShowUserInfoProcess(vector<stUser>& vAllUsers)
{
    stUser User;
    string Again = "";
    string UserName = "";

    do
    {
        system("cls");
        FindUserHeader();

        UserName = in::ReadString("\nPlease enter Username: ");
        if (IsUserNameFound(vAllUsers, UserName, User))
        {
            cout << "\nUser Details: " << endl;
            PrintUserRecord(User);
        }
        else
        {
            cout << "\nUser with this Username Doesn`t exist !" << endl;
        }


        Again = in::AskY_N("\nDo you want to find other Users info? y/n?");

    } while (Again == "y" || Again == "Y");
}


void ManageUsersProcess(vector<stUser>& vAllUsers, string Username)
{
    short Choice = 0;
    do
    {
        system("cls");
        ShowManageMenu(Username);
        Choice = in::ReadPositiveNumInRange("Choose what to do from the list [1 to 6]: ", 1, 6);

        if (Choice == enManageOption::eListUser)
        {
            system("cls");
            ShowUsersList(vAllUsers);
            system("pause");
        }
        else if (Choice == enManageOption::eAddUser)
        {
            system("cls");
            AddNewUserProcess(vAllUsers);
            system("pause");
        }
        else if (Choice == enManageOption::eDeleteUser)
        {
            system("cls");
            DeleteUserProcess(vAllUsers);
            system("pause");
        }
        else if (Choice == enManageOption::eUpdateUser)
        {
            system("cls");
            UpdateUserProcess(vAllUsers);
            system("pause");
        }
        else if(Choice == enManageOption::eFindUser)
        {
            system("cls");
            ShowUserInfoProcess(vAllUsers);
            system("pause");
        }
        else
        {
            break;
        }
        

    } while (Choice != enManageOption::eMainMenu);
}



void PrintDeniedAccess()
{
    cout << "Access denied!" << endl;
    cout << "You have no permission to access this option." << endl;
    cout << "Contact the Admin for more info." << endl;
}

bool HasPermission(short Permission, enPermission Access)
{
    return (Permission == -1) || (Permission & Access);
}

void StartProgram(vector<stUser>& vAllUsers, stUser User)
{
    vector<stClientData> vAllClients = LoadDataFromFile(ClientBase);
    short Choice = 0;

    do
    {
        system("cls");
        ShowMenu(User.UserName);
        Choice = in::ReadPositiveNumInRange("Choose what to do from the list [1 to 8]: ", 1, 8);

        if (Choice == enChoice::eShowList)
        {
            if (HasPermission(User.Permission, enPermission::pShowClients))
            {
                system("cls");
                ShowClientsList(vAllClients);
                system("pause");
            }
            else
            {
                system("cls");
                PrintDeniedAccess();
                system("pause");
            }
        }
        else if (Choice == enChoice::eAddClient)
        {
            if (HasPermission(User.Permission, enPermission::pAddClient))
            {
                system("cls");
                AddNewClient(vAllClients);
                system("pause");
            }
            else
            {
                system("cls");
                PrintDeniedAccess();
                system("pause");
            }
        }
        else if (Choice == enChoice::eDeleteClient)
        {
            if (HasPermission(User.Permission, enPermission::pDeleteClient))
            {
                system("cls");
                DeleteClientProcess(vAllClients);
                system("pause");
            }
            else
            {
                system("cls");
                PrintDeniedAccess();
                system("pause");
            }
        }
        else if (Choice == enChoice::eUpdateClient)
        {
            if (HasPermission(User.Permission, enPermission::pUpdateClient))
            {
                system("cls");
                UpdateClientInfo(vAllClients);
                system("pause");
            }
            else
            {
                system("cls");
                PrintDeniedAccess();
                system("pause");
            }
        }
        else if (Choice == enChoice::eFindClient)
        {
            if (HasPermission(User.Permission, enPermission::pFindClient))
            {
                system("cls");
                ShowClientInfo(vAllClients);
                system("pause");
            }
            else
            {
                system("cls");
                PrintDeniedAccess();
                system("pause");
            }
        }
        else  if (Choice == enChoice::eTransaction)
        {
            if (HasPermission(User.Permission, enPermission::pTransaction))
            {
                system("cls");
                TransactionProcess(vAllClients, User.UserName);
            }
            else
            {
                system("cls");
                PrintDeniedAccess();
                system("pause");
            }
        }
        else if (Choice == enChoice::eManageUsers)
        {
            if (HasPermission(User.Permission, enPermission::pManageUsers))
            {
                system("cls");
                ManageUsersProcess(vAllUsers, User.UserName);
            }
            else
            {
                system("cls");
                PrintDeniedAccess();
                system("pause");
            }
        }
        else
        {
            break;
        }
      
    } while (Choice != enChoice::eLogout);

}

void Login()
{
    bool KeepRunning = true;
    vector<stUser> vAllUsers = LoadUsersFromFile(UserBase);

    do
    {
        system("cls");
        stUser User;

        User = ReadAndValidateLogin(vAllUsers);

        StartProgram(vAllUsers, User);


    } while (KeepRunning);
}


int main()
{

    Login();


    return 0;
}

