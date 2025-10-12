#include <iostream>
using namespace std;

int ReadInputs(int Numbers)
{
    cout << "Enter Numbers to add their sum (Enter -99 to stop): " << endl;
    cin >> Numbers;

    int Sum = 0;

     while (Numbers != -99)
         {

            Sum = Sum + Numbers;
            
            cout << "Enter another Number: " << endl;
            cin >> Numbers;
         }

    return Sum;
}


int main()
{
    int Numbers = 0;

    cout << "Sum is: " << ReadInputs(Numbers) << endl;



    return 0;
}

