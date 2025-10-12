#include <iostream>
#include <string>
using namespace std;

// int Num1; 
// - 'int' is a primitive data type in C++.
// - 'Num1' is the variable that holds an integer value.

// In C++, some data types are actually classes that define objects.
// Example: string s1;
// - 'string' is a data type, but it's also a class in the C++ Standard Library.
// - The class 'string' has member functions (methods) and properties.
// - 's1' is the variable name, and it's also the object of the 'string' class.

//Primitive types = built - in, no methods. (like int, char, double)
//Class types = user-defined or library-defined, have methods. (like string, vector)
//Object = instance of a class (the thing made of the class)

 
  

int main()  
{  
    string s1 = "My name is Abdullah, I love programming.";  

    // prints the length of the string  
    cout << s1.length() << endl;  // .length() is a method (the function or procedure inside the class).  

    // returns letter at position 3  
    cout << s1.at(3) << endl;  

    // adds to the end of the string  
    s1.append("@programmingAdvices.");  
    cout << s1 << endl;  

    // inserts " Abood " at position 7  
    s1.insert(7, " Ali ");  
    cout << s1 << endl;

    // print all the next 8 letters from position 16
    cout << s1.substr(16, 8) << endl;

    //adds one character to the end of string
    s1.push_back(' X ');
    cout << s1 << endl;

    // removes one character from the end of the string
    s1.pop_back();
    cout << s1 << endl;

    // finds Ali in the string and give the posiotion
    cout << s1.find(" Ali ") << endl;

    // finds Abood in the string, if not found, it will give a ling number which represent false
    cout << s1.find(" Abood ") << endl;

    if (s1.find(" Abood ") == s1.npos)  //instead of dealing with that long number, use .npos to represent it. (it means no position)
    {
        cout << "Abood was not found" << endl;
    }

    return 0;  
}

