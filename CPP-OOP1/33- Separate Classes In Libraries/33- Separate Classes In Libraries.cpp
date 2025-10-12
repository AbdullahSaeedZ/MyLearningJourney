#include <iostream>
#include "clsPerson.h"
#include "clsEmployee.h"
using namespace std;


// Add header -> class -> put the name and check inline.

int main()

{

    clsEmployee Employee1(10, "Abdullah", "Alzahrani", "A@a.com", "8298982", "CEO", "bbb", 5000);

    Employee1.Print();

    system("pause>0");
    return 0;
}