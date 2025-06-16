#include <iostream>
using namespace std;

int ReadAge()
{
    int Age;
    cout << " Enter your Age: " << endl;
    cin >> Age;

    return Age;
}

bool CheckAgeValidity(int Age, int From, int To)
{
    return (Age >= From && Age <= To);
}

void PrintValidity(int Age)
{
    if (CheckAgeValidity(Age, 18, 45))
        cout << Age << " is a Valid Age!" << endl;
    else
        cout << Age << " is an Invalid Age!" << endl;

}


int main()
{
    PrintValidity(ReadAge());

    return 0;
}