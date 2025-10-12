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

float Installment(float LoanAmount, float MonthlyPayment)
{

    return LoanAmount / MonthlyPayment;
}


int main()
{
    float LoanAmount = ReadPositiveNumber("Enter the loan amount");
    float MonthlyPayment = ReadPositiveNumber("How much would you like to pay every month:");

    cout << "Loan will be finished in " << Installment(LoanAmount, MonthlyPayment) << " Months." << endl;

    return 0;
}

