#include <iostream>
using namespace std;

void ReadSales(int& Sales)
{
    cout << "Enter your total sales: " << endl;
    cin >> Sales;
}

void Commission(int Sales)
{
    if (Sales > 1000000)
    {
        cout << "Your commission is: " << Sales * 0.01 << endl;
    }
    else if (Sales > 500000)
    {
        cout << "Your commission is: " << Sales * 0.02 << endl;
    }
    else if (Sales > 100000)
    {
        cout << "Your commission is: " << Sales * 0.03 << endl;
    }
    else if (Sales > 50000)
    {
        cout << "Your commission is: " << Sales * 0.05 << endl;
    }
    else
    {
        cout << "Your commission is: 0" << endl;
    }
}


int main()
{
    
    int Sales;
    ReadSales(Sales);
    Commission(Sales);

    return 0;
}

