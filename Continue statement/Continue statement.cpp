#include <iostream>
using namespace std;

//void ReadInputs(int Array[5])
//{
//    for (int Counter = 0; Counter < 5; Counter++)
//    {
//        cout << "Enter a number: " << endl;
//        cin >> Array[Counter];
//
//    }
//}
//
//int Sum(int Array[5])
//{
//    int Sum = 0;
//    for (int Counter = 0; Counter < 5; Counter++)
//    {
//        if (Array[Counter] > 50) continue;
//       
//
//        Sum += Array[Counter];
//    }                                                  // this my solution, it has more code but i did it for fun.
//
//    return Sum;
//}

int main()
{
    /*int Array[5];

    ReadInputs(Array);
    cout << "the sum of numbers below 50 is: " << Sum(Array) << endl;
*/


    int Sum = 0;
    int Number = 0;
    for (int Counter = 1; Counter <= 5; Counter++)
    {

        cout << "Enter a number (5 numbers in total):";
        cin >> Number;

        if (Number > 50)
        {
            cout << "The number is greater than 50 and wont be calculated!" << endl;
            Counter--;
            continue;
        }

        Sum += Number;


    }

    cout << "The sum of numbers entered is: " << Sum << endl;


    return 0;
}
