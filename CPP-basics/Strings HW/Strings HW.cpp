#include <iostream>
#include <string>
using namespace std;

int main()
{
    
    string String1, String2, String3;
    cout << "Please enter string1 value: " << endl;  
    getline(cin, String1); // in any string with spaces we have to use this function
    cout << "Please enter string2 value: " << endl;
    cin >> String2;
    cout <<"Please enter string3 value: " << endl;
    cin >> String3;

    cout << "*****************" << endl;

    cout << "Length of String1 is: " << String1.length() << endl;
    cout << "Characters at 0,2,4,7 are: " << String1[0] << "," << String1[2] << "," << String1[4] << "," << String1[7] << endl;
    cout << "Concatenating String2 and string3 is: " << String2 + String3 << endl;

    short int Result = stoi(String2) * stoi(String3);
    cout << String2 << " * " << String3 << " = "<< Result;



    
    
    
    return 0;
}
