#include <iostream>
using namespace std;


int main()
{

    // printf is a better way for formatting instead of cout.
    
    int Page = 1, TotalPages = 10;

    // printing string with int variables:

    printf("The page number is %d \n", Page);
    printf("You are in page %d of %d \n", Page, TotalPages);

    //width specification 00 or 000 and so on:
    printf("the page number is %0*d \n", 2, Page);
    printf("the page number is %0*d \n", 3, Page);
    printf("the page number is %0*d \n", 4, Page);
    printf("the page number is %0*d \n", 5, Page);


    int number1 = 1, number2 = 2;                          //can put any expression
    printf("result of %d + %d is %d \n", number1, number2, number1 + number2);

    return 0;
}


// %0*d means:
// % = start printing 
// 0 = replace empty spaces with zeros
// * = width of spaces will come from outside value
// d = print a decimal number (from 0 to 9)

// example:
// * = 4 , will print 4 spaces
// d = 7, will print this number.
// 0 = empty spaces wil be shown as zeros.
// result will be 0007