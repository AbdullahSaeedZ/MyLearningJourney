#include <iostream>
using namespace std;
// function is a block of code in my program that only work when i call it
// function are two types: procedural which doesnt return a value | a function which returns a value.
// always make functions that does one job only, for better code and ease of control.

void InfoCard()
{
    cout << "*******" << endl;
    cout << "Name: Abdullah \nAge: 27 \nCity: DMM\nCountry: SA" << endl;
    cout << "*******" << endl;
}

void Stars()
{
    cout << "*******" << endl;
    cout << "*******" << endl;
    cout << "*******" << endl;
    cout << "*******" << endl;
}

void LoveProgramming()
{
    cout << "I love programming\ni promise to be the best developer ever\ni know it...\nBest Regards,\nAbdullah Alzahrani" << endl;
}

void HStars()
{
    cout << "*     *\n";
    cout << "*     *\n";
    cout << "*******\n";
    cout << "*     *\n";
    cout << "*     *\n";
}


int main()
{
    // now we call our procedural function:

    InfoCard();
    HStars();
    LoveProgramming();


    return 0;
}

