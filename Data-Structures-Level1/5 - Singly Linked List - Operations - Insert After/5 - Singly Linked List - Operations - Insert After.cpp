#include <iostream>
using namespace std;

class Node
{
public:
    int value;
    Node* next;
};

void InsertAtBeginning(Node*& head, int value)
{
    // Allocate memory to a node
    Node* new_node = new Node();

    // insert the data
    new_node->value = value;
    new_node->next = head;

    // Move head to new node
    head = new_node;

}

Node* Find(Node* head, int Value)
{

    while (head != NULL) {

        if (head->value == Value)
            return head;


        head = head->next;
    }

    return NULL;

}

void PrintList(Node* head)

{
    cout << "\n";
    while (head != NULL) {
        cout << head->value << " ";
        head = head->next;
    }
}

// Suppose we have a Linked List like this:
// Head → [1] → [2] → [3] → NULL

// Goal: insert a new node [500] AFTER node [2]

// -------------------------------------------------

// 1) Create the new node
// newNode = [500 | Next = NULL]
// Right now this node is "separate", not connected to the list.

// -------------------------------------------------

// 2) Link the new node to the next node (node [3])
// newNode->next = node2->next
// Meaning: [500] → [3]
// Now the new node knows who comes after it.

// -------------------------------------------------

// 3) Cancel the old link and update it
// node2->next = newNode
// Meaning: instead of [2] pointing directly to [3],
// now [2] points to [500].

// -------------------------------------------------

// 4) Final result:
// Head → [1] → [2] → [500] → [3] → NULL


void InsertAfter(Node* prev_node, int Value) {

    if (prev_node == NULL) {
        cout << "the given previous node cannot be NULL";
        return;
    }

    Node* new_node = new Node();
    new_node->value = Value;
    new_node->next = prev_node->next;
    prev_node->next = new_node;
}

int main()
{
    Node* head = NULL;
    InsertAtBeginning(head, 1);
    InsertAtBeginning(head, 2);
    InsertAtBeginning(head, 3);
    InsertAtBeginning(head, 4);
    InsertAtBeginning(head, 5);

    PrintList(head);
    Node* N1 = NULL;

    N1 = Find(head, 2);

    InsertAfter(N1, 500);

    PrintList(head);


    system("pause>0");

}