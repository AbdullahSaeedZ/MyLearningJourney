#include <iostream>
using namespace std;

// HW1

//void PrintFromMtoN(int N, int M)
//{
//    if (N >= M)
//    {
//        cout << N << endl;
//        PrintFromMtoN(N - 1, M);
//    }
//    
//}



// HW2   check this vid AMAZING :  https://www.youtube.com/watch?v=Gqn6hmm9HEw
int PowerNum(int N, int P)
{
    

    if (P == 0)
    {
        return 1;
    }
    else
    {
        
       return (N * PowerNum(N, P - 1));
    }
    
    
   
    
}



int main()
{
    
   /* PrintFromMtoN(10, 1);*/

   cout << PowerNum(2, 3) << endl;

    

    return 0;
}

