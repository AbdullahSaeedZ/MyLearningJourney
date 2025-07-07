#include <iostream>
using namespace std;


int main()
{
    
    // row 1 {1,2,3,4},
    // row 2 { 5, 6, 7, 8 },
    // row 3 { 9,10,11,12 }



    // int x[row][colmns];

    int x[3][4] =
    {
        {1,2,3,4},
        {5,6,7,8},
        {9,10,11,12}
    };


    // dealing with two dimensional arrays is always with 2 for loops
    for (int row = 0; row < 3; row++)
    {
        for (int colmns = 0; colmns < 4; colmns++)
        {
            cout << x[row][colmns] << " ";
        }

        cout << endl;
    }


    return 0;
}
