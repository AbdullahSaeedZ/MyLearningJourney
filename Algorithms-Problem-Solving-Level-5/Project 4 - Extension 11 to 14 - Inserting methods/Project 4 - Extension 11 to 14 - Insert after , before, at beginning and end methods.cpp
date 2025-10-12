#include <iostream>
#include "clsDynamicArray.h"
using namespace std;

int main()
{

    clsDynamicArray <int> DyArr(5);

    DyArr.SetItem(0, 10);
    DyArr.SetItem(1, 20);
    DyArr.SetItem(2, 30);
    DyArr.SetItem(3, 40);
    DyArr.SetItem(4, 50);

    cout << "Is empty: " << DyArr.IsEmpty() << endl;
    cout << "Size: " << DyArr.Size() << endl;
    cout << "\narray items: " << endl;
    DyArr.PrintItems();


    DyArr.InsertAtBeginning(500);
    cout << "\n\nSize: " << DyArr.Size() << endl;
    cout << "array items after inserting at beginning: " << endl;
    DyArr.PrintItems();

    DyArr.InsertBeforeIndex(2, 11);
    cout << "\n\nSize: " << DyArr.Size() << endl;
    cout << "array items after inserting before index 2: " << endl;
    DyArr.PrintItems();

    DyArr.InsertAfterIndex(2, 222);
    cout << "\n\nSize: " << DyArr.Size() << endl;
    cout << "array items after inserting after index 2: " << endl;
    DyArr.PrintItems();

    DyArr.InsertAtEnd(99);
    cout << "\n\nSize: " << DyArr.Size() << endl;
    cout << "array items after inserting at end: " << endl;
    DyArr.PrintItems();
    

    return 0;
}