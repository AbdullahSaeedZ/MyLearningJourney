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


    DyArr.DeleteItemAtFirst();
    cout << "\n\nSize: " << DyArr.Size() << endl;
    cout << "array items after delete at first: " << endl;
    DyArr.PrintItems();


    DyArr.DeleteItemAtEnd();
    cout << "\n\nSize: " << DyArr.Size() << endl;
    cout << "array items after delete at end: " << endl;
    DyArr.PrintItems();
  

    return 0;
}