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

    List.UpdateNodeValueByIndex(2, 500);
    cout << "\nlist after updating value of node 3:" << endl;
    List.PrintList();


    return 0;
}