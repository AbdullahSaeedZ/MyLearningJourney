#include <iostream>
using namespace std;


//HEAD ->[DATA | NEXT] ->[DATA | NEXT] ->[DATA | NEXT]->NULL
//          Node 1          Node 2           Node 3

// Creating a node
class Node
{
public:
    int value; // data variable
    Node* next; // pointer to point to the next node (the next node is also a class so we create a pointer of class Node), so we have a pointer to save address of another node made of class Node.
};

int main()
{
    // start of linked list, head is used to access the nodes one by one (no index access)
    Node* head;

    // declare node pointers and define or allocate 3 nodes in the heap (they will be in different locations inside memory)
    // here we create an object of pointer then using new + default constructor of Node class to create it in heap
    // in pointer declaration, we either give him address of variable &Name , or to reserve a new place in memory using New keyword (prepare new memory address in heap and save it in the pointer), 
    // then we use temp object declaration Node() to tell that this new address in heap is for an object of Node Class.
    Node* Node1 = new Node();
    Node* Node2 = new Node();
    Node* Node3 = new Node();

    // Assign values to value members in each node
    Node1->value = 1;
    Node2->value = 2;
    Node3->value = 3;

    // Connect nodes
    Node1->next = Node2;
    Node2->next = Node3;
    Node3->next = NULL;   // end of linked list

    // now we use the head to print the linked list value (see picture)
    // so we link the head with the first node in the list
    head = Node1;

    while (head != NULL) 
    {
        cout << head->value << endl;
        head = head->next; // will access next node
    }


    // when done, delete them from heap to avoid memory leaks.
    delete Node1;
    delete Node2;
    delete Node3;
    // no need to delete Head, cuz it is in the stack and i didnt use it in heap using New keyword!!

    system("pause>0");
    return 0;

}
