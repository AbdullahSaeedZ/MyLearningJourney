#include <iostream>
using namespace std;


// in overloading two  functions with same name but different signatures and different code implementation.
// in template it is on function that takes different data types and do one operation(code implementation)



template <typename koko> // declare the template, this indicate that we want to take multiple data types under koko variable.
koko Add(koko Num1, koko Num2) // it take any data type.
{
    return Num1 + Num2;
}


int main()
{


    cout << Add<int>(3, 7) << endl; // here the <int> will replace all the koko variable inside the function.
    cout << Add<string>("abdullah ", "Alzahrani") << endl;
    return 0;
}

