#include <iostream>
#include <string>
using namespace std;
// include string library to use string conversion functions 


// when convertin from higher datatype to lower such as float to int , some data will be lost, but from lower to higher there wont be loss.

int main()
{
    
    int Num1;
    double Num2 = 18.99;

    Num1 = Num2; // this is called Implecit Conversion, the compiler will convert directly but it is not recommended, mah give errors.

    Num1 = (int)Num2;  // this is explicit conversion made by the user which is a better praactice.

    Num1 = int(Num2);  // this is another explicit conversion method using a function. 
    
    //======================= string conversions ==================

    string String1 = "2554";
    int Int1;
    
    Int1 = stoi(String1);  // stoi() is a function that means String TO Int.
    
    // or stof()  String TO Float

    double Double1 = stof(String1);

    // or stod()  String TO Double
    
    float Float1 = stof(String1);


    return 0;
}
