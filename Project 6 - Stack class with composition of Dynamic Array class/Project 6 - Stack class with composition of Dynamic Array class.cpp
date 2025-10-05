#include <iostream>
#include "clsStackArr.h"
using namespace std;

int main()
{
    clsStackArr<int> MyStack;

    MyStack.Push(10);
    MyStack.Push(20);
    MyStack.Push(30);
    MyStack.Push(40);
    MyStack.Push(50);


    cout << "\nStack items:" << endl;
    MyStack.PrintItems();

    cout << "\n\nStack Size: " << MyStack.Size() << endl;
    cout << "Stack top item: " << MyStack.Top() << endl;
    cout << "Stack bottom item: " << MyStack.Bottom() << endl;

    MyStack.Pop();
    cout << "\nafter popping (LIFO):" << endl;
    MyStack.PrintItems();

    cout << "\n\n====== After adding extensions to Stack DS ======" << endl;

    cout << "\nvalue of index 2: " << MyStack.GetItemValueByIndex(2) << endl;

    cout << "\nStack after reversing: " << endl;
    MyStack.Reverse();
    MyStack.PrintItems();

    cout << "\n\nStack after updating index 2:" << endl;
    MyStack.UpdateItemValueByIndex(2, 500);
    MyStack.PrintItems();

    cout << "\n\nStack after inserting after index 2:" << endl;
    MyStack.InsertAfterIndex(2, 99);
    MyStack.PrintItems();

    cout << "\n\nStack after inserting at top: " << endl;
    MyStack.InsertAtTop(100);
    MyStack.PrintItems();

    cout << "\n\nStack after inserting at bottom:" << endl;
    MyStack.InsertAtBottom(400);
    MyStack.PrintItems();

    cout << "\n\nStack after clearing: " << endl;
    MyStack.Clear();
    MyStack.PrintItems();


    //MyStack.Back() << this shoudnt be accessible here , but they are , cuz they are public in base class, make them protected to be accessible only in classes  and not here in the object.



    return 0;
}