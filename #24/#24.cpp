#include <iostream>
using namespace std;

enum AgeValidity {ValidAge = 1, InvalidAge = 2};

int ReadAge()
{
    int Age;
    cout << " Enter your Age: " << endl;
    cin >> Age;

    return Age;
}

AgeValidity CheckAgeValidity(int Age)
{
    if (Age >= 18 && Age <= 45)
        return AgeValidity::ValidAge;
    else
        return AgeValidity::InvalidAge;
}

void PrintValidity(AgeValidity CheckAgeValidity)
{
    if (CheckAgeValidity == AgeValidity::ValidAge)
        cout << "Valid Age!" << endl;
    else
        cout << "Invalid Age!" << endl;
}


int main()
{
    PrintValidity(CheckAgeValidity(ReadAge()));

    return 0;
}