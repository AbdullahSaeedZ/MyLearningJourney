#include <iostream>
using namespace std;

int ReadSales()
{
    int Sales = 0;
    cout << "Enter your total sales: " << endl;
    cin >> Sales;
    return Sales;
}

float CommissionPercentage(int Sales)
{
    
    if (Sales > 1000000)
        return 0.01;
    else if (Sales > 500000)
        return 0.02;
    else if (Sales > 100000)
        return 0.03;
    else if (Sales > 50000)
        return 0.05;
    else
        return 0.00;
}

float CalculateCommission(int Sales)
{
    return CommissionPercentage(Sales) * Sales;
}

void PrintCommission(int Sales)
{
    cout << "Your commission percentage is: " << CommissionPercentage(Sales)<< endl;
    cout << "Your Commission is: " << CalculateCommission(Sales) << endl;
}

int main()
{
    PrintCommission(ReadSales());

    return 0;
}

