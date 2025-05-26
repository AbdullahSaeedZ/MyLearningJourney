#include <iostream>
using namespace std;


int main()
{
    
    short int LoanAmount, Months;

    cout << "Enter the loan amount and how many months for installments:" << endl;
    cin >> LoanAmount >> Months;

    short int Payment = LoanAmount / Months;

    cout << "Your monthly amount will be: " << Payment << " SAR per month." << endl;





    return 0;
}
