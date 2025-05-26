#include <iostream>
using namespace std;

int main()
{
   
	short int LoanAmount, MonthlyPayment;

	cout << "Enter the loan amount and the monthly payment: " << endl;
	cin >> LoanAmount >> MonthlyPayment;

	short int TotalMonths = LoanAmount / MonthlyPayment;

	cout << "Loan will be settled in: " << TotalMonths << " Months." << endl;




	return 0;
}
