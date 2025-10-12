#include <iostream>
using namespace std;


void ReadAge(short int& Age)
{
    cout << "Enter your Age" << endl;
    cin >> Age;
}


void CheckAge(int short Age)
{
    if ((Age >= 18) && (Age <= 45))
    {
        cout << "Valid Age" << endl;
    }
    else
    {
        cout << "Invalid Age" << endl;
    }

}

int main()
{
    short int Age;
    ReadAge(Age);
    CheckAge(Age);
}

