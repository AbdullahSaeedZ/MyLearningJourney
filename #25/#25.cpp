#include <iostream>
using namespace std;

int ReadAge()
{
    int Age;

        cout << " Enter your Age (from 18 to 45): " << endl;
        cin >> Age;

    return Age;
}


bool CheckAgeValidity(int Age, int From, int To)   // this function can be used any where to validate a number in range for any purpose in any program (reusability)
{
    return (Age >= From && Age <= To);
}

int ReadUntilInRange(int From, int To)
{
    int Age = 0;
    do
    {
       Age = ReadAge();

    } while (!CheckAgeValidity(Age, From, To));     /*note that is used NOT sign (!) to make the function false when i get true value in order to exit the loop when i get age between 18 - 45.
                                                      otherwise when i get true value the loop will continue. */

    return Age;

}

void PrintValidity(int Age)
{
    cout << "Your Age is " << Age << endl;        // here the age will come checked and ready to be printed.
}


int main()
{
    PrintValidity(ReadUntilInRange(18, 45));

    return 0;
}