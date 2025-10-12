#include <iostream>
#include "clsInputValidate.h"
using namespace std;


int main()
{
    
    int x;

    x = clsInputValidate::ReadIntNumber();

    cout << x << endl;

    return 0;
}

