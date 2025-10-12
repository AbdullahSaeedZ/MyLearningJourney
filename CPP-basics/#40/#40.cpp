#include <iostream>
using namespace std;

int main()
{
    
    short int BillValue;

    cout << "Enter the bill amount: " << endl;
    cin >> BillValue;

    float TotalBill = BillValue * 1.1;
    TotalBill = TotalBill * 1.16;

    cout << "Your total bill is: " << TotalBill << endl;


    return 0;
}
