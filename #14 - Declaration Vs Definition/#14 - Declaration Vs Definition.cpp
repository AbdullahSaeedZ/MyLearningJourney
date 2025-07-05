#include <iostream>
using namespace std;

// function declaration: to tell the compiler that there is a function with that name but i will define it later 
void add(int, int);

int main()
{
    add(10, 20);

    return 0;
}


// function Definition
void add(int a, int b) 
{     
    cout << (a + b);
}
