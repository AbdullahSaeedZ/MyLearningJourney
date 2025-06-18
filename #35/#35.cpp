#include <iostream>
using namespace std;

struct stBankContent
{
    int Penny;
    int Nickel;
    int Dime;
    int Quarter;
    int Dollar;
};

stBankContent ReadContent()
{
    stBankContent Content;

    cout << "Enter how many Pennies: " << endl;
    cin >> Content.Penny;
    cout << "Enter how many Nickels:" << endl;
    cin >> Content.Nickel;
    cout << "Enter how many Dimes:" << endl;
    cin >> Content.Dime;
    cout << "Enter how many Quarters:" << endl;
    cin >> Content.Quarter;
    cout << "Enter how many Dollars:" << endl;
    cin >> Content.Dollar;

    return Content;
}

int CalculateTotalPennies(stBankContent Content)
{
    int TotalPennies = Content.Penny * 1 + Content.Nickel * 5 + Content.Dime * 10 + Content.Quarter * 25 + Content.Dollar * 100;

    return TotalPennies;
}



int main()
{
    int TotalPennies = CalculateTotalPennies(ReadContent());

    cout << "Total Pennies: " << TotalPennies << endl;
    cout << "Total Dollars: " << (float)TotalPennies / 100 << endl;

    return 0;
}
