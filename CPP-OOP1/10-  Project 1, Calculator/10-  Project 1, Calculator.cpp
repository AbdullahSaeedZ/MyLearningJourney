#include <iostream>
using namespace std;

// all functions and variables are encapsulated inside this class, unlike FP, everything would be allover the place.


// i didnt use set and get here cuz the data members are not used by anyone outside the class, they are just used inside the class. this is my understanding for now.

class clsCalculator
{
private:

    float _Result = 0;
    float _NumEntered = 0;
    string _OpType = "Clearing";
    float _PreviousResult = 0;

    bool IsZero(float num)
    {
        return num == 0;
    }

public:

    void Clear()
    {
        _Result = 0;
        _NumEntered = 0;
        _PreviousResult = 0;
        _OpType = "Clearing ";
    }

    void Add(float num)
    {
        _PreviousResult = _Result;
        _Result += num;
        _NumEntered = num;
        _OpType = "Adding ";
    }

    void Subtract(float num)
    {
        _PreviousResult = _Result;
        _Result -= num;
        _NumEntered = num;
        _OpType = "Subtracting ";
    }

    void Divide(float num)
    {
        if (IsZero(num)) // bool function just to demo how to call a private function
            num = 1;

        _PreviousResult = _Result;
        _Result /= num;
        _NumEntered = num;
        _OpType = "Dividing ";
    }

    void Multiply(float num)
    {
        _PreviousResult = _Result;
        _Result *= num;
        _NumEntered = num;
        _OpType = "Multiplying ";
    }

    void CancelLastOperation()
    {
        _NumEntered = 0;
        _OpType = "Cancelling last operation ";
        _Result = _PreviousResult;
    }

    void PrintResult()
    {
        cout << "Result after " << _OpType << _NumEntered << " : " << _Result << endl;
    }



};



int main()
{
    
    clsCalculator Calculator1;

    Calculator1.Clear();
    
    Calculator1.Add(10);
    Calculator1.PrintResult();
    
    Calculator1.Subtract(4);
    Calculator1.PrintResult();

    Calculator1.CancelLastOperation();
    Calculator1.PrintResult();

    Calculator1.Divide(0);
    Calculator1.PrintResult();
    
    Calculator1.Add(100);
    Calculator1.PrintResult();
    
    Calculator1.Divide(5);
    Calculator1.PrintResult();

    Calculator1.Clear();
    Calculator1.PrintResult();


    return 0;
}
