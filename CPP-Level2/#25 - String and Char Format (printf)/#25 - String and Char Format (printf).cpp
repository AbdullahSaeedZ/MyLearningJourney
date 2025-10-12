#include <iostream>
#include <string>
using namespace std;


int main()
{
    
    // printf is from C language, and it doesnt support strings, so to deal with strings we must write an array of char.

    char Name[] = "Abdullah Alxahrani";
    char SchoolName[] = "Programming Advices";

    printf("Dear %s, how are you? \n", Name);
    printf("Welcome to %s school! \n\n", SchoolName);

    // or we can use a function to cast from string to char

    string MyName = "Abdullah";

    printf("Hello %s ", MyName.c_str());
    

    char c = 'S';

    printf("Setting the width of c : %*c \n", 1, c);
    printf("Setting the width of c : %*c \n", 2, c);
    printf("Setting the width of c : %*c \n", 3, c);
    printf("Setting the width of c : %*c \n", 4, c);
    printf("Setting the width of c : %*c \n", 5, c);





    return 0;
}

