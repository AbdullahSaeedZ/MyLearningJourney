#include <iostream>
using namespace std;

int main()
{

    short int TotalBill;
    short int CashPaid;

    cout << "Please enter the total bill and the cash paid: " << endl;
    cin >> TotalBill >> CashPaid;

    short int PaidBack = CashPaid - TotalBill; // since we want remaining amount, it means the customer will pay more than the bill

    cout << "you will be paid back :" << PaidBack << endl;

    return 0;
}

