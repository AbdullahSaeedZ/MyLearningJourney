#include <iostream>
using namespace std;


class Node
{
public:

    int value;
    Node* next;
    Node* prev;
};


// DOUBLY LINKED LIST:
// Each node contains data, next pointer, and previous pointer
// Head points to first node, tail points to last node
// Can traverse in both directions (forward and backward)
// More memory overhead - two pointers per node

//Structure:
// NULL <- [Prev|Data|Next] <-> [Prev|Data|Next] <-> [Prev|Data|Next] -> NULL
//        ^Head                                                    ^Tail


int main()
{
    
    Node* head = NULL;
    Node* tail = NULL;

    Node* node1 = new Node();
    Node* node2 = new Node();
    Node* node3 = new Node();


    node1->value = 1;
    node1->next = node2;
    node1->prev = NULL;  // cuz doubly list point to null from start and from end.

    node2->value = 2;
    node2->next = node3;
    node2->prev = node1;

    node3->value = 3;
    node3->next = NULL;
    node3->prev = node2;


    head = node1;
    tail = node3;

    while (head != NULL) // traverse from left to right using head.
    {
        cout << head->value << endl;
        head = head->next;
    }

    cout << "\n\n";

    while (tail != NULL) // traverse from right to left using tail.
    {
        cout << tail->value << endl;
        tail = tail->prev;
    }

    return 0;
}

