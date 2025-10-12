#include <iostream>
using namespace std;

float ReadPositiveNumber(string Message)
{
    float Number = 0;

    do
    {
        cout << Message << endl;
        cin >> Number;
    } while (Number < 0);

    return Number;
}

float CalculateRemainder(float Bill, float Paid)
{
    return Paid - Bill;
}

int main()
{
    float TotalBill = ReadPositiveNumber("Enter total bill:");
    float CashPaid = ReadPositiveNumber("Enter total cash paid:");

    cout << endl;
    cout << "Total bill is: " << TotalBill << endl;
    cout << "Total cash paid is: " << CashPaid << endl;

    cout << "**********************************" << endl;
    cout << "Remainder is: " << CalculateRemainder(TotalBill, CashPaid) << endl;

    return 0;
}

