#include <iostream>
#include <string>
using namespace std;

float ReadNumbers(string Message)
{
    int Number = 0;
    cout << Message << endl;
    cin >> Number;

    return Number;
}

float Sum()
{
    int Sum = 0, Counter = 1, Number = 0;

    do
    {
        Number = ReadNumbers("Enter Number " + to_string(Counter));

        if (Number == -99)
            break;

        Sum += Number;
        Counter++;

    } while (Number != -99);

    return Sum;
}




int main()
{
    
    cout << "Result is: " << Sum() << endl;
    

    return 0;
}

