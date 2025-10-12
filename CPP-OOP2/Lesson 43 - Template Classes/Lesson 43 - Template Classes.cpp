#include <iostream>
using namespace std;

// this is the way vectors are made.


template <class T>
class Calculator
{
private:

    T Num1;
    T Num2;

public:

    Calculator(T Number1, T Number2)
    {
        Num1 = Number1;
        Num2 = Number2;
    }

    T Add()
    {
        return Num1 + Num2;
    }

    T Multiply()
    {
        return Num1 * Num2;
    }

    void PrintResults()
    {
        cout << "Number1 : " << Num1 << endl;
        cout << "Number2 : " << Num2 << endl;
        cout << "Addition Result: " << Add() << endl;
    }



};


int main()
{
    
    Calculator <int> IntObject(1, 2); 

    Calculator <float> FloatObject(1.5, 2.4);

    IntObject.PrintResults();
    
    FloatObject.PrintResults();
    
    
    
    return 0;
}

