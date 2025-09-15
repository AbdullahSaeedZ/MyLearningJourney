#include <iostream>
#include "clsCurrencies.h"
using namespace std;



int main()
{
    
    clsCurrencies c1 = c1.Find("Saudi riyal");

    c1.UpdateRate(3.99);

    if (c1.IsEmpty())
    {
        cout << "not found" << endl;
    }
    else
    {
        cout << "Rate: " << c1.getCurrencyRate() << endl;
    }


    return 0;
}