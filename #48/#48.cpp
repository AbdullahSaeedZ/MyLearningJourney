#include <iostream>
using namespace std;

float ReadPositiveNumber(string Message)
{
    float Number = 0;

    cout << Message << endl;
    cin >> Number;

    while (Number < 0)
    {
        cout << "Wrong Number, enter a Positive Number:" << endl;
        cin >> Number;
    }

    return Number;
}

float Installment(float LoanAmount, float Months)
{

    return LoanAmount / Months;
}


int main()
{
    float LoanAmount = ReadPositiveNumber("Enter the loan amount");
    float Months = ReadPositiveNumber("How many months would you need to settle the loan:");

    cout << "Your monthly installment will be: " << Installment(LoanAmount, Months) << " Months." << endl;

    return 0;
}

