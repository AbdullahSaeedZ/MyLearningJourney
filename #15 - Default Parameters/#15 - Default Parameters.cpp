#include <iostream>
using namespace std;




// a and b are required parameters that needed to be used in the function.
// c and d are called Default parameters which means they are optional, if we put them then the function will use them otherwise the function will use the DEfAULT values of them.
// we can assign any value as default not only 0.
// when declaring default parameters, there shoulnt be any required parameters after them, meaning they must be the last parameters.

int MySum(int a, int b, int c = 0, int d = 0) 
{ 
    return (a + b + c + d); 
}



int main()
{
    cout << MySum(10, 20) << endl;
    cout << MySum(10, 20, 30) << endl; 
    cout << MySum(10, 20, 30, 40) << endl; 


    return 0;
}

