#include <iostream>
using namespace std;

enum NumberType { Even = 1, Odd = 2, All = 3};

int ReadNumber()
{
    int N;
    cout << "Enter a number to print sum of its numbers: " << endl;
    cin >> N;

    return N;
}

NumberType ReadWantedType()
{
    int Wanted;

     cout << "Enter the number of type you want to sum:" << endl;
     cout << "1-Even \n2-Odd \n3-All" << endl;
     cin >> Wanted;

     while ((Wanted != 1 && Wanted != 2) && Wanted != 3)
     {
         cout << "Wrong number, Choose from the menu:" << endl;
         cout << "1-Even \n2-Odd \n3-All" << endl;
         cin >> Wanted;
     }

    

    switch (Wanted)
    {
    case 1: return NumberType::Even;
    case 2: return NumberType::Odd;
    case 3: return NumberType::All;
    default: return NumberType::All;
    }
}

NumberType CheckNumberType(int Number)
{
    if (Number % 2 == 0)
        return NumberType::Even;
    else 
        return NumberType::Odd;
    
        

}

void CountingUsingForLoop(int N, NumberType Wanted)
{
    int SumOdd = 0;
    int SumEven = 0;
    
    for (int Counter = 1; Counter <= N; Counter++)
    {
        if (CheckNumberType(Counter) == NumberType::Odd)
        {
            SumOdd += Counter;
        }
        else 
        {
            SumEven += Counter;
        }
    }


    if (Wanted == NumberType::All)
    {
        cout << "Sum of all numbers is : " << SumOdd + SumEven << endl;
    } 
    else if (Wanted == NumberType::Even)
    {
        cout << "Sum of Even numbers is : " << SumEven << endl;
    }
    else 
    {
        cout << "Sum of Odd numbers is : " << SumOdd << endl;
    }
}


int main()
{
    int N = ReadNumber();
    NumberType WantedType = ReadWantedType();

    CountingUsingForLoop(N, WantedType);
  

    return 0;
}