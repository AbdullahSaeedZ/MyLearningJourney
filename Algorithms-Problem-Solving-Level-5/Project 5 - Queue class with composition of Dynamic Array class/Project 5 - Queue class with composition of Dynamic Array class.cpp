#include <iostream>
#include "clsQueueArr.h"
using namespace std;

int main()
{
    clsQueueArr <int> MyQueue;

    MyQueue.Push(10);
    MyQueue.Push(20);
    MyQueue.Push(30);
    MyQueue.Push(40);
    MyQueue.Push(50);


    cout << "\nQueue: \n";
    MyQueue.PrintList();

    cout << "\nQueue Size: " << MyQueue.Size();
    cout << "\nQueue Front: " << MyQueue.Front();
    cout << "\nQueue Back: " << MyQueue.Back();

    MyQueue.Pop();

    cout << "\n\nQueue after pop() FIFO : \n";
    MyQueue.PrintList();


    cout << "\n\n Item(2) : " << MyQueue.GetItemByIndex(2);


    MyQueue.Reverse();
    cout << "\n\nQueue after reverse() : \n";
    MyQueue.PrintList();


    MyQueue.UpdateItemByIndex(2, 600);
    cout << "\n\nQueue after updating Item(2) to 600 : \n";
    MyQueue.PrintList();


    MyQueue.InsertAfter(2, 800);
    cout << "\n\nQueue after Inserting 800 after Item(2) : \n";
    MyQueue.PrintList();



    MyQueue.InsertAtFront(1000);
    cout << "\n\nQueue after Inserting 1000 at front: \n";
    MyQueue.PrintList();


    MyQueue.InsertAtBack(2000);
    cout << "\n\nQueue after Inserting 2000 at back: \n";
    MyQueue.PrintList();


    MyQueue.Clear();
    cout << "\n\nQueue after Clear(): \n";
    MyQueue.PrintList();

    return 0;
}

