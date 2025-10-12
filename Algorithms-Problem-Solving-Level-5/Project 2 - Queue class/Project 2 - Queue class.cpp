#include <iostream>
#include "clsMyQueue.h"
using namespace std;


int main()
{
    
    clsMyQueue <int> List;

    List.Push(1);
    List.Push(2);
    List.Push(3);
    List.Push(4);
    List.Push(5);

    cout << "Queue List Items:" << endl;
    List.PrintList();

    cout << "\n\nFirst item: " << List.Front() << endl;
    cout << "Last item: " << List.Back() << endl;
    cout << "Size: " << List.Size() << endl;

    List.Pop();
    cout << "\nList after popping (FIFO):" << endl;
    List.PrintList();



    return 0;
}

