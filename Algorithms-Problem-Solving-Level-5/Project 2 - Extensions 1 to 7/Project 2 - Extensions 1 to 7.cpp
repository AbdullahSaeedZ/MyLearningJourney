#include <iostream>
#include "clsMyQueue.h"
using namespace std;


int main()
{

    clsMyQueue <int> Queue;

    Queue.Push(1);
    Queue.Push(2);
    Queue.Push(3);
    Queue.Push(4);
    Queue.Push(5);

    cout << "Queue List Items:" << endl;
    Queue.PrintList();

    cout << "\n\nFirst item: " << Queue.Front() << endl;
    cout << "Last item: " << Queue.Back() << endl;
    cout << "Size: " << Queue.Size() << endl;

    Queue.Pop();
    cout << "\nList after popping (FIFO):" << endl;
    Queue.PrintList();

    cout << "\n\nItem index 2 value : " << Queue.GetItemValueByIndex(2) << endl;

    Queue.Reverse();
    cout << "\nAfter reversing items: " << endl;
    Queue.PrintList();

    Queue.UpdateItemValueByIndex(1, 500);
    cout << "\n\nAfter updating value of index 1 item: " << endl;
    Queue.PrintList();


    Queue.InsertItemAfterIndex(1, 77);
    cout << "\n\ninserting item after index 1: " << endl;
    Queue.PrintList();


    Queue.InsertItemAtFront(100);
    cout << "\n\ninserting item at front: " << endl;
    Queue.PrintList();


    Queue.InsertItemAtBack(99);
    cout << "\n\ninserting item at back: " << endl;
    Queue.PrintList();

    Queue.Clear();
    cout << "\n\nItems after clearing: " << endl;
    Queue.PrintList();




    return 0;
}