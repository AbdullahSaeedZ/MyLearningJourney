#include <iostream>
#include <vector>
#include <string>
#include <cctype>
#include "MyLib.h"
using namespace std;
using namespace MyLib;




string ReverseString(string str)
{
    vector<string> Vector = SplitStringToVector(str, " ");
    string Reversed = "";

    vector<string>::iterator itr = Vector.end();
    
    while (itr != Vector.begin())
    {
        itr--;

        Reversed += *itr + " ";
    }



    return Reversed.substr(0, Reversed.length() - 1);
    
}






int main()
{
    string str = "Im Abdullah from saudi";
    cout << "string: " << endl;
    cout << str << endl;


    cout << "\nstring reversed:" << endl;
    cout << ReverseString(str) << endl;





    return 0;

}

