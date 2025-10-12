#include <iostream>
using namespace std;


int main()
{
    
    int Mark = 90;
    string result; 
    
    //Using normal if statement:
    
    if (Mark >= 50) 
    {  
        result = "PASS";  
    }
    else 
    {   
        result = "FAIL";
    }      

    cout << result << endl; 

    //using ternary short hand IF:

    //condition    true code body   else code body
    (Mark >= 50) ? result = "Pass" : result = "Fail";       // in the body we can write any thing such as functions or any expression even nested ternary operator.


    cout << result << endl;

}

