#include <iostream>
#include "clsBankClient.h"
#include "clsInputValidate.h"
using namespace std;


void DeleteClient()
{
    clsBankClient ClientToDelete;
    string AcctNumber = clsInputValidate::ReadString("Enter Account Number:");

    while (!clsBankClient::IsClientExist(ClientToDelete, AcctNumber))
    {
        AcctNumber = clsInputValidate::ReadString("Account Number Does not Exist, Enter Account Number:");
    }

    ClientToDelete.Print();

    if (clsInputValidate::ReadBoolean("\nAre You sure You Want To Delete The Client ? Y / N : "))
    {
        ClientToDelete.Delete();
        
        cout << "\nClient Deleted Successfully!" << endl;
        ClientToDelete.Print();
    }

}


int main()
{
    
    
    DeleteClient();
    
    
    return 0;
}

