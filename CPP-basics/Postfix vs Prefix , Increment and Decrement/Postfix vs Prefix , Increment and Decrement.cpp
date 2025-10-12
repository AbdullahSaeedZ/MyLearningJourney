#include <iostream>
using namespace std;

int main()
{
    int A = 10;
    int B = A++; // postfix means that B will take value of A THEN A will be updated to increase by 1.

    cout << A << endl;
    cout << B << endl;
    

    cout << "========" << endl;

    int D = 10;
    int C = ++D; // prefix means that D is UPDATED FIRST by increasing 1 Then C will take the updated value. 

    cout << D << endl;
    cout << C << endl;
    
    cout << "========" << endl;

    int S = 10;
    int X = S--; // postfix means that B will take value of A THEN A will be updated to decrease by 1.

    cout << S << endl;
    cout << X << endl;


    cout << "========" << endl;

    int R = 10;
    int T = --R; // prefix means that D is UPDATED FIRST by decreasing 1 Then C will take the updated value. 

    cout << R << endl;
    cout << T << endl;


    return 0;
}

