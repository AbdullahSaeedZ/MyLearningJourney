#include <iostream>
#include "clsBankClient.h"
using namespace std;

int main()
{
    
    clsBankClient Client1 = clsBankClient::Find("A100");

    Client1.Print();

    cout << clsBankClient::IsClientExist("A10043");

    return 0;
}

