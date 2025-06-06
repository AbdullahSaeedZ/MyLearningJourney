//string is a variable that contains a collection of characters surrounded by double quotes.
//string is a Array of Characters

#include <iostream>
#include <string>
using namespace std;

int main()
{
    
    string MyString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    // MyString is an object that has functions inside it and one of them is the function to calculate length.

    cout << "the length of MyString is " << MyString.length() << endl; // this function will calculate length of characters inside the sting starting from 0
    cout << MyString[2] << endl; // this will print the char number 2 in the Mystring (starts from 0)


    string S1 = "10" ,S2 = "20";
    string S3 = S1 + S2;  // since S1 and S2 are strings then the will not be added as numbers, but the strings will be added next to each other (concatonation)
    cout << S3 << endl;


    short int Sum = stoi(S1) + stoi(S2); // to do the adding as numbers, convert strinng to int using the functions and assign to the Sum variable that is int.
    cout << Sum << endl;

    //==================================== spaces in strings with cin ======================

    /*for isolation
    string MyName; 
    cin >> MyName;
    cout << MyName << endl;
    */

    // i entered my full name, but it will only print my first name or both combined without a space inbetween.
    //to solve this issue we use the get.line() function which will read the whole line in the cin process and will print it as it is.
    
    string MyName;
    getline(cin, MyName);
    cout << MyName << endl;

    return 0;
}

