#include <iostream>
using namespace std;

int main()
{
    short int Penny, Nickel, Dime, Quarter, Dollar;

    cout << "Enter the money you have in Penny, Nickel, Dime, Quarter and Dollar : " << endl;
    cin >> Penny >> Nickel >> Dime >> Quarter >> Dollar;


    float TotalPennies = (Penny * 1) + (Nickel * 5) + (Dime * 10) + (Quarter * 25) + (Dollar * 100);
    float TotalDollars = TotalPennies / 100;
   

    cout << "Total in Pennies is: " << TotalPennies << endl;
    cout << "Total in Dollars is: " << TotalDollars << endl;

    return 0;
}

