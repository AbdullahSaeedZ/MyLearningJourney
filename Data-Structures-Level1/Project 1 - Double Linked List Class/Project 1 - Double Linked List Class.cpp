#include <iostream>
#include "clsDblLinkedList.h"
using namespace std;

int main()
{
    clsDblLinkedList <int> List;

    List.InsertAtBeginning(1);
    List.InsertAtBeginning(2);
    List.InsertAtBeginning(3);

    cout << "inserting at beginning:" << endl;
    List.PrintList();

    clsDblLinkedList<int>::Node* N1 = List.Find(2);

    cout << "\ninserting after value 2:" << endl;
    List.InsertAfter(N1, 400);
    List.PrintList();

    cout << "\ninserting at end:" << endl;
    List.InsertAtEnd(99);
    List.PrintList();

    cout << "\ndelete node with value of 1:" << endl;
    N1 = List.Find(1);
    List.DeleteNode(N1);
    List.PrintList();

    cout << "\ndeleteing first node:" << endl;
    List.DeleteFirstNode();
    List.PrintList();
     
    cout << "\ndeleteing last node:" << endl;
    List.DeleteLastNode();
    List.PrintList();

    return 0;
}